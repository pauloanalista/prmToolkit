using System.Data;

namespace prmToolkit.AccessMultipleDatabaseWithAdoNet.Databases
{
    public abstract class AbstractDatabase
    {
        public string connectionString;

        #region Funções Abstratas

        public abstract IDbConnection CreateConnection();
        public abstract IDbCommand CreateCommand();
        public abstract IDbConnection CreateOpenConnection();
        public abstract IDbCommand CreateCommand(string commandText, IDbConnection connection);
        public abstract IDbCommand CreateStoredProcedureCommand(string procedureName, IDbConnection connection);
        public abstract IDataParameter CreateParameter(string parameterName, object parameterValue);

        #endregion
    }
}