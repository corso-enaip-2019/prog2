using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace P19_Web_Dynamic_06_MVC.ViewModels
{
    public class VillainOnlyIdNameViewModel
    {
        public int ID { get; set; }
        public string VillainName { get; set; }

        public VillainOnlyIdNameViewModel() { }

        public VillainOnlyIdNameViewModel(int iD, string villainName)
        {
            ID = iD;
            VillainName = villainName;
        }
    }
}