using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;

namespace Web0101WebAPI.Models
{
    public class SuperHero
    {
        [Required]
        public int ID { get; set; }

        [Required]
        public string NameHero { get; set; }

        [Required]
        public string NameSecret { get; set; }

        [Range(1, 100)]
        public int Strength { get; set; }

        public double AssetsValue { get; set; }
        public bool CanFly { get; set; }
        public string Powers { get; set; }

        public List<Villain> Enemies { get; set; }

        //public SHero(int iD, string nameHero, string nameSecret, int strength, double assetsValue, bool canFly, string powers)
        //{
        //    ID = iD;
        //    NameHero = nameHero;
        //    NameSecret = nameSecret;
        //    Strength = strength;
        //    AssetsValue = assetsValue;
        //    CanFly = canFly;
        //    Powers = powers;
        //}
    }
}