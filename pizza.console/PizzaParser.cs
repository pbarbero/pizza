using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace pizza.console
{
    public class PizzaParser
    {
        public void Parse(IEnumerable<string> lines)
        {
            var pizzaHeader = lines.FirstOrDefault().Split(" ");
        }

        private PizzaHeader GetPizzaHeader(string[] line)
        {
            return new PizzaHeader()
            {
            };
        }
    }
}
