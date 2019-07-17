using System;
using System.Collections.Generic;
using PayDay_d.PayCheckCalculators;
using PayDay_d.PayDaySchedulers;

namespace PayDay_d

{
    class Employee
    {
        public Employee()
        {
            PayCheckCalculator = NullPayCalculator._Instance;

            /* Liste istanziate per evitare d'aggiungere oggetti ad una lista che è null (che non esiste). */
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

        public IPayCheckCalculator PayCheckCalculator { get; set; }
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