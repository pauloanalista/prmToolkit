using prmToolkit.Log.Domain.Entities;
using System.Collections.Generic;

namespace prmToolkit.Log.Domain.Interfaces.Repositories
{
    public interface ILogMessageRepository
    {
        IEnumerable<LogMessage> ObterLogs();
    }
}
