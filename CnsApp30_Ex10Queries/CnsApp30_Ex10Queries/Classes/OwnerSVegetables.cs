using System;
using System.Collections.Generic;
using System.Text;

namespace CnsApp30_Ex10Queries.Classes
{
    class OwnerSVegetables
    {
        public string Name { get; set; }
        public List<VegetablePercentage> ListOfVegetablesPercentage { get; set; }

        public OwnerSVegetables() { }

        public OwnerSVegetables(string ownerSName, List<VegetablePercentage> inListOfVegetablesPercentage)
        {
            Name = ownerSName;
            ListOfVegetablesPercentage = inListOfVegetablesPercentage;
        }
    }
}