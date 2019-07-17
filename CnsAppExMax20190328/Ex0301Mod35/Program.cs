using System;

/* 20190403 */

/* 3.1
 * Print all the numbers divisible by 3 and 5, from 1 to 100.
 * Print all the numbers divisible by 3 or 5, from 1 to 100.
 * Print the first 100 numbers that are divisible by 3 or 5. */

/* /!\ NON SO PERCHE',MA NEL 1°-100° ENTRA SEMPRE NELL'IF /!\ */

namespace Ex0301Mod35
{
    class Program
    {
        static void Main(string[] args)
        {
            bool rePlay = true;
            while (rePlay)
            {
                const string INTRO_3AND5_1TO100 = "Numeri divisibili per 3 E per 5, da 1 a 100:";
                const string INTRO_3OR5_1TO100 = "Numeri divisibili per 3 O per 5, da 1 a 100:";
                const string INTRO_3OR5_1ST_100_NUMBERS_ = "PRIMI 100 numeri divisibili per 3 O per 5:";

                const string OUTSTR1 = " - Il numero ";
                const string OUTSTR2 = " è divisibile per ";
                const string OUTSTR3_3AND5 = "3 e 5.";
                const string OUTSTR3_3OR5 = "3 o 5.";
                const string OUTSTR3_3OR5_1ST_100_NUMBERS = "3 o 5.";



                /* 3&5, 1-100 */
                Console.WriteLine(INTRO_3AND5_1TO100);
                for (int i = 1; i <= 100; i++)
                {
                    if ((i % 3 == 0) && (i % 5 == 0))
                    {
                        Console.WriteLine(OUTSTR1 + i + OUTSTR2 + OUTSTR3_3AND5);
                    }
                }

                Console.ReadLine();

                /* 3||5, 1-100 */
                Console.WriteLine(INTRO_3OR5_1TO100);
                for (int i = 1; i <= 100; i++)
                {
                    if ((i % 3 == 0) || (i % 5 == 0))
                    {
                        Console.WriteLine(OUTSTR1 + i + OUTSTR2 + OUTSTR3_3OR5);
                    }
                }

                Console.ReadLine();

                /*  3||5, 1°-100° */
                Console.WriteLine(INTRO_3OR5_1ST_100_NUMBERS_);
                /* j = n° da testare, k = n-esimo n° trovato. */
                int j = 1, k = 1;
                while (k <= 100)
                {
                    if ((j % 3 == 0) || (j % 5 == 0))
                    {
                        Console.WriteLine(OUTSTR1 + k + OUTSTR2 + OUTSTR3_3OR5 + $" ({k}° numero)");
                        k++;
                    }
                    else
                    {
                    }

                    j++;
                }

                rePlay = false;
            }

            Console.ReadLine();
        }
    }
}