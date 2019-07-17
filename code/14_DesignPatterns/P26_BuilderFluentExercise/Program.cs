using System;
using System.Collections.Generic;
using System.Linq;

namespace P26_BuilderFluentExercise
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
            var builder1 = new PizzaBuilder()
                .AddHam()
                .AddMushrooms()
                .AddRocketSalad();
            var hamburger1 = builder1.Create();

            var builder2 = new PizzaBuilder(isMignon: true)
                .AddHam()
                .AddRocketSalad();

            var hamburger2 = builder2.Create();

            Console.Read();
        }
    }

    enum IngredientType
    {
        Tomato,
        Mozzerella,
        Ham,
        Mushrooms,
        RocketSalad,
    }

    class Ingredient
    {
        public IngredientType Type { get; set; }
        public int Quantity { get; set; }

        public override string ToString()
        {
            return $"Ingredient of type {Type}, with quantity: {Quantity}";
        }
    }

    class Pizza
    {
        public Pizza(bool isMignon = false)
        {
            IsMignon = isMignon;
            Ingredients = new List<Ingredient>();
        }

        public bool IsMignon { get; }
        public List<Ingredient> Ingredients { get; }
    }

    interface IPizzaBuilder
    {
        Pizza Create();
    }

    class PizzaBuilder : IPizzaBuilder
    {
        private static Dictionary<bool, PizzaConfiguration> _configurations
            = new Dictionary<bool, PizzaConfiguration>
            {
                {
                    true,
                    new PizzaConfiguration
                    {
                        Tomato = 80,
                        Mozzarella = 50,
                        Ham = 60,
                        Mushrooms = 40,
                        RocketSalad = 30,
                    }
                },
                {
                    false,
                    new PizzaConfiguration
                    {
                        Tomato = 120,
                        Mozzarella = 70,
                        Ham = 80,
                        Mushrooms = 60,
                        RocketSalad = 50,
                    }
                },
            };

        private List<Ingredient> _ingredients;
        private bool _isMignon;
        private PizzaConfiguration _config;

        public PizzaBuilder(bool isMignon = false)
        {
            _isMignon = isMignon;
            _config = _configurations[_isMignon];
            _ingredients = new List<Ingredient>
            {
                new Ingredient { Type = IngredientType.Tomato, Quantity = _config.Tomato },
                new Ingredient { Type = IngredientType.Mozzerella, Quantity = _config.Mozzarella },
            };
        }

        public PizzaBuilder AddHam()
        {
            _ingredients.Add(new Ingredient
            {
                Type = IngredientType.Ham,
                Quantity = _config.Ham,
            });
            return this;
        }

        public PizzaBuilder AddMushrooms()
        {
            _ingredients.Add(new Ingredient
            {
                Type = IngredientType.Mushrooms,
                Quantity = _config.Mushrooms,
            });
            return this;
        }

        public PizzaBuilder AddRocketSalad()
        {
            _ingredients.Add(new Ingredient
            {
                Type = IngredientType.RocketSalad,
                Quantity = _config.RocketSalad,
            });
            return this;
        }

        public Pizza Create()
        {
            var ingredientClones = _ingredients
                .Select(x => new Ingredient { Type = x.Type, Quantity = x.Quantity });

            var h = new Pizza(_isMignon);
            h.Ingredients.AddRange(ingredientClones);
            return h;
        }

        private class PizzaConfiguration
        {
            public int Tomato { get; set; }
            public int Mozzarella { get; set; }
            public int Ham { get; set; }
            public int Mushrooms { get; set; }
            public int RocketSalad { get; set; }
        }
    }
}
