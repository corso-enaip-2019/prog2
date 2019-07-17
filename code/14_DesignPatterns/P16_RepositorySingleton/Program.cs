using System;
using System.Collections.Generic;
using System.Linq;

namespace P16_RepositorySingleton
{
    class Program
    {
        static void Main(string[] args)
        {
            var mario = new Person { FullName = "Mario Rossi" };
            var luigi = new Person { FullName = "Luigi Verdi" };

            PersonRepository.Instance.Add(mario);
            PersonRepository.Instance.Add(luigi);

            try
            {
                PersonRepository.Instance.Add(mario);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }

            try
            {
                PersonRepository.Instance.Update(new Person { FullName = "Fake" });
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }

            var savedMario = PersonRepository.Instance.Get(1);
            Console.WriteLine($"retrieved person name: {savedMario.FullName}");

            // NON posso creare da fuori altre istanze di 'PersonRepository':
            //var newRep = new PersonRepository();
            //newRep.Add(mario);

            var p = new Printer();

            p.Print();

            Console.Read();
        }
    }

    class Printer
    {
        public void Print()
        {
            var people = PersonRepository.Instance.GetAll();

            foreach (var p in people)
                Console.WriteLine($"name: {p.FullName}");
        }
    }

    class PersonRepository
    {
        // implementazione primitiva che NON è thread-safe:
        // due esecuzioni parallele o asincrone potrebbero arrivare
        // a creare entrambe una loro istanza di PersonRepository
        //public static PersonRepository Instance
        //{
        //    get
        //    {
        //        if (_Instance == null)
        //            _Instance = new PersonRepository();
        //        return _Instance;
        //    }
        //}
        //private static PersonRepository _Instance;

        // SINGLETON
        // 1) costruttore privato;
        // 2) proprietà statica pubblica in solo get;
        // 3) costruttore statico che istanzia la classe.
        static PersonRepository()
        {
            Instance = new PersonRepository();
        }

        public static PersonRepository Instance { get; }

        private PersonRepository()
        {
            _items = new List<Person>();
        }

        public void Add(Person p)
        {
            if (p.Id != 0)
                throw new ArgumentException("Id già valorizzato!", nameof(p));

            var newId = _items.Count == 0
                ? 1
                : _items.Max(x => x.Id) + 1;

            p.Id = newId;

            _items.Add(p);
        }

        public void Update(Person p)
        {
            if (p.Id == 0)
                throw new ArgumentException("Id 0!", nameof(p));

            var index = _items.FindIndex(x => x.Id == p.Id);
            if (index == -1)
                throw new ArgumentException("Person not registered!", nameof(p));

            _items[index] = p;
        }

        public void Remove(int id)
        {
            var p = _items.FirstOrDefault(x => x.Id == id);

            if (p == null)
                throw new ArgumentException("Person not registered", nameof(p));

            _items.Remove(p);
        }

        public Person Get(int id)
        {
            var p = _items.FirstOrDefault(x => x.Id == id);

            if (p == null)
                throw new ArgumentException("Person not registered", nameof(p));

            return p;
        }

        public IEnumerable<Person> GetAll()
        {
            return _items.ToList();
        }

        private List<Person> _items;
    }

    class Person
    {
        public int Id { get; set; }
        public string FullName { get; set; }
    }
}
