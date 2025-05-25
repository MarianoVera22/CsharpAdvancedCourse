using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generics
{
    public class IPABeerCreator:IDrinkCreator<Beer>
    {
        public Beer Create(double quantity)
            => new Beer("Cerveza IPA", quantity);
    }
}
