using System;
using System.Collections.Generic;

namespace P28_NullObject_2_Solution
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

            // Usando un NULL-OBJECT, non devo più scrivere costantemente controlli sui null.
            // Ad esempio non sono obbligato a istanziare in BonusCalculator quando creo
            // un'istanza di Employee:
            var newEmployee = new Employee
            {
                FullName = "Anna Neri",
                Salary = 2000,
                SoldCommissions = 0,
            };

            // Avendo modificato il set della proprietà,
            // se anche dall'esterno si prova ad assegnare null dopo la costruzione,
            // comunque sarà assegnata un'istanza di NullBonusCalculator.
            newEmployee.BonusCalculator = null;

            var employees = new List<Employee>
            {
                lazyEmployee,
                productiveEmployee,
                newEmployee,
            };

            // Ora il foreach non si rompe più, anche senza controlli sui null sparsi in giro:
            foreach (var e in employees)
                Console.WriteLine($"{e.FullName} ha guadagnato {e.CalculateSalary()} euro");

            Console.Read();
        }
    }

    class Employee
    {
        // Nel costruttore di Employee istanzio come prima cosa un NullObject.
        // Così, se qualcuno crea un Employee senza settare il BonusCalculator,
        // abbiamo comunque l'istanza di un oggetto su cui chiamare 'CalculateSalary()'.
        public Employee()
        {
            BonusCalculator = new NullBonusCalculator();
        }

        public string FullName { get; set; }
        public decimal Salary { get; set; }
        public int SoldCommissions { get; set; }

        // Impostare il NULL-OBJECT nel costruttore non basta:
        // Qualcuno potrebbe settare il valore null nella proprietà più tardi.
        // Devo modificare il set della proprietà in questo modo:
        public IBonusCalculator BonusCalculator
        {
            get { return _BonusCalculator; }
            set
            {
                if (value == null)
                    value = new NullBonusCalculator();
                _BonusCalculator = value;
            }
        }
        private IBonusCalculator _BonusCalculator;
        // a questo punto ho protetto tutti i punti in cui si potrebbe passare un valore null.


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

    // Creo una classe che implementi il concetto di "OPERAZIONI NULLE".
    // Questa classe ha gli stessi metodi delle classi operative sorelle,
    // Ma non fa niente e restituisce valori di default.
    class NullBonusCalculator : IBonusCalculator
    {
        public decimal CalculateBonus(Employee e)
        {
            return 0;
        }
    }
}
