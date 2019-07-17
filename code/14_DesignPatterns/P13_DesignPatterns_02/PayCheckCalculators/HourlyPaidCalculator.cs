using System;
using System.Linq;

namespace P13_DesignPatterns_03.PayCheckCalculators
{
    class HourlyPaidCalculator : IPayCheckCalculator
    {
        public decimal CalculatePay(Employee employee, DateTime startDate, DateTime endDate)
        {
            if (employee == null)
                throw new ArgumentNullException(nameof(employee));

            if (endDate < startDate)
                throw new ArgumentException(
                    $"{nameof(endDate)} < {nameof(startDate)}",
                    nameof(endDate));

            var workedHours = employee.WorkedTimes
                .Where(wt => startDate < wt.Date && wt.Date < endDate)
                .Sum(wt => wt.Hours);

            return workedHours * employee.HourlyRate;
        }
    }
}
