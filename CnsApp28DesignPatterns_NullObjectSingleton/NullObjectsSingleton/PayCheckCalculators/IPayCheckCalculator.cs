using PayDay_d;
using System;

namespace PayDay_d.PayCheckCalculators
{
    interface IPayCheckCalculator
    {
        decimal CalculatePay(Employee employee, DateTime startDate, DateTime endDate);
    }
}