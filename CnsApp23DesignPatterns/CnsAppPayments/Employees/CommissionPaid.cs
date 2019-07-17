using System;
using System.Collections.Generic;
using System.Text;

namespace CnsAppPayments.Employees
{
    class CommissionPaid : IEmployee
    {
        #region Dall_interfaccia
        public int ID { get; }
        public string Name { get; }
        public string Surname { get; }

        public decimal CalculatePay()
        {
            return this.CommissionsOfToday;
        }

        /* Viene pagato ogni giorno. */
        public bool IsPayDay(DateTime day)
        { return true; }

        public bool IsPayDay_b(DateTime day)
        { return (day == DateTime.Today); }
        #endregion

        #region ctor
        public CommissionPaid()
        { }

        public CommissionPaid(int iD, string name, string surname)
        {
            ID = iD;
            Name = name;
            Surname = surname;
        }

        public CommissionPaid(int iD, string name, string surname, decimal commissionsOfToday)
        {
            ID = iD;
            Name = name;
            Surname = surname;
            CommissionsOfToday = commissionsOfToday;
        }
        #endregion

        public decimal CommissionsOfToday { get; set; }

        void ResetWorkedHours()
        { CommissionsOfToday = 0m; }
    }
}