using P19_Web_Dynamic_05_WebApi.Infrastructure;
using P19_Web_Dynamic_05_WebApi.Infrastructure.DomainExceptions;
using P19_Web_Dynamic_05_WebApi.Models;
using P19_Web_Dynamic_05_WebApi.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace P19_Web_Dynamic_05_WebApi.DataAccess
{
    public class Repository
    {
        static Repository()
        {
            Instance = new Repository();
        }

        public static Repository Instance { get; }

        private Repository()
        {
            var superman = new Superhero
            {
                Id = 1,
                HeroName = "Superman",
                SecretName = "Clark Kent",
                CanFly = true,
                AssetsValue = 5_000,
                Strength = 100,
                Powers = "Super laser sight, super speed"
            };
            var batman = new Superhero
            {
                Id = 2,
                HeroName = "Batman",
                SecretName = "Bruce Wayne",
                CanFly = false,
                AssetsValue = 500_000_000,
                Strength = 9,
                Powers = "",
            };
            var wonderWoman = new Superhero
            {
                Id = 3,
                HeroName = "Wonder Woman",
                SecretName = "Diana Qualcosa",
                CanFly = false,
                AssetsValue = 1_000_000,
                Strength = 70,
                Powers = "Truth string"
            };

            var penguin = new Villain
            {
                Id = 1,
                SecretName = "Osvald Cobble",
                VillainName = "The Penguin",
                KilledPeople = 20,
                KidnappedPeople = 30,
                FirstDate = new DateTime(1970, 6, 5),
                Strength = 6,
                Characteristics = "Always with an umbrella",
            };
            var lexLuthor = new Villain
            {
                Id = 2,
                SecretName = "Lex Luthor",
                VillainName = "Lex Luthor",
                KilledPeople = 5,
                KidnappedPeople = 2,
                FirstDate = new DateTime(1940, 11, 15),
                Strength = 8,
                Characteristics = "Bald",
            };
            var pete = new Villain
            {
                Id = 3,
                SecretName = "Pete",
                VillainName = "Pete",
                KilledPeople = 0,
                KidnappedPeople = 20,
                FirstDate = new DateTime(1920, 1, 1),
                Strength = 9,
                Characteristics = "A wood leg and soooo many hair",
            };
            var joker = new Villain
            {
                Id = 4,
                SecretName = "Jack Napier",
                VillainName = "Joker",
                KilledPeople = 50,
                KidnappedPeople = 10,
                FirstDate = new DateTime(1960, 10, 2),
                Strength = 6,
                Characteristics = "dressed like a clown, crazy as hell",
            };

            penguin.Nemesis = batman;
            joker.Nemesis = batman;
            lexLuthor.Nemesis = superman;

            batman.Enemies = new List<Villain> { penguin, joker };
            superman.Enemies = new List<Villain> { lexLuthor };
            wonderWoman.Enemies = new List<Villain>();

            _superheroes = new List<Superhero> { batman, superman, wonderWoman };
            _villains = new List<Villain> { penguin, joker, pete, lexLuthor };
        }

        public List<Superhero> _superheroes;
        public List<Villain> _villains;

        public List<SuperheroRowViewModel> GetAllSuperheroes()
        {
            return _superheroes
                .Select(x => new SuperheroRowViewModel
                    {
                        Id = x.Id,
                        Name = x.HeroName,
                        AssetsValue = x.AssetsValue,
                        CanFly = x.CanFly,
                        Powers = x.Powers,
                        Strength = x.Strength,
                    })
                .ToList();
        }

        public Superhero GetSuperhero(int id)
        {
            var model = _superheroes.FirstOrDefault(x => x.Id == id);

            if (model == null)
                throw new NotFoundException("superhero not found");

            return model;
        }

        public int InsertSuperhero(SuperheroEditViewModel viewModel)
        {
            if (viewModel == null)
                throw new InvalidInputException("null input");

            if (viewModel.Id != 0)
                throw new InvalidInputException("non-zero id");

            var maxId = _superheroes.Count == 0
                ? 0
                : _superheroes.Max(x => x.Id);

            var model = new Superhero
            {
                AssetsValue = viewModel.AssetsValue,
                CanFly = viewModel.CanFly,
                HeroName = viewModel.HeroName,
                Powers = viewModel.Powers,
                SecretName = viewModel.SecretName,
                Strength = viewModel.Strength,
                Enemies = new List<Villain>(),
            };

            model.Id = maxId + 1;

            _superheroes.Add(model);

            return model.Id;
        }

        public void UpdateSuperhero(int id, SuperheroEditViewModel viewModel)
        {
            if (viewModel == null)
                throw new InvalidInputException("null input");

            if (viewModel.Id == 0 || id != viewModel.Id)
                throw new InvalidInputException("invalid id");

            var old = _superheroes.FirstOrDefault(x => x.Id == viewModel.Id);

            if (old == null)
                throw new NotFoundException("superhero not found");

            old.AssetsValue = viewModel.AssetsValue;
            old.CanFly = viewModel.CanFly;
            old.HeroName = viewModel.HeroName;
            old.Powers = viewModel.Powers;
            old.SecretName = viewModel.SecretName;
            old.Strength = viewModel.Strength;
        }

        public void RemoveSuperhero(int id)
        {
            var toRemove = _superheroes.FirstOrDefault(x => x.Id == id);

            if (toRemove == null)
                throw new NotFoundException("superhero not found");

            _superheroes.Remove(toRemove);

            var villains = _villains
                .Where(x => x.Nemesis != null && x.Nemesis.Id == toRemove.Id)
                .ToList();

            foreach (var v in villains)
                v.Nemesis = null;
        }


        public List<VillainRowViewModel> GetAllVillains()
        {
            return _villains
                .Select(x => new VillainRowViewModel
                    {
                        Id = x.Id,
                        Characteristics = x.Characteristics,
                        KidnappedPeople = x.KidnappedPeople,
                        KilledPeople = x.KilledPeople,
                        Nemesis = x.Nemesis == null ? null : x.Nemesis.HeroName,
                        VillainName = x.VillainName,
                    })
                .ToList();
        }

        public Villain GetVillain(int id)
        {
            var model = _villains.FirstOrDefault(x => x.Id == id);

            if (model == null)
                throw new NotFoundException("villain not found");

            return model;
        }

        public int InsertVillain(VillainEditViewModel viewModel)
        {
            if (viewModel == null)
                throw new InvalidInputException("null input");

            if (viewModel.Id != 0)
                throw new InvalidInputException("non-zero id");

            if (viewModel.NemesisId != 0 && !_superheroes.Any(x => x.Id == viewModel.NemesisId))
                throw new InvalidInputException("nemesisId not valid");

            var maxId = _villains.Count == 0
                ? 0
                : _villains.Max(x => x.Id);

            viewModel.Id = maxId + 1;

            var model = new Villain
            {
                Id = viewModel.Id,
                SecretName = viewModel.SecretName,
                VillainName = viewModel.VillainName,
                KilledPeople = viewModel.KilledPeople,
                KidnappedPeople = viewModel.KidnappedPeople,
                FirstDate = viewModel.FirstDate,
                Strength = viewModel.Strength,
                Characteristics = viewModel.Characteristics,
                
            };

            if (viewModel.NemesisId != 0)
            {
                var superhero = _superheroes.First(x => x.Id == viewModel.NemesisId);
                model.Nemesis = superhero;
                superhero.Enemies.Add(model);
            }

            _villains.Add(model);

            return viewModel.Id;
        }

        public void UpdateVillain(int id, VillainEditViewModel viewModel)
        {
            if (viewModel == null)
                throw new InvalidInputException("null input");

            if (viewModel.Id == 0 || id != viewModel.Id)
                throw new InvalidInputException("invalid id");

            if (viewModel.NemesisId != 0 && !_superheroes.Any(x => x.Id == viewModel.NemesisId))
                throw new InvalidInputException("nemesisId not valid");

            var old = _villains.FirstOrDefault(x => x.Id == viewModel.Id);

            if (old == null)
                throw new NotFoundException("villain not found");

            old.KidnappedPeople = viewModel.KidnappedPeople;
            old.KilledPeople = viewModel.KilledPeople;
            old.SecretName = viewModel.SecretName;
            old.Strength = viewModel.Strength;
            old.VillainName = viewModel.VillainName;
            
            if (viewModel.NemesisId != 0)
            {
                if (old.Nemesis == null)
                {
                    var superhero = _superheroes.First(x => x.Id == viewModel.NemesisId);
                    old.Nemesis = superhero;
                    superhero.Enemies.Add(old);
                }
                else if(old.Nemesis.Id != viewModel.NemesisId)
                {
                    var superhero = _superheroes.First(x => x.Id == viewModel.NemesisId);
                    old.Nemesis = superhero;
                    superhero.Enemies.Add(old);
                    var oldSuperhero = _superheroes.First(x => x.Id == old.Nemesis.Id);
                    oldSuperhero.Enemies.Remove(old);
                }
            }
            else
            {
                if (old.Nemesis != null)
                {
                    var oldSuperhero = _superheroes.First(x => x.Id == old.Nemesis.Id);
                    oldSuperhero.Enemies.Remove(old);
                    old.Nemesis = null;
                }
            }
        }

        public void RemoveVillain(int id)
        {
            var toRemove = _villains.FirstOrDefault(x => x.Id == id);

            if (toRemove == null)
                throw new NotFoundException("villain not found");

            _villains.Remove(toRemove);

            toRemove.Nemesis?.Enemies.Remove(toRemove);
        }
    }
}
