using prmToolkit.Log.Interfaces;
using System.Diagnostics;
using System.Threading.Tasks;

namespace prmToolkit.Log
{
    public sealed class EventViewerLog : ILog
    {
        private readonly string _source;
        public EventViewerLog(string source)
        {
            _source = source;
        }

        public void Save(string message)
        {
            EventLog eventLog = new EventLog();
            eventLog.Source = _source;

            eventLog.WriteEntry(message, EventLogEntryType.Information);
        }

        public async Task SaveAsync(string message)
        {
            await Task.Run(() => Save(message));
        }
    }
}
