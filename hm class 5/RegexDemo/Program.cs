using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace RegexDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            string algorithm = GetAlgorithm(args);

            Console.WriteLine(algorithm);

            var starLines = File.ReadAllLines("stars.txt");
            var nanobotLines = File.ReadAllLines("nanobots.txt");

            var reader = ReaderFactory.MakeMeAReader(algorithm);

            var stars = reader.ReadStars(starLines);
            PrintCollection(stars.Take(10));
            var nanobots = reader.ReadNanobots(nanobotLines);
            PrintCollection(nanobots.Take(10));
        }

        private static void PrintCollection<T>(IEnumerable<T> source)
        {
            foreach (var item in source)
            {
                Console.WriteLine(item);
            }
        }

        private static string GetAlgorithm(string[] args)
        {
            if (args.Length > 1)
            {
                return args[1];
            }
            return args.Length > 0 ? args[0] : "standard";
        }
    }
}
