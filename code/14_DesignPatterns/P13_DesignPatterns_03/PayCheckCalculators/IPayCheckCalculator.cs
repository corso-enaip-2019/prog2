using P13_DesignPatterns_03;
using System;

namespace P13_DesignPatterns_03.PayCheckCalculators
{
    interface IPayCheckCalculator
    {
        decimal CalculatePay(Employee employee, DateTime startDate, DateTime endDate);
    }
}
