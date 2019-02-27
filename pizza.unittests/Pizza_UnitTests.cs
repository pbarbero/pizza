using System;
using Xunit;
using pizza.lib;
using pizza.lib.models;
using System.Linq;

namespace pizza.unittests
{
    public class Pizza_UnitTests
    {
        private readonly IPizzaCutter pizzaCutter;

        public Pizza_UnitTests()
        {
            pizzaCutter = new PizzaCutter();
        }

        [Fact]
        public void Test_Slices()
        {
            var pizza = MockPizza();
            pizzaCutter.InitPizza(pizza);
            pizza.Slices = pizzaCutter.InitialCut();

            Assert.True(pizza.Slices.Count() == 3);
        }

        private Pizza MockPizza()
        {
            return new Pizza()
            {
                Header = MockPizzaHeader(),
                Ingredients = MockIngredients()
            };
        }

        private PizzaHeader MockPizzaHeader()
        {
            return new PizzaHeader()
            {
                Columns = 5,
                Rows = 3,
                MaxCells = 6,
                MinIngredients = 1
            };
        }

        private char[,] MockIngredients()
        {
            return new char[3,5]
            {
                {'T', 'T', 'T', 'T', 'T'},
                {'T', 'M', 'M', 'M', 'T'},
                {'T', 'T', 'T', 'T', 'T'},
            };
        }             
    }
}
