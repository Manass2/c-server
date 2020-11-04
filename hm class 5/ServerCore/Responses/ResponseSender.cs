using ServerEntities;
using ServerEntities.Logging;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;

namespace ServerCore.Responses
{
    public class ResponseSender: IDisposable
    {
        public NetworkStream Stream { get; private set; }
        public ILogger Logger { get; private set; }

        public ResponseSender(NetworkStream stream, ILogger logger)
        {
            Stream = stream;
            Logger = logger;
        }

        public void SendResponse(Response response)
        {
            var status = (int)response.Status;
            var statusLine = $"HTTP/{response.Version} {status} {response.Message}";
            var headersLines = GetHeaderLines(response.Headers);

            string content = statusLine + Environment.NewLine + headersLines + Environment.NewLine;
            if (!string.IsNullOrEmpty(response.Body))
            {
                content += Environment.NewLine + response.Body;
            }

            Logger.Debug(content);
            var contentBytes = Encoding.ASCII.GetBytes(content);
            Stream.Write(contentBytes);
            Stream.Close();
        }

        private static string GetHeaderLines(HeaderCollection headers)
        {
            return string.Join(Environment.NewLine, headers.GetAvailableHeaders().Select(header => $"{header}: {headers.GetHeader(header).Value}"));
        }

        public void Dispose()
        {
            Stream.Dispose();
        }

        internal void SendRequestErrorResponse(Exception ex, bool debugMode)
        {
            var response = ResponseGenerator.MakeRequestErrorResponse(ex, debugMode);
            SendResponse(response);
        }
    }
}
