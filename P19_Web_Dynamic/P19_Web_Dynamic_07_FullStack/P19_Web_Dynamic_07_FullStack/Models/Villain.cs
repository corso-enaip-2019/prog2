﻿using P19_Web_Dynamic_07_FullStack.Infrastructure.Attributes;
using System;
using System.ComponentModel.DataAnnotations;

namespace P19_Web_Dynamic_07_FullStack.Models
{
    public class Villain
    {
        public int Id { get; set; }

        [Required]
        public string SecretName { get; set; }

        [Required]
        public string VillainName { get; set; }

        public int KilledPeople { get; set; }

        public int KidnappedPeople { get; set; }

        [DateRange(1900, 01, 01)]
        public DateTime FirstDate { get; set; }

        [Range(1, int.MaxValue)]
        public int Strength { get; set; }

        public string Characteristics { get; set; }

        public Superhero Nemesis { get; set; }
        public int? NemesisId { get; set; }
    }
}
