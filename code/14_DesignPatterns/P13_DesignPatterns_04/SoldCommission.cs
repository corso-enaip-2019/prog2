using System;

namespace P13_DesignPatterns_04
{
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
