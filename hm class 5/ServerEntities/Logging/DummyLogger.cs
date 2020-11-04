using System;
using System.Collections.Generic;
using System.Text;

namespace ServerEntities.Logging
{
    public class DummyLogger : ILogger
    {
        public LogLevel Level { get; } = LogLevel.Debug;

        public void LogMessage(LogLevel level, string message, Exception exception = null)
        {
        }
    }
}
