using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using Web02Mvc01Heroes.Models;

namespace Web02Mvc01Heroes.ViewModels
{
    public class VillainsVillainToEditViewModel 
    {
        public int ID { get; set; }

        [Required]
        public string NameVillain { get; set; }

        [Required]
        public string NameSecret { get; set; }

        [Range(0, int.MaxValue)]
        public int KilledPeople { get; set; }

        [Range(0, int.MaxValue)]
        public int KidnappedPeople { get; set; }

        public bool CanFly { get; set; }

        public DateTime Debut { get; set; }

        [Range(1, 100)]
        public int Strength { get; set; }

        public string Characteristics { get; set; }

        public SuperHero Nemesis { get; set; }

        public VillainsVillainToEditViewModel(int iD, string nameVillain, string nameSecret, int killedPeople, int kidnappedPeople, bool canFly, int strength, SuperHero nemesis)
        {
            ID = iD;
            NameVillain = nameVillain;
            NameSecret =nameSecret ;
            KilledPeople = killedPeople;
            KidnappedPeople =kidnappedPeople ;
            bool CanFly =canFly ;
            Strength = strength;
            Nemesis = nemesis;
        }
    }
}

