using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* 20180304 - 1 */

namespace CnsApp01_2
{
    /* Controllare se i tre numeri/lati immessi dall'utente corrispondano alle seguenti regole:
     * a>b+c   b>a+c   c>a+b   a>|b-c| 
     * Se sono tutte valide _contemporaneamente_, sarà un triangolo. */
    class Program
    {
        static void Main(string[] args)
        {
            #region Esempo con cicli

            #region Dichiarazione variabili
            string[] ordinale = { "zero", "primo", "secondo", "terzo" };
            string esitoFinale;

            // Lati
            int[] lato = new int[4];
            int a, b, c;

            // Test per controllare se è un triangolo.
            bool[] Test = new bool[4];
            #endregion

            #region Fase d'immissione dati
            for (int i = 1; i <= 3; i++)
            {
                lato[i] = AskAndCheckNumber($"Inserisci il {ordinale[i]} lato:\t\a");
            }

            // Per mantenere leggibili le formule più avanti.
            a = lato[1];
            b = lato[2];
            c = lato[3];
            #endregion

            #region Controllo se è un triangolo
            // a < (b + c)
            Test[0] = (a < (b + c)) ? true : false;

            // b < (a + c)
            Test[1] = (b < (a + c)) ? true : false;

            // c < (a + b)) ? true : false;
            Test[2] = (c < (a + b)) ? true : false;

            // a > |b-c|
            // |b-c|   »-»   Math.Abs(b-c)
            Test[3] = (a > (Math.Abs(b - c))) ? true : false;

            esitoFinale = (Test[0] && Test[1] && Test[2] && Test[3]) ? "E\' un triangolo." : "Non è un triangolo.";
            #endregion

            #region Output
            Console.WriteLine(esitoFinale);
            Console.ReadLine();
            #endregion



            #endregion
        }

        /// <summary>
        /// Mostra all'utente il messaggio d'immissione (in input) e
        /// prova a convertire il valore inserito in input in un intero (string->int).
        /// </summary>
        /// <param name="message">Messaggio mostrato all' utente.</param>
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
                    Console.WriteLine("Valore immesso minore (od uguale)di zero!\a");
                    conversioneRiuscita = false;
                }
            }
            return latoConvertito_str2int;
        }
    }
}