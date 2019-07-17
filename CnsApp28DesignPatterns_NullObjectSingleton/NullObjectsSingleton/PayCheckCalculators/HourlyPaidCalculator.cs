using System;
using System.Linq;

namespace PayDay_d.PayCheckCalculators
{
    class HourlyPaidCalculator : BasePayCheckCalculator
    {
        protected override decimal CalculateAmount(Employee employee, DateTime startDate, DateTime endDate)
        {
            var workedHours = employee.WorkedTimes
                .Where(wt => startDate < wt.Date && wt.Date < endDate)
                .Sum(wt => wt.Hours);

            return workedHours * employee.HourlyRate;
        }
    }
}