using System;
using System.Collections.Generic;
using System.Text;

namespace StarWars1
{
    class Dad : Person
    {
        public Baby Child { get; set; }

        public Dad(string name)
              : base(name)
        { }

        public void MakeBaby(Mum mum, string childName)
        {
            Baby b = new Baby(childName);
        }

        public void RemoveBaby(Baby baby)
        {
            //non è possibile connvertire da «StarWars1.Dad» a «StarWars1.Parent»
            //baby.RemoveParent(this);
        }


    }
}