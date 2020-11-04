using System;
using System.Collections.Generic;
using System.Text;

namespace ServerEntities.Logging
{
    public interface ILogger
    {
        LogLevel Level { get; }
        void Debug(string message)
        {
            LogMessage(LogLevel.Debug, message);
        }

        void Info(string message)
        {
            LogMessage(LogLevel.Info, message);
        }

        void Warning(string message)
        {
            LogMessage(LogLevel.Warning, message);
        }

        void Error(string message, Exception exception = null)
        {
            LogMessage(LogLevel.Error, message, exception);
        }

        void Fatal(string message, Exception exception = null)
        {
            LogMessage(LogLevel.Fatal, message, exception);
        }

        void LogMessage(LogLevel level, string message, Exception exception = null);
    }

    public enum LogLevel
    {
        Debug = 1,
        Info = 2,
        Warning = 3,
        Error = 4,
        Fatal = 5
    }
}
