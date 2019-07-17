using System;
using System.Collections.Generic;
using System.Text;

/* Create a Smartphone class, with properties: Model, Version, Cost, Color. */

namespace CnsApp17Ex06Smartphones
{
    class Smartphone
    {
        public string Model { get; }
        public string Version { get; }
        public string Color { get; }
        public float Cost { get; set; }

        #region ctor
        public Smartphone()
        { }

        public Smartphone(string model, string version, string color, float cost)
        {
            Model = model;
            Version = version;
            Color = color.ToLower();
            Cost = cost;
        }
        #endregion
    }
}
