using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedFunctionalPreogramming
{
    public interface IFunctor<T>
    {
        IFunctor<TResult> Map<TResult>(Func<T, TResult> fn);

        T GetValue();
    }
}
