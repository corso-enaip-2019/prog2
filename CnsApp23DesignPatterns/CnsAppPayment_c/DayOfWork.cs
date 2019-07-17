using System;
using System.Collections.Generic;
using System.Text;

namespace CnsAppPayment_c
{
    class DayOfWork
    {
        public DateTime WorkDay { get; set; }
        public Employee Worker { get; set; }
        public int workerID { get; set; }

        public PeriodOfPayment PeriodOfPay { get; set; }
        public TypeOfEmployment Employment { get; set; }
        public decimal ToPay { get; set; }
        public decimal? WorkedHours { get; set; }

        public string Annotations { get; set; }

        public DayOfWork(DateTime workDay, Employee worker, int workerID, PeriodOfPayment periodOfPay, TypeOfEmployment employment, decimal toPay, decimal? torkedHours, string annotations)
        { }
        public DayOfWork(DateTime workDay, Employee worker, PeriodOfPayment periodOfPay, TypeOfEmployment employment, decimal toPay, decimal? torkedHours, string annotations)
        { }
        public DayOfWork(DateTime workDay, int workerID, PeriodOfPayment periodOfPay, TypeOfEmployment employment, decimal toPay, decimal? torkedHours, string annotations)
        { }
    }
}