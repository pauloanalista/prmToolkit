using prmToolkit.Log.Application.Interfaces;
using prmToolkit.Log.Domain.Entities;
using prmToolkit.Log.Domain.Interfaces.Services;
using System.Collections.Generic;

namespace prmToolkit.Log.Application.Services
{
    public class LogMessageApplication : ILogMessageApplication
    {
        private readonly ILogMessageService _logMessageService;

        public LogMessageApplication(ILogMessageService logMessageService)
        {
            _logMessageService = logMessageService;
        }

        public IEnumerable<LogMessage> ObterLogs()
        {
            return _logMessageService.ObterLogs();
        }
    }
}
