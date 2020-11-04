using ServerCore.Requests;

using ServerEntities;

using System;

namespace ServerTests
{
    class Program
    {
        static void Main(string[] args)
        {
            RequestParser parser = new RequestParser(null);

            var requestString1 = @"WHATEVS /one/two?three=4 HTTP/1.1
User-Agent: PostmanRuntime/7.26.7
Accept: */*
Cache-Control: no-cache
Postman-Token: 87b90cfe-9637-4ba8-bf67-54e0ad7538ee
Host: localhost:668
Accept-Encoding: gzip, deflate, br
Connection: keep-alive
Content-Length: 0";

            var request1 = parser.Parse(requestString1);

            Console.Write("Request 1 Test 1 ");
            if (request1.Method == Method.Unknown)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("OK");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("NOT OK ");
                Console.ResetColor();
            }

            Console.Write("Request 1 Test 2 ");
            if (request1.Uri.Uri == "/one/two?three=4")
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("OK");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("NOT OK ");
                Console.ResetColor();
            }

            Console.Write("Request 1 Test 3 ");
            if (request1.Version == "1.1")
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("OK");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("NOT OK ");
                Console.ResetColor();
            }
        }
    }
}
