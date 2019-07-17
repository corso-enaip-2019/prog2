using System;
using System.Collections.Generic;
using System.Linq;

namespace _08_Linq_Test_Solution
{
    /*
    Scrivere una query di LINQ che permetta di ottenere uno dei risultati seguenti,
    in base alla squadra di appartenenza.
    1) team RED
    Un elenco di City, ognuna con:
    - nome della città
    - numero di cani totali
    - numero di gatti totali
    Includere solo le città con nome composto da più di 5 lettere.
    
    2) team GREEN
    Un elenco di Person, ognuna con:
    - nome completo (concatenando nome e cognome)
    - lista di Pet, dove Pet è classe base con proprietà Name, e classi derivate Dog e Cat, da istanziare in base al PetType
    Includere solo le persone con almeno 1 animale domestico
    
    3) team BLUE
    Un elenco di Person, ognuna con:
    - Identificativo (Nome + Cognome + trattino + Città)
    - lista di Pet (ognuno con nome e tipo), ma solo quelli di età minore di 2 anni
    
    4) team BROWN
    Un elenco di Pet, ognuno con:
    - nome
    - padrone, di tipo Person, con Id, CompleteName (Name + Surname)
    I Pet sono di due classi derivate, Dog o Cat, in base al DogType
    Includere solo i Pet il cui padrone sta a Trieste.

    5) team VIOLET
    Un elenco di città, ognuna con:
    - nome
    - numero di animali totali
    - media dell'età degli animali di quella città, espressa come double
    Includere solo i Pet il cui nome termina per vocale ("y" compresa)

    6) team YELLOW
    Un elenco di città, ognuna con:
    - nome
    - elenco di Person
    Ogni Person con:
    - cognome
    - lista di Pet
    Ogni Pet con:
    - nome
    - tipo
    Includere solo le Person femmine.

    Va scritta una sola catena di LINQ (cioè sono si possono creare risultati parziali da salvare in variabili locali).
    Alla fine della catena di metodi, concretizzare la collezione in una List<T> o in un Array<T>.
    Creare le classi adeguate (Person, Cat, Dog, Pet...).
    È permesso creare sotto metodi (ad esempio, se da un PetEntity va creato un Dog o un Cat, si può creare un metodo a parte da richiamare
    dentro la query LINQ, se lo si ritiene utile)
    */
    class Program
    {
        static void Main(string[] args)
        {
            var people = CreateMockPeople();
            var pets = CreateMockPets();

            //Red.Application.Run(people, pets);
        }

        static List<PersonEntity> CreateMockPeople()
        {
            return new List<PersonEntity>
            {
                new PersonEntity
                {
                    Id = 1,
                    Name = "Mario",
                    Surname = "Rossi",
                    City = "Trieste",
                    Gender = GenderType.Male,
                },
                new PersonEntity
                {
                    Id = 2,
                    Name = "Luigi",
                    Surname = "Neri",
                    City = "Udine",
                    Gender = GenderType.Male,
                },
                new PersonEntity
                {
                    Id = 3,
                    Name = "Anna",
                    Surname = "Gialli",
                    City = "Trieste",
                    Gender = GenderType.Female,
                },
                new PersonEntity
                {
                    Id = 4,
                    Name = "Cinzia",
                    Surname = "Bianchi",
                    City = "Gorizia",
                    Gender = GenderType.Female,
                },
                new PersonEntity
                {
                    Id = 5,
                    Name = "Barbara",
                    Surname = "Arancioni",
                    City = "Trieste",
                    Gender = GenderType.Female,
                },
                new PersonEntity
                {
                    Id = 6,
                    Name = "Matteo",
                    Surname = "Marroni",
                    City = "Udine",
                    Gender = GenderType.Male,
                },
            };
        }

