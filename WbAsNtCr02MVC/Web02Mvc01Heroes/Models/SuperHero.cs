using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;

namespace Web02Mvc01Heroes.Models
{
    public class SuperHero
    {
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
    }
}