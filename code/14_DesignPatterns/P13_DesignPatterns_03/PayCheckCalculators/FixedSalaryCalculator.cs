using System;

namespace P13_DesignPatterns_03.PayCheckCalculators
{
    class FixedSalaryCalculator : BasePayCheckCalculator
    {
        protected override decimal CalculateAmount(Employee employee, DateTime startDate, DateTime endDate)
        {
            return employee.FixedSalary;
        }
    }
}
