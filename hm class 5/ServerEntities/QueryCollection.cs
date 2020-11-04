using System;
using System.Collections.Generic;


namespace ServerEntities
{
    public class QueryCollection
    {
        private readonly Dictionary<string, string> _queries = new Dictionary<string, string>();
        public QueryCollection() { }


        public Dictionary<string, string> Queries 
        {
            get => _queries; 
        }
        public QueryCollection(IEnumerable<Query> inputQueries)
        {
            foreach (var query in inputQueries)
            {
                _queries.Add(query.Name, query.Value);
            }
        }

        public int Count
        {
            get
            {
                return _queries.Count;
            }
        }

        public bool HasQuery(string name)
        {
            return _queries.ContainsKey(name);
        }

        public Query GetQuery(string name)
        {
            if (!_queries.ContainsKey(name))
            {
                throw new ArgumentException("name");
            }
            return new Query(name, _queries[name]);
        }
        
        public void SetQuery(string name, string value)
        {
            if (_queries.ContainsKey(name))
            {
                _queries[name] = value;
            }
            else
            {
                _queries.Add(name, value);
            }
        }

        public void SetQuery(string query)
        {
            var queries = query.Split('&', StringSplitOptions.RemoveEmptyEntries);
            foreach (var queryPart in queries) 
            {
                var keyValuePair = queryPart.Split('=');
                string key = keyValuePair[0];
                string value = keyValuePair[1];

                SetQuery(key, value);
            }         
        }

        public IEnumerable<string> GetAvailableQueries()
        {
            return _queries.Keys;
        }
    }
}
