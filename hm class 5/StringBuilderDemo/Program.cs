using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace StringBuilderDemo
{
    class Program
    {

        private static List<string> numbers = new List<string> { "one", "two", "three" };
        static void Main(string[] args)
        {
            var numnums = SquareStrings(numbers);
            numnums = SquareStrings(numnums);
            numnums = SquareStrings(numnums);
            numnums = MulStrings(numnums, numbers);
            // PrintStrings(numnums);
            Console.WriteLine(numnums.Count());

            Stopwatch stopwatch = Stopwatch.StartNew();

            var result = string.Empty;
            foreach (var line in numnums)
            {
                result += line;
            }
            stopwatch.Stop();

            Console.WriteLine(result.Length);
            Console.WriteLine($"Duration: {stopwatch.ElapsedMilliseconds}ms");

            stopwatch = Stopwatch.StartNew();

            StringBuilder sb = new StringBuilder();
            foreach (var line in numnums)
            {
                sb.Append(line);
            }
            result = sb.ToString();
            stopwatch.Stop();

            Console.WriteLine(result.Length);
            Console.WriteLine($"Duration: {stopwatch.ElapsedMilliseconds}ms");


            //var weko = "weko";
            //weko = weko + "slav";
            //weko = weko + " ";
            //weko = weko + "stef";
            //weko = weko + "ano";
            //weko = weko + "vski";
            //Console.WriteLine(weko);
        }

        private static IEnumerable<string> SquareStrings(IEnumerable<string> input)
        {
            var result = from a in input
                         from b in input
                         select a + b;
            return result;
        }

        private static IEnumerable<string> MulStrings(IEnumerable<string> first, IEnumerable<string> second)
        {
            var result = from a in first
                         from b in second
                         select a + b;
            return result;
        }

        private static void PrintStrings(IEnumerable<string> input)
        {
            foreach (var line in input)
            {
                Console.WriteLine(line);
            }
        }
    }
}