        static List<PetEntity> CreateMockPets()
        {
            return new List<PetEntity>
            {
                new PetEntity
                {
                    Id = 1,
                    Name = "Fuffi",
                    OwnerId = 1,
                    Type = PetType.Dog,
                    Birth = new DateTime(2015, 5, 1),
                },
                new PetEntity
                {
                    Id = 2,
                    Name = "Luffi",
                    OwnerId = 1,
                    Type = PetType.Dog,
                    Birth = new DateTime(2015, 10, 1),
                },
                new PetEntity
                {
                    Id = 3,
                    Name = "Muffin",
                    OwnerId = 3,
                    Type = PetType.Cat,
                    Birth = new DateTime(2016, 1, 1),
                },
                new PetEntity
                {
                    Id = 4,
                    Name = "Socks",
                    OwnerId = 3,
                    Type = PetType.Cat,
                    Birth = new DateTime(2016, 4, 1),
                },
                new PetEntity
                {
                    Id = 5,
                    Name = "Whiskey",
                    OwnerId = 4,
                    Type = PetType.Dog,
                    Birth = new DateTime(2016, 10, 1),
                },
                new PetEntity
                {
                    Id = 6,
                    Name = "Champagne",
                    OwnerId = 5,
                    Type = PetType.Cat,
                    Birth = new DateTime(2017, 1, 1),
                },
                new PetEntity
                {
                    Id = 7,
                    Name = "Marameo",
                    OwnerId = 6,
                    Type = PetType.Cat,
                    Birth = new DateTime(2017, 3, 1),
                },
                new PetEntity
                {
                    Id = 8,
                    Name = "Ciccio",
                    OwnerId = 1,
                    Type = PetType.Dog,
                    Birth = new DateTime(2017, 9, 1),
                },
                new PetEntity
                {
                    Id = 9,
                    Name = "Firulais",
                    OwnerId = 4,
                    Type = PetType.Dog,
                    Birth = new DateTime(2018, 2, 1),
                },
                new PetEntity
                {
                    Id = 10,
                    Name = "Silvestro",
                    OwnerId = 5,
                    Type = PetType.Cat,
                    Birth = new DateTime(2018, 8, 1),
                }
            };
        }
    }

    namespace Red
    {
        class Application
        {
            public static void Run(List<PersonEntity> people, List<PetEntity> pets)
            {
                var result = people
                    .GroupBy(p => p.City)
                    .Select(g => new
                        {
                            CityName = g.Key,
                            People = g.Select(p => new
                            {
                                Dogs = pets.Count(a => a.OwnerId == p.Id && a.Type == PetType.Dog),
                                Cats = pets.Count(a => a.OwnerId == p.Id && a.Type == PetType.Cat),
                            })
                        })
                    .Select(cg => new City
                        {
                            Name = cg.CityName,
                            DogCount = cg.People.Sum(p => p.Dogs),
                            CatCount = cg.People.Sum(p => p.Cats)
                        })
                    .Where(x => x.Name.Length > 5)
                    .ToList();
            }
        }

        class City
        {
            public string Name { get; set; }
            public int DogCount { get; set; }
            public int CatCount { get; set; }
        }
    }

    namespace Green
    {
        class Application
        {
            public static void Run(List<PersonEntity> people, List<PetEntity> pets)
            {
                var result = people
                    .Select(p => new Person
                        {
                            FullName = $"{p.Name} {p.Surname}",
                            Pets = pets
                                .Where(x => x.OwnerId == p.Id)
                                .Select(CreatePet)
                                .ToList()
                        })
                    .Where(x => x.Pets.Count > 0)
                    .ToList();
            }

            static Pet CreatePet(PetEntity pet)
            {
                switch (pet.Type)
                {
                    case PetType.Cat:
                        return new Cat { Name = pet.Name };
                    case PetType.Dog:
                        return new Dog { Name = pet.Name };
                    default:
                        throw new InvalidOperationException();
                }
            }
        }

        class Person
        {
            public string FullName { get; set; }
            public List<Pet> Pets { get; set; }
        }

        class Pet
        {
            public string Name { get; set; }
        }

        class Dog : Pet { }

        class Cat : Pet { }
    }

    namespace Blue
    {
        class Application
        {
            public static void Run(List<PersonEntity> people, List<PetEntity> pets)
            {
                var result = people
                    .Select(p => new Person
                        {
                            Identifier = $"{p.Name} {p.Surname} - {p.City}",
                            Pets = pets
                                .Where(x => x.OwnerId == p.Id)
                                .Where(x => IsLessThan2Years(x.Birth))
                                .Select(x => new Pet
                                    {
                                        Name = x.Name,
                                        Type = x.Type
                                    })
                                .ToList()
                        })
                    .ToList();
            }

