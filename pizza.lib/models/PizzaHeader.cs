using System;
using System.Collections.Generic;
using System.Text;

namespace pizza
{
    public class PizzaHeader
    {
        public int Rows { get; set; }
        public int Columns { get; set; }
        public int MinIngredients { get; set; }
        public int MaxCells { get; set; }
    }
}
