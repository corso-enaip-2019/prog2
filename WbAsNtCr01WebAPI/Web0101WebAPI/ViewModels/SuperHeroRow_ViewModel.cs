using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Web0101WebAPI.Models;

namespace Web0101WebAPI.ViewModels
{
    public class SuperHeroRow_ViewModel
    {
        public int ID { get; set; }
        public string NameHero { get; set; }
        public string NameSecret { get; set; }
        public bool CanFly { get; set; }
        public string Powers { get; set; }

        public List<Villain> Enemies { get; set; }

        
    }
}