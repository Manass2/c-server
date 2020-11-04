using ServerCore.Engine;

using ServerEntities.Logging;

using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace SedcServer
{
    class Program
    {

        static void Main(string[] args)
        {
            var address = IPAddress.Loopback;
            var port = 668;
            
            var logger = new CompositeLogger(new ConsoleLogger(LogLevel.Info), new FileLogger("log.txt"));
            logger.Add(new FileLogger("other-log.txt", LogLevel.Error));

            var server = new WebServer(address, port, logger);

            server.Run();

        }
    }
}
