using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using pizza.lib;
using pizza.lib.models;

namespace pizza.console
{
    class Program
    {
        private static IPizzaCutter pizzaCutter;

        static void Main(string[] args)
        {
            var FilesNames = new List<string>()
            {
                @"../../../data/a_example.in",
                @"../../../data/b_small.in",
                @"../../../data/c_medium.in",
                @"../../../data/d_big.in"
            };

            foreach (var file in FilesNames)
            {
                CutPizza(file);
                Console.Write("Press a key to continue...");
            }           
            
            var foo = Console.ReadKey();
            Console.Write("Bye!");
        }

        private static void CutPizza(string file)
        {
            Console.WriteLine($"Hello Pizza {Path.GetFileName(file)}!");

            var lines = ReadFile(file);
            pizzaCutter = new PizzaCutter();
            var pizza = PizzaParser.Parse(lines);

            //Print
            //PrintPizza(pizza);

            //Cut pizza
            Console.WriteLine("Let's cut!");
            pizza.Slices = pizzaCutter.InitialCut(pizza);           

            //Write
            WriteOutFile(pizza, file);
        }

        private static void PrintPizza(Pizza pizza)
        {
            Console.WriteLine($"My pizza has {pizza.Header.Rows} rows");
            Console.WriteLine($"My pizza has {pizza.Header.Columns} columns");
            Console.WriteLine($"My pizza has {pizza.Header.MaxCells} of maximun cells");
            Console.WriteLine($"My pizza has {pizza.Header.MinIngredients} of min ingredients");

            Console.WriteLine("My pizza is like:");
            for (var i = 0; i < pizza.Header.Rows; i++)
            {
                for (var j = 0; j < pizza.Header.Columns; j++)
                {
                    Console.Write($"{pizza.Ingredients[i, j]}");
                }

                Console.Write("\n");
            }
        }

        private static void WriteOutFile(Pizza pizza, string file)
        {
            //Console
            Console.WriteLine($"My pizza has {pizza.Slices.Count()} slices");

            foreach (var slice in pizza.Slices)
            {
                Console.Write($"{slice.GetMinCell().X} {slice.GetMinCell().Y} {slice.GetMaxCell().X} {slice.GetMaxCell().Y}");
                Console.Write("\n");
            }

            //File
            using (StreamWriter writetext = new StreamWriter(@"../../../output/" + Path.GetFileName(file) + ".out"))
            {
                var stringBuilder = new StringBuilder($"{pizza.Slices.Count()} \n");

                foreach (var slice in pizza.Slices)
                {
                    stringBuilder.Append($"{slice.GetMinCell().X} {slice.GetMinCell().Y} {slice.GetMaxCell().X} {slice.GetMaxCell().Y}");
                    stringBuilder.Append("\n");
                }

                writetext.WriteLine(stringBuilder);
            }
        }

        private static IEnumerable<string> ReadFile(string filePath)
        {
            var frequencies = new List<int>();
            var path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), filePath);

            return File.ReadLines(path);
        }
    }
}
