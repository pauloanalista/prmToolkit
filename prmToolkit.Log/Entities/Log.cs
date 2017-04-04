using System;

namespace prmToolkit.Log.Entities
{
    public class Log
    {
        public Int64 Id { get; set; }

        public string Application { get; set; }

        public string  Message { get; set; }

        public DateTime CurrentDate { get; set; }
    }
}
