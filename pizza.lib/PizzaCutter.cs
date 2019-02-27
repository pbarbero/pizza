using System.Collections.Generic;
using System.Linq;
using pizza.lib.models;

namespace pizza.lib
{
    public class PizzaCutter : IPizzaCutter
    {
        private Pizza _pizza { get; set; }
        private int _minIngredients { get; set; }
        private int _rows { get; set; }
        private int _columns { get; set; }

        public PizzaCutter()
        {

        }

        public void InitPizza(Pizza pizza)
        {
            _pizza = pizza;
            _minIngredients = pizza.Header.MinIngredients;
            _rows = pizza.Header.Rows;
            _columns = pizza.Header.Columns;
        }

        public IEnumerable<Slice> Cut()
        {
            var slices = new List<Slice>();
            var initColumn = 0;

            for (var column = 1; column < _columns; column++)
            {
                var slice = GetSlice(initColumn, column);

                if (slice.HasEnoughIngredients(_minIngredients))
                {
                    slices.Add(slice);
                    initColumn = slice.GetMaxCell().Y + 1;
                }
                else if (IsLastSlice(slice))
                {
                    slices.Last().Cells.AddRange(slice.Cells);
                }
            }

            return slices;
        }

        private Slice GetSlice(int initColumn, int lastColumn)
        {
            var slice = new Slice();

            for (var column = initColumn; column <= lastColumn; column++)
            {
                for (var row = 0; row < _rows; row++)
                {
                    slice.Cells.Add(new Cell()
                    {
                        X = row,
                        Y = column,
                        Ingredient = _pizza.Ingredients[row, column]
                    });
                }
            }

            return slice;
        }

        private bool IsLastSlice(Slice slice)
        {
            return slice.GetMaxCell().X == _rows - 1
                && slice.GetMaxCell().Y == _columns - 1;
        }
    }
}