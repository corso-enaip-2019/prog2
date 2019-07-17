using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace P19_Web_Dynamic_06_MVC.ViewModels
{
    public class VillainForSuperHeroEditViewModel
    {
        public int ID { get; set; }
        public string NameVillain { get; set; }

        public VillainForSuperHeroEditViewModel(int iD, string nameVillain)
        {
            ID = iD;
            NameVillain = nameVillain;
        }
    }
}