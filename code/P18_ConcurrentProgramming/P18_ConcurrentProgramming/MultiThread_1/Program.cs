using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MultiThread_1
{
    class Program
    {
        static void Main(string[] args)
        {
            //calculateIsPrime(1_000_000_087, isPrimeSingleThread);
            //calculateIsPrime(1_000_000_087, isPrimeDoubleThread);
            //calculateIsPrime(1_000_000_088, isPrimeDoubleThread);
            //calculateIsPrime(10_510_100_501, isPrimeDoubleThread);

            var threadCount = 16;

            //calculateIsPrime(1_000_000_087, n => isPrimeMultiThread(n, threadCount));
            //calculateIsPrime(1_000_000_088, n => isPrimeMultiThread(n, threadCount));
            //calculateIsPrime(10_510_100_501, n => isPrimeMultiThread(n, threadCount));

            calculateIsPrime(1_000_000_087, n => isPrimeThreadPool(n, threadCount));
            calculateIsPrime(1_000_000_088, n => isPrimeThreadPool(n, threadCount));
            calculateIsPrime(10_510_100_501, n => isPrimeThreadPool(n, threadCount));

            
            Console.Read();
        }

        private static void calculateIsPrime(long n, Func<long, bool> isPrimeFunc)
        {
            Console.Write($"Calculating if {n:#,#} is prime");
            var t = new System.Timers.Timer(500);
            t.Elapsed += (s, e) => { Console.Write("."); };
            t.AutoReset = true;
            t.Start();
            var sw = Stopwatch.StartNew();
            var isPrime = isPrimeFunc(n);
            sw.Stop();
            t.Stop();
            Console.WriteLine();
            Console.WriteLine($"{n:#,#} is {(isPrime ? "" : "not ")}prime; time: {sw.ElapsedMilliseconds} ms");
        }

        private static bool isPrimeSingleThread(long n)
        {
            for (long i = 2; i < n; i++)
                if (n % i == 0)
                    return false;

            return true;
        }

        private static bool isPrimeDoubleThread(long n)
        {
            var midPoint = n / 2;

            var isPrime = true;

            var t1 = new Thread(() => {
                for (long i = 2; i < midPoint; i++) {
                    if (!isPrime) {
                        break;
                    }
                    if (n % i == 0) {
                        isPrime = false;
                        break;
                    }
                }
            });
            t1.Start();

            var t2 = new Thread(() => {
                for (long i = midPoint; i < n - 1; i++) {
                    if (!isPrime) {
                        break;
                    }
                    if (n % i == 0) {
                        isPrime = false;
                        break;
                    }
                }
            });
            t2.Start();

            t1.Join();
            t2.Join();

            return isPrime;
        }

        private static bool isPrimeMultiThread(long n, int threadCount)
        {
            var range = n / threadCount;

            var isPrime = true;

            var threads = Enumerable
                .Range(0, threadCount)
                .Select(t => new Thread(() =>
                    {
                        for (long i = Math.Max(2, range * t); i < (range * (t+1)) - 1; i++)
                        {
                            if (!isPrime)
                            {
                                break;
                            }
                            if (n % i == 0)
                            {
                                isPrime = false;
                                break;
                            }
                        }
                    }))
                .ToList();

            foreach (var t in threads)
                t.Start();

            foreach (var t in threads)
                t.Join();

            return isPrime;
        }

        private static bool isPrimeThreadPool(long n, int threadCount)
        {
            var range = n / threadCount;

            var isPrime = true;

            using (var cde = new CountdownEvent(threadCount))
            {
                Enumerable
                    .Range(0, threadCount)
                    .ToList()
                    .ForEach(t => {
                        ThreadPool.QueueUserWorkItem(_ => {
                            for (long i = Math.Max(2, range * t); i < (range * (t + 1)) - 1; i++) {
                                if (!isPrime) {
                                    cde.Signal();
                                    return;
                                }
                                if (n % i == 0) {
                                    isPrime = false;
                                    cde.Signal();
                                    return;
                                }
                            }
                            cde.Signal();
                        });
                    });

                cde.Wait();
            }

            return isPrime;
        }
    }
}
