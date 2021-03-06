﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test04FastPrimes
{
    static class FastPrime
    {
        static public bool IsPrime(int n)
        {
            if (n < 2)
                return false;

            for (int i = 2; i < Math.Sqrt(n); i++)
            {
                if (n % i == 0)
                    return false;
            }

            return true;
        }
    }
}