using System;

namespace Recap2
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] array = new char[4];
            array[0] = 'c';
            array[1] = 'i';
            array[2] = 'a';
            array[3] = 'o';

            Console.WriteLine((object)array);

            string hello = "ciao";
            // una stringa è un array di caratteri readonly,
            // la seguente riga dà errore:
            //hello[0] = 'C';

            for(int index = 0; index < hello.Length; index++)
            {
                // posso accedere al singolo carattere in lettura:
                Console.WriteLine(hello[index]);
            }

            while(true)
            {
                Console.Write("Insert a string: ");
                string input = Console.ReadLine();
                //bool isPalindrome = IsPalindromeWithCycle(input);
                bool isPalindrome = IsPalindromeRecursive(input);
                if (isPalindrome)
                    Console.WriteLine("La stringa è palindroma");
                else
                    Console.WriteLine("La stringa non è palindroma");
            }

            Console.Read();
        }

        private static bool IsPalindromeWithCycle(string input)
        {
            // for con 2 variabili
            //for (int i = 0, j = input.Length - 1; i < j; i++, j--)
            //    if (input[i] != input[j])
            //        return false;

            // for con 1 variabile ma più calcoli
            for (int i = 0; i < input.Length / 2; i++)
                if (input[i] != input[input.Length - i - 1])
                    return false;

            return true;
        }

        private static bool IsPalindromeRecursive(string input)
        {
            //if (input.Length == 0 || input.Length == 1)
            if (input.Length < 2)
                return true;

            if (input[0] != input[input.Length - 1])
                return false;

            string newInput = input.Substring(1, input.Length - 2);

            return IsPalindromeRecursive(newInput);
        }
    }
}
