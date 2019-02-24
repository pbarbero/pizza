using System.Collections.Generic;

namespace pizza.lib.models
{
    public class Pizza
    {
        public PizzaHeader Header { get; set; }
        public char[,] Ingredients { get; set; }
        public IEnumerable<Slice> Slices { get; set; }
    }
}