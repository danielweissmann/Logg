using System;
using System.Diagnostics;

namespace Logg
{
    public class LoggerException : Exception
    {
        public LoggerException(string message) : base(message)
        {
            new TraceContext(new StackTrace());

            Logger logg = new Logger();
            LogEntry logEntry = logg.GetLogEntry(message, LogEntryType.Exception);

            logg.WriteTo(logEntry);
        }
    }
}
