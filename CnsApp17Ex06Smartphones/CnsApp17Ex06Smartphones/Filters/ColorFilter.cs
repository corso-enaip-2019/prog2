using System;
using System.Collections.Generic;
using System.Text;

namespace CnsApp17Ex06Smartphones.Filters
{
    class ColorFilter : IFilter<Smartphone>
    {
        public string Color { get; set; }

        public bool Filter(Smartphone sPh)
        {
            return sPh.Color.ToString().ToLower() == Color;
        }

        #region ctor
        public ColorFilter(string color) => Color = color.ToLower();
        #endregion
    }
}