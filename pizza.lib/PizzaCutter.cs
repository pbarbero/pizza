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

            var row = 0;
            var column = 0;
            var lastRow = 0;
            var lastColumn = 0;
            var slice = new Slice();

            while (column < _columns)
            {
                while (row < _rows)
                {
                    if (HasEnoughIngredients(slice))
                    {
                        slices.Add(slice);
                        row = slice.GetMaxCell().X + 1;
                        column = slice.GetMinCell().Y;
                        lastRow = row;
                        lastColumn = column;
                        slice = new Slice();
                    }
                    else
                    {
                        var cellsToAdd = BuildSlice(row, column, lastRow, lastColumn);
                        slice.Cells.AddRange(cellsToAdd);
                        row++;
                        column++;

                        if (row >= _rows)
                        {
                            slices.Last().Cells.AddRange(slice.Cells);
                            slice = new Slice();
                        }
                    }
                }

                row = 0;
                column = slices.Last().GetMaxCell().Y + 1;
            }

            return slices;
        }

        private List<Cell> BuildSlice(int centerX, int centerY, int rowToStart, int columnToStart)
        {
            var cells = new List<Cell>()
            {
                new Cell()
                {
                    X = centerX,
                    Y = centerY,
                    Ingredient = _pizza.Ingredients[centerX, centerY]
                }
            };

            for (var i = rowToStart; i < centerX; i++)
            {
                cells.Add(new Cell()
                {
                    X = i,
                    Y = centerY,
                    Ingredient = _pizza.Ingredients[i, centerY]
                });
            }


            for (var j = rowToStart; j < centerX; j++)
            {
                cells.Add(new Cell()
                {
                    X = centerX,
                    Y = j,
                    Ingredient = _pizza.Ingredients[centerX, j]
                });
            }

            return cells; 
        }

        private int GetMaxXFromSlice(Slice slice)
        {
            return slice.Cells.Max(cell => cell.X);
        }
        private int GetMaxYFromSlice(Slice slice)
        {
            return slice.Cells.Max(cell => cell.Y);
        }


        private bool HasEnoughIngredients(Slice slice)
        {
            var tomatoes = slice.Cells.Where(x => x.Ingredient == 'T');
            var mushrooms = slice.Cells.Where(x => x.Ingredient == 'M');

            return tomatoes.Count() >= _minIngredients && mushrooms.Count() >= 1;
        }
    }
}