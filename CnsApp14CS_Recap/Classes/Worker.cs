using System;
using System.Collections.Generic;
using System.Text;

namespace Classes
{
    class Worker
    {
        public string Name;
        public string Surname;
        public string Gender;
        public string Address;

        public decimal Salary;

        public Worker(string name, string surname, string gender, string address, decimal salary)
        {
            this.Name = name;
            this.Surname = surname;
            this.Gender = gender;
            this.Address = address;
            this.Salary = salary;
        }
    }
}
