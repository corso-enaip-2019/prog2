using System;
using System.Collections.Generic;

namespace Recap5
{
    class Program
    {
        static void Main(string[] args)
        {
            // esercizio:
            // stampare i primi n numeri primi,
            // dove n è un numero chiesto all'utente.

            int howManyPrimes = AskCountToUser();

            List<int> primes = GetPrimeNumbers(howManyPrimes);

            PrintPrimeNumbers(primes);

            Console.Read();
        }

        private static int AskCountToUser()
        {
            Console.Write("Give me how many prime numbers you want: ");

            while(true)
            {
                string input = Console.ReadLine();
                bool succeed = int.TryParse(input, out int count);
                if (succeed && count > 0)
                    return count;
                Console.Write("The value is not a valid number. Re-enter: ");
            }
        }

        private static List<int> GetPrimeNumbers(int count)
        {
            List<int> primeList = new List<int>();

            for (int i = 2; primeList.Count < count; i++)
                if (IsPrime(i))
                    primeList.Add(i);

            return primeList;
        }

        private static void PrintPrimeNumbers(List<int> primes)
        {
            Console.WriteLine($"The first {primes.Count} prime numbers are:");

            //for (int i = 0; i < primes.Count; i++)
            //    Console.WriteLine(primes[i]);

            foreach (int prime in primes)
                Console.WriteLine(prime);
        }

        static bool IsPrime(int n)
        {
            if (n < 2)
                return false;

            for(int i = 2; i <= Math.Sqrt(n); i++)
                if (n % i == 0)
                    return false;

            return true;
        }
    }
}
