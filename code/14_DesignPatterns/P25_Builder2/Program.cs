using System;
using System.Collections.Generic;
using System.Linq;

namespace P25_Builder2
{
    // Un sistema un po' più flessibile di BUILDER
    // è quello di usare i suoi metodi non per creare già l'istanza di Hamburger
    // con i suoi campi, ma salvando in una configurazione interna il modo in cui
    // creare gli Hamburger.
    // In questo modo, il metodo Create() ogni volta crea un nuovo Hamburger,
    // basandosi sulla configurazione accumulata dentro il BUILDER.
    // Questa seconda opzione è più usata:
    // Restituendo ogni volta un'istanza indipendente di Hamburger,
    // non c'è rischio di conflitto, cioè di più riferimenti sparsi alla stessa area di memoria.
    class Program
    {
        static void Main(string[] args)
        {
            var builder = new HamburgerBuilder(HamburgerType.Small);

            builder.AddMeat();
            builder.AddCheese();
            builder.AddOnion();
            builder.AddMeat();

            var hamburger1 = builder.Create();
            var hamburger2 = builder.Create();

            hamburger1.Ingredients[0].Quantity--;
            hamburger1.Ingredients.Add(
                new Ingredient { Type = IngredientType.Ketchup, Quantity = 20 });

            Console.Read();
        }
    }

    enum IngredientType
    {
        Meat,
        Onion,
        Cheese,
        Bacon,
        Lattuce,
        Tomatoes,
        Ketchup
    }

    class Ingredient
    {
        public IngredientType Type { get; set; }
        public int Quantity { get; set; }
    }

    enum HamburgerType
    {
        Small,
        Big,
    }

    class Hamburger
    {
        public Hamburger(HamburgerType type)
        {
            Type = type;
            Ingredients = new List<Ingredient>();
        }

        public HamburgerType Type { get; }
        public List<Ingredient> Ingredients { get; }
    }

    interface IHamburgerBuilder
    {
        Hamburger Create();
    }

    class HamburgerBuilder : IHamburgerBuilder
    {
        // In questo caso, in base all'HamburgerType, ho numeri diversi di quantità
        // per i vari ingredienti.
        // Invece che disperdere i valori nei vari metodi/if/else,
        // creo un dizionario centralizzato di configurazione,
        // che in base al tipo di Hamburger mi restituisce una configurazione specifica.
        // so questa configurazione nei vari metodi per decidere ad esempio
        // la quantità dei vari ingredienti, o se aggiungere ingredienti ausiliari (sale, pepe...).
        private static Dictionary<HamburgerType, HamburgerConfiguration> _configurations
            = new Dictionary<HamburgerType, HamburgerConfiguration>
            {
                {
                    HamburgerType.Small,
                    new HamburgerConfiguration
                    {
                        Meat = 100,
                        Cheese = 50,
                        Onion = 25,
                    }
                },
                {
                    HamburgerType.Big,
                    new HamburgerConfiguration
                    {
                        Meat = 250,
                        Cheese = 120,
                        Onion = 40,
                    }
                },
            };

        private List<Ingredient> _ingredients;
        private HamburgerType _type;
        private HamburgerConfiguration _config;

        public HamburgerBuilder(HamburgerType type)
        {
            _type = type;
            _config = _configurations[type];
            _ingredients = new List<Ingredient>();
        }

        public void AddMeat()
        {
            _ingredients.Add(new Ingredient
            {
                Type = IngredientType.Meat,
                Quantity = _config.Meat,
            });
        }

        public void AddCheese()
        {
            _ingredients.Add(new Ingredient
            {
                Type = IngredientType.Cheese,
                Quantity = _config.Cheese,
            });
        }

        public void AddOnion()
        {
            _ingredients.Add(new Ingredient
            {
                Type = IngredientType.Onion,
                Quantity = _config.Onion,
            });
        }

        public Hamburger Create()
        {
            // Devo clonare la lista di ingredienti, in modo che 
            // ogni hamburger abbia le proprie istanze autonome.
            var ingredientClones = _ingredients
                .Select(x => new Ingredient { Type = x.Type, Quantity = x.Quantity });

            // Parentesi: qui non ha senso chiamare il ToList() alla fine del Select().
            // L'IEnumerable restituito dal Select() viene iterato una volta sola
            // dentro al metodo AddRange() chiamato più sotto, e poi dimenticato.

            // Non ha senso creare quindi una lista concreta con il ToList(),
            // sarebbe spazio sullo HEAP sprecato.

            var h = new Hamburger(_type);
            h.Ingredients.AddRange(ingredientClones);
            return h;
        }

        private class HamburgerConfiguration
        {
            public int Meat { get; set; }
            public int Onion { get; set; }
            public int Cheese { get; set; }
            // Una configurazione per il Builder potrebbe avere 10, 20, 30 parametri:
            //public int Bacon { get; set; }
            //public int Lattuce { get; set; }
            //public int Tomatoes { get; set; }
            //public int Ketchup { get; set; }
            // ...
        }
    }
}
