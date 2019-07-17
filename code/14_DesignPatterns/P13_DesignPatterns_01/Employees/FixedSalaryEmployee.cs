using System;
using System.Collections.Generic;
using System.Text;

namespace P13_DesignPattern_01.Employees
{
    class FixedSalaryEmployee : Employee
    {
        public decimal Salary { get; set; }

        public override decimal CalculatePay(DateTime date)
        {
            return Salary;
        }

        public override bool IsPayDay(DateTime date)
        {
            // prima soluzione, che è un po' un "hack".
            //if (dt.Day == new DateTime(dt.Year, dt.Month + 1, 1).AddDays(-1).Day)
            //{ }

            return date.Day == DateTime.DaysInMonth(date.Year, date.Month);
        }
    }
}
