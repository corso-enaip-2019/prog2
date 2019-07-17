using System;
using System.Collections.Generic;
using System.Linq;

namespace StarWars1
{
    class Program
    {
        static void Main(string[] args)
        {
            // questa sarebbe la sintassi con i getter e setter invece delle proprietà:
            //b.SetName("Pippo");
            //Console.WriteLine(b.GetName());

            // le Proprietà, rispetto ai getter e setter, mi permettono anche
            // operazioni di post/pre-increment, ecc.
            //obj.IntValue++;
            //obj.SetIntValue(obj.GetIntValue() + 1);

            Robot r2d2 = new Robot("R2D2");

            Mum leila = new Mum("Leila");
            Dad hanSolo = new Dad("Han Solo");

            leila.MakeBaby(hanSolo, "Kylo Ren");

            leila.Child.AddComforter(r2d2);

            leila.Child.StartCrying();
            leila.Child.StartCrying();
            leila.Child.StartCrying();
            leila.Child.StartCrying();
            leila.Child.StartCrying();

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
            _comforters = new List<IComforter>();
        }

        public void StartCrying()
        {
            Console.WriteLine($"{Name} ha cominciato a piangere in modo assordante");

            if (_comforters.Count > 0)
                foreach (IComforter p in _comforters.ToList())
                    p.ComfortChild(this);
            else
                Console.WriteLine($"{Name} passa al lato oscuro");
        }

        public void AddComforter(IComforter p)
        {
            _comforters.Add(p);
        }

        public void RemoveComforter(IComforter p)
        {
            _comforters.Remove(p);
        }

        private List<IComforter> _comforters;
    }

    abstract class Parent : Person, IComforter
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
                baby.RemoveComforter(this);
            }
        }

        public void MakeBaby(Dad dad, string name)
        {
            Baby baby = new Baby(name);
            Child = baby;
            dad.Child = baby;
            baby.AddComforter(dad);
            baby.AddComforter(this);
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
            baby.RemoveComforter(this);
        }
    }

    /*
     * Grazie alle interfacce ho disaccoppiato la classe Baby
     * dalla classe Parent: ora chiunque abbia un metodo "ComfortBaby"
     * può essere un consolatore del bambino, anche un robot come R2D2.
     * 
     * Disaccoppiare è utilissimo. Ad esempio, se voglio testare il Baby,
     * posso creare del Comforter di test, e fare delle prove con il Baby isolato
     * dalle altre classi dell'applicazione.
     */
    interface IComforter
    {
        void ComfortChild(Baby baby);
    }

    class Robot : IComforter
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
}
