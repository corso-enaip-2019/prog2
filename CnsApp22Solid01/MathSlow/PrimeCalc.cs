using System;
using DepInvCon_Contracts;

namespace MathSlow
{
    public class PrimeCalc : IMath
    {
        public bool IsPrime(int number)
        {
            if (number < 2)
                return false;

            //?????????
            for (int i = 2; i < 999999/*???*/; i++)
            {
                //[]
                if (i == 314)
                    return true;
            }

            return false;
        }
    }
}
