using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedFunctionalPreogramming
{
    public static class ListExtensions
    {
        public static List<TOutput> Map<TInput, TOutput>(this List<TInput> lst,
            Func<TInput, TOutput> fn)
        {
            List<TOutput > lstResult = new List<TOutput>();

            foreach (TInput item in lst) {
                TOutput result = fn(item);
                lstResult.Add(result);
            }

            return lstResult;
        }

        public static List<T> Filter<T>(this List<T> lst, Func<T, bool> fn) {
            List<T> lstResult = new List<T>();

            foreach (T item in lst) {
                if (fn(item)) {
                    lstResult.Add(item);
                }
            }

            return lstResult;
        }

        public static TOutput Reduce<TInput, TOutput>(this List<TInput> lst,Func<TOutput, TInput, TOutput> fn, TOutput initialValue) {
            TOutput result = initialValue;

            foreach (TInput item in lst) {
                result = fn(result, item);
            }

            return result;
        }
    }
}
