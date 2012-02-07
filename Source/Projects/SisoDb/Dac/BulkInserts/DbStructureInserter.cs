﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NCore;
using NCore.Collections;
using PineCone.Structures;
using PineCone.Structures.Schemas;
using SisoDb.DbSchema;
using SisoDb.Structures;

namespace SisoDb.Dac.BulkInserts
{
    public class DbStructureInserter : IStructureInserter
    {
        protected class InsertAction
        {
            public IStructureIndex[] Data;
            public Action<IDbClient> Action;
            public bool HasData
            {
                get { return Data != null && Data.Length > 0; }
            }
        }

        protected static readonly Type TextType;

        protected const int NumberOfStructuresLimitForParallelEscalation = 10;
        protected const int MaxIndexesBatchSize = 5000;
        protected const int MaxUniquesBatchSize = 5000;

        protected readonly IDbClient MainDbClient;
        protected readonly Func<IDbClient> DbClientFnForParallelInserts;

        protected bool SupportsParallelInserts
        {
            get { return DbClientFnForParallelInserts != null; }
        }

        static DbStructureInserter()
        {
            TextType = typeof(Text);
        }

        public DbStructureInserter(IDbClient dbClient, Func<IDbClient> dbClientFnForParallelInserts = null)
        {
            MainDbClient = dbClient;
            DbClientFnForParallelInserts = dbClientFnForParallelInserts;
        }

        public virtual void Insert(IStructureSchema structureSchema, IStructure[] structures)
        {
            if (SupportsParallelInserts && structures.Length > NumberOfStructuresLimitForParallelEscalation)
                InsertInParallel(structureSchema, structures);
            else
                InsertInSequential(structureSchema, structures);
        }

        protected void InsertInSequential(IStructureSchema structureSchema, IStructure[] structures)
        {
            InsertStructures(structureSchema, structures, MainDbClient);
            BulkInsertUniques(structureSchema, structures, MainDbClient);
            InsertIndexes(structureSchema, structures, MainDbClient);
        }

        protected virtual void InsertInParallel(IStructureSchema structureSchema, IStructure[] structures)
        {
            var tasks = new Task[2];
            try
            {
                tasks[0] = new Task(() =>
                {
                    InsertStructures(structureSchema, structures, MainDbClient);
                    BulkInsertUniques(structureSchema, structures, MainDbClient);
                });

                tasks[1] = new Task(() =>
                {
                    //InsertIndexes(structureSchema, structures, null);
                    using (var indexesDbClient = DbClientFnForParallelInserts.Invoke())
                    {
                        InsertIndexes(structureSchema, structures, indexesDbClient);
                    }
                });

                foreach (var task in tasks)
                    task.Start();

                Task.WaitAll(tasks);
            }
            finally
            {
                foreach (var task in tasks)
                    task.Dispose();
            }
        }

        protected virtual void InsertStructures(IStructureSchema structureSchema, IStructure[] structures, IDbClient dbClient)
        {
            if (structures.Length == 1)
                SingleInsertStructure(structureSchema, structures[0], dbClient);
            else
                BulkInsertStructures(structureSchema, structures, dbClient);
        }

        protected virtual void SingleInsertStructure(IStructureSchema structureSchema, IStructure structure, IDbClient dbClient)
        {
            var sql = "insert into [{0}] ([{1}], [{2}]) values (@{1}, @{2});".Inject(
                structureSchema.GetStructureTableName(),
                StructureStorageSchema.Fields.Id.Name,
                StructureStorageSchema.Fields.Json.Name);

            dbClient.ExecuteNonQuery(sql,
                new DacParameter(StructureStorageSchema.Fields.Id.Name, structure.Id.Value),
                new DacParameter(StructureStorageSchema.Fields.Json.Name, structure.Data));
        }

        protected virtual void BulkInsertStructures(IStructureSchema structureSchema, IEnumerable<IStructure> structures, IDbClient dbClient)
        {
            var structureStorageSchema = new StructureStorageSchema(structureSchema, structureSchema.GetStructureTableName());

            using (var structuresReader = new StructuresReader(structureStorageSchema, structures))
            {
                using (var bulkInserter = dbClient.GetBulkCopy())
                {
                    bulkInserter.DestinationTableName = structuresReader.StorageSchema.Name;
                    bulkInserter.BatchSize = structuresReader.RecordsAffected;

                    foreach (var field in structuresReader.StorageSchema.GetFieldsOrderedByIndex())
                        bulkInserter.AddColumnMapping(field.Name, field.Name);

                    bulkInserter.Write(structuresReader);
                }
            }
        }

