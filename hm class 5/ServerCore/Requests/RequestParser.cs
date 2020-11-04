using ServerEntities;
using ServerEntities.Logging;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace ServerCore.Requests
{
    public class RequestParser
    {
        public ILogger Logger { get; set; }

        public RequestParser(ILogger logger)
        {
            Logger = logger;
        }

        public Request Parse(string requestData)
        {
            Logger.Debug(requestData);

            var lines = requestData.Split(Environment.NewLine);

            var requestLine = lines[0];
            var requestRegex = new Regex(@"^([A-Z]+) (.+) HTTP\/(.*)$");
            var match = requestRegex.Match(requestLine);
            var method = match.Groups[1].Value;

            var uri = match.Groups[2].Value;
            var uriParts = UriParser.Parse(uri);

            var version = match.Groups[3].Value;

            var headerLines = lines.Skip(1).TakeWhile(line => !string.IsNullOrEmpty(line));

            var headerRegex = new Regex(@"^(.*): (.*)$");
            var headers = headerLines.Select(line => {
                var match = headerRegex.Match(line);
                return new Header(match.Groups[1].Value, match.Groups[2].Value);
            });

            var body = string.Join(Environment.NewLine, lines.Skip(1).Skip(headerLines.Count()).Skip(1));

            return new Request(method, uriParts, version, headers, body);
        }
    }
}