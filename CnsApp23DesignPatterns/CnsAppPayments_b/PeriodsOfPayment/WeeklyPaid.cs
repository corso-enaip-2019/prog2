using System;
using System.Collections.Generic;
using System.Text;

namespace CnsAppPayments_b.TypesOfPayment
{
    class WeeklyPaid : PeriodOfPayment
    {
        public override string Name { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public override string Description { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public override IPayCalc CalculatePay(DateTime day)
        {
            throw new NotImplementedException();
        }

        public override IIsPayDay IsPayDay(DateTime day)
        {
            throw new NotImplementedException();
        }
    }
}
