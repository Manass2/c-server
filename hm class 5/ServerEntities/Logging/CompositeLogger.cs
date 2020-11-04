using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ServerEntities.Logging
{
    public class CompositeLogger : ILogger
    {
        private readonly List<ILogger> loggers;
        public LogLevel Level { get; }

        public CompositeLogger(params ILogger[] loggers)
        {
            this.loggers = new List<ILogger>(loggers);
        }

        


        public void LogMessage(LogLevel level, string message, Exception exception = null)
        {
            foreach (var logger in loggers)
            {
                logger.LogMessage(level, message, exception);
            }
        }

        public void Add(ILogger logger)
        {
            loggers.Add(logger);
        }
    }
}
