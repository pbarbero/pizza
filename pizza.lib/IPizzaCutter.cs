using pizza.lib.models;
using System.Collections.Generic;

namespace pizza.lib
{
    public interface IPizzaCutter
    {
         IEnumerable<Slice> Cut(Pizza pizza);
    }
}