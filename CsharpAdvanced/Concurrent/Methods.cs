using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Concurrent
{
    public static class Methods
    {
        public static async Task Wait(int miliseconds)
        {
            Console.WriteLine("Comienza la espera");
            await Task.Delay(miliseconds);
            Console.WriteLine("Termina la espera");
        }

        public static async Task<double> AddAsync(double number1, double number2)
        {
            await Task.Delay(1000);
            return number1 + number2;
        }
    }
}
