using P13_DesignPatterns_04.PayCheckCalculators;
using P13_DesignPatterns_04.PayDaySchedulers;
using System;
using System.Collections.Generic;

namespace P13_DesignPatterns_04
{
    class Employee
    {
        public Employee()
        {
            PayCheckCalculator = NullPayCheckCalculator.Instance;

            _WorkedTimes = new List<WorkedTime>();
            _SoldCommissions = new List<SoldCommission>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public decimal FixedSalary { get; set; }
        public decimal HourlyRate { get; set; }
        public decimal CommissionPercentage { get; set; }

        public IEnumerable<WorkedTime> WorkedTimes
        {
            get { return _WorkedTimes; }
        }
        private readonly List<WorkedTime> _WorkedTimes;

        public IEnumerable<SoldCommission> SoldCommissions
        {
            get { return _SoldCommissions; }
        }
        private readonly List<SoldCommission> _SoldCommissions;

        public IPayCheckCalculator PayCheckCalculator
        {
            get { return _PayCheckCalculator; }
            set
            {
                if (value == null)
                    value = NullPayCheckCalculator.Instance;

                _PayCheckCalculator = value;
            }
        }
        private IPayCheckCalculator _PayCheckCalculator;

        public IPayDayScheduler PayDayScheduler { get; set; }

        public void AddWorkedHours(int year, int month, int day, int workedHours)
        {
            _WorkedTimes.Add(new WorkedTime(year, month, day, workedHours));
        }

        public void AddCommission(int year, int month, int day, decimal amount)
        {
            _SoldCommissions.Add(new SoldCommission(year, month, day, amount));
        }

        public bool IsPayDay(DateTime date)
        {
            return PayDayScheduler.IsPayDay(date);
        }

        public decimal CalculatePay(DateTime date)
        {
            var interval = PayDayScheduler.GetPayInterval(date);
            return PayCheckCalculator.CalculatePay(this, interval.Start, interval.End);
        }
    }
}
