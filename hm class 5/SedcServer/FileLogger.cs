using ServerEntities.Logging;

using System;
using System.Collections.Generic;
using System.IO;
using System.Security;
using System.Text;

namespace SedcServer
{
    public class FileLogger : ILogger
    {
        public string LogFile { get; private set; }
        public LogLevel Level { get; private set; }

        public FileLogger(string logFile, LogLevel level = LogLevel.Debug)
        {
            Level = level;
            LogFile = logFile;
        }

        public void LogMessage(LogLevel level, string message, Exception exception = null)
        {
            if (level >= Level)
            {
                using var stream = new StreamWriter(LogFile, true);
                var levelstr = level.ToString().ToUpperInvariant();
                stream.WriteLine($"[{levelstr}] {message}");
                if (exception != null)
                {
                    stream.WriteLine($"[{levelstr}]    {exception.Message}");
                    stream.WriteLine($"{exception.StackTrace}");
                }
            }
        }
       
    }
}
