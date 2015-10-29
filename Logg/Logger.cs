using System;
using System.Diagnostics;

namespace Logg
{
    public class Logger : ILogger
    {
        private LogEntry logEntry;

        public Logger()
        {
            if (TraceContext.stackTrace == null) {
                new TraceContext(new StackTrace()); }
        }

        public LogEntry GetLogEntry(string message, LogEntryType type)
        {
            logEntry = new LogEntry(
                  System.Security.Principal.WindowsIdentity.GetCurrent().Name
                , String.Format("Assembly: {0}, Module: {1}, Method: {2}"
                        , TraceContext.methodBase.DeclaringType.Assembly.GetName().Name
                        , TraceContext.methodBase.DeclaringType.FullName
                        , TraceContext.methodBase.Name)
                , message
                , type
                , DateTime.Now);

            return logEntry;
        }

        public LogEntry GetLogEntry(Exception exception, LogEntryType type)
        {
            string message = null;

            return GetLogEntry(message, type);
        }

        public void WriteTo(LogEntry logEntry)
        {
            IWriteTo ObjIntrface = null;

            ObjIntrface = WriteToFactory.GetObject(LoggSession.WriteTo);

            ObjIntrface.WriteTo(logEntry);
        }
    }
}
