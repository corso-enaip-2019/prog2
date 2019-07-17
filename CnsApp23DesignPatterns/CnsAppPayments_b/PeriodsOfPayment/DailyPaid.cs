using System;
using System.Collections.Generic;
using System.Text;

namespace CnsAppPayments_b.TypesOfPayment
{
    class DailyPaid : PeriodOfPayment
    {
        public override string Name { get; set; }
        public override string Description { get; set; }

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
