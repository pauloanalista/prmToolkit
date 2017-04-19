using prmToolkit.AccessMultipleDatabaseWithAdoNet;
using prmToolkit.AccessMultipleDatabaseWithAdoNet.Enumerators;
using prmToolkit.Log.Domain.Entities;
using prmToolkit.Log.Domain.Interfaces.Repositories;
using prmToolkit.Log.Infra.Helpers;
using System.Collections.Generic;
using System.Linq;

namespace prmToolkit.Log.Infra.Persistencia.AdoNet
{
    public class LogMessageRepository : AbstractRepository, ILogMessageRepository
    {
        public IEnumerable<LogMessage> ObterLogs()
        {
            string query = @"SELECT Id
                                  , Application
                                  , MessageType
                                  , Message
                                  , CurrentDate
                              FROM Log";
            
            //Define em que banco será executada a aquery
            CommandSql cmd = new CommandSql(ConfigHelper.GetConnectionString("Log_ConnectionString"), query, EnumDatabaseType.SqlServer);

            //Obtem os dados do banco de dados MySql
            IEnumerable<LogMessage> logMessageCollection = GetCollection<LogMessage>(cmd)?.ToList();

            return logMessageCollection;
        }
    }
}
