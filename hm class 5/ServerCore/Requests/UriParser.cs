using ServerEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;


namespace ServerCore.Requests
{
    public class UriParser
    {
        public static UriParts Parse(string uri)
        {
            /* 
             * Explanation of regex at https://regex101.com/r/jPWZsT/1/          
             */
            var match = Regex.Match(uri, @"^((?:\/(?:\w|\.)*\/?)+)\??((?:\w+=\w+&?)*)$");
            if (!match.Success)
            {
                throw new ArgumentException("uri");
            }

            var paths = match.Groups[1].Value;
            var query = match.Groups[2].Value;

            var uriPaths = paths.Split('/', StringSplitOptions.RemoveEmptyEntries);
            var queryCollection = new QueryCollection();
            queryCollection.SetQuery(query);
            var queries = queryCollection.Queries;

            return new UriParts { Paths = uriPaths, Query = queries, Uri = GetFullUri(uriPaths, queries) };
        }

        private static string GetFullUri(string[] paths, Dictionary<string, string> query)
        {
            string path = string.Join("/", paths);

            var keyValueQueries = query.Select(kvp => $"{kvp.Key}={kvp.Value}");
            string finalQuery = string.Join("&", keyValueQueries);

            string finalUri = (finalQuery == string.Empty) ? path : string.Join("?", path, finalQuery);

            return $"/{finalUri}";
        }
    }
}
