using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedFunctionalPreogramming
{
    public class MaybeMonad<T>
    {
        private readonly T _value;
        private readonly bool _hasValue;

        private MaybeMonad(T value, bool hasValue)
        {
            _value = value;
            _hasValue = hasValue;
        }

        public static MaybeMonad<T> Some(T value) => new MaybeMonad<T>(value, true);
        public static MaybeMonad<T> None() => new MaybeMonad<T>(default(T), false);

        public T GetValue() =>
            _hasValue ? _value : default(T);

        public override string ToString() =>
            _hasValue ? $"Some: {_value}" : "None";

        public MaybeMonad<TResult> Bind<TResult>(Func<T, MaybeMonad<TResult>> binder) // Regresa un objeto MaybeMonad a diferencia del functor que regresa un resultado de funcion
        {
            if (!_hasValue) {
                return MaybeMonad<TResult>.None();
            }

            return binder(_value);
        }
    }

}
