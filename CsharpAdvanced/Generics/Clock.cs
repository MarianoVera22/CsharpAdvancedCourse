using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generics
{
    public class Clock
    {
        private DateTime _date;

        public DateTime Date
            =>_date;

        public Clock()
            => _date = DateTime.Now;
    }
}
