using System;
using System.Collections.Generic;
using System.Linq;
using Lesniarasoft.Client;

namespace SessionDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome Session Demo!");
            StringTest();
            Console.WriteLine();

            IntegerTest();
            Console.WriteLine();

            ListTest();
            Console.WriteLine();

            ChangeFirstStringTest();
            Console.WriteLine();

            Console.WriteLine("All Done!");
        }

        static void StringTest()
        {
            Console.WriteLine("Enter Session Key:");
            var sessionKey = Console.ReadLine();

            Console.WriteLine("Enter Session String Value:");
            var sessionValue = Console.ReadLine();

            // write
            Session.TrySet<string>(sessionKey, sessionValue);

            // read
            Session.TryGet<string>(sessionKey, out sessionValue);

            Console.WriteLine($"Session String Key: {sessionKey}, Value:{sessionValue}");
        }

        static void IntegerTest()
        {
            Console.WriteLine("Enter Session Key:");
            var sessionKey = Console.ReadLine();

            Console.WriteLine("Enter Session Integer Value:");
            // sanitize command line input
            int sessionValue = 0;
            Int32.TryParse(Console.ReadLine(), out sessionValue);

            // write 
            Session.TrySet<int>(sessionKey, sessionValue);

            // read
            Session.TryGet<int>(sessionKey, out sessionValue);

            Console.WriteLine($"Session Integer Key: {sessionKey}, Value:{sessionValue}");
        }

        static void ListTest()
        {
            Console.WriteLine("Enter Session Key:");
            var sessionKey = Console.ReadLine();

            Console.WriteLine("Enter comma separated values:");
            var sessionValue = Console.ReadLine().Split(",").ToList<string>();

            // write
            Session.TrySet<List<string>>(sessionKey, sessionValue);

            // read
            Session.TryGet<List<string>>(sessionKey, out sessionValue);

            Console.WriteLine($"Session List Key: {sessionKey}, Values:");

            foreach (string item in sessionValue)
            {
                Console.WriteLine(item);
            }
        }

        static void ChangeFirstStringTest()
        {
            var firstStringKey = Session.Bag.Keys.First();
            string originalValue;

            Session.TryGet(firstStringKey, out originalValue);

            Console.WriteLine("Changing the original string value:");
            Console.WriteLine($"Key: {firstStringKey}, Value: {originalValue}");
            Console.WriteLine("Enter New Session String Value:");
            var sessionValue = Console.ReadLine();

            // write
            Session.TrySet<string>(firstStringKey, sessionValue);

            // read
            Session.TryGet<string>(firstStringKey, out sessionValue);

            Console.WriteLine($"Session String Key: {firstStringKey}, Value:{sessionValue}");
        }

    }
}
