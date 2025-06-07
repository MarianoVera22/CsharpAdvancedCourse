using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedFunctionalPreogramming
{
    public static class Functions
    {
        public static string PipeStrings(string input, params Func<string, string>[] functions) {
            string result = input;

            foreach (var func in functions) {
                result = func(result);
            }

            return result;
        }

        public static T Pipe<T>(T input, params Func<T, T>[] functions)
        {
            T result = input;

            foreach (var func in functions)
            {
                result = func(result);
            }

            return result;
        }

        public static TResult P<TInput, TResult>(this TInput input, Func<TInput, TResult> func) {
            return func(input);
        }
    }
}
