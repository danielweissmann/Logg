using System;
using System.IO;
using System.Xml.Linq;

namespace Logg
{
    public class WriteToFile : IWriteTo
    {
        private LogEntries logEntries;

        private string SerializeTo { get { return Path.Combine(LoggSession.WriteToPath, WriteToFileName); } }

        public string WriteToFileName { get { return String.Format("dump_{0}.xml", DateTime.Now.ToString("yyyy-MM-dd")); } }

        public WriteToFile()
        {
            logEntries = new LogEntries();

            if (File.Exists(SerializeTo))
            {
                logEntries = Serialization.Deserialize<LogEntries>(XDocument.Load(SerializeTo).ToString());

                File.Delete(SerializeTo);
            }
        }

        public void WriteTo(LogEntry logEntry)
        {
            logEntry.Id = logEntries.Count + 1;

            logEntries.Add(logEntry);

            string serializeXml = String.Empty;

            //serialize xml
            Serialization.Serialize<Logg.LogEntries>(logEntries, ref serializeXml);

            XDocument.Parse(serializeXml).Save(SerializeTo);
        }
    }
}
