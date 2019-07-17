using System;
using System.Collections.Generic;
using System.Text;

namespace CnsAppPayment_c
{
    class Employee
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Annotations { get; set; }

        public decimal FixedPayment_perPeriod { get; set; }
        public decimal HourlyPayment_perHour { get; set; }
        public decimal Commission_Base { get; set; }
        public decimal Commission_VariablePart_perHour { get; set; }

        public Dictionary<DateTime, DayOfWork> RecordOf_WorkedDays { get; set; }

        public void AddAWorkedDayToRecord(DateTime day, PeriodOfPayment periodOfPay, TypeOfEmployment employment) { }
        public void AddAWorkedDayToRecord(DateTime day, PeriodOfPayment periodOfPay, TypeOfEmployment employment, decimal toPay, decimal? workedHours, String annotations) { }

        public bool CalcHisPayday(DateTime day) { return true; }

        #region ctor
        public Employee() { }
        public Employee(int iD, string name, string surname, string annotations) { }
        public Employee(int iD, string name, string surname, string annotations, decimal fixedPayment_perPeriod, decimal hourlyPayment_perHour, decimal commission_Base, decimal commission_VariablePart_perHour) { }
        #endregion
    }
}

