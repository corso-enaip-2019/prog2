using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CnsApp08Caffetteria
{
    class Menu
    {
        public List<ITopping> ListOfToppingsAvailableInMenu { get; set; }



        public void AddToppingToMenu(ITopping toppingToAddToMenu)
        {
            if (!ListOfToppingsAvailableInMenu.Contains(toppingToAddToMenu))
            { ListOfToppingsAvailableInMenu.Add((ITopping)toppingToAddToMenu); }
        }

        public void RemoveToppingFromMenu(ITopping toppingToRemoveFromMenu)
        {
            if (ListOfToppingsAvailableInMenu.Contains(toppingToRemoveFromMenu))
            { ListOfToppingsAvailableInMenu.Remove/*All*/(toppingToRemoveFromMenu); }
        }

        public void AddToppingsToMenu(params ITopping[] toppingToAddToMenu)
        {
            foreach (ITopping topping in toppingToAddToMenu)
            {
                if (!ListOfToppingsAvailableInMenu.Contains(topping))
                { ListOfToppingsAvailableInMenu.Add(topping); }
            }
        }

        public void RemoveToppingsFromMenu(params ITopping[] toppingToRemoveFromMenu)
        {
            foreach (ITopping topping in toppingToRemoveFromMenu)
            {
                if (ListOfToppingsAvailableInMenu.Contains(topping))
                { ListOfToppingsAvailableInMenu.Remove/*All*/(topping); }
            }
        }
    }
}