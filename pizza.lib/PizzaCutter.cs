using System.Collections.Generic;
using pizza.lib.models;

namespace pizza.lib
{
    public class PizzaCutter : IPizzaCutter
    {
        public PizzaCutter()
        {

        }

        public IEnumerable<Slice> Cut(Pizza pizza)
        {
            return new List<Slice>()
            {
                new Slice(),
                new Slice(),
                new Slice()
            };
        }
    }
}