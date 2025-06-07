using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedFunctionalPreogramming
{
    public static class Memoization
    {
        public static Func<double, double> Pow(double pow)
        {
            var cache = new Dictionary<double, double>();

            return (number) =>
            {
                if (cache.ContainsKey(number))
                {
                    Console.WriteLine($"Ya existe {number}");
                    return cache[number];
                }

                Console.WriteLine($"No existe {number}");
                double total = Math.Pow(number, pow);
                cache[number] = total;
                return total;
            };
        }

        public static Func<int, Task<string>> GetUrl(string url)
        {
            var cache = new Dictionary<int, string>();

            return async (id) =>
            {
                if (cache.ContainsKey(id)) {
                    Console.WriteLine($"Ya existe {id}");
                    return cache[id];
                }

                Console.WriteLine($"No existe {id}");

                using (var client = new HttpClient())
                {
                    var requestURL = url + "/" + id;
                    var response = await client.GetAsync(requestURL);
                    var responseBody = await response.Content.ReadAsStringAsync();

                    cache[id] = responseBody;
                    return responseBody;
                }
            };
        }

        public static Func<TInput, TOutput> Mem<TInput, TOutput>(Func<TInput, TOutput> fn)
        {
            var cache = new Dictionary<TInput, TOutput>();
            return (key) =>
            {
                if (cache.ContainsKey(key))
                {
                    Console.WriteLine($"Ya existe {key}");
                    return cache[key];
                }

                Console.WriteLine($"No existe {key}");
                TOutput value = fn(key);
                cache[key] = value;
                return value;
            };
        }

        public static Func<TInput, Task<TOutput>> MemAsync<TInput, TOutput>(Func<TInput, Task<TOutput>> fn)
        {
            var cache = new Dictionary<TInput, TOutput>();

            return async (key) =>
            {
                if (cache.ContainsKey(key))
                {
                    Console.WriteLine($"Ya existe {key}");
                    return cache[key];
                }

                Console.WriteLine($"No existe {key}");
                TOutput value =await fn(key);
                cache[key] = value;
                return value;
            };
        }
    }
}
