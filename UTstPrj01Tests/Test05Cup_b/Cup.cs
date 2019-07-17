using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test05Cup_b
{
    /* La tazza appena creata è vuota.
     * Se la tazza è vuota, è possibile riempirla.
     * Se la tazza è vuota, è possibile berla.
     * Se si prova a bere e la tazza è vuota, verrà lanciata un'eccezione.
     * Se si prova a rimpire una tazza piena, (verrà lanciata un'eccezione.?)
     * Deve essere possibile eseguire il ciclo riempi-bevi un numero potenzialmente infinito di volte (1k nel nostro test). */

    /* Aggiunte rispetto al Cup di Test01Cup:
     * Tazza riempita = 10/10 (MAX_FILL_LEVEL/MAX_FILL_LEVEL);
     * Se si beve si beve n/10 (n/MAX_FILL_LEVEL);
     * Se si beve più del rimanente, lancia ex;
     * Se si riempie, @<10/10, -> 10/10 (x/MAX -> MAX/MAX, con x != MAX);
     * Se si riempie, @10/10 (MAX/MAX), lancia ex. */

    class Cup
    {
        public const int MAX_FILL_LEVEL = 10;
        public bool IsFull { get { return (FillLevel == MAX_FILL_LEVEL); } private set; }
        public int FillLevel { get; private set; }

        public Cup()
        {
            Fill();
        }

        public void Fill()
        {
            if (IsFull)
                throw new InvalidOperationException("Cannot fill an already filled cup.");

            IsFull = true;
        }

        public void Drink()
        {
            if (!IsFull)
                throw new InvalidOperationException("Cannot drink from an empty cup.");
            else
            {
                FillLevel = 0;
                //IsFull = false;
                CheckFullness();
            }
        }

        public void Drink(int howMuch)
        {
            if (!IsFull)
                throw new InvalidOperationException("Cannot drink from an empty cup.");
            if (howMuch > FillLevel)
                throw new ArgumentException("Cannot drink more than the present level.");

            FillLevel -= howMuch;
            CheckFullness();
        }

        private void CheckFullness()
        {
            IsFull = (FillLevel == 10);
        }

        //public Cup() { IsFull = false; }

        /* Se un metordo restituisce un valore,  */
        public int GetQuantity()
        {
            return -314;
            throw new NotImplementedException();
        }
    }
}