using System;

namespace P21_FactoryClass
{
    class Program
    {
        static void Main(string[] args)
        {
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
        public Hamburger CreateBigHamburger(bool addKetchup, bool addCheese, bool addOnion)
        {
            return new Hamburger
            {
                MeatQuantity = 400,
                KetchupQuantity = addKetchup ? 50 : 0,
                CheeseQuantity = addCheese ? 5 : 0,
                OnionQuantity = addOnion ? 4 : 0,
            };
        }

        public Hamburger CreateSmallHamburger(bool addKetchup, bool addCheese, bool addOnion)
        {
            return new Hamburger
            {
                MeatQuantity = 100,
                KetchupQuantity = addKetchup ? 10 : 0,
                CheeseQuantity = addCheese ? 1 : 0,
                OnionQuantity = addOnion ? 1 : 0,
            };
        }
    }
}
