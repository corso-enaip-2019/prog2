using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;


namespace Test03BetterPrimes
{
    static class BetterPrimeCalculator
    {
        static public bool IsPrime(int n)
        {
            if (n < 0)
                throw new ArgumentException("Not a natural number.");

            if (n <= 1)
                return false;

            for (int i = 2; i < Math.Sqrt(n); i++)
            {
                if (n % i == 0)
                {
                    return false;
                }
            }

            return true;
        }
    }
}