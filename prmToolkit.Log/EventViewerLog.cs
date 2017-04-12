using prmToolkit.Log.Enum;
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

        public void Save(string message, EnumMessageType enumMessageType = EnumMessageType.Information)
        {
            EventLog eventLog = new EventLog();
            eventLog.Source = _source;

            if (enumMessageType == EnumMessageType.Information)
            {
                eventLog.WriteEntry(message, EventLogEntryType.Information);
            }
            else if (enumMessageType == EnumMessageType.Warning)
            {
                eventLog.WriteEntry(message, EventLogEntryType.Warning);
            }
            else if (enumMessageType == EnumMessageType.Error)
            {
                eventLog.WriteEntry(message, EventLogEntryType.Error);
            }

        }

        public async Task SaveAsync(string message, EnumMessageType enumMessageType = EnumMessageType.Information)
        {
            await Task.Run(() => Save(message, enumMessageType));
        }
    }
}
