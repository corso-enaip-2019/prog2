using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CnsApp08Caffetteria
{
    class Cup
    {
        public List<ITopping> CupOfToppings { get; set; }

        public Coffee CoffeeShot { get;}



        #region ctor
        public Cup()
        { CoffeeShot = new Coffee(CupSize.M); }

        public Cup(Coffee coffee)
        { CoffeeShot = new Coffee(coffee.Size); }
        #endregion


        public void AddToppingToCup(ITopping toppingToAdd)
        { CupOfToppings.Add(toppingToAdd); }

        public void RemoveToppingFromCup(ITopping toppingToRemove)
        {
            if (CupOfToppings.Contains(toppingToRemove))
            { CupOfToppings.Remove(toppingToRemove); }
        }
    }
}
