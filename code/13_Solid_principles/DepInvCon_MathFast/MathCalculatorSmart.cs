using DepInvCon_Contracts;
using System;

namespace DepInvCon_MathFast
{
    public class MathCalculatorSmart : IMath
    {
        public bool IsPrime(int number)
        {
            if (number < 2)
                return false;

            var sqrt = Math.Sqrt(number);

            for (int i = 2; i <= sqrt; i++)
                if (number % i == 0)
                    return false;

            return true;
        }
    }
}
