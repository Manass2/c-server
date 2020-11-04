using ServerEntities;
using ServerEntities.Logging;

using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;

namespace ServerCore.Requests
{
    public class RequestGetter: IDisposable
    {
        public NetworkStream Stream { get; private set; }
        public ILogger Logger { get; private set; }

        public RequestGetter(NetworkStream stream, ILogger logger)
        {
            Stream = stream;
            Logger = logger;
        }
        public Request GetRequest()
        {
            byte[] bytes = new byte[8192];
            var readCount = Stream.Read(bytes, 0, bytes.Length);
            string requestData = Encoding.ASCII.GetString(bytes, 0, readCount);
            var parser = new RequestParser(Logger);
            var request = parser.Parse(requestData);
            return request;
        }

        public void Dispose()
        {
            // intentionally does not close the stream
        }
    }
}
