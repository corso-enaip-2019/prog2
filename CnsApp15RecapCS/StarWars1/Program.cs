using System;

/* 20190401 */
/* Esercizio con ereditarietà ed interfacce. */
/* StarWars1 */

namespace StarWars1
{
    class Program
    {
        static void Main(string[] args)
        {
            Mum leila = new Mum("Leila");
            Dad hanSolo = new Dad("Han Solo");

            leila.MakeBaby(hanSolo, "Kilo-Ren");



            Console.ReadLine();
        }

        //static void SWTitle(int n)
        //{
        //    switch (n)
        //    { 
        //        case 1:
        //    Console.WriteLine(@"  _________ __                __      __                    ][");
        //            break;
        //        case 2:
        //    Console.WriteLine(@"  _________ __                __      __                 ][ ][");
        //            break;
        //        case 3:
        //    Console.WriteLine(@"  _________ __                __      __              ][ ][ ][");
        //            break;
        //        default:
        //    Console.WriteLine(@"  _________ __                __      __                      ");
        //            break;
        //    }
        //    Console.WriteLine(@" /   _____//  |______ _______/  \    /  \_____ _______  ______");
        //    Console.WriteLine(@" \_____  \\   __\__  \\_  __ \   \/\/   /\__  \\_  __ \/  ___/");
        //    Console.WriteLine(@" /        \|  |  / __ \|  | \/\        /  / __ \|  | \/\___ \ ");
        //    Console.WriteLine(@"/_______  /|__| (____  /__|    \__/\  /  (____  /__|  /____  >");
        //    Console.WriteLine(@"        \/           \/             \/        \/           \/ ");
        //}
    }
}