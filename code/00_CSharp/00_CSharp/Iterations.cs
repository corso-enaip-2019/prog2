﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp
{
    class Iterations
    {
        public void Iterate()
        {
            //for con incremento
            int i = 0;
            for (i = 0; i < 20; i++)
            {
                Console.WriteLine("Sono nell'iterazione " + (i + 1));
                if (i == 5)
                    continue;

                if (i == 7)
                    break;

                Console.WriteLine(i);
                System.Diagnostics.Debug.WriteLine(i);
            }

            //for con decremento
            for (i = 3; i > 0; i--)
            {
                System.Diagnostics.Debug.WriteLine(i);
            }

            // for con variabile di iterazione 'j' che ha vita solo dentro il loop:
            for (int j = 0; j < 10; j++)
            {
                System.Diagnostics.Debug.WriteLine(j);
            }
            // qui, fuori dal for, 'j' non esiste più. La seguente riga dà errore:
            // System.Diagnostics.Debug.WriteLine(j);

            //while
            i = 0;
            while (i < 3)
            {
                System.Diagnostics.Debug.WriteLine(i);
                if (i == 2)
                    break;
                i++;
            }

            //do while
            i = 0;
            do
            {
                System.Diagnostics.Debug.WriteLine(i);
                i++;
            } while (i < 3);

            //foreach
            List<string> stringhe = new List<string>() { "uno", "due", "tre" };
            foreach (string item in stringhe)
            {
                System.Diagnostics.Debug.WriteLine(item);
            }

            //foreach (implicit type)
            foreach (var item in stringhe)
            {
                System.Diagnostics.Debug.WriteLine(item);
            }
        }
    }
}
