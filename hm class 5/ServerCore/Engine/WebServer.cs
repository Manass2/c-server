using ServerCore.Engine;
using ServerCore.Requests;
using ServerCore.Responses;

using ServerEntities;
using ServerEntities.Logging;

using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace ServerCore.Engine
{
    public class WebServer
    {
        public IPAddress Address { get; private set; }

        public int Port { get; private set; }

        public ILogger Logger { get; set; }
        public bool DebugMode { get; private set; }

        public WebServer(IPAddress address, int port, ILogger logger = null, bool debugMode = false)
        {
            Address = address;
            Port = port;
            Logger = logger ?? new ConsoleLogger();
            DebugMode = debugMode;
        }

        public void Run()
        {
            TcpListener listener = new TcpListener(Address, Port);
            listener.Start();
            Logger.Info("Started listening");

            while (true)
            {
                Logger.Info("Waiting for request");
                var client = listener.AcceptTcpClient();
                Logger.Info("Client connected");
                var stream = client.GetStream();
                using var requester = new RequestGetter(stream, Logger);
                using var responder = new ResponseSender(stream, Logger);

                Request request;
                try 
                { 
                    // Step 1: Accept the request and get the data
                    request = requester.GetRequest();
                }
                catch (Exception ex)
                {
                    Logger.Error("Unable to get the request", ex);
                    responder.SendRequestErrorResponse(ex, DebugMode);
                    continue;
                }

                // Step 2: Transform the request object into a response object
                var response = ServerEngine.Process(request);

                // Step 3: Sent the response data and close the request
                responder.SendResponse(response);

                Logger.Info("Sent response");
                client.Close();
            }
        }
    }
}
