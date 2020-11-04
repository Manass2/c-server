using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Text.RegularExpressions;

namespace ServerEntities
{
    public class Request
    {
        public Request(string method, UriParts uri, string version, IEnumerable<Header> headers, string body)
        {
            Method = MethodResolver.FromString(method);
            Uri = uri;
            Version = version;
            Headers = new HeaderCollection(headers);
            Body = body;
        }

        public Method Method { get; private set; }

        public UriParts Uri { get; private set; }

        public string Version { get; private set; }

        public HeaderCollection Headers { get; private set; }

        public string Body { get; private set; }

        public override string ToString()
        {
            return $"{Method} - {Uri} - HTTP {Version}{Environment.NewLine}{Body}";
        }
    }
}
