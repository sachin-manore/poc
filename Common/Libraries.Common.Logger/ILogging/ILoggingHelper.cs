namespace Libraries.Common.Logger
{
    public interface ILoggingHelper
    {
        void WriteLog(string message, string componentName, TraceLevel traceLevel = TraceLevel.Info, Exception ex = null);

        void LogMessage(Exception ex, string componentName = "", TraceLevel traceLevel = TraceLevel.Info, object obj = null);

        void LogMessage(string message, string componentName = "", TraceLevel traceLevel = TraceLevel.Info, object obj = null, [CallerMemberName] string methodName = "", [CallerFilePath] string fileName = "", [CallerLineNumber] int lineNumber = 0);

        void LogObject(Type objectType, Object objectInstance, string componentName = "");
    }
}
