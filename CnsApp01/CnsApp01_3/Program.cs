using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* 20180304 - 2 */
/* Controllo traiangolo ed "aggiustamento". */
/* Esempio con cicli ed array. */

namespace CnsApp01_3
{
    /* Controllare se i tre numeri/lati immessi dall'utente corrispondano alle seguenti regole:
     * a>b+c   b>a+c   c>a+b   a>|b-c| 
     * Se sono tutte valide _contemporaneamente_, sarà un triangolo.
     * Se non è un triangolo, trovare i dati più vicini per un triangolo valido.
     * [Per ora ... Riduci il più lungo.] */

    class Program
    {
        static void Main(string[] args)
        {

            #region Dichiarazione variabili
            string[] ordinale = { "zero", "primo", "secondo", "terzo" };
            string esitoFinale;

            // Lati
            int[] TriangoloLato = new int[3];
            #endregion

            #region Fase d'immissione dati
            for (int i = 0; i < 3; i++)
            {
                TriangoloLato[i] = AskAndCheckNumber($"Inserisci il {ordinale[i + 1]} lato:\t\a");
            }
            #endregion

            #region Controllo se triangolo piu eventuale modifica
            /* Controllo se è un triangolo ed eventualmente creazione d'uno nuovo */
            if (IsATriangle(TriangoloLato))
            {
                esitoFinale = "E\' un triangolo.";
            }
            else
            {
                esitoFinale = "Non è un triangolo.";
                TriangoloLato = SearchForValidTriangleFromBadOne(TriangoloLato);
                esitoFinale = $"{esitoFinale}\nUn triangolo \"vicino\" è: {TriangoloLato[0]}, {TriangoloLato[1]} e {TriangoloLato[2]}.";
            }
            #endregion

            #region Output
            Console.WriteLine(esitoFinale);
            Console.ReadLine();
            #endregion
        }

        /// <summary>
        /// Genera tre lati di un nuovo triangolo partendo da uno con i lati "sbagliati".
        /// </summary>
        /// <returns>Array di lati (3*int).</returns>
        static int[] SearchForValidTriangleFromBadOne(int[] BadTriangle)
        {
            int[] NewTriangle = new int[3];
            /* Copia di BadTriangle in NewTriangle. */
            for (int i = 0; i < 3; i++)
            { NewTriangle[i] = BadTriangle[i]; }

            #region Trovare il lato maggiore
            int indexOfBiggestSide;
            if (BadTriangle[0] > BadTriangle[1])
            {
                if (BadTriangle[0] > BadTriangle[2])
                { indexOfBiggestSide = 0; }
                else
                { indexOfBiggestSide = 2; }
            }
            else
            {
                if (BadTriangle[1] > BadTriangle[2])
                { indexOfBiggestSide = 1; }
                else
                { indexOfBiggestSide = 2; }
            }
            #endregion

            while (!IsATriangle(NewTriangle) && NewTriangle[indexOfBiggestSide]>0)
            {
                NewTriangle[indexOfBiggestSide]--;
                IsATriangle(NewTriangle);
            }

            return NewTriangle;
        }

        /// <summary>
        /// Controlla se è un triangolo, partendo da un array di tre lati (int).
        /// </summary>
        /// <param name="inTriangle">Array di 3 int.</param>
        /// <returns>Booleano: "true" se è un triangolo, "false" altrimenti.</returns>
        static bool IsATriangle(int[] inTriangle)
        {
            #region Variabili
            bool[] Test = new bool[5];
            int a, b, c;
            // Per mantenere leggibili le formule.
            a = inTriangle[0];
            b = inTriangle[1];
            c = inTriangle[2];
            #endregion

            #region Singoli test
            // a < (b + c)
            Test[0] = (a < (b + c)) ? true : false;

            // b < (a + c)
            Test[1] = (b < (a + c)) ? true : false;

            // c < (a + b)) ? true : false;
            Test[2] = (c < (a + b)) ? true : false;

            // a > |b-c|
            // |b-c|   »-»   Math.Abs(b-c)
            Test[3] = (a > (Math.Abs(b - c))) ? true : false;
            #endregion

            // Test[4] = Test finale = (Test0 & Test1 & Test2 & Test3)
            Test[4] = (Test[0] && Test[1] && Test[2] && Test[3]);

            return Test[4];
        }

        /// <summary>
        /// Mostra all'utente il messaggio d'immissione (in input) e
        /// prova a convertire il valore inserito in input in un intero (string->int).
        /// </summary>
        /// <param name="message">Messaggio da mostrare all' utente.</param>
        /// <returns></returns>
        static int AskAndCheckNumber(string message)
        {
            int latoConvertito_str2int = 0;

            bool conversioneRiuscita = false;
            while (!conversioneRiuscita)
            {
                Console.Write(message);
                string valImmesso = Console.ReadLine();
                conversioneRiuscita = int.TryParse(valImmesso, out latoConvertito_str2int);

                // Dato immesso non valido NAN (no un int).
                if (!conversioneRiuscita)
                {
                    Console.WriteLine("Valore immesso non valido!\a");
                }

                // Se è un valore è <= a 0, non ha senso.
                if ((conversioneRiuscita) && (latoConvertito_str2int <= 0))
                {
                    Console.WriteLine("Valore immesso minore di (od uguale a) zero!\a");
                    conversioneRiuscita = false;
                }
            }

            return latoConvertito_str2int;
        }
    }
}