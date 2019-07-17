using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web0101WebAPI.ViewModels
{
    public class VillainEdit_ViewModel
    {
        public int ID { get; set; }
        public string NameVillain { get; set; }
        public string NameSecret { get; set; }
        public int Strength { get; set; }
        public int KilledPeople { get; set; }
        public int KidnappedPeople { get; set; }
        public DateTime Debut { get; set; }
        public bool CanFly { get; set; }
        public string Characteristics { get; set; }
        public int NemesisID { get; set; } //Qui c'è l'ID della nemesi, non l'oggetto.
    }
}