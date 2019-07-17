using DepInvCon_Contracts;
using System;

namespace DevInvCon_MathSlow
{
    public class PrimeCalculator : IMath
    {
        public PrimeCalculator() { }

        public PrimeCalculator(string name)
        {
            Name = name;
        }

        public string Name { get; }

        public bool IsPrime(int number)
        {
            if (number < 2)
                return false;

            for(int i = 2; i < number; i++)
                if (number % i == 0)
                    return false;

            return true;
        }
    }
}
