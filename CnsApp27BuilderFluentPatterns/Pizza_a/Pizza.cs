using System;
using System.Collections.Generic;
using System.Text;

namespace Pizza_a
{
    class Pizza
    {
        public Dictionary<Ingredient, int> PizzaToppings { get; set; }
        public int TotalWeigth { get; set; }
        
        public PizzaDimension Dimension { get; }

        public Pizza()
        {
            //Pizza(/*AskDimension()*/);
        }

        public Pizza(PizzaDimension pizzaDimension)
        {
            Dimension = pizzaDimension;

            /* Dimension= FromStrToPizzaDimension(pizzaDimension); */

            PizzaBuilder pB = new PizzaBuilder(pizzaDimension);

            pB.AddTomato();
            pB.AddMozzarella();

        }


        public Pizza(Dictionary<Ingredient, int> PizzaToppings)
        {
            /* TotalWeigth = ∑(PizzaToppings); */
            /* ShowIngredients(); */
            /* ShowWeigth(); */

            return;
        }
    }
}
