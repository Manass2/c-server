using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace RegexDemo
{
    public class RegularReader : IReader
    {
        public IEnumerable<NanoBot> ReadNanobots(IEnumerable<string> nanobotLines)
        {
            var result = new List<NanoBot>();
            foreach (var line in nanobotLines)
            {
                var nums = line.Substring(5, line.IndexOf(">")-5);
                var coords = nums.Split(",");
                var x = int.Parse(coords[0]);
                var y = int.Parse(coords[1]);
                var z = int.Parse(coords[2]);
                var rad = line.Substring(line.IndexOf("r=")+2);
                var r = int.Parse(rad);
                var nanobot = new NanoBot
                {
                    Position = new Point3
                    {
                        X = x,
                        Y = y,
                        Z = z
                    },
                    Radius = r
                };
                result.Add(nanobot);
            }

            return result;
        }

        public IEnumerable<Star> ReadStars(IEnumerable<string> starLines)
        {
            var result = new List<Star>();
            foreach (var line in starLines)
            {
                var posxsign = line.Substring(10, 1);
                var posxvalue = line.Substring(11, 5);
                var posx = int.Parse(posxvalue);
                if (posxsign[0] == '-')
                {
                    posx = -posx;
                }
                var posysign = line.Substring(18, 1);
                var posyvalue = line.Substring(19, 5);
                var posy = int.Parse(posyvalue);
                if (posysign[0] == '-')
                {
                    posy = -posy;
                }

                var velxsign = line.Substring(36, 1);
                var velxvalue = line.Substring(37, 1);
                var velx = int.Parse(velxvalue);
                if (velxsign[0] == '-')
                {
                    velx = -velx;
                }

                var velysign = line.Substring(40, 1);
                var velyvalue = line.Substring(41, 1);
                var vely = int.Parse(velyvalue);
                if (velysign[0] == '-')
                {
                    vely = -vely;
                }

                var star = new Star
                {
                    Position = new Point2
                    {
                        X = posx,
                        Y = posy
                    },
                    Velocity = new Point2
                    {
                        X = velx,
                        Y = vely
                    }
                };

                result.Add(star);
            }
            return result;
        }
    }
}
