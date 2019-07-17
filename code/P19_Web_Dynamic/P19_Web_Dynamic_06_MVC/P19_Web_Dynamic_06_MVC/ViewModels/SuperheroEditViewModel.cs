using System.ComponentModel.DataAnnotations;

using System.Collections.Generic;

using P19_Web_Dynamic_06_MVC.Models;

namespace P19_Web_Dynamic_06_MVC.ViewModels
{
    public class SuperheroEditViewModel
    {
        public int Id { get; set; }

        [Required]
        public string SecretName { get; set; }

        [Required]
        public string HeroName { get; set; }

        [Range(1, int.MaxValue)]
        public int Strength { get; set; }

        public double AssetsValue { get; set; }

        public bool CanFly { get; set; }

        public string Powers { get; set; }

        public List<int> EnemiesIDs { get; set; }
    }
}