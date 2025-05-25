using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generics
{
    public interface IDrinkCreator<out T>
    {
        T Create(double quantity);
    }
}
