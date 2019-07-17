using System;
using System.Collections.Generic;
using System.Text;

namespace StarWars1
{
    abstract class Parent : Person, IComforter
    {
        public Baby Child { get; set; }

        public Parent(string name) : base(name)
        {
        }

        abstract public void ComfortChild(Baby baby);
    }
}
