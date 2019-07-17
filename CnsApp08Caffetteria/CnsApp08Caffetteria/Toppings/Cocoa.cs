using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CnsApp08Caffetteria.Toppings
{
    class Cocoa:ITopping
    {
        string _name = "Cocoa";
        string _code = "C";

        float _price = 0.50f;

        public string Name { get { return _name; } }
        public string Code { get { return _code; } }

        public float Price { get { return _price; } }
    }
}
