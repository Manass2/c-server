using System;
using System.Collections.Generic;
using System.Text;

namespace ServerEntities
{
    public class HeaderCollection
    {
        private Dictionary<string, string> data = new Dictionary<string, string>();

        public HeaderCollection()
        {
        }

        public HeaderCollection(Dictionary<string, string> headers)
        {
            foreach (var kvp in headers)
            {
                data.Add(kvp.Key, kvp.Value);
            }
        }

        public HeaderCollection(IEnumerable<Header> headers)
        {
            foreach (var header in headers)
            {
                data.Add(header.Name, header.Value);
            }
        }

        public int Count { 
            get
            {
                return data.Count;
            }
        }

        public bool HasHeader(string name)
        {
            return data.ContainsKey(name);
        }

        public Header GetHeader(string name)
        {
            if (!data.ContainsKey(name))
            {
                throw new ArgumentException("name");
                // return Header.Empty;
            }
            return new Header(name, data[name]);
        }

        public void SetHeader(string name, string value)
        {
            if (data.ContainsKey(name))
            {
                data[name] = value;
            }
            else
            {
                data.Add(name, value);
            }
        }

        public IEnumerable<string> GetAvailableHeaders()
        {
            return data.Keys;
        }
    }
}
