using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstConsole
{
    class Generics
    {
        static void Method(string[] args)
        {
            // Non posso istanziare un tipo con generics se:
            // 1) il tipo T non è specificato sull'oggetto e
            // 2) il tipo T non è specificato nel metodo in cui si è o nella classe che contiene il metodo.
            // Questa riga dà errore:
            //Person<T> agnostic = new Person<T>();

            Person<Cat> catLover1 = new Person<Cat>();
            catLover1.Pets.Add(new Cat() { Nickname = "Fuffi" });

            CatLover catLover2 = new CatLover();
            catLover2.Pets.Add(new Cat() { Nickname = "Socks" });

            Person<Dog> dogLover1 = CreateLover<Dog>();
            dogLover1.Pets.Add(new Dog { Nickname = "Whiskey" });
        }

        // Un metodo può essere dichiarato con uno o più parametri generics:
        static Person<T> CreateLover<T>()
        {
            return new Person<T>();
        }
    }

    class Animal
    {
        public string Nickname { get; set; }
    }

    class Cat : Animal { }

    class Dog : Animal { }

    // Una classe può dichiarare uno o più parametri generic:
    class Person<T>
    {
        public string Name { get; set; }
        public List<T> Pets { get; set; }
    }

    // Una classe derivata può specificare un tipo concreto al posto di T:
    class CatLover : Person<Cat> { }

    class DogLover : Person<Dog> { }

    // Una classe derivata può anche NON specificare il tipo di T,
    // e continuare a "portarselo dietro" come parametro generic:
    class Lover<T> : Person<T> { }

    // Su un parametro generic si possono aggiungere dei vincoli,
    // ad esempio la classe base del tipo generic:
    class MuchAnimalLover<T> : Person<T> where T : Animal { }
    // per chi è "molto amante degli animali", il tipo T deve derivare da Animal.

    // Se derivo una classe che ha vincoli sui generic, devo replicare quei vincoli:
    class MuchMuchAnimalLover<T> : MuchAnimalLover<T> where T : Animal { }
    // altrimenti ho un errore in compilazione.

    // Non posso derivare 'MuchAnimalLover' usando un generic che non derivi da Animal.
    // 'string' NON deriva da 'Animal', quindi la riga seguente dà errore:
    //class StringLover : MuchAnimalLover<string> { }
}
