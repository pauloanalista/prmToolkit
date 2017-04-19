using prmToolkit.Log.Domain.Entities;
using System.Collections.Generic;

namespace prmToolkit.Log.Application.Interfaces
{
    public interface ILogMessageApplication
    {
        IEnumerable<LogMessage> ObterLogs();
    }
}
