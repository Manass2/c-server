using System;
using System.Collections.Generic;
using System.Text;

namespace RegexDemo
{
    public class Star
    {
        public Point2 Position { get; set; }
        public Point2 Velocity { get; set; }

        public override string ToString()
        {
            return $"Position: {Position}, Velocity: {Velocity}";
        }
    }
}
