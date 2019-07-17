using System;

/* 20190401 */
/* Done */

/* 2
 * Create a variable with a number of your choice.
 * Print the double and the triple of the number.
 * The numbers must be printed with adequate messages, concatenating strings and numbers. */

namespace Ex02DoubleTriple
{
    class Program
    {
        static void Main(string[] args)
        {
            const string INPUT_INVITE = "Immettere un numero (\"q\" per uscire): \a";
            const string OUTPUT_1_2X = "Il doppio ";
            const string OUTPUT_1_3X = "Il triplo ";
            const string OUTPUT_2 = "del numero ";
            const string OUTPUT_3 = " vale: ";

            while (true)
            {
                int inNumber = 0;
                bool converted = false;

                while (!converted)
                {
                    string inNumberStr = "";

                    Console.Write(INPUT_INVITE);

                    inNumberStr = Console.ReadLine();
                    converted = int.TryParse(inNumberStr, out inNumber);

                    if (inNumberStr == "q")
                    {
                        return;
                    }
                }

                Console.WriteLine(OUTPUT_1_2X + OUTPUT_2 + inNumber.ToString() + OUTPUT_3 + (2 * inNumber).ToString()+ ".");
                Console.WriteLine(OUTPUT_1_3X + OUTPUT_2 + inNumber.ToString() + OUTPUT_3 + (3 * inNumber).ToString() + ".");

                Console.WriteLine();
            }

            //return;
        }
    }
}