        protected virtual void InsertIndexes(IStructureSchema structureSchema, IEnumerable<IStructure> structures, IDbClient dbClient)
        {
            var indexesTableNames = structureSchema.GetIndexesTableNames();
            var insertActions = new Dictionary<DataTypeCode, InsertAction>(indexesTableNames.AllTableNames.Length);
            foreach (var group in structures.SelectMany(s => s.Indexes).GroupBy(i => i.DataTypeCode))
            {
                var insertAction = CreateInsertAction(structureSchema, indexesTableNames, group.Key, group.ToArray());
                if (insertAction.HasData)
                    insertActions.Add(group.Key, insertAction);
            }

            var mergeStringsAndEnums = insertActions.ContainsKey(DataTypeCode.String) && insertActions.ContainsKey(DataTypeCode.Enum);
            if (mergeStringsAndEnums)
            {
                var strings = insertActions[DataTypeCode.String];
                strings.Data = insertActions[DataTypeCode.Enum].Data.MergeWith(strings.Data).ToArray();
                insertActions.Remove(DataTypeCode.Enum);
            }

            if (dbClient != null)
                foreach (var insertAction in insertActions.Values)
                    insertAction.Action.Invoke(dbClient);
            else
            {
                Parallel.ForEach(insertActions.Values, insertAction =>
                {
                    using (var indexesDbClient = DbClientFnForParallelInserts.Invoke())
                    {
                        insertAction.Action.Invoke(indexesDbClient);
                    }
                });
            }
        }

        protected virtual InsertAction CreateInsertAction(IStructureSchema structureSchema, IndexesTableNames indexesTableNames, DataTypeCode dataTypeCode, IStructureIndex[] indexes)
        {
            var container = new InsertAction { Data = indexes };

            switch (dataTypeCode)
            {
                case DataTypeCode.IntegerNumber:
                    if (container.Data.Length > 1)
                        container.Action = dbClient => BulkInsertIndexes(new ValueTypeIndexesReader(new IndexStorageSchema(structureSchema, indexesTableNames.IntegersTableName), container.Data), dbClient);
                    if (container.Data.Length == 1)
                        container.Action = dbClient => SingleInsertIntoValueTypeIndexesOfX(indexesTableNames.IntegersTableName, container.Data[0], dbClient);
                    break;
                case DataTypeCode.FractalNumber:
                    if (container.Data.Length > 1)
                        container.Action = dbClient => BulkInsertIndexes(new ValueTypeIndexesReader(new IndexStorageSchema(structureSchema, indexesTableNames.FractalsTableName), container.Data), dbClient);
                    if (container.Data.Length == 1)
                        container.Action = dbClient => SingleInsertIntoValueTypeIndexesOfX(indexesTableNames.FractalsTableName, container.Data[0], dbClient);
                    break;
                case DataTypeCode.Bool:
                    if (container.Data.Length > 1)
                        container.Action = dbClient => BulkInsertIndexes(new ValueTypeIndexesReader(new IndexStorageSchema(structureSchema, indexesTableNames.BooleansTableName), container.Data), dbClient);
                    if (container.Data.Length == 1)
                        container.Action = dbClient => SingleInsertIntoValueTypeIndexesOfX(indexesTableNames.BooleansTableName, container.Data[0], dbClient);
                    break;
                case DataTypeCode.DateTime:
                    if (container.Data.Length > 1)
                        container.Action = dbClient => BulkInsertIndexes(new ValueTypeIndexesReader(new IndexStorageSchema(structureSchema, indexesTableNames.DatesTableName), container.Data), dbClient);
                    if (container.Data.Length == 1)
                        container.Action = dbClient => SingleInsertIntoValueTypeIndexesOfX(indexesTableNames.DatesTableName, container.Data[0], dbClient);
                    break;
                case DataTypeCode.Guid:
                    if (container.Data.Length > 1)
                        container.Action = dbClient => BulkInsertIndexes(new ValueTypeIndexesReader(new IndexStorageSchema(structureSchema, indexesTableNames.GuidsTableName), container.Data), dbClient);
                    if (container.Data.Length == 1)
                        container.Action = dbClient => SingleInsertIntoValueTypeIndexesOfX(indexesTableNames.GuidsTableName, container.Data[0], dbClient);
                    break;
                case DataTypeCode.String:
                case DataTypeCode.Enum:
                    if (container.Data.Length > 1)
                        container.Action = dbClient => BulkInsertIndexes(new StringIndexesReader(new IndexStorageSchema(structureSchema, indexesTableNames.StringsTableName), container.Data), dbClient);
                    if (container.Data.Length == 1)
                        container.Action = dbClient => SingleInsertIntoStringishIndexesOfX(indexesTableNames.StringsTableName, container.Data[0], dbClient);
                    break;
                case DataTypeCode.Unknown:
                    container.Data = container.Data.Where(i => i.DataType == TextType).ToArray();
                    if (container.Data.Length > 1)
                        container.Action = dbClient => BulkInsertIndexes(new StringIndexesReader(new IndexStorageSchema(structureSchema, indexesTableNames.TextsTableName), container.Data), dbClient);
                    if (container.Data.Length == 1)
                        container.Action = dbClient => SingleInsertIntoStringishIndexesOfX(indexesTableNames.TextsTableName, container.Data[0], dbClient);
                    break;
            }

            return container;
        }

