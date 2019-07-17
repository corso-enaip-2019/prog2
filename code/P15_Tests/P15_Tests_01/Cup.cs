using System;

namespace P15_Tests_01_Cup
{
    /*
     * Quando la tazza è creata, è vuota.
     * Se la tazza è vuota, la posso riempire.
     * Se la tazza è piena, la posso bere.
     * Se provo a bere una tazza vuota, viene lanciata eccezione.
     * Se provo a riempire una tazza piena, viene lanciata eccezione.
     * Posso riempire-bere-riempire-bere infinite volte.
     */

    class Cup
    {
        public bool IsFull { get; private set; }

        /// <summary>
        /// This method makes the Cup filled up.
        /// Exceptions:
        ///     InvalidOperationException if the Cup is already full.
        /// </summary>
        public void Fill()
        {
            if (IsFull)
                throw new InvalidOperationException("Cannot fill an already filled Cup!");

            IsFull = true;
        }

        public void Drink()
        {
            if (!IsFull)
                throw new InvalidOperationException("Cannot drink from an empty Cup!");

            IsFull = false;
        }

        // Se devo implementare dei metodi che restituiscono valori,
        // prima restituisco solo un default o lancio eccezione,
        // e solo DOPO aver scritto i test implemento il metodo correttamente.
        //public int GetQuantity()
        //{
        //    return -1;
        //    throw new NotImplementedException();
        //}
    }
}
