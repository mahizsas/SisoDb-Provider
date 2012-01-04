﻿using System;
using System.Linq;
using NCore;
using PineCone.Structures;
using PineCone.Structures.Schemas;
using SisoDb.Dac;
using SisoDb.Resources;

namespace SisoDb.DbSchema
{
	public class SqlDbIndexesSchemaBuilder
	{
		private readonly ISqlStatements _sqlStatements;

		public SqlDbIndexesSchemaBuilder(ISqlStatements sqlStatements)
		{
			_sqlStatements = sqlStatements;
		}

		public string[] GenerateSql(IStructureSchema structureSchema, IndexesTableStatuses indexesTableStatuses)
		{
			var indexesTableNames = structureSchema.GetIndexesTableNames();
			var structureTableName = structureSchema.GetStructureTableName();
			var sqlTemplateNameSuffix = GetSqlTemplateNameSuffix(structureSchema.IdAccessor.IdType);
			var generators = new Func<string>[]
			{
				() => indexesTableStatuses.IntegersTableExists 
					? GenerateSqlForIntegers(sqlTemplateNameSuffix, structureTableName, indexesTableNames.IntegersTableName) 
					: "",
				() => indexesTableStatuses.FractalsTableExists 
					?GenerateSqlForFractals(sqlTemplateNameSuffix, structureTableName, indexesTableNames.FractalsTableName) 
					: "",
				() => indexesTableStatuses.BooleansTableExists 
					? GenerateSqlForBooleans(sqlTemplateNameSuffix, structureTableName, indexesTableNames.BooleansTableName) 
					: "",
				() => indexesTableStatuses.DatesTableExists 
					? GenerateSqlForDates(sqlTemplateNameSuffix, structureTableName, indexesTableNames.DatesTableName) 
					: "",
				() => indexesTableStatuses.GuidsTableExists 
					? GenerateSqlForGuids(sqlTemplateNameSuffix, structureTableName, indexesTableNames.GuidsTableName) 
					: "",
				() => indexesTableStatuses.StringsTableExists 
					? GenerateSqlForStrings(sqlTemplateNameSuffix, structureTableName, indexesTableNames.StringsTableName) 
					: ""
			};

			return generators.Select(generator => generator()).Where(s => !string.IsNullOrWhiteSpace(s)).ToArray();
		}

		private string GetSqlTemplateNameSuffix(StructureIdTypes idType)
		{
			if(idType == StructureIdTypes.String)
				return "String";

			if (idType == StructureIdTypes.Guid)
				return "Guid";

			if (idType.IsIdentity())
				return "Identity";

			throw new SisoDbException(ExceptionMessages.SqlDbIndexesSchemaBuilder_GenerateSql.Inject(idType));
		}

		private string GenerateSqlForIntegers(string sqlTemplateNameSuffix, string structureTableName, string indexesTableName)
		{
			return string.Format(
				_sqlStatements.GetSql(string.Concat("CreateIntegersIndexes", sqlTemplateNameSuffix)),
				indexesTableName,
				structureTableName);
		}

		private string GenerateSqlForFractals(string sqlTemplateNameSuffix, string structureTableName, string indexesTableName)
		{
			return string.Format(
				_sqlStatements.GetSql(string.Concat("CreateFractalsIndexes", sqlTemplateNameSuffix)),
				indexesTableName,
				structureTableName);
		}

		private string GenerateSqlForBooleans(string sqlTemplateNameSuffix, string structureTableName, string indexesTableName)
		{
			return string.Format(
				_sqlStatements.GetSql(string.Concat("CreateBooleansIndexes", sqlTemplateNameSuffix)),
				indexesTableName,
				structureTableName);
		}

		private string GenerateSqlForDates(string sqlTemplateNameSuffix, string structureTableName, string indexesTableName)
		{
			return string.Format(
				_sqlStatements.GetSql(string.Concat("CreateDatesIndexes", sqlTemplateNameSuffix)),
				indexesTableName,
				structureTableName);
		}

		private string GenerateSqlForGuids(string sqlTemplateNameSuffix, string structureTableName, string indexesTableName)
		{
			return string.Format(
				_sqlStatements.GetSql(string.Concat("CreateGuidsIndexes", sqlTemplateNameSuffix)),
				indexesTableName,
				structureTableName);
		}

		private string GenerateSqlForStrings(string sqlTemplateNameSuffix, string structureTableName, string indexesTableName)
		{
			return string.Format(
				_sqlStatements.GetSql(string.Concat("CreateStringsIndexes", sqlTemplateNameSuffix)),
				indexesTableName,
				structureTableName);
		}
	}
}