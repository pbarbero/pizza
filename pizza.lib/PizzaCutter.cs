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
            var diagonal = 0;
            var slice = new Slice();

            while (!HasEnoughIngredients(slice))
            {
                var cells = BuildAdjacentCells();
                slice.Cells.AddRange(cells);
            }

            return slices;
        }

        private List<Cell> BuildAdjacentCells(int diagonal, int initRow, int column)
        {
            var cells = new List<Cell>()
            {
                new Cell()
                {
                    X = diagonal,
                    Y = diagonal,
                    Ingredient = _pizza.Ingredients[diagonal, diagonal]
                }
            };

            for(var row = initRow; row < diagonal - 1; row++)
            {
                cells.Add(new Cell()
                {
                    X = row,
                    Y = column,
                    Ingredient = _pizza.Ingredients[row, column]
                });

                cells.Add(new Cell()
                {
                    X = column,
                    Y = row,
                    Ingredient = _pizza.Ingredients[column, row]
                });
            };

            return cells; 
        }

        private bool HasEnoughIngredients(Slice slice)
        {
            var tomatoes = slice.Cells.Where(x => x.Ingredient == 'T');
            var mushrooms = slice.Cells.Where(x => x.Ingredient == 'M');

            return tomatoes.Count() > minIngredients && mushrooms.Count() > 1;
        }
    }
}