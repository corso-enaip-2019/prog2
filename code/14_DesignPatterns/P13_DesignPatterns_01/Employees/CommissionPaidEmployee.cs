using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P13_DesignPattern_01.Employees
{
    class CommissionPaidEmployee : Employee
    {
        public CommissionPaidEmployee()
        {
            _SoldCommissions = new List<SoldCommission>();
        }

        public int Percentage { get; set; }

        public IEnumerable<SoldCommission> SoldCommissions
        {
            get { return _SoldCommissions; }
        }
        private List<SoldCommission> _SoldCommissions;

        public void AddCommission(int year, int month, int day, decimal amount)
        {
            _SoldCommissions.Add(new SoldCommission(year, month, day, amount));
        }

        public override decimal CalculatePay(DateTime date)
        {
            var soldAmount = _SoldCommissions
                .Where(sc => sc.Date == date.Date)
                .Sum(sc => sc.Amount);

            return soldAmount * Percentage / 100;
        }

        public override bool IsPayDay(DateTime date)
        {
            return true;
        }

        public struct SoldCommission
        {
            public SoldCommission(int year, int month, int day, decimal amount)
                : this(new DateTime(year, month, day), amount)
            { }

            public SoldCommission(DateTime date, decimal amount)
            {
                Date = date;
                Amount = amount;
            }

            public decimal Amount { get; }
            public DateTime Date { get; }
        }
    }
}
