using System;
using System.Collections.Generic;
using System.Text;

namespace P15_Tests_02_PrimeNumbers
{
    static class MathUtilities
    {
        public static bool IsPrime(int n)
        {
            if (n < 2)
                return false;

            var sqrt = Math.Sqrt(n);

            for (int i = 2; i <= sqrt; i++)
                if (n % i == 0)
                    return false;

            return true;
        }
    }
}
