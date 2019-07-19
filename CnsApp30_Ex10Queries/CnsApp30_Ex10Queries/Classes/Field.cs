using System;
using System.Collections.Generic;
using System.Text;

namespace CnsApp30_Ex10Queries
{
    public class Field
    {
        public string Vegetable { get; set; }
        public int Extension { get; set; }

        public Field() { }

        public Field(string vegetable, int extension)
        {
            Vegetable = vegetable;
            Extension = extension;
        }
    }
}