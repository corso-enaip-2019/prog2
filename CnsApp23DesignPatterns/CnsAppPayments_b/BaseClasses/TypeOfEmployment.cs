using System;
using System.Collections.Generic;
using System.Text;

namespace CnsAppPayments_b
{
    abstract class TypeOfEmployment
    {
        public abstract string Name { get; set; }
        public abstract string Description { get; set; }

        public abstract IPayCalc CalculatePay(DateTime day);
    }
}
