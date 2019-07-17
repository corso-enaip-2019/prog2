using System;
using System.Numerics;

namespace Recap1
{
    class Program
    {
        static void Main(string[] args)
        {
            // qual è il massimo intero esprimibile con un int?

            // 1) 2^32-1
            // 2) ciclo sommando 1 finché... succede qualcosa

            // Una variabile è una "scatola" che ha un certo nome e una certa forma.

            int i; // 1) dichiarazione
            i = 1; // 2) assegnazione
            Console.WriteLine("i vale: " + i); // 3) utilizzo del valore assegnato.

            // non posso assegnare valori di tipo diverso da quello dichiarato.
            //i = "ciao";
            //i = 123.123;

            // il range dei numeri interi è limitato.
            // esercizio: calcoliamo il massimo intero.

            while (true)
            {
                if (i + 1 < i)
                {
                    break;
                }

                // sintassi più verbose
                //i = i + 1;
                //i += 1;
                i++;
            }

            Console.WriteLine(i);

            // .NET mette a disposizione una costante:
            int max = int.MaxValue;

            // se gli int non mi bastano, posso usare i long.
            // per dichiarare un valore numerico esplicito come "long"
            // devo usare il suffisso "l" o "L":
            long l = 1L;
            l = (long)int.MaxValue + 1;
            // per assegnare un valore long a una variabile int
            // devo fare un cast esplicito,
            // assumendomi la responsabilità di eventuali overflow:
            i = (int)l;

            Console.WriteLine(i);

            // se voglio calcoli "sicuri",
            // cioè che lancino errori in caso di oveflow
            // posso usare un blocco checked:

            checked
            {
                int over = 2000000000;
                // questo calcolo causa un'eccezione:
                // int doubleOver = over + over;
            }

            // anche i long sono limitati.
            // Se voglio numeri interi a grandezza arbitraria posso usare:
            BigInteger bi = 10;

            // con questo for proviamo a generare un numero "grandissimo":
            for(int j = 0; j < 10; j++)
            {
                bi *= bi;

                Console.WriteLine(bi);
            }

            // il for ha molte opzioni. Posso usare più variabili:
            //for(int j1 = 0, j2 = 10; j1 == j2; j1 += 3, j2--)
            //{ }

            // identico al "while(true)"
            //for(; ; )
            //{ }

            // per dichiarare un valore decimale esplicito come float
            // devo aggiungere il suffisso "f" o "F".
            // Senza questo suffisso, un valore decimale esplicito
            // viene sempre preso come double.
            float f = (float)1.123;
            f = 1.123F;
            f = 1.1F;

            // anche double e float hanno un limite di dimensione.
            // Per i double è ~10e307, infatti la seguente riga dà errore:
            //double d = 10e400;

            // in più, double e float hanno anche un limite di precisione,
            // dovuto al numero limitato di cifre decimali memorizzabili.

            // A seconda delle operazioni che svolgo, il livello di
            // approssimazione e errore cambia.
            // I seguenti due numeri dovrebbero essere uguali:
            double d1 = Math.Pow((Math.Sqrt(2)-1)/(Math.Sqrt(2)+1), 3);
            double d2 = 1 / Math.Pow(Math.Sqrt(2) + 1, 6);
            
            // ma se stampo la differenza... non è 0!
            Console.WriteLine("d1 - d2: " + (d1 - d2));

            // Ci sono numeri decimali con la virgola che NON sono
            // esprimibili con i double. Esempio:
            double zeroThree = 0.1 + 0.2;
            Console.WriteLine("zeroThree is equal to 0.3? " + (zeroThree == 0.3));

            // La riga seguente genera errore: un numero esplicito con la virgola
            // è sempre considerato un double dal compilatore.
            //decimal dec = 0.1;

            // per dichiarare un valore decimale esplicito come decimal
            // devo aggiungere il suffisso "m" o "M":
            decimal dec = 0.1M;

            // anche se i decimal hanno 128 bit e i double solo 64,
            // hanno strutture incompatibili, quindi non esiste cast implicito.
            // Queste due linee danno errore:
            //dec = zeroThree;
            //zeroThree = dec;

            Console.Read();
        }
    }
}
