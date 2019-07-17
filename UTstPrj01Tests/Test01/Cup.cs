using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

namespace Test01Cup
{
    /* La tazza appena creata è vuota.
     * Se la tazza è vuota, è possibile riempirla.
     * Se la tazza è vuota, è possibile berla.
     * Se si prova a bere e la tazza è vuota, verrà lanciata un'eccezione.
     * Se si prova a rimpire una tazza piena, (verrà lanciata un'eccezione.?)
     * Deve essere possibile eseguire il ciclo riempi-bevi un numero potenzialmente infinito di volte (1k nel nostro test). */

    class Cup
    {
        public bool IsFull { get; private set; }

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
                IsFull = false;
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