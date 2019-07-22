using System;

namespace P19_Web_Dynamic_06_MVC.ViewModels
{
    public class VillainEditViewModel
    {
        public int Id { get; set; }
        public string SecretName { get; set; }
        public string VillainName { get; set; }
        public int KilledPeople { get; set; }
        public int KidnappedPeople { get; set; }
        public DateTime FirstDate { get; set; }
        public int Strength { get; set; }
        public string Characteristics { get; set; }
        public int NemesisId { get; set; }
    }
}
