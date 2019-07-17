using System;
using System.Collections.Generic;
using System.Text;

namespace CnsApp17Ex06Smartphones.Filters
{
    class CostLessFilter : IFilter<Smartphone>
    {
        public float MaxPrice { get; set; }

        public bool Filter(Smartphone sPh)
        {
            return sPh.Cost <= MaxPrice;
        }

        #region ctor
        public CostLessFilter(float maxPrice) => MaxPrice = maxPrice;
        #endregion
    }
}