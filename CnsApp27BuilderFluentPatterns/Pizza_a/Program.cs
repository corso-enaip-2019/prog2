using System;

namespace Pizza_a
{
    public enum IngredientType { Ham, Mozzarella, Mushrooms, RocketSalad, Tomato };
    public enum PizzaDimension { mignon, normal, maxi };

    class Program
    {

        static void Main(string[] args)
        {
            bool rePlay = true;
            while (rePlay)
            {
                PizzaBuilder pb1 = new PizzaBuilder(); //senza paramentri, crea una pizza "normale"

                Console.Write("\"q\"? \a");
                rePlay = (Console.ReadLine() != "q") ? true : false;
            }
        }

        static PizzaDimension AcquirePizzaDimension()
        {
            while (true)
            {
                Console.Write("(n)ormale, (m)ignon, ma(x)i? \a");
                switch (Console.ReadLine().ToLower())
                {
                    case "mignon":
                    case "m":
                        return PizzaDimension.mignon;

                    case "normale":
                    case "n":
                        return PizzaDimension.normal;

                    case "maxi":
                    case "x":
                        return PizzaDimension.maxi;

                    default:
                        break;
                }
            }
        }
    }
}