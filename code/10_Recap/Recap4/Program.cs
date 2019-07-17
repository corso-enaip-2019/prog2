using System;

namespace Recap4
{
    class Program
    {
        // *** ALERT ***
        // Questo programma NON è scritto bene:
        // 1) ha diverse duplicazioni che si possono evitare
        // 2) parte subito con i dettagli, nel Main, invece di usare
        //    un approccio top-down.
        // ESERCIZIO: rifattorizzare questo programma per migliorarne il design.

        static void Main(string[] args)
        {
            // chiesti due numeri interi all'utente,
            // stampare a console tutti i numeri triangolari in quel range.

            Console.WriteLine("*** TRIANGULAR NUMBERS IN RANGE ***");

            Console.Write("Inserire il limite inferiore del range: ");
            string string1 = Console.ReadLine();
            bool hasConverted1 = int.TryParse(string1, out int lower);
            bool isLowerGreaterThenZero = lower >= 0;
            while(!hasConverted1 || !isLowerGreaterThenZero)
            {
                Console.WriteLine("Il valore inserito non è un numero valido o è un numero minore di 0!");
                Console.Write("Re-inserire il valore: ");
                string1 = Console.ReadLine();
                hasConverted1 = int.TryParse(string1, out lower);
                if (hasConverted1)
                {
                    isLowerGreaterThenZero = lower >= 0;
                }
            }

            Console.Write("Inserire il limite superiore del range: ");
            string string2 = Console.ReadLine();
            bool hasConverted2 = int.TryParse(string2, out int upper);
            bool isUpperGreaterThanLower = upper >= lower;
            while (!hasConverted2 || !isUpperGreaterThanLower)
            {
                Console.WriteLine("Il valore inserito non è un numero valido o è un numero minore del limite inferiore!");
                Console.Write("Re-inserire il valore: ");
                string2 = Console.ReadLine();
                hasConverted2 = int.TryParse(string2, out upper);

                if (hasConverted2)
                {
                    isUpperGreaterThanLower = upper >= lower;
                }
            }

            int n = 1;
            int t = n * (n + 1) / 2;

            while (t < lower)
            {
                n++;
                t = n * (n + 1) / 2;
            }

            while (t <= upper)
            {
                Console.WriteLine(t);
                n++;
                t = n * (n + 1) / 2;
            }

            // si può risolvere anche con un for, ma diventa meno leggibile:

            //for (n = 1, t = n * (n+1) / 2; t < lower; n++, t = n * (n + 1) / 2)
            //{ }

            //for(; t <= upper; n++, t = n * (n + 1) / 2)
            //{
            //    Console.WriteLine(t);
            //}

            // in genere il for è usato per condizioni "note e regolari";
            // il while è più usato quando la condizione di uscita è più incerta
            // ("finché la condizione resta vera, continua, continua, continua...)

            Console.Read();
        }
    }
}
