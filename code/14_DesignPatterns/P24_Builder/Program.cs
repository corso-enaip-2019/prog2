using System;

namespace P24_Builder
{
    class Program
    {
        static void Main(string[] args)
        {
            var b = new HamburgerBuilder();
            b.AddMeat();
            b.AddMeat();
            b.AddCheese();

            var hamburger = b.Create();

            Console.Read();
        }
    }

    class Hamburger
    {
        public int MeatQuantity { get; set; }
        public int KetchupQuantity { get; set; }
        public int CheeseQuantity { get; set; }
        public int OnionQuantity { get; set; }
    }

    // Un BUILDER può avere numerosi metodi di configurazione,
    // in genere con prefisso "Add", o "Set", "Put", "Configure", ecc.
    // Però TUTTI i builder, alla fine, hanno un metodo Create() che mi permetta
    // di creare effettivamente istanze della classe target.
    // Ecco quindi la classica interfaccia dei BUILDER:
    interface IHamburgerBuilder
    {
        Hamburger Create();
    }

    // Parentesi: Potrei rendere l'intefaccia Generic:
    //interface IBuilder<T>
    //{
    //    T Create();
    //}

    // Prima opzione per i BUILDER, qui implementata:
    // - Nel costruttore già istanzio la classe che si vuole creare.
    // - Man mano che vengono chiamati i metodi di aggiunta/configurazione ingredienti,
    //     li aggiungo a quell'istanza.
    // - Alla fine il metodo Create() restituisce quell'unica istanza.
    // In questo caso il builder è one-shot, e devo assicurarmi
    // che non venga chiamato il metodo Create() più di una volta.
    class HamburgerBuilder : IHamburgerBuilder
    {
        private Hamburger _hamburger;
        public bool _alreadyCreated { get; }

        public HamburgerBuilder()
        {
            _hamburger = new Hamburger();
        }

        public void AddMeat()
        {
            _hamburger.MeatQuantity+= 200;
        }

        public void AddCheese()
        {
            _hamburger.CheeseQuantity += 50;
        }

        public void AddOnion()
        {
            _hamburger.OnionQuantity += 30;
        }

        public Hamburger Create()
        {
            // Al primo Create() il campo '_alreadyCreated' viene messo a true.

            // In questo modo, alle chiamate successive di Create()
            // viene controllato il flag ed eventualmente viene lanciata eccezione.

            if (_alreadyCreated)
                throw new InvalidOperationException("Hamburger already created");

            var h = _hamburger;

            _hamburger = null;

            return h;
        }
    }
}
