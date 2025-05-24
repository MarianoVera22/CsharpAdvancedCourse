using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generics
{
    public class Drink
    {
        private double _quantity;

        public double Quantity {
            get => _quantity;
        }

        public Drink(double quantity) {
            _quantity = quantity;
        }
    }
}
