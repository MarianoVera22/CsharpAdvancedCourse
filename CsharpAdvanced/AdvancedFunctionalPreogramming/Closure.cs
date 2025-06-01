using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedFunctionalPreogramming
{
    public static class Closure
    {
        public static Func<int, int, int> SumClosure() {
            int i = 0;
            return (a,b) =>{
                i++;
                Console.WriteLine(i);
                return a + b;
            };
        }

        public static Action DelayExecutor(int time, Action fn) {
            return () =>
            {
                Console.WriteLine("Antes del delay");
                Thread.Sleep(time);
                fn();
                Console.WriteLine("Despues del delay");
            };
        }
    }

}
