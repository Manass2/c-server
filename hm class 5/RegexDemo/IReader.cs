using System;
using System.Collections.Generic;
using System.Text;

namespace RegexDemo
{
    interface IReader
    {
        IEnumerable<Star> ReadStars(IEnumerable<string> starLines);

        IEnumerable<NanoBot> ReadNanobots(IEnumerable<string> nanobotLines);
    }
}
