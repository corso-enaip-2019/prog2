using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CnsApp08Caffetteria.Toppings
{
    class GenericTopping : ITopping
    {

        public string Name { get; }
        public string Code { get; }
        public float Price { get; }

        public GenericTopping(string inName, string inCode, float inPrice)
        {
            Name = inName;
            Code = inCode;
            Price = inPrice;
        }
    }
}
