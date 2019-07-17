using System;
using System.Collections.Generic;
using System.Text;

namespace Pizza_a
{
    class PizzaBuilder:IPizzaBuilder
    {

        //private static Dictionary<PizzaDimension, PizzaConfiguration> _configurations { };


        public Dictionary<IngredientType, int> PizzaToppings { get; set; }
        PizzaDimension _pizzaDimension;

        #region Aggiunta d_ingredienti
        public PizzaBuilder AddMozzarella()
        {
            if (PizzaToppings.ContainsKey(IngredientType.Mozzarella))
                PizzaToppings[IngredientType.Mozzarella] += 100;
            else
                PizzaToppings.Add(IngredientType.Mozzarella, 150);

            return this;
        }

        public PizzaBuilder AddTomato()
        {
            if (PizzaToppings.ContainsKey(IngredientType.Tomato))
                PizzaToppings[IngredientType.Tomato] += 100;
            else
                PizzaToppings.Add(IngredientType.Tomato, 150);

            return this;
        }

        public PizzaBuilder AddHam()
        {
            if (PizzaToppings.ContainsKey(IngredientType.Ham))
                PizzaToppings[IngredientType.Ham] += 100;
            else
                PizzaToppings.Add(IngredientType.Ham, 150);

            return this;
        }

        public PizzaBuilder AddMushrooms()
        {
            if (PizzaToppings.ContainsKey(IngredientType.Mushrooms))
                PizzaToppings[IngredientType.Mushrooms] += 80;
            else
                PizzaToppings.Add(IngredientType.Mushrooms, 100);

            return this;
        }

        public PizzaBuilder AddRocketSalad()
        {
            if (PizzaToppings.ContainsKey(IngredientType.RocketSalad))
                PizzaToppings[IngredientType.RocketSalad] += 50;
            else
                PizzaToppings.Add(IngredientType.RocketSalad, 200);

            return this;
        }
        #endregion

        public PizzaBuilder(PizzaDimension pizzaDimension=PizzaDimension.normal)
        {

        }
    }
}
