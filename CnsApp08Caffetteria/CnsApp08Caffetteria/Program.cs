using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CnsApp08Caffetteria.Toppings;

/* 20190321 */

namespace CnsApp08Caffetteria
{
    public enum CupSize { S, M, L }

    class Program
    {
        static void Main(string[] args)
        {
            #region Generazione e popolamento menu
            Menu menu = new Menu();
            menu.ListOfToppingsAvailableInMenu=new List<ITopping>();

            GenericTopping gT = new GenericTopping("toppingDProva", "X", 0.56f);
            menu.AddToppingToMenu((ITopping)gT);

            Cocoa cocoa = new Cocoa();
            CocoaPowder powder = new CocoaPowder();
            Milk milk = new Milk();
            MilkFoam foam = new MilkFoam();

            menu.AddToppingToMenu(cocoa);
            menu.AddToppingsToMenu(cocoa, powder, milk, foam);
            #endregion

            foreach (ITopping topping in menu.ListOfToppingsAvailableInMenu.Where((topping) => topping.Price > 0.10f))
            {
                Console.Write($"{topping.Code}\t");
                Console.Write($"{topping.Price:0.00}\t");
                Console.Write($"{topping.Name}\n");
            }
            Console.ReadLine();
            //Test con la lambda/delegate ... fallito miseramente ...
            //DlgMetod provaScrittura(sondaLambda())
            //sondaLambda(txt);

        }


        //Test con la lambda/delegate ... fallito miseramente ...
        //...
        //...
        //...
        //static void MetodoDiProva(ScriviQuesto("test"))
        //{

        //return;
        //}
    }

    //Test con la lambda/delegate ... fallito miseramente ...
    //...
    //...
    //...
    //static class Deeelegates
    //{
    //    public delegate void ScriviQuesto(string TestoDaScrivere);

    //    ScriviQuesto ScriviProva = (txtDaScrivere) => { Console.WriteLine(txtDaScrivere); return; };
    //}
}