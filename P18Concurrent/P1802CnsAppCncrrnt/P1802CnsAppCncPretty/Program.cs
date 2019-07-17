using System;
using System.Diagnostics;
using System.Linq;
//using System.Timers;
using System.Threading;

namespace P1802CnsAppCncPretty
{
    class Program
    {
        static void Main(string[] args)
        {
            //bool rePlay = true;

            long n = 100_000_314; //100'000'314

            while (true)
            {
                GC.Collect(); // Forza il Garbage-Collector.

                bool sTIsPrime, dTIsPrime, mTIsPrime, mTPoolIsPrime;
                Stopwatch sTSW = new Stopwatch(), dTSW = new Stopwatch(), mTSW = new Stopwatch(), mTPoolSW = new Stopwatch();

                /*  « Stopwatch.StartNew(); » restituisce un nuovo StopWatch già partito.
                 *  Stopwatch.StartNew(); == new(); + start(); */
                #region singleThread
                sTSW.Reset();
                sTSW.Start();

                sTIsPrime = STIsPrime(n);

                sTSW.Stop();
                #endregion

                GC.Collect(); // Forza il Garbage-Collector.

                #region doubleThread
                dTSW.Reset();
                dTSW.Start();

                dTIsPrime = DTIsPrime(n);

                dTSW.Stop();
                #endregion

                GC.Collect(); // Forza il Garbage-Collector.

                #region multiThread
                mTSW.Reset();
                mTSW.Start();

                mTIsPrime = MTIsPrime(n, 7);

                mTSW.Stop();
                #endregion

                GC.Collect(); // Forza il Garbage-Collector.

                #region multiThread con threadPool
                mTPoolSW.Reset();
                mTPoolSW.Start();

                mTPoolIsPrime = MTPoolIsPrime(n, 7);

                mTPoolSW.Stop();
                #endregion

                Console.WriteLine($"n = {n.ToString()}");
                Console.WriteLine("Single thread:");
                Console.WriteLine($"∆t = {sTSW.ElapsedMilliseconds.ToString()}ms\t Il numero {n} {(sTIsPrime ? "E\'" : "Non")} primo.\n");
                Console.WriteLine("Double-thread:");
                Console.WriteLine($"∆t = {dTSW.ElapsedMilliseconds.ToString()}ms\t Il numero {n} {(dTIsPrime ? "E\'" : "Non")} primo.\n");
                Console.WriteLine("Multi-thread:");
                Console.WriteLine($"∆t = {mTSW.ElapsedMilliseconds.ToString()}ms\t Il numero {n} {(mTIsPrime ? "E\'" : "Non")} primo.\n");
                Console.WriteLine("Multi-thread con thread-pool:");
                Console.WriteLine($"∆t = {mTPoolSW.ElapsedMilliseconds.ToString()}ms\t Il numero {n} {(mTPoolIsPrime ? "E\'" : "Non")} primo.\n");

                Console.Write("Immettere \"q\" per uscire ... \a");
                //rePlay = (Console.ReadLine().ToLower() != "q") ? true : false;
                if (Console.ReadLine().ToLower() == "q") { return; }

                    Console.WriteLine();

                sTSW.Reset();
                dTSW.Reset();
                mTSW.Reset();


                n = (n + 1) * 10L + 1;

            }
        }

        static bool STIsPrime(long inNum)
        {
            bool isPrime = true;


            System.Timers.Timer tmr = new System.Timers.Timer
            {
                AutoReset = true,
                Interval = 25 //ms
            };
            tmr.Start();

            Console.Write("Loadin\' ...  ");


            for (int i = 2; i < inNum; i++)
            {
                if (inNum % i == 0)
                {
                    isPrime = false;
                    break;
                }
            }

            tmr.Stop();

            return isPrime;
        }

        /* Con due thread indipendenti, scritti singolaremente. */
        static bool DTIsPrime(long inNum)
        {
            bool isPrime = true;

            System.Timers.Timer tmr = new System.Timers.Timer
            {
                Interval = 25, //ms
                AutoReset = true
            };
            tmr.Start();

            Thread thread01 = new Thread(
                () =>
                {
                    for (long i = 2; i < inNum / 2L; i++)
                    {
                        if (inNum % i == 0)
                        {
                            isPrime = false;
                            break;
                        }
                    }
                    //return isPrime;
                });

            thread01.Start();

            Thread thread02 = new Thread(
                () =>
                {
                    for (long i = inNum / 2L; i < inNum; i++)
                    {
                        if (inNum % i == 0)
                        {
                            isPrime = false;
                            break;
                        }
                    }
                    //return isPrime;
                });

            thread02.Start();

            return isPrime;
        }

        static bool MTIsPrime(long inNum, int numberOfThreads)
        {
            bool isPrime = true;

            long rangePerThread = inNum / numberOfThreads;
            var threads = Enumerable
                .Range(0, numberOfThreads)
                .Select(thr => new Thread(
                    () =>
                    {
                    }
                    ));

            Console.WriteLine("L°ªd\'ng ...");

            for (int i = 1; i < inNum; i++)
            {
                if (inNum % i == 0)
                {
                    isPrime = false;
                    break;
                }
            }
            return isPrime;
        }

        static bool MTPoolIsPrime(long inNum, int numberOfThreads)
        {
            bool isPrime = true;

            long rangePerThread = inNum / numberOfThreads;
            var threads = Enumerable
                .Range(0, numberOfThreads)
                .Select(thr => new Thread(
                    () =>
                    {
                    }
                    ));

            Console.WriteLine("L°ªd\'ng ...");

            for (int i = 1; i < inNum; i++)
            {
                if (inNum % i == 0)
                {
                    isPrime = false;
                    break;
                }
            }
            return isPrime;
        }

        void Spinnin() => Console.Write(SpinninFix());

        string SpinninFix() { return "»"; }

        string STSpinnin(int cicle)
        {
            Console.Write("\b"); //backspace
            if ((cicle % 4) == 0) { return "|"; }
            else if ((cicle + 1 % 4) == 0) { return "\\"; }
            else if ((cicle + 2 % 4) == 0) { return "-"; }
            else if ((cicle + 3 % 4) == 0) { return "/"; }
            else { return "?"; }
        }

        string MTSpinnin(int cicle, int threads)
        {
            string bs = "";
            for (int i = 1; i <= threads; i++)
            {
                bs=bs+"\b\b"; //backspace
            }

            for (int i = 1; i <= threads; i++)
            {
                if ((cicle % 4) == 0) { return bs + "| "; }
                else if ((cicle + 1 % 4) == 0) { return bs + "\\ "; }
                else if ((cicle + 2 % 4) == 0) { return bs + "- "; }
                else if ((cicle + 3 % 4) == 0) { return bs + "/ "; }
                else { return " ?"; }
            }

            return " ?";
        }

        string STArrow(int cicle)
        {
            Console.Write("\b"); //backspace
            if ((cicle % 4) == 0) { return "»--->   "; }
            else if ((cicle + 1 % 11) == 0) { return " »--->  "; }
            else if ((cicle + 2 % 11) == 0) { return "  »---> "; }
            else if ((cicle + 3 % 11) == 0) { return "   »--->"; }
            else if ((cicle + 4 % 11) == 0) { return "    »---"; }
            else if ((cicle + 5 % 11) == 0) { return "     »--"; }
            else if ((cicle + 6 % 11) == 0) { return "      »-"; }
            else if ((cicle + 7 % 11) == 0) { return ">      »"; }
            else if ((cicle + 8 % 11) == 0) { return "->      "; }
            else if ((cicle + 9 % 11) == 0) { return "-->     "; }
            else if ((cicle + 10 % 11) == 0) { return "--->    "; }
            else { return "? ? ? ? "; }
        }
    }
}