using System;
using System.Timers;

namespace StarWars3_Events
{
    class Program
    {
        static void Main(string[] args)
        {
            Robot r2d2 = new Robot("R2D2");

            Mum leila = new Mum("Leila");
            Dad hanSolo = new Dad("Han Solo");

            leila.MakeBaby(hanSolo, "Kylo Ren");

            leila.Child.StartedCrying += r2d2.Comfort;
            leila.Child.StartedCrying += TheForce.ComfortChild;

            // NON posso invocare un evento fuori dalla classe
            // in cui l'ho dichiarato.
            //leila.Child.StartedCrying.Invoke(leila.Child);

            Console.Read();
        }
    }

    abstract class Person
    {
        public Person(string name)
        {
            Name = name;
        }

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
            GenerateRandomCrying();
        }

        private void GenerateRandomCrying()
        {
            Timer timer = new Timer(new Random().Next(1000, 10000));
            timer.AutoReset = false;
            timer.Elapsed += NotifyCry;
            timer.Start();
        }

        private void NotifyCry(object sender, ElapsedEventArgs e)
        {
            Console.WriteLine();
            Console.WriteLine($"{Name} ha cominciato a piangere in modo assordante");

            if (StartedCrying != null)
            {
                StartedCrying.Invoke(this);
                GenerateRandomCrying();
            }
            else
            {
                Console.WriteLine($"{Name} passa al lato oscuro");
            }
        }

        public event ComfortBaby StartedCrying;
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
                baby.StartedCrying -= ComfortChild;
            }
        }

        public void MakeBaby(Dad dad, string name)
        {
            Baby baby = new Baby(name);
            Child = baby;
            dad.Child = baby;
            baby.StartedCrying += dad.ComfortChild;
            baby.StartedCrying += ComfortChild;
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
            baby.StartedCrying -= ComfortChild;
        }

        // Questo metodo NON rispetta la firma del delegate, quindi NON può essere usato
        // in AddComforter o RemoveComforter
        //public void ComfortChildAndMum(Baby b, Mum m) { }

        // Questo metodo rispetta la firma del delegate, quindi può essere usato
        //public void CleanBaby(Baby b) { }
    }

    class Robot
    {
        public Robot(string name)
        {
            Name = name;
        }

        public string Name { get; }

        public void Comfort(Baby baby)
        {
            Console.WriteLine($"{Name} genera una frequenza armonica su cui sincronizza i movimenti delle sue braccia per cullare {baby.Name}");
        }

        public void Comfort(Robot babyRobot)
        {
            // ...
        }

        public void Comfort(Dad dad)
        {
            Console.WriteLine($"{Name} dà una pacca sulla spalla a {dad.Name}");
        }
    }

    static class TheForce
    {
        public static void ComfortChild(Baby baby)
        {
            Console.WriteLine($"La Forza mostra a {baby.Name} il fantasmino di Obi-Wan Kenobi");
        }
    }

    delegate void ComfortBaby(Baby baby);
}
