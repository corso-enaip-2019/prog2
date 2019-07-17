using System;
using System.Collections.Generic;

namespace P27_NullObject_1_Try
{
    class Program
    {
        static void Main(string[] args)
        {
            var lazyEmployee = new Employee
            {
                FullName = "Mario Rossi",
                Salary = 1500,
                SoldCommissions = 5,
                BonusCalculator = new ProductionBonusCalculator(),
            };

            var productiveEmployee = new Employee
            {
                FullName = "Luigi Neri",
                Salary = 1500,
                SoldCommissions = 13,
                BonusCalculator = new ProductionBonusCalculator(),
            };

            var employees = new List<Employee>
            {
                lazyEmployee,
                productiveEmployee,
            };

            // Finché tutti gli Employee hanno un BonusCalculator settato,
            // il programma funziona bene:

            foreach (var e in employees)
                Console.WriteLine($"{e.FullName} ha guadagnato {e.CalculateSalary()} euro");

            // Però se aggiungo alla lista un nuovo Employee che NON ha il BonusCalculator
            // settato, riceverò una NullReferenceException:
            var newEmployee = new Employee
            {
                FullName = "Anna Neri",
                Salary = 2000,
                SoldCommissions = 0,
            };

            employees.Add(newEmployee);

            foreach (var e in employees)
                Console.WriteLine($"{e.FullName} ha guadagnato {e.CalculateSalary()} euro");

            Console.Read();
        }
    }
    
    class Employee
    {
        public string FullName { get; set; }
        public decimal Salary { get; set; }
        public int SoldCommissions { get; set; }

        public IBonusCalculator BonusCalculator { get; set; }

        public decimal CalculateSalary()
        {
            // Questo punto lancia una NullReferenceException se BonusCalculator è null:
            return BonusCalculator.CalculateBonus(this);

            // Per correggere il codice, dovrei modificare ogni punto in cui compare
            // "e.BonusCalculator" per verificare se il valore non sia null.
            // Ad esempio, la riga di codice sopra andrebbe scritta così:
            //if (BonusCalculator != null)
            //    return BonusCalculator.CalculateBonus(this);
            //else
            //    return 0;

            // Con questo controllo in questo punto ho risolto il problema per l'Employee...
            // Ma potrei avere N punti in cui il BonusCalculator è chiamato, dall'esterno,
            // e uno di questi punti potrebbe dimenticarsi di fare il check.
            // => NullReferenceException.
            // Queste eccezioni causano una buona parte dei bug di un'applicazione.
        }
    }

    interface IBonusCalculator
    {
        decimal CalculateBonus(Employee e);
    }

    class ProductionBonusCalculator : IBonusCalculator
    {
        public decimal CalculateBonus(Employee e)
        {
            var amount = e.Salary;

            if (e.SoldCommissions > 10)
                amount *= 1.1M;

            return amount;
        }
    }
}
