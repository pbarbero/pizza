using System;
using System.Collections.Generic;
using System.Linq;
using pizza.lib.models;

namespace pizza.console
{
    public static class PizzaParser
    {
        public static Pizza Parse(IEnumerable<string> lines)
        {
            var pizzaHeader = GetPizzaHeader(lines.FirstOrDefault());
            return GetPizza(lines.Skip(1), pizzaHeader);
        }

        private static PizzaHeader GetPizzaHeader(string line)
        {
            var splittedLine = line.Split(" ");

            return new PizzaHeader()
            {
                Rows = GetInt(splittedLine[0]),
                Columns = GetInt(splittedLine[1]),
                MinIngredients = GetInt(splittedLine[2]),
                MaxCells = GetInt(splittedLine[3])
            };
        }

        private static Pizza GetPizza(IEnumerable<string> lines, PizzaHeader pizzaHeader)
        {
            var ingredients = new char[pizzaHeader.Rows, pizzaHeader.Columns];

            for (var i = 0; i < pizzaHeader.Rows; i++)
            {
                var splittedLine = lines.ToList()[i];

                for (var j = 0; j < pizzaHeader.Columns; j++)
                {
                    ingredients[i, j] = splittedLine[j];
                }
            }

            return new Pizza()
            {
                Header = pizzaHeader,
                Ingredients = ingredients
            };
        }

        private static int GetInt(string foo)
        {
            var number = 0;

            if (!Int32.TryParse(foo, out number))
            {
                throw new Exception("Cannot parse file");
            }

            return number;
        }        
    }
}
