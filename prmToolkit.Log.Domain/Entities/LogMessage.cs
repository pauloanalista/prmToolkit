using System;

namespace prmToolkit.Log.Domain.Entities
{
    public class LogMessage
    {
        public int Id { get; set; }

        public string Application { get; set; }

        public string MessageType { get; set; }

        public string Message { get; set; }

        public DateTime CurrentDate { get; set; }

    }
}
