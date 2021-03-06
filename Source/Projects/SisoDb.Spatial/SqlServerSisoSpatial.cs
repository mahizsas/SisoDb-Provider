using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Globalization;
using System.Linq;
using System.Text;
using Microsoft.SqlServer.Types;
using SisoDb.Dac;
using SisoDb.NCore;
using SisoDb.DbSchema;
using SisoDb.Spatial.Resources;
using SisoDb.Structures;
using SisoDb.Structures.Schemas;

namespace SisoDb.Spatial
{
    public class SqlServerSisoSpatial : ISisoSpatial
    {
        protected readonly ISessionExecutionContext ExecutionContext;
        protected ISession Session { get { return ExecutionContext.Session; } }
        protected readonly ISqlStatements SqlStatements;

        protected internal SqlServerSisoSpatial(ISessionExecutionContext executionContext)
        {
            ExecutionContext = executionContext;
            SqlStatements = SpatialSqlStatements.Instance;
        }

        public virtual void EnableFor<T>() where T : class
        {
            ExecutionContext.Try(() =>
            {
                if (!Session.Db.Settings.AllowDynamicSchemaCreation) return;
                var schema = Session.GetStructureSchema<T>();
                var sql = GetUpsertTableSql(schema);
                Session.DbClient.ExecuteNonQuery(sql);
            });
        }

        public virtual void RemoveFor<T>() where T : class
        {
            ExecutionContext.Try(() =>
            {
                var schema = Session.GetStructureSchema<T>();
                var sql = SqlStatements.GetSql("DropSpatialTable").Inject(schema.GetSpatialTableName());
                Session.DbClient.ExecuteNonQuery(sql);
            });
        }

        public virtual void DeleteGeoIn<T>(object id) where T : class
        {
            ExecutionContext.Try(() =>
            {
                var schema = Session.GetStructureSchema<T>();
                var sidParam = CreateStructureIdParam<T>(id);
                var sql = SqlStatements.GetSql("DeleteGeo").Inject(schema.GetSpatialTableName());
                Session.DbClient.ExecuteNonQuery(sql, sidParam);
            });
        }

        public virtual void InsertPolygonTo<T>(object id, Coordinates[] coords, int srid = SpatialReferenceId.Wsg84) where T : class
        {
            ExecutionContext.Try(() =>
            {
                var schema = Session.GetStructureSchema<T>();
                var sidParam = CreateStructureIdParam<T>(id);
                var geoParam = CreatePolygonParam(coords, srid);
                var sql = SqlStatements.GetSql("InsertGeo").Inject(schema.GetSpatialTableName());
                Session.DbClient.ExecuteNonQuery(sql, sidParam, geoParam);
            });
        }

        public virtual void UpdatePolygonIn<T>(object id, Coordinates[] coords, int srid = SpatialReferenceId.Wsg84) where T : class
        {
            ExecutionContext.Try(() =>
            {
                var schema = Session.GetStructureSchema<T>();
                var sidParam = CreateStructureIdParam<T>(id);
                var geoParam = CreatePolygonParam(coords, srid);
                var sql = SqlStatements.GetSql("UpdateGeo").Inject(schema.GetSpatialTableName());
                Session.DbClient.ExecuteNonQuery(sql, sidParam, geoParam);
            });
        }

        public virtual void SetPolygonIn<T>(object id, Coordinates[] coords, int srid = SpatialReferenceId.Wsg84) where T : class
        {
            ExecutionContext.Try(() =>
            {
                var schema = Session.GetStructureSchema<T>();
                var sidParam = CreateStructureIdParam<T>(id);
                var geoParam = CreatePolygonParam(coords, srid);
                var sql = SqlStatements.GetSql("SetGeo").Inject(schema.GetSpatialTableName());
                Session.DbClient.ExecuteNonQuery(sql, sidParam, geoParam);
            });
        }

        public virtual Coordinates[] GetCoordinatesIn<T>(object id) where T : class
        {
            return ExecutionContext.Try(() =>
            {
                var schema = Session.GetStructureSchema<T>();
                var sidParam = CreateStructureIdParam<T>(id);
                var sql = SqlStatements.GetSql("GetCoordinatesIn").Inject(schema.GetSpatialTableName());
                
                return ExtractPoints(GetGeograpy(sql, sidParam)).Select(p => new Coordinates
                {
                    Latitude = p.Lat.Value,
                    Longitude = p.Long.Value
                }).ToArray();
            });
        }

        protected virtual SqlGeography GetGeograpy(string sql, params IDacParameter[] parameters)
        {
            //I know, ugly. Thank Microsoft for that: http://msdn.microsoft.com/en-us/library/ms143179.aspx
            SqlGeography geo = null;
            Session.DbClient.SingleResultSequentialReader(sql, dr =>
            {
                var d = (SqlDataReader)dr;
                geo = SqlGeography.Deserialize(d.GetSqlBytes(0));
            }, parameters);
            return geo;
        }

        protected virtual SqlGeography[] ExtractPoints(SqlGeography geo)
        {
            if(geo == null || geo.IsNull)
                return new SqlGeography[0];

            var numOfPoints = geo.STNumPoints();
            if (numOfPoints.IsNull || numOfPoints.Value == 0)
                return new SqlGeography[0];

            var points = new SqlGeography[numOfPoints.Value];
            for (var i = 0; i < numOfPoints.Value; i++)
                points[i] = geo.STPointN(i+1);

            return points;
        }

        public virtual bool PointExistsInPolygonFor<T>(object id, Coordinates coords, int srid = SpatialReferenceId.Wsg84) where T : class
        {
            return ExecutionContext.Try(() =>
            {
                var schema = Session.GetStructureSchema<T>();
                var sidParam = CreateStructureIdParam<T>(id);
                var geoParam = CreatePointParam(coords, srid);
                var sql = SqlStatements.GetSql("PointExistsInPolygon").Inject(schema.GetSpatialTableName());

                return Session.DbClient.ExecuteScalar<int>(sql, sidParam, geoParam) > 0;
            });
        }

        protected virtual string GetUpsertTableSql(IStructureSchema structureSchema)
        {
            var tableName = structureSchema.GetSpatialTableName();
            var structureTableName = structureSchema.GetStructureTableName();

            if (structureSchema.IdAccessor.IdType.IsIdentity())
                return SqlStatements.GetSql("UpsertSpatialTableWithIdentity").Inject(tableName, structureTableName);

            if (structureSchema.IdAccessor.IdType.IsGuid())
                return SqlStatements.GetSql("UpsertSpatialTableWithGuid").Inject(tableName, structureTableName);

            if (structureSchema.IdAccessor.IdType.IsString())
                return SqlStatements.GetSql("UpsertSpatialTableWithString").Inject(tableName, structureTableName);

            throw new SisoDbException(ExceptionMessages.IdTypeNotSupported.Inject(structureSchema.IdAccessor.IdType));
        }

        protected virtual DacParameter CreateStructureIdParam<T>(object id) where T : class
        {
            return new DacParameter("id", id);
        }

        protected virtual GeographyDacParameter CreatePointParam(Coordinates coords, int srid)
        {
            return new GeographyDacParameter("geo", SqlGeography.Point(coords.Latitude, coords.Longitude, srid));
        }

        protected virtual GeographyDacParameter CreatePolygonParam(Coordinates[] coords, int srid)
        {
            var s = BuildPolygonString(coords);
            var polygon = new SqlChars(s.ToCharArray());

            return new GeographyDacParameter("geo", SqlGeography.STPolyFromText(polygon, srid));
        }

        protected virtual string BuildPolygonString(Coordinates[] coords)
        {
            var s = new StringBuilder();
            s.Append("POLYGON((");
            for (var i = 0; i < coords.Length; i++)
            {
                var coord = coords[i];
                s.Append(coord.Longitude.ToString(CultureInfo.InvariantCulture));
                s.Append(" ");
                s.Append(coord.Latitude.ToString(CultureInfo.InvariantCulture));

                if (i < coords.Length - 1)
                    s.Append(",");
            }
            s.Append("))");

            return s.ToString();
        }
    }
}