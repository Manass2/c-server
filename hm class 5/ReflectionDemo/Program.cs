using System;

namespace ReflectionDemo
{
    class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public override string ToString()
        {
            return $"{FirstName} {LastName}";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var weko = new Person
            {
                FirstName = "Wekoslav",
                LastName = "Stefanovski"
            };

            AnalyzeObject(weko);

            Console.WriteLine(weko);
        }

        private static void AnalyzeObject(object something)
        {
            var type = something.GetType();
            Console.WriteLine(type.FullName);

            var props = type.GetProperties();

            foreach (var prop in props)
            {
                Console.WriteLine($"{prop.Name} ({prop.PropertyType})");
            }

            foreach (var prop in props)
            {
                var value = prop.GetValue(something);
                Console.WriteLine($"{prop.Name} has value {value}");
                prop.SetValue(something, value.ToString().Substring(0, 4));
            }
        }
    }
}
