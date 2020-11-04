using ServerEntities;

using System;
using System.Collections.Generic;
using System.Text;

namespace ServerCore.Engine
{
    public class ServerEngine
    {
        public static Response Process(Request request)
        {
            var processor = new EchoProcessor();
            var response = processor.Process(request);
            return response;
        }
    }
}
