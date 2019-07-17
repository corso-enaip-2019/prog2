using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* 20180328 */

namespace PrimeNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            //PrintFirstNPrimeNumbers(10);
            //
            //Console.WriteLine();

            //List<int> primeNumbers = new List<int>(ListFirstNPrimeNumbers(20));
            //List<int> primeNumbers = new List<int>(ListFirstNPrimeNumbers_v2(20));
            List<int> primeNumbers = new List<int>(ListFirstNPrimeNumbers_v2(AcquireUserSPositiveInt("Trova fino all\'n-esimo primo")));
            
            //foreach (int n in primeNumbers)
            //{ Console.WriteLine(n); }
            //
            //Console.WriteLine();

            foreach (int n in primeNumbers)
            {
                Console.Write(n.ToString().PadLeft(4));
                if (n < 60)
                { Console.WriteLine($" {"".PadRight(n, '*')}"); }
                else
                { Console.WriteLine($" {"".PadRight(62, '*')} ..."); }
            }
            //Console.WriteLine(n); 

            Console.ReadLine();

            return;
        }

        static bool IsPrime(int n)
        {
            if (n < 2)
            { return false; }

            if (n == 2)
            { return true; }

            //for (int i = 0; i < n / 2; i++)
            // E' sufficiente la radice quadrata.
            for (int i = 2; i < Math.Sqrt(n) + 1; i++)
            {
                if (n % i == 0)
                { return false; }
            }
            return true;
        }

        static void PrintIsPrime(int n)
        {
            bool isPrime = IsPrime(n);
            string s1 = isPrime ? "è" : "non è";
            Console.WriteLine($"Il numero {n} {s1} un numero primo.");

            return;
        }

        static void PrintFirstNPrimeNumbers(int n)
        {
            int max = n;

            for (int i = 2, primesFound = 0; primesFound < max; i++)
            {
                if (IsPrime(i))
                {
                    Console.WriteLine(i);
                    primesFound++;
                }
            }
            return;
        }

        static List<int> ListFirstNPrimeNumbers(int n)
        {
            List<int> outList = new List<int>();
            int max = n;

            for (int i = 2, primesFound = 0; primesFound < max; i++)
            {
                if (IsPrime(i))
                {
                    outList.Add(i);
                    primesFound++;
                }
            }
            return outList;
        }

        static List<int> ListFirstNPrimeNumbers_v2(int n)
        {
            List<int> outList = new List<int>();

            for (int i = 2; outList.Count < n; i++)
            {
                if (IsPrime(i))
                { outList.Add(i); }
            }
            return outList;
        }

        static int AcquireUserSPositiveInt(string message)
        {
            int outInt = 0;

            Console.Write($"{message}: \a");

            bool convertedNumber = false, isPositive = false;
            while (!convertedNumber && !isPositive)
            {
                convertedNumber = int.TryParse(Console.ReadLine(), out outInt);
                if (convertedNumber)
                { isPositive = outInt > 0; }
            }

            return outInt;
        }
    }
}