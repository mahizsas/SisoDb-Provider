using System;
using System.Resources;

namespace SisoDb.Providers.SqlStrings
{
    public class SqlStringsRepository : ISqlStringsRepository
    {
        private static readonly Type ThisType = typeof (SqlStringsRepository);
        private static readonly ResourceManager Sql2008Strings;
        private static readonly ResourceManager SqlAzureStrings;
        private static readonly ResourceManager SqlCe4Strings;

        private readonly ResourceManager _primary;
        private readonly ResourceManager _secondary;

        static SqlStringsRepository()
        {
            var prefix = ThisType.Namespace + ".SqlStrings.";
            var sql2008Resx = prefix + "2008";
            var sqlAzureResx = prefix + "Azure";
            var sqlCe4Resx = prefix + "SqlCe4";

            Sql2008Strings = new ResourceManager(sql2008Resx, ThisType.Assembly);
            SqlAzureStrings = new ResourceManager(sqlAzureResx, ThisType.Assembly);
            SqlCe4Strings = new ResourceManager(sqlCe4Resx, ThisType.Assembly);
        }

        public SqlStringsRepository(StorageProviders storageProvider)
        {
            switch (storageProvider)
            {
                case StorageProviders.SqlAzure:
                    _primary = SqlAzureStrings;
                    _secondary = Sql2008Strings;
                    break;
                case StorageProviders.SqlCe4:
                    _primary = SqlCe4Strings;
                    _secondary = Sql2008Strings;
                    break;
                default:
                    _primary = Sql2008Strings;
                    _secondary = _primary;
                    break;
            }
        }

        public string GetSql(string name)
        {
            return _primary.GetString(name) ?? _secondary.GetString(name);
        }
    }
}