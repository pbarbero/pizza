using System.Collections.Generic;
using System.Linq;

namespace pizza.lib.models
{
    public class Slice
    {
        public Slice()
        {
            Cells = new List<Cell>();
        }

        public List<Cell> Cells { get; set; }
        public Cell StartCell { get; set; }
        public Cell EndCell { get; set; }

        public Cell GetMinCell()
        {
            var minX = Cells.Min(cell => cell.X);
            var minY = Cells.Min(cell => cell.Y);

            return new Cell() { X = minX, Y = minY };
        }

        public Cell GetMaxCell()
        {
            var maxX = Cells.Max(cell => cell.X);
            var maxY = Cells.Max(cell => cell.Y);

            return new Cell() { X = maxX, Y = maxY };
        }

        public bool HasEnoughIngredients(int minIngredients)
        {
            var tomatoes = Cells.Where(x => x.Ingredient == 'T');
            var mushrooms = Cells.Where(x => x.Ingredient == 'M');

            return tomatoes.Count() >= minIngredients && mushrooms.Count() >= 1;
        }
    }
}