using System.Collections.Generic;


namespace ServerEntities
{
    public class UriParts
    {
        public string[] Paths { get; set; }
        public Dictionary<string, string> Query { get; set; }
        public string Uri { get; set; }
    }
}
