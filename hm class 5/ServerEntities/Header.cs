using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace ServerEntities
{
    public class Header
    {
        public Header(string name, string value)
        {
            Name = name;
            Value = value;
        }
        public string Name { get; private set; }
        public string Value { get; private set; }

        private class EmptyHeader : Header
        {
            public EmptyHeader(): base(string.Empty, string.Empty)
            {

            }
        }

        public static Header Empty
        {
            get
            {
                return new EmptyHeader();
            }
        }

    }

}