            private static bool IsLessThan2Years(DateTime birth)
            {
                var timeSpan = DateTime.Now - birth;
                return timeSpan.TotalDays / 365 < 2;

                // facile anche se non tiene conto degli anni bisestili
            }
        }

        class Person
        {
            public string Identifier { get; set; }
            public List<Pet> Pets { get; set; }
        }

        class Pet
        {
            public string Name { get; set; }
            public PetType Type { get; set; }
        }
    }

    namespace Brown
    {
        class Application
        {
            public static void Run(List<PersonEntity> people, List<PetEntity> pets)
            {
                var result = pets
                    .Select(entity =>
                        {
                            var pet = CreatePet(entity);
                            pet.Owner = new Owner
                                {
                                    Id = entity.OwnerId,
                                    CompleteName = $"{people.First(x => x.Id == entity.OwnerId).Name} {people.First(x => x.Id == entity.OwnerId).Surname}",
                                };
                            return pet;
                        })
                    .ToList();
            }

            private static Pet CreatePet(PetEntity entity)
            {
                switch (entity.Type)
                {
                    case PetType.Cat:
                        return new Cat { Name = entity.Name };
                    case PetType.Dog:
                        return new Dog { Name = entity.Name };
                    default:
                        throw new InvalidOperationException();
                }
            }
        }

        class Pet
        {
            public string Name { get; set; }
            public Owner Owner { get; set; }
        }

        class Dog : Pet { }

        class Cat : Pet { }

        class Owner
        {
            public int Id { get; set; }
            public string CompleteName { get; set; }
        }
    }

    namespace Violet
    {
        class Application
        {
            private static char[] VOWELS = new[] { 'a', 'e', 'i', 'o', 'u', 'y' };

            public static void Run(List<PersonEntity> people, List<PetEntity> pets)
            {
                var result = people
                    .GroupBy(p => p.City)
                    .Select(g => new
                        {
                            Name = g.Key,
                            OwnerIds = g.Select(x => x.Id)
                        })
                    .Select(cg => new
                        {
                            cg.Name,
                            Pets = pets
                                .Where(x => cg.OwnerIds.Contains(x.OwnerId))
                                .Where(x => VOWELS.Contains(x.Name[x.Name.Length - 1]))
                                .ToList(),
                        })
                    .Select(cg => new City
                        {
                            Name = cg.Name,
                            PetCount = cg.Pets.Count,
                            PetAgeAverage = cg.Pets.Average(p => (DateTime.Now - p.Birth).TotalDays) / 365
                        })
                    .ToList();
            }
        }

        class City
        {
            public string Name { get; set; }
            public int PetCount { get; set; }
            public double PetAgeAverage { get; set; }
        }
    }

    namespace Yellow
    {
        class Application
        {
            public static void Run(List<PersonEntity> people, List<PetEntity> pets)
            {
                var result = people
                    .GroupBy(p => p.City)
                    .Select(g => new City
                        {
                            Name = g.Key,
                            People = g
                                .Where(p => p.Gender == GenderType.Female)
                                .Select(p => new Person
                                    {
                                        Surname = p.Surname,
                                        Pets = pets
                                            .Where(pet => pet.OwnerId == p.Id)
                                            .Select(pet => new Pet
                                                {
                                                    Name = pet.Name,
                                                    Type = pet.Type,
                                                })
                                            .ToList()
                                    })
                                .ToList()
                        })
                    .ToList();
            }
        }

        class City
        {
            public string Name { get; set; }
            public List<Person> People { get; set; }
        }

        class Person
        {
            public string Surname { get; set; }
            public List<Pet> Pets { get; set; }
        }

        class Pet
        {
            public string Name { get; set; }
            public PetType Type { get; set; }
        }
    }

    class PetEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int OwnerId { get; set; }
        public PetType Type { get; set; }
        public DateTime Birth { get; set; }
    }

    class PersonEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public GenderType Gender { get; set; }
        public string City { get; set; }
    }

    enum PetType
    {
        Cat,
        Dog
    }

    enum GenderType
    {
        Male, Female
    }
}
