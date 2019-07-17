using System;

namespace PayDay_d.PayCheckCalculators
{
    class FixedSalaryCalculator : BasePayCheckCalculator
    {
        protected override decimal CalculateAmount(Employee employee, DateTime startDate, DateTime endDate)
        {
            return employee.FixedSalary;
        }
    }
}