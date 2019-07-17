using System;

namespace P23_FactoryClass2
{
    // Se il numero di parametri è troppo alto nei metodi di Create,
    // Posso:
    // 1) passare i parametri più "fissi" nel costruttore, così da rendere più semplici
    //     i vari metodi di Create()
    // 2) creare una classe di configurazione da passare come unico parametro.
    // Qui vediamo il punto 2).

    class Program
    {
        static void Main(string[] args)
        {
            // 

            Console.WriteLine("Hello World!");
        }
    }

    class Hamburger
    {
        public int MeatQuantity { get; set; }
        public int KetchupQuantity { get; set; }
        public int CheeseQuantity { get; set; }
        public int OnionQuantity { get; set; }
    }

    // FACTORY CLASS
    class HamburgerFactory
    {
        public Hamburger CreateHamburger(HamburgerConfiguration config)
        {
            return new Hamburger
            {
                // Add ingredients based on configuration:
                CheeseQuantity = config.AddCheese ? 100 : 0,
                // ...
            };
        }
    }

    class HamburgerConfiguration
    {
        public bool AddKetchup { get; set; }
        public bool AddMostard { get; set; }
        public bool AddMayo { get; set; }
        public bool AddCheese { get; set; }
        public bool AddOnion { get; set; }
        public bool AddBacon { get; set; }
        public bool AddLattuce { get; set; }
    }
}
