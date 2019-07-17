using System;

using System.Collections.Generic;
using System.Text;


namespace CnsAppPayments.Employees
{
    class FixedSalary : IEmployee
    {
        #region Dall_interfaccia
        public int ID { get; }
        public string Name { get; }
        public string Surname { get; }

        public decimal CalculatePay()
        {
            return MonthlyPay;
        }

        /* Viene pagato ogni fine-mese. */
        public bool IsPayDay(DateTime day)
        { return Utilities.UtilDateTime.IsThisDayLastDayOfMonth(day); }

        public bool IsPayDay_b(DateTime day)
        { return (day.Month == DateTime.DaysInMonth(day.Year, day.Month)); }
        #endregion

        public decimal MonthlyPay { get; }

        #region ctor
        public FixedSalary()
        { }

        public FixedSalary(int iD, string name, string surname, decimal monthlyPay)
        {
            ID = iD;
            Name = name;
            Surname = surname;
            MonthlyPay = monthlyPay;
        }
        #endregion
    }
}