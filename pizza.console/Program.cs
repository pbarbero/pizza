using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace pizza.console
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello Pizza!");

            var lines = ReadFile(@"../../../input1.txt");
        }

        private static IEnumerable<string> ReadFile(string filePath)
        {
            var frequencies = new List<int>();
            var path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), filePath);

            return File.ReadLines(path);
        }
    }
}
