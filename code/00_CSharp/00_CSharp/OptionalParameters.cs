using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstConsole
{
    class OptionalParameters
    {
        public void Run()
        {
            var f = new HamburgerFactory();

            // Quando chiamo un metodo, posso scrivere il nome dei parametri:
            Console.WriteLine(value: "factory class with default parameters");

            // Questo è molto utile quando:
            // 1) più parametri possono essere confusi tra loro
            // 2) voglio invertire l'ordine dei parametri
            // 3) ho tanti parametri opzionali dello stesso tipo, e voglio indicare esattamente
            //     di che parametro sto impostando il valore.
            var h = f.CreateHamburger(addBacon: true, addLettuce: true);

            // Posso passare sia valori espliciti che variabili o costanti,
            // esattamente come con i metodi normali.
            var addBaconVariable = true;
            var h2 = f.CreateHamburger(addBacon: addBaconVariable);
        }
    }

    class HamburgerFactory
    {
        // Con un'assegnazione, il parametro diventa opzionale.
        // L'assegnazione mi dice qual è il valore di default da usare se l'utente non usa il parametro.
        public Hamburger CreateHamburger(
            bool addKetchup = false,
            bool addCheese = false,
            bool addOnion = false,
            bool addBacon = false,
            bool addLettuce = false)
            // DEVO usare valori di default noti a compile time (valori espliciti o costanti);
            // questa riga darebbe errore:
            // bool addLattuce = GetDefaultValue()
        {
            return new Hamburger
            {
                MeatQuantity = 400,
                KetchupQuantity = addKetchup ? 50 : 0,
                CheeseQuantity = addCheese ? 5 : 0,
                OnionQuantity = addOnion ? 4 : 0,
            };
        }

        // metodo per dimostrare che i valori di default dei parametri devono essere noti a compile-time.
        private static bool GetDefaultValue()
        {
            return false;
        }
    }

    class Hamburger
    {
        public int MeatQuantity { get; set; }
        public int KetchupQuantity { get; set; }
        public int CheeseQuantity { get; set; }
        public int OnionQuantity { get; set; }
    }
}
