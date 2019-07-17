using System;
using System.Linq;

namespace P13_DesignPatterns_03.PayCheckCalculators
{
    class CommissionPayCalculator : IPayCheckCalculator
    {
        public decimal CalculatePay(Employee employee, DateTime startDate, DateTime endDate)
        {
            if (employee == null)
                throw new ArgumentNullException(nameof(employee));

            if (endDate < startDate)
                throw new ArgumentException(
                    $"{nameof(endDate)} < {nameof(startDate)}",
                    nameof(endDate));

            var soldAmount = employee.SoldCommissions
                .Where(sc => startDate < sc.Date && sc.Date < endDate)
                .Sum(sc => sc.Amount);

            return soldAmount * employee.CommissionPercentage / 100;
        }
    }
}
