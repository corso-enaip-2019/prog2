using System;
using System.Collections.Generic;
using System.Text;

namespace CnsAppPayments_b
{
    abstract class Employee
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }

        public Dictionary<DateTime, decimal> RecordOf_Day_WorkedHours { get; set; }
        public Dictionary<DateTime, decimal> RecordOf_Day_FixedAmountOf { get; set; }

        public TypeOfEmployment Employment { get; set; }
        public PeriodOfPayment Payment { get; set; }

        public abstract IIsPayDay IsPayDay();
        public abstract IPayCalc PayCalculator();
    }
}