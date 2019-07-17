using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CnsApp08Caffetteria
{
    interface ITopping
    {
        string Name { get; }
        string Code { get; }
        float Price { get; }
    }
}