        protected virtual void SingleInsertIntoValueTypeIndexesOfX(string valueTypeIndexesTableName, IStructureIndex structureIndex, IDbClient dbClient)
        {
            var sql = "insert into [{0}] ([{1}], [{2}], [{3}], [{4}]) values (@{1}, @{2}, @{3}, @{4})".Inject(
                valueTypeIndexesTableName,
                IndexStorageSchema.Fields.StructureId.Name,
                IndexStorageSchema.Fields.MemberPath.Name,
                IndexStorageSchema.Fields.Value.Name,
                IndexStorageSchema.Fields.StringValue.Name);

            dbClient.ExecuteNonQuery(sql,
                new DacParameter(IndexStorageSchema.Fields.StructureId.Name, structureIndex.StructureId.Value),
                new DacParameter(IndexStorageSchema.Fields.MemberPath.Name, structureIndex.Path),
                new DacParameter(IndexStorageSchema.Fields.Value.Name, structureIndex.Value),
                new DacParameter(IndexStorageSchema.Fields.StringValue.Name, SisoEnvironment.StringConverter.AsString(structureIndex.Value)));
        }

        protected virtual void SingleInsertIntoStringishIndexesOfX(string stringishIndexesTableName, IStructureIndex structureIndex, IDbClient dbClient)
        {
            var sql = "insert into [{0}] ([{1}], [{2}], [{3}]) values (@{1}, @{2}, @{3})".Inject(
                stringishIndexesTableName,
                IndexStorageSchema.Fields.StructureId.Name,
                IndexStorageSchema.Fields.MemberPath.Name,
                IndexStorageSchema.Fields.Value.Name);

            dbClient.ExecuteNonQuery(sql,
                new DacParameter(IndexStorageSchema.Fields.StructureId.Name, structureIndex.StructureId.Value),
                new DacParameter(IndexStorageSchema.Fields.MemberPath.Name, structureIndex.Path),
                new DacParameter(IndexStorageSchema.Fields.Value.Name, structureIndex.Value.ToString()));
        }

        protected virtual void BulkInsertIndexes(IndexesReader indexesReader, IDbClient dbClient)
        {
            using (indexesReader)
            {
                using (var bulkInserter = dbClient.GetBulkCopy())
                {
                    bulkInserter.DestinationTableName = indexesReader.StorageSchema.Name;
                    bulkInserter.BatchSize = indexesReader.RecordsAffected > MaxIndexesBatchSize
                        ? MaxIndexesBatchSize
                        : indexesReader.RecordsAffected;

                    var fields = indexesReader.StorageSchema.GetFieldsOrderedByIndex();
                    foreach (var field in fields)
                    {
                        if (field.Name == IndexStorageSchema.Fields.StringValue.Name && !(indexesReader is ValueTypeIndexesReader))
                            continue;

                        bulkInserter.AddColumnMapping(field.Name, field.Name);
                    }
                    bulkInserter.Write(indexesReader);
                }
            }
        }

        protected virtual void BulkInsertUniques(IStructureSchema structureSchema, IEnumerable<IStructure> structures, IDbClient dbClient)
        {
            var uniques = structures.SelectMany(s => s.Uniques).ToArray();
            if (uniques.Length <= 0)
                return;

            var uniquesStorageSchema = new UniqueStorageSchema(structureSchema, structureSchema.GetUniquesTableName());

            using (var uniquesReader = new UniquesReader(uniquesStorageSchema, uniques))
            {
                using (var bulkInserter = dbClient.GetBulkCopy())
                {
                    bulkInserter.DestinationTableName = uniquesReader.StorageSchema.Name;
                    bulkInserter.BatchSize = uniquesReader.RecordsAffected > MaxUniquesBatchSize
                        ? MaxUniquesBatchSize
                        : uniquesReader.RecordsAffected;

                    foreach (var field in uniquesReader.StorageSchema.GetFieldsOrderedByIndex())
                        bulkInserter.AddColumnMapping(field.Name, field.Name);

                    bulkInserter.Write(uniquesReader);
                }
            }
        }
    }
}