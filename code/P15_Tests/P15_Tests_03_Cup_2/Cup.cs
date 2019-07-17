using System;

namespace P15_Tests_03_Cup_2
{
    /*
     * Rispetto al progetto precedente, la Cup va modificata come segue:
     * 1) Quando la tazza è riempita, ha 10/10 di bevanda.
     * 2) Quando si beve, si può bere solo in parte (in decimi).
     * 3) Se si prova a bere più del rimanente, viene lanciata eccezione
     * 4) Quando riempio, anche se la tazza è mezza riempita, torna a 10/10
     * 5) Una tazza già piena, se riempita di nuovo lancia eccezione.
     * 
     * Per procedere in modalità TEST-DRIVEN, bisogna seguire questi passaggi in ordine:
     * 1) Si modifica la FORMA della classe, ma SENZA implementare i metodi nuovi.
     * 2) Si scrivono tutti i test che verifichino le nuove condizioni.
     * 3) Si verifica che tutti i test "spacchino" almeno una volta.
     * 4) Si implementano le funzioni sulla classe, continuando finché tutti i test passano.
     */
    class Cup
    {
        public const int MAX_FILL_LEVEL = 10;

        public bool IsFull
        {
            get { return FillLevel == MAX_FILL_LEVEL; }
        }

        public int FillLevel { get; private set; }

        public void Fill()
        {
            if (IsFull)
                throw new InvalidOperationException("Cannot fill an already filled Cup!");

            FillLevel = MAX_FILL_LEVEL;
        }

        public void Drink(int quantity)
        {
            var newFillLevel = FillLevel - quantity;

            if (newFillLevel < 0)
                throw new InvalidOperationException("Cannot drink more than remaining quantity on Cup!");

            FillLevel = newFillLevel;
        }
    }
}
