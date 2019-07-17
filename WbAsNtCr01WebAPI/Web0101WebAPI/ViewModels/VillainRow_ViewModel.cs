using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Web0101WebAPI.Models;

namespace Web0101WebAPI.ViewModels
{
    public class VillainRow_ViewModel
    {
        public int ID { get; set; }
        public string NameVillain { get; set; }
        public string NameSecret { get; set; }
        public int KilledPeople { get; set; }
        public int KidnappedPeople { get; set; }
        public bool CanFly { get; set; }
        public string Characteristics { get; set; }
        public SuperHero Nemesis { get; set; }

        #region istanze gia_ pronte di eroi_nemici
        //SuperHero spr = new SuperHero { ID = 1, NameSecret = "Kal El", NameHero = "SuperMan", Strength = 100, AssetsValue = 100, CanFly = true, Powers = "Heat-ray, Bullet-proof, Ice-breath" };
        //SuperHero bat = new SuperHero { ID = 2, NameSecret = "Bruce Wane", NameHero = "BatMan", Strength = 9, AssetsValue = 100_000_000_000, CanFly = false, Powers = "Ninja" };
        //SuperHero ww = new SuperHero { ID = 3, NameSecret = "Diana Prince", NameHero = "WonderWoman", Strength = 70, AssetsValue = 100_000, CanFly = true, Powers = "Truth-lazo, Bullet-proof" };
        //SuperHero plc = new SuperHero { ID = 4, NameSecret = "Police", NameHero = "Police", Strength = 5, AssetsValue = 100_000, CanFly = true, Powers = "Law, Bribes" };
        //SuperHero xvr = new SuperHero { ID = 5, NameSecret = "Charles Xavier", NameHero = "Prof.X", Strength = 1, AssetsValue = 80_000_000, CanFly = true, Powers = "PSI, Patrick Stewart" };

        //Villain jkr = new Villain { ID = 1, NameSecret = "NA", NameVillain = "The Joker", CanFly = false, Characteristics = "Mad, Poison-specialist", Debut = new DateTime(1940, 4, 25), KidnappedPeople = 1337, KilledPeople = 888, Strength = 6, Nemesis = bat };
        //Villain mgn = new Villain { ID = 2, NameSecret = "Max Eisenhardt AKA Erik Magnus Lehnsherr", NameVillain = "Magneto", CanFly = true, Characteristics = "Magnetist, Ego", Debut = new DateTime(1963, 9, 1), KidnappedPeople = 1000, KilledPeople = 2221, Strength = 3, Nemesis = xvr };
        //Villain frd = new Villain { ID = 3, NameSecret = "Fred Krueger", NameVillain = "Freddy Krueger", CanFly = false, Characteristics = "Immortal, Mask", Debut = new DateTime(1984, 1, 1), KidnappedPeople = 5, KilledPeople = 30, Strength = 10, Nemesis = plc };
        //Villain jsn = new Villain { ID = 4, NameSecret = "Jason Voorhees", NameVillain = "Jason", CanFly = false, Characteristics = "Immortal, Scalpels", Debut = new DateTime(1980, 1, 1), KidnappedPeople = 1, KilledPeople = 45, Strength = 10, Nemesis = plc };

        //List<Villain> sprEnemies = new List<Villain> { };
        //List<Villain> batEnemies = new List<Villain> { jkr };
        //List<Villain> wwEnemies = new List<Villain> { };
        //List<Villain> plcEnemies = new List<Villain> { jkr, mgn, frd, jsn };
        //List<Villain> xvrEnemies = new List<Villain> { mgn };
        #endregion
    }
}