using System;
using System.Collections.Generic;
using System.Text;

namespace FromInstanceToJsonXml_const
{
    class Person
    {
        public string FullName { get; }
        public int Age { get; }
        public decimal Salary { get; }

        public Person(string name, string surname, int age, decimal salary)
        {
            FullName = $"{name} - {surname.ToUpper()}";
            Age = age;
            Salary = salary;
        }

    }
}