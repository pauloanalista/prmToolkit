using prmToolkit.Log.Domain.Entities;
using prmToolkit.Log.Domain.Interfaces.Repositories;
using prmToolkit.Log.Domain.Interfaces.Services;
using System.Collections.Generic;

namespace prmToolkit.Log.Domain.Services
{
    public class LogMessageService : ILogMessageService
    {
        private readonly ILogMessageRepository _logMessageRepository;

        public LogMessageService(ILogMessageRepository logMessageRepository)
        {
            _logMessageRepository = logMessageRepository;
        }
        public IEnumerable<LogMessage> ObterLogs()
        {
            return _logMessageRepository.ObterLogs();
        }
    }
}
