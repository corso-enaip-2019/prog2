using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CnsApp08Caffetteria.Toppings
{
    class CocoaPowder : ITopping
    {
        string _name = "CocoaPowder";
        string _code = "P";

        float _price = 0.13f;

        public string Name { get { return _name; } }
        public string Code { get { return _code; } }

        public float Price { get { return _price; } }
    }
}
