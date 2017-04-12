using FirebirdSql.Data.FirebirdClient;
using MySql.Data.MySqlClient;
using prmToolkit.AccessMultipleDatabaseWithAdoNet;
using prmToolkit.AccessMultipleDatabaseWithAdoNet.Enumerators;
using prmToolkit.EnumExtension;
using prmToolkit.Log.Enum;
using prmToolkit.Log.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace prmToolkit.Log
{
    public sealed class DatabaseLog : AbstractRepository, ILog
    {
        private readonly string _connectionString;
        private readonly string _applicationName;
        private readonly EnumDatabaseType _enumDatabaseType;
        public DatabaseLog(string applicationName, string connectionString, EnumDatabaseType enumDatabaseType)
        {
            _connectionString = connectionString;
            _applicationName = applicationName;
            _enumDatabaseType = enumDatabaseType;
        }

        public void Save(string message, EnumMessageType enumMessageType = EnumMessageType.Information)
        {
            List<DbParameter> parametros = new List<DbParameter>();

            if (_enumDatabaseType == EnumDatabaseType.SqlServer)
            {
                parametros.Add(new SqlParameter()
                {
                    DbType = DbType.String,
                    Direction = ParameterDirection.Input,
                    ParameterName = "@ApplicationName",
                    Value = _applicationName
                });

                parametros.Add(new SqlParameter()
                {
                    DbType = DbType.String,
                    Direction = ParameterDirection.Input,
                    ParameterName = "@Message",
                    Value = message
                });

                
                parametros.Add(new SqlParameter()
                {
                    DbType = DbType.String,
                    Direction = ParameterDirection.Input,
                    ParameterName = "@MessageType",
                    Value = enumMessageType.GetDescription()
                });
                
            }
            else if (_enumDatabaseType == EnumDatabaseType.MySql)
            {
                parametros.Add(new MySqlParameter()
                {
                    DbType = DbType.String,
                    Direction = ParameterDirection.Input,
                    ParameterName = "@ApplicationName",
                    Value = _applicationName
                });

                parametros.Add(new MySqlParameter()
                {
                    DbType = DbType.String,
                    Direction = ParameterDirection.Input,
                    ParameterName = "@Message",
                    Value = message
                });

                parametros.Add(new MySqlParameter()
                {
                    DbType = DbType.String,
                    Direction = ParameterDirection.Input,
                    ParameterName = "@MessageType",
                    Value = enumMessageType.GetDescription()
                });

            }
            else if (_enumDatabaseType == EnumDatabaseType.Firebird)
            {
                parametros.Add(new FbParameter()
                {
                    DbType = DbType.String,
                    Direction = ParameterDirection.Input,
                    ParameterName = "@ApplicationName",
                    Value = _applicationName
                });

                parametros.Add(new FbParameter()
                {
                    DbType = DbType.String,
                    Direction = ParameterDirection.Input,
                    ParameterName = "@Message",
                    Value = message
                });

                parametros.Add(new FbParameter()
                {
                    DbType = DbType.String,
                    Direction = ParameterDirection.Input,
                    ParameterName = "@MessageType",
                    Value = enumMessageType.GetDescription()
                });

            }


            string sql = $"INSERT INTO log (Application, MessageType, Message, CurrentDate) VALUES (@ApplicationName, @MessageType, @Message, '{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}');";

            CommandSql comandoSql = new CommandSql(_connectionString, sql, parametros, _enumDatabaseType);

            this.ExecuteNonQuery(comandoSql);


        }

        public async Task SaveAsync(string message, EnumMessageType enumMessageType = EnumMessageType.Information)
        {
            await Task.Run(() => { Save(message, enumMessageType); });
        }
    }
}
