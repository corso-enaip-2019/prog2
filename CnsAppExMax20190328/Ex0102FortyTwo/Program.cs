using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* 20190329 */
/* Done */

/* 1.2
 * 42 is the answer to all questions.
 * Read a number from the Console, and print on the Console if it is divisible by 42 or not. */

namespace Ex0102FortyTwo
{
    class Program
    {
        static void Main(string[] args)
        {
            const string INPUT_INVITE = "Immettere un numero (\"q\" per uscire): \a";
            const string OUTPUT_1 = "Il numero ";
            const string OUTPUT_2Y = "è";
            const string OUTPUT_2N = "NON è";
            const string OUTPUT_3 = " divisibile per ";


            while (true)
            {
                const int THE_NUMBER = 42;
                int inNumber = -314;
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

                string outString = "";

                /* √ = OUTPUT_2Y / × = OUTPUT_2N */
                outString = (inNumber % THE_NUMBER == 0) ? (OUTPUT_1 + OUTPUT_2Y + OUTPUT_3 + THE_NUMBER + ".") : (OUTPUT_1 + OUTPUT_2N + OUTPUT_3 + THE_NUMBER + ".");

                Console.WriteLine(outString);
                Console.WriteLine();
            }

            //return;
        }
    }
}