using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;

namespace Web02Mvc01Heroes.Models
{
    public class Villain
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
    }
}