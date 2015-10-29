using System;

namespace Logg
{
    public interface ILogger
    {
        LogEntry GetLogEntry(string message, LogEntryType type);
        LogEntry GetLogEntry(Exception exception, LogEntryType type);
        void WriteTo(LogEntry logEntry);
    }
}
