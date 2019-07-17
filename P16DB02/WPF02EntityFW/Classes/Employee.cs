using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF02EntityFW.Classes
{
    public class Employee
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public float Productivity { get; set; }
        public int TotalBonus { get; set; }

        #region ctors
        public Employee() { }

        public Employee(string name, float productivity, int totalBonus)
        {
            Name = name;
            Productivity = productivity;
            TotalBonus = totalBonus;
        }

        public Employee(int iD, string name, float productivity, int totalBonus)
        {
            ID = iD;
            Name = name;
            Productivity = productivity;
            TotalBonus = totalBonus;
        }
        #endregion
    }
}