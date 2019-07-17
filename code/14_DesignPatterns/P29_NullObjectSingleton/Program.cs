using System;
using System.Collections.Generic;

namespace P29_NullObjectSingleton
{
    // Creare una nuova istanza di un NullBonusCalculator ogni volta che istanzio un Employee
    // è uno spreco:
    // 1) se subito dopo la creazione imposto un BonusCalculator normale, l'istanza del NullBonusCalculator
    //     non viene mai usata
    // 2) tutte le istanze di NullBonusCalculator fanno la stessa identica cosa,
    //     non hanno ognuna un proprio stato o dati da salvare internamente.
    // Ha quindi senso implementare un NULL-OBJECT come SINGLETON.
    // 
    class Program
    {
        static void Main(string[] args)
        {
            var employees = new List<Employee>
            {
                new Employee
                {
                    FullName = "Mario Rossi",
                    Salary = 1500,
                    SoldCommissions = 5,
                    BonusCalculator = new ProductionBonusCalculator(),
                },
                new Employee
                {
                    FullName = "Luigi Neri",
                    Salary = 1500,
                    SoldCommissions = 13,
                    BonusCalculator = new ProductionBonusCalculator(),
                },
                new Employee
                {
                    FullName = "Anna Neri",
                    Salary = 2000,
                    SoldCommissions = 0,
                }
            };

            foreach (var e in employees)
                Console.WriteLine($"{e.FullName} ha guadagnato {e.CalculateSalary()} euro");

            Console.Read();
        }
    }

    class Employee
    {
        public Employee()
        {
            BonusCalculator = NullBonusCalculator.Instance;
        }

        public string FullName { get; set; }
        public decimal Salary { get; set; }
        public int SoldCommissions { get; set; }

        public IBonusCalculator BonusCalculator
        {
            get { return _BonusCalculator; }
            set
            {
                if (value == null)
                    value = NullBonusCalculator.Instance;
                _BonusCalculator = value;
            }
        }
        private IBonusCalculator _BonusCalculator;


        public decimal CalculateSalary()
        {
            return BonusCalculator.CalculateBonus(this);
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

    class NullBonusCalculator : IBonusCalculator
    {
        static NullBonusCalculator()
        {
            Instance = new NullBonusCalculator();
        }

        public static NullBonusCalculator Instance { get; }

        private NullBonusCalculator() { }

        public decimal CalculateBonus(Employee e)
        {
            return 0;
        }
    }
}
