using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;

namespace Web02Mvc01Heroes.ViewModels.VillainsViewModels
{
    public class VillainsHomeListViewModel
    {
        public int ID { get; set; }

        [Required]
        public string NameVillain { get; set; }

        [Range(0, int.MaxValue)]
        public int KilledPeople { get; set; }

        [Range(1, 100)]
        public int Strength { get; set; }

        

        public VillainsHomeListViewModel(int iD, string nameVillain, int killedPeople, int strength )
        {
            ID = ID;
            NameVillain = nameVillain;
            KilledPeople = killedPeople;
            Strength = strength;
        }
    }
}