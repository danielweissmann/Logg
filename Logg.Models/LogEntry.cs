using System;
using System.Xml.Serialization;

namespace Logg
{
    [XmlRoot(ElementName = "LogEntry", IsNullable = false)]
    public class LogEntry
    {
        public int Id { get; set; }

        public string User { get; set; }

        public string Source { get; set; }

        public string Message { get; set; }

        public LogEntryType Type { get; set; }

        public DateTime Date { get; set; }

        public LogEntry() { }

        public LogEntry(
              string user
            , string source
            , string message
            , LogEntryType type
            , DateTime date)
        {
            this.Id = 0;
            this.User = user;
            this.Source = source;
            this.Message = message;
            this.Type = type;
            this.Date = date;
        }
    }
}
