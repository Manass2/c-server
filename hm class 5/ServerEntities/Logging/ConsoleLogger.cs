using System;
using System.Collections.Generic;
using System.Text;

namespace ServerEntities.Logging
{
    public class ConsoleLogger : ILogger
    {
        public LogLevel Level { get; private set; }

        public ConsoleLogger(LogLevel level = LogLevel.Debug)
        {
            Level = level;
        }

        public void LogMessage(LogLevel level, string message, Exception exception = null)
        {
            if (level >= Level)
            {
                var levelstr = level.ToString().ToUpperInvariant();
                Console.WriteLine($"[{levelstr}] {message}");
                if (exception != null)
                {
                    Console.WriteLine($"[{levelstr}]    {exception.Message}");
                    Console.WriteLine($"{exception.StackTrace}");
                }
            }
        }
    }
}
