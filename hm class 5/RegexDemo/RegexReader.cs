using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace RegexDemo
{
    class RegexReader : IReader
    {
        public IEnumerable<NanoBot> ReadNanobots(IEnumerable<string> nanobotLines)
        {
            var regex = new Regex(@"^pos=<(.*),(.*),(.*)>, r=(.*)$");
            var result = new List<NanoBot>();
            foreach (var line in nanobotLines)
            {
                var match = regex.Match(line);
                var nanobot = new NanoBot
                {
                    Position = new Point3
                    {
                        X = int.Parse(match.Groups[1].Value),
                        Y = int.Parse(match.Groups[2].Value),
                        Z = int.Parse(match.Groups[3].Value),
                    },
                    Radius = int.Parse(match.Groups[4].Value),
                };
                result.Add(nanobot);
            }
            return result;
        }

        public IEnumerable<Star> ReadStars(IEnumerable<string> starLines)
        {
            var regex = new Regex(@"^position=<\s?(.*),\s+(.*)> velocity=<\s?(.*),\s+(.*)>$");
            var result = new List<Star>();
            foreach (var line in starLines)
            {
                var match = regex.Match(line);
                var star = new Star
                {
                    Position = new Point2
                    {
                        X = int.Parse(match.Groups[1].Value),
                        Y = int.Parse(match.Groups[2].Value),
                    },
                    Velocity = new Point2
                    {
                        X = int.Parse(match.Groups[3].Value),
                        Y = int.Parse(match.Groups[4].Value),
                    },
                };
                result.Add(star);
            }
            return result;
        }
    }
}
