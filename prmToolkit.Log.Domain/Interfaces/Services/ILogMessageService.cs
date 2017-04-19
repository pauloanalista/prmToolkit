using prmToolkit.Log.Domain.Entities;
using System.Collections.Generic;

namespace prmToolkit.Log.Domain.Interfaces.Services
{
    public interface ILogMessageService
    {
        IEnumerable<LogMessage> ObterLogs();
    }
}
