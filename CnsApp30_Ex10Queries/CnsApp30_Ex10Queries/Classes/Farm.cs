using System;
using System.Collections.Generic;
using System.Text;

namespace CnsApp30_Ex10Queries
{
    public class Farm
    {
        public string Owner { get; set; }
        public List<Field> Fields { get; set; }

        public Farm() { }

        public Farm(string owner, List<Field> fields)
        {
            Owner = owner;
            Fields = fields;
        }
    }
}