using System;
using System.Collections.Generic;
using System.Text;

namespace P13_DesignPattern_01.Employees
{
    abstract class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public abstract bool IsPayDay(DateTime date);
        public abstract decimal CalculatePay(DateTime date);
    }
}
