namespace ServerEntities
{
    public class Query
    {
        public Query(string name, string value)
        {
            Name = name;
            Value = value;
        }


        public string Name { get; private set; }
        public string Value { get; private set; }

        private class EmptyQuery : Query
        {
            public EmptyQuery() : base(string.Empty, string.Empty)
            {

            }
        }

        public static Query Empty
        {
            get
            {
                return new EmptyQuery();
            }
        }

    }
}
