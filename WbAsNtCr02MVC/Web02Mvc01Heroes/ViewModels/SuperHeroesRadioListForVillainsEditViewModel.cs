using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;

namespace Web02Mvc01Heroes.ViewModels
{
    public class SuperHeroesRadioListForVillainsEditViewModel
    {
        [Required]
        [Range(1, int.MaxValue)]
        public int ID { get; set; }
        [Required]
        public string NameHero { get; set; }

        public SuperHeroesRadioListForVillainsEditViewModel(int iD, string nameHero)
        {
            ID = ID;
            NameHero = nameHero;
        }
    }
}
