using System;
using System.Collections.Generic;
using System.Text;

namespace CnsApp30_Ex10Queries.Classes
{
    class VegetableSExtension
    {
        //Vegetable` and `TotalExtension
        public string Vegetable { get; set; }
        public int TotalExtension { get; set; }

        public VegetableSExtension() { }

        public VegetableSExtension(string cropSName, int totalCultivatedExtension)
        {
            Vegetable = cropSName;
            TotalExtension = totalCultivatedExtension;
        }
    }
}