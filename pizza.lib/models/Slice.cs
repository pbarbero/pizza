using System.Collections.Generic;

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
    }
}