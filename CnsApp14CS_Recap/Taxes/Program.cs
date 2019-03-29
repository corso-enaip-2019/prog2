using System;

namespace Taxes
{
    class Program
    {
        static void Main(string[] args)
        {
            string mode = "?";

            while (mode != "quit")
            {
                mode = AskMode();

                switch (mode.ToLower())
                {
                    case "ln":
                    case "long":
                        { break; }
                    default:
                        break;
                }
            }

            Console.ReadLine();
            return;
        }

        static string AskMode()
        {
            string selectedMode ="?";

            Console.WriteLine("Immettere la modalità voluta fra:");
            Console.WriteLine(" fatt \t Aggiungi fattura a P.IVA;");
            Console.WriteLine(" spesa \t Aggiungi spesa a P.IVA;");
            Console.WriteLine(" calc \t Calcola guadagno netto e tasse totali;");
            Console.WriteLine(" mod \t Modifica P.IVA;");
            Console.WriteLine();
            Console.WriteLine(" q \t Esci.");

            selectedMode = AskForAString("Modalità:", "Stringa non valida.");

            return selectedMode;
        }

        static string AskForAString(string message, string errMessage)
        {
            string outStr = "";

            bool sensed = false;
            while (!sensed)
            {
                Console.Write(message + " \a");
                outStr = Console.ReadLine();
                sensed = (outStr == null || outStr == "") ? false : true;
                if (!sensed)
                { Console.WriteLine(errMessage); }
                Console.WriteLine();
            }

            return outStr;
        }

        static decimal AskForAPositiveDecimal(string message, string errMessage)
        {
            decimal outDec = -3.14m;

            bool converted = false, positive = false;
            while (!converted)
            {
                Console.Write(message + " \a");
                string inStr = Console.ReadLine();

                while (!converted || !positive)
                {
                    positive = false;

                    decimal.TryParse(inStr, out outDec);
                    converted = (outDec <= 0) ? false : true;

                    if (!converted)
                    { Console.WriteLine(errMessage); }
                    else
                    { positive = (outDec > 0) ? true : false; }
                    Console.WriteLine();
                }
            }

            return outDec;
        }
    }
}
