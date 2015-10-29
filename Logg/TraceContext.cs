using System.Diagnostics;
using System.Reflection;

namespace Logg
{
    public class TraceContext
    {
        public static StackTrace stackTrace { get; private set; }
        public static StackFrame stackFrame { get; private set; }
        public static MethodBase methodBase { get; private set; }

        public TraceContext(StackTrace pTrace)
        {
            stackTrace = pTrace;
            stackFrame = stackTrace.GetFrame(1);
            methodBase = stackFrame.GetMethod();
        }
    }
}
