using System;
using System.Collections.Generic;
using System.Linq;

namespace P15_Singleton
{
    class Program
    {
        static void Main(string[] args)
        {
            var rep = new PersonRepository();

            var mario = new Person { FullName = "Mario Rossi" };
            var luigi = new Person { FullName = "Luigi Verdi" };

            rep.Add(mario);
            rep.Add(luigi);

            try
            {
                rep.Add(mario);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }

            try
            {
                rep.Update(new Person { FullName = "Fake" });
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }

            var savedMario = rep.Get(1);
            Console.WriteLine($"retrieved person name: {savedMario.FullName}");

            // NON posso creare da fuori altre istanze di 'PersonRepository':
            //var newRep = new PersonRepository();
            //newRep.Add(mario);

            Console.Read();
        }
    }

    class PersonRepository
    {
        private List<Person> _items;

        public PersonRepository()
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

            //var old = _items.FirstOrDefault(x => x.Id == p.Id);
            //if (old == null)
            //    throw new ArgumentException("Person not registered!", nameof(p));
            //var index = _items.IndexOf(old);

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
    }

    class Person
    {
        public int Id { get; set; }
        public string FullName { get; set; }
    }
}
