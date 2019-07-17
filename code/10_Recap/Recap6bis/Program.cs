using System;

namespace Recap6bis
{
    class Program
    {
        // Questo esercizio è un miglioramento di Recap6.
        // In fondo al file abbiamo creato una classe Person,
        // che raggruppi tutte le informazioni che riguardano una persona.
        // Ora possiamo "portarci in giro" un semplice riferimento "p",
        // che dentro contiene tutti quei dati, invece di doverli scrivere esplicitamente ogni volta.

        static void Main(string[] args)
        {
            Person p = ReadFromConsole();

            PrintAllModes(p);

            Console.Read();
        }

        // Questo inoltre ci permette di incapsulare la lettura dei dati:
        // creiamo un'istanza di Person, che racchiude tutti i dati
        // e che possiamo poi restituire in fondo al metodo.
        private static Person ReadFromConsole()
        {
            Person p = new Person();

            Console.Write("Inserire il nome della Persona: ");
            p.Name = Console.ReadLine();

            Console.Write("Inserire il cognome della Persona: ");
            p.Surname = Console.ReadLine();

            Console.Write("Inserire il genere della Persona: ");
            p.Gender = Console.ReadLine();

            Console.Write("Inserire lo stipendio della Persona: ");
            string salaryString = Console.ReadLine();
            p.Salary = decimal.Parse(salaryString);

            Console.Write("Inserire l'indirizzo della Persona: ");
            p.Address = Console.ReadLine();

            return p;
        }

        static void PrintAllModes(Person p)
        {
            PrintInline(p);
            Console.WriteLine();
            PrintLarge(p);
        }

        static void PrintInline(Person p)
        {
            Console.Write($"nome: {p.Name}; cognome: {p.Surname}; genere: {p.Gender}; salario: {p.Salary} €; indirizzo: {p.Address}");
        }

        static void PrintLarge(Person p)
        {
            Console.WriteLine($"nome: {p.Name}");
            Console.WriteLine($"cognome: {p.Surname}");
            Console.WriteLine($"genere: {p.Gender}");
            Console.WriteLine($"salario: {p.Salary}");
            Console.WriteLine($"indirizzo: {p.Address}");
        }
    }

    class Person
    {
        public string Name;
        public string Surname;
        public string Gender;
        public decimal Salary;
        public string Address;
    }
}
