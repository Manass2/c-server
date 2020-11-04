using System;
using System.Collections.Generic;
using System.Text;

namespace ServerEntities
{
    public class Response
    {
        public HeaderCollection Headers { get; set; }

        public string Version { get; set; }

        public string Body { get; set; }

        private int status;

        public StatusCode Status {
            get => (StatusCode)status;
            set {
                status = (int)value;
                Message = value.GetDescription();
            }
        }

        public string Message { get; set; }

        public static Response EmptyResponse = new Response
        {
            Headers = new HeaderCollection(),
            Version = "1.1",
            Status = StatusCode.Invalid,
            Message = string.Empty
        };
    }
}
