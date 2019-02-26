using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using pizza.lib;

namespace pizza.console
{
    class Program
    {
        private static IPizzaCutter pizzaCutter;

        static void Main(string[] args)
        {
            Console.WriteLine("Hello Pizza!");

            var lines = ReadFile(@"../../../data/a_example.in");
            pizzaCutter = new PizzaCutter();
            var pizza = PizzaParser.Parse(lines);
            Console.WriteLine($"My pizza has {pizza.Header.Rows} rows");
            Console.WriteLine($"My pizza has {pizza.Header.Columns} columns");
            Console.WriteLine($"My pizza has {pizza.Header.MaxCells} of maximun cells");
            Console.WriteLine($"My pizza has {pizza.Header.MinIngredients} of min ingredients");

            Console.WriteLine("My piza is like:");
            for(var i = 0; i < pizza.Header.Rows; i++)
            {
                for(var j = 0; j < pizza.Header.Columns; j++)
                {
                    Console.Write($"{pizza.Ingredients[i,j]}");
                }

                Console.Write("\n");
            }

            Console.WriteLine("Let's cut!");
            pizzaCutter.InitPizza(pizza);
            pizza.Slices = pizzaCutter.Cut(); 
        }

        private static IEnumerable<string> ReadFile(string filePath)
        {
            var frequencies = new List<int>();
            var path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), filePath);

            return File.ReadLines(path);
        }
    }
}
