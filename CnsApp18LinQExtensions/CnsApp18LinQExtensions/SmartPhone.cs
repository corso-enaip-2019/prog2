using System;
using System.Collections.Generic;
using System.Text;

namespace CnsApp18LinQExtensions
{
    class SmartPhone
    {
        public string Model { get; }
        public string Version { get; }
        public string Color { get; }
        public float Cost { get; set; }

        #region ctor
        public SmartPhone()
        { }

        public SmartPhone(string model, string version, string color, float cost)
        {
            Model = model;
            Version = version;
            Color = color.ToLower();
            Cost = cost;
        }
        #endregion
    }
}