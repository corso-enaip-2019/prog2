using System;

using System.Collections.Generic;
using System.Linq;
using System.Timers;


/* 20180403 */
/* Esercizio con eventi (+ delegati + ereditarietà ed interfacce). */
/* StarWars3 */

namespace StarWars3_Event
{
    class Program
    {
        static void Main(string[] args)
        {

            Mum leila = new Mum("Leila");
            Dad hanSolo = new Dad("Han Solo");

            leila.MakeBaby(hanSolo, "Kylo Ren");

            //leila.Child.AddComforter(leila.ComfortChild);

            Robot r2d2 = new Robot("R2D2");
            leila.Child.StartedCrying += r2d2.ComfortChild;


            /* Aggiungi al Child di Leila il conforter TheForce (che è static) che calma il piccolo tramite il suo metodo/delegate TheForce.ConmfortChild(). */
            //leila.Child.AddComforter(TheForce.ComfortChild);



            /*
            leila.Child.StartCrying();
            Console.ReadLine();
            leila.Child.StartCrying();
            Console.ReadLine();
            leila.Child.StartCrying();
            Console.ReadLine();
            leila.Child.StartCrying();
            Console.ReadLine();
            leila.Child.StartCrying();
            */

            Console.ReadLine();
        }
    }

    abstract class Person
    {
        public Person(string name)
        {
            Name = name;
        }

        //private string name;
        //public string GetName()
        //{
        //    return name;
        //}
        //private void SetName(string value)
        //{
        //    if (string.IsNullOrWhiteSpace(value))
        //        throw new ArgumentException("the name cannot be empty or blank");
        //    name = value;
        //}

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("the name cannot be empty or blank");
                name = value;
            }
        }
        private string name;
    }

    class Baby : Person
    {
        public Baby(string name)
            : base(name)
        {
            // Usando gl'eventi, non è più necessario tener traccia dei Comforter
            //_comforters = new List<ComfortBaby>();

            // (b) ???
            //StartedCrying += (b);
        }

        public event ComfortBaby StartedCrying;

        /// <summary>
        /// Ogni volta che questo metodo viene chiamato, verrà generato un evento pianto fra 1s-5s.
        /// </summary>
        private void GenerateRandomCrying()
        {
            Timer timer = new Timer(new Random().Next(1000, 5000));
            timer.AutoReset = false;

            /* « timer.Elapsed » è l'evento che viene generato dal Timer timer ogni volta che s'esaurisce. */
            /* « timer.Elapsed xxx += xyz » : il "+=" aggancia il metodo "xyz" all' evento "timer.Elapsed". */
            //timer.Elapsed += NotifyCry;

            timer.Start();
        }


        void NotifyCry()
        {
            Console.WriteLine($"\nIl bambino {Name} sta piangendo.\n");

            if (StartedCrying != null)
            {

            }
            else
            {
                Console.WriteLine($"{Name} passa al lato oscuro!");
            }

            StartedCrying.Invoke(this);

            //timer.Start();

        }





        // Usando gl'eventi, non è più necessario tener traccia dei Comforter
        //public void AddComforter(ComfortBaby ComfortChild)
        //{
        //    _comforters.Add(ComfortChild);
        //}

        //public void RemoveComforter(ComfortBaby ComfortChild)
        //{
        //    _comforters.Remove(ComfortChild);
        //}

        private List<ComfortBaby> _comforters;
    }

    abstract class Parent : Person
    {
        public Parent(string name)
            : base(name)
        { }

        public Baby Child { get; set; }
        public abstract void ComfortChild(Baby baby);
    }

    class Mum : Parent
    {
        public Mum(string name)
            : base(name)
        {
            Patience = 3;
        }

        public override void ComfortChild(Baby baby)
        {
            if (Patience > 0)
            {
                Console.WriteLine($"{Name} prende in braccio {baby.Name} e lo culla");
                Patience--;
            }
            else
            {
                Console.WriteLine($"{Name} scappa con Chewbecca");
                //baby.RemoveComforter(ComfortChild);
            }
        }

        public void Comfort(Dad dad)
        { Console.WriteLine($"{Name} da' una pacca sulla spalla a {dad}."); }

        public void MakeBaby(Dad dad, string name)
        {
            Baby baby = new Baby(name);
            Child = baby;
            dad.Child = baby;
            //???
            //baby.AddComforter(dad.ComfortChild);
            //baby.AddComforter(/*this.*/ComfortChild);
            Console.WriteLine($"{Name} ha fatto un figlio con {dad.Name}, che si chiama {baby.Name}");
        }

        public int Patience { get; private set; }
    }

    class Dad : Parent
    {
        public Dad(string name)
            : base(name)
        { }

        public override void ComfortChild(Baby baby)
        {
            Console.WriteLine($"{Name} compra un biglietto per il Messico");
            //baby.RemoveComforter(/*this.*/ComfortChild);
        }
    }

    class Robot
    {
        public Robot(string name)
        {
            Name = name;
        }

        public string Name { get; }

        public void ComfortChild(Baby baby)
        {
            Console.WriteLine($"{Name} genera una frequenza armonica su cui sincronizza i movimenti delle sue braccia per cullare {baby.Name}");
        }
    }

    static class TheForce
    {
        public static void ComfortChild(Baby baby)
        {
            Console.WriteLine($"La Forza  mostra al bambino {baby.Name} il fantasma di Obi-Wan Kenobi.");
        }
    }

    delegate void ComfortBaby(Baby baby);
}