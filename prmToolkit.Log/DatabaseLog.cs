using prmToolkit.AccessMultipleDatabaseWithAdoNet;
using prmToolkit.AccessMultipleDatabaseWithAdoNet.Enumerators;
using prmToolkit.Log.Interfaces;
using System;
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

        public void Save(string message)
        {
            string sql = $"INSERT INTO log (Application, Message, CurrentDate) VALUES ('{_applicationName}', '{message}', '{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}');";

            CommandSql comandoSql = new CommandSql(_connectionString, sql, _enumDatabaseType);

            this.ExecuteNonQuery(comandoSql);


        }

        public async Task SaveAsync(string message)
        {
            await Task.Run(() => { Save(message); });
        }
    }
}
