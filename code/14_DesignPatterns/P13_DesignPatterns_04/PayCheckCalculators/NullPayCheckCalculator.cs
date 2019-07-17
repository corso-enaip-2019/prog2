using System;

namespace P13_DesignPatterns_04.PayCheckCalculators
{
    class NullPayCheckCalculator : IPayCheckCalculator
    {
        static NullPayCheckCalculator()
        {
            Instance = new NullPayCheckCalculator();
        }

        public static NullPayCheckCalculator Instance { get; }

        private NullPayCheckCalculator() { }

        public decimal CalculatePay(Employee employee, DateTime startDate, DateTime endDate)
        {
            return 0;
        }
    }
}
