﻿using System;
using System.Data;
using SisoDb.Querying;

namespace SisoDb.Providers
{
    internal static class AdoNetExtensions
    {
        internal static T GetScalarResult<T>(this IDbCommand cmd)
        {
            var value = cmd.ExecuteScalar();

            if (value == null || value == DBNull.Value)
                return default(T);

            return (T)Convert.ChangeType(value, typeof(T));
        }

        internal static IDbCommand CreateCommand(this IDbConnection connection, CommandType commandType, string sql, params IQueryParameter[] parameters)
        {
            return connection.CreateCommand(null, commandType, sql, parameters);
        }

        internal static IDbCommand CreateCommand(this IDbConnection connection, IDbTransaction transaction, CommandType commandType, string sql, params IQueryParameter[] parameters)
        {
            var cmd = connection.CreateCommand();
            cmd.CommandType = commandType;
            cmd.UpdatedRowSource = UpdateRowSource.None;

            if (!string.IsNullOrWhiteSpace(sql))
                cmd.CommandText = sql;

            if (transaction != null)
                cmd.Transaction = transaction;

            foreach (var queryParameter in parameters)
            {
                var parameter = cmd.CreateParameter();
                parameter.ParameterName = queryParameter.Name;
                parameter.Value = queryParameter.Value;

                cmd.Parameters.Add(parameter);
            }
            
            return cmd;
        }
    }
}