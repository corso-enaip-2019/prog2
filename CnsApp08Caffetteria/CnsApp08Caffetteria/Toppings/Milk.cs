using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CnsApp08Caffetteria.Toppings
{
    class Milk : ITopping
    {
        string _name = "Milk";
        string _code = "M";

        float _price = 0.25f;

        public string Name { get {return _name; } }
        public string Code { get { return _code; } }

        public float Price { get { return _price; } }
    }
}
