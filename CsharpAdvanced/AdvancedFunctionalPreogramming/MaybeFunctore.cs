using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedFunctionalPreogramming
{
    public class MaybeFunctore<T> : IFunctor<T>
    {
        private readonly T _value;
        private readonly bool _hasValue;

        private MaybeFunctore(T value, bool hasValue)
        {
            _value = value;
            _hasValue = hasValue;
        }

        public static MaybeFunctore<T> Some(T value) => new MaybeFunctore<T>(value, true);
        public static MaybeFunctore<T> None() => new MaybeFunctore<T>(default(T), false);

        public IFunctor<TResult> Map<TResult>(Func<T, TResult> fn)
        {
            if (!_hasValue)
            {
                return MaybeFunctore<TResult>.None();
            }

            return MaybeFunctore<TResult>.Some(fn(_value));
        }

        public T GetValue() =>
            _hasValue ? _value : default(T);
    }
}
