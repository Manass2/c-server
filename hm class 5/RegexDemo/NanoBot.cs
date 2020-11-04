using System;
using System.Collections.Generic;
using System.Text;

namespace RegexDemo
{
    public class NanoBot
    {
        public Point3 Position { get; set; }

        public int Radius { get; set; }

        public override string ToString()
        {
            return $"Position: {Position}, Radius: {Radius}";
        }
    }
}
