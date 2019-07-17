using System;

namespace P13_DesignPatterns_03.PayCheckCalculators
{
    class FixedSalaryCalculator : IPayCheckCalculator
    {
        public decimal CalculatePay(Employee employee, DateTime startDate, DateTime endDate)
        {
            if (employee == null)
                throw new ArgumentNullException(nameof(employee));

            if (endDate < startDate)
                throw new ArgumentException(
                    $"{nameof(endDate)} < {nameof(startDate)}",
                    nameof(endDate));

            return employee.FixedSalary;
        }
    }
}
