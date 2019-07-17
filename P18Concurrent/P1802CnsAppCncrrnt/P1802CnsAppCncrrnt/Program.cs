using System;

using System.Diagnostics;

namespace P1802CnsAppCncrrnt
{
    class Program
    {
        static void Main(string[] args)
        {
            bool rePlay = true;

            long n = 100_000_314; //100'000'314

            while (rePlay)
            {
                /*  « Stopwatch.StartNew(); » restituisce un nuovo StopWatch già partito.
                 *  Stopwatch.StartNew(); == new(); + start(); */
                var stpW = Stopwatch.StartNew();

                bool isPrime = true;

                Console.WriteLine("L°ªd\'ng ...");

                for (int i = 1; i < n - 1; i++)
                {
                    if (n % i == 0)
                    {
                        isPrime = false;
                        break;
                    }
                }

                stpW.Stop();

                Console.WriteLine($"{stpW.ElapsedMilliseconds.ToString()}ms");
                Console.WriteLine($"Il numero {n} {(isPrime ? "" : "non ")}è primo.");

                Console.Write("Immettere \"q\" per uscire ... \a");
                rePlay = (Console.ReadLine().ToLower() != "q") ? true : false;
                Console.WriteLine();

                n = (n+1) * 10L;
            }
        }
    }
}
