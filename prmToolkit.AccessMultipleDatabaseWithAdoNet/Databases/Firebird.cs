using FirebirdSql.Data.FirebirdClient;
using System.Data;

namespace prmToolkit.AccessMultipleDatabaseWithAdoNet.Databases
{
    public class Firebird : AbstractDatabase
    {
        public override IDbConnection CreateConnection()
        {
            return new FbConnection(connectionString);
        }

        public override IDbCommand CreateCommand()
        {
            return new FbCommand();
        }

        public override IDbConnection CreateOpenConnection()
        {
            FbConnection connection = (FbConnection)CreateConnection();
            connection.Open();

            return connection;
        }

        public override IDbCommand CreateCommand(string commandText, IDbConnection connection)
        {
            FbCommand command = (FbCommand)CreateCommand();

            command.CommandText = commandText;
            command.Connection = (FbConnection)connection;
            command.CommandType = CommandType.Text;

            return command;
        }

        public override IDbCommand CreateStoredProcedureCommand(string procName, IDbConnection connection)
        {
            FbCommand command = (FbCommand)CreateCommand();

            command.CommandText = procName;
            command.Connection = (FbConnection)connection;
            command.CommandType = CommandType.StoredProcedure;

            return command;
        }

        public override IDataParameter CreateParameter(string parameterName, object parameterValue)
        {
            return new FbParameter(parameterName, parameterValue);
        }

        public static void ClearAllPools()
        {
            FbConnection.ClearAllPools();
        }
    }
}