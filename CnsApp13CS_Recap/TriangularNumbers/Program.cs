using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* 20180328 */
/* Dati due in n ed m (che rappresentano i limiti del range voluto), stampare a console tutti i "numeri triangolari"¹ presenti in quel range. */
/* ¹Un "numero triangolare" è un numero della serie composta dalla successione di somme del tipo 1+2+3+4+5+... .
 * Per avere il p-esimo numero triangolare,
 * - si può usare la ricorsività per come sono definiti i numeri triangolari: 1+2+3+...+p.
 * - si può sfruttare la caratteristica² che dato un numero p, il p-esimo numero è (p*(p+1))/2 .*/
/* ²Costruire il "triangolo" dei numeri triangolare, fermandosi alla riga p-esima, affiancargli a destra un triangolo capovolto (la prima riga avrà il primo •, gli sarà affiancata una serie di p*•; l'ultima riga (la p-esima) avrà p*• afficancata da )*/


namespace CnsApp12TriangularNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            LimitsAcquisition(out int lowerLimit, out int upperLimit);

            Console.WriteLine();
            Console.WriteLine($"Limite inferiore:\t{lowerLimit}");
            Console.WriteLine($"Limite superiore:\t{upperLimit}");

            CalculateAndShowTriangularNumbersBetweenLimits(lowerLimit, upperLimit);

            Console.ReadLine();
            return;
        }

        static void LimitsAcquisition(out int lowerLimit, out int upperLimit)
        {
            lowerLimit = 0;
            upperLimit = 0;

            const string INVITO = "Immttere il limite";
            bool hasConverted = false;

            /* Acquisizione limite inferiore. */
            hasConverted = false;
            bool isPositive = false;
            while (!hasConverted || !isPositive)
            {
                Console.Write(INVITO + " inferiore: \a");

                hasConverted = int.TryParse(Console.ReadLine(), out lowerLimit);

                if (hasConverted)
                { isPositive = lowerLimit > 0; }
            }

            Console.WriteLine();

            /* Acquisizione limite superiore. */
            hasConverted = false;
            bool upperLimitIsLessThanLowerLimit = true;
            while (!hasConverted || upperLimitIsLessThanLowerLimit)
            {
                Console.Write(INVITO + $" superiore (maggiore od uguale a {lowerLimit}): \a");
                hasConverted = int.TryParse(Console.ReadLine(), out upperLimit);

                if (hasConverted)
                { upperLimitIsLessThanLowerLimit = upperLimit < lowerLimit; }
            }

            return;
        }

        static int CalculateTriangular_nth_Number(int baseNumber)
        {
            /* nth_triangularNumber = (n(n+1))/2 */
            int triangularNumber = (baseNumber * (baseNumber + 1)) / 2;

            return triangularNumber;
        }

        static void CalculateAndShowTriangularNumbersBetweenLimits(int loLimit, int hiLimit)
        {
            int n = 1;
            int triangularNumber = CalculateTriangular_nth_Number(n);

            /* Per trovare la "base del numero triangolare" con il numero triangolare più vicino al limte inferiore (però dentro al range). */
            while (triangularNumber < loLimit)
            {
                n++;
                triangularNumber = CalculateTriangular_nth_Number(n);
            }

            while (triangularNumber < hiLimit)
            {
                Console.Write(triangularNumber);
                Console.Write("\t");

                n++;
                triangularNumber = CalculateTriangular_nth_Number(n);
            }

            return;
        }
    }
}