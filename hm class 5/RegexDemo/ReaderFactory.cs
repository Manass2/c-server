using System;
using System.Collections.Generic;
using System.Text;

namespace RegexDemo
{
    static class ReaderFactory
    {
        static public IReader MakeMeAReader(string algorithm)
        {
            if (algorithm == "standard")
            {
                return new RegularReader();
            }
            if (algorithm == "regex")
            {
                return new RegexReader();
            }
            else
            {
                throw new ArgumentOutOfRangeException("algorithm");
            }
        }
    }
}
