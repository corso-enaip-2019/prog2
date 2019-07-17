using P13_DesignPatterns_04;
using System;

namespace P13_DesignPatterns_04.PayCheckCalculators
{
    interface IPayCheckCalculator
    {
        decimal CalculatePay(Employee employee, DateTime startDate, DateTime endDate);
    }
}
