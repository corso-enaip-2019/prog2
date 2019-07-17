using System;
using System.Text;

using System.Collections.Generic;
using System.Linq;

namespace StarWars1
{
    class Baby : Person
    {
        public string MumName;

        private List<Parent> _parents;
        private List<IComforter> _comforters;

        public Baby(string name)
            : base(name)
        {
            _parents = new List<Parent> { };

        }

        public void StartCrying()
        {
            Console.WriteLine($"{Name} ha cominciato a piangere in modo assordante! /a/a/a");

            if (_parents.Count>0)
            {
                foreach (Parent p in _parents.ToList())
                {
                    p.ComfortChild(this);
                }
            }
        }

        public void AddParent(Parent parent)
        {
            /* ??? */

        }

        public void RemoveParent(Parent parent)
        {
            _parents.Remove(parent);
        }

        public void AddComforter(Parent parent)
        {
            /* ??? */

        }

        public void RemoveComforter(Parent parent)
        {
            _parents.Remove(parent);
        }
    }
}