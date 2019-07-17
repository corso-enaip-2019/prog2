using System;
using System.Collections.Generic;
using System.Linq;

namespace P26_BuilderFluent
{
    class Program
    {
        static void Main(string[] args)
        {
            // Il pattern FLUENT mi permette di chiamare una serie di metodi
            // in cascata, perché ogni metodo restituisce un oggetto
            // su cui chiamare altri metodi.

            // Un esempio è LINQ: ogni metodo restituisce un IEnumerable<T>
            // su cui posso chiamare un altro metodo di LINQ, a cascata.

            // Il pattern FLUENT si usa molto spesso in combinazione con il pattern BUILDER:
            var builder = new HamburgerBuilder(HamburgerType.Small)
                .AddMeat()
                .AddCheese()
                .AddOnion()
                .AddMeat();

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

        public HamburgerBuilder AddMeat()
        {
            _ingredients.Add(new Ingredient
            {
                Type = IngredientType.Meat,
                Quantity = _config.Meat,
            });
            return this;
        }

        public HamburgerBuilder AddCheese()
        {
            _ingredients.Add(new Ingredient
            {
                Type = IngredientType.Cheese,
                Quantity = _config.Cheese,
            });
            return this;
        }

        public HamburgerBuilder AddOnion()
        {
            _ingredients.Add(new Ingredient
            {
                Type = IngredientType.Onion,
                Quantity = _config.Onion,
            });
            return this;
        }

        public Hamburger Create()
        {
            var ingredientClones = _ingredients
                .Select(x => new Ingredient { Type = x.Type, Quantity = x.Quantity });

            var h = new Hamburger(_type);
            h.Ingredients.AddRange(ingredientClones);
            return h;
        }

        // Questa classe è usata solo internamente dal Builder.
        // Ha quindi senso dichiararla come classe annidata e privata:
        private class HamburgerConfiguration
        {
            public int Meat { get; set; }
            public int Onion { get; set; }
            public int Cheese { get; set; }
            // Un Builder potrebbe avere 10, 20, 30 parametri:
            //public int Bacon { get; set; }
            //public int Lattuce { get; set; }
            //public int Tomatoes { get; set; }
            //public int Ketchup { get; set; }
        }
    }
}
