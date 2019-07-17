using P13_DesignPatterns_03.PayCheckCalculators;
using P13_DesignPatterns_03.PayDaySchedulers;
using System;
using System.Collections.Generic;

namespace P13_DesignPatterns_03
{
    /*
     * Rispetto al progetto precedente, vogliamo risolvere il problema di duplicazione
     * sui vari Calculator: tutti hanno gli stessi identici check sui parametri d'ingresso.
     * Per evitare la duplicazione possiamo usare il pattern TEMPLATE
     * (vedi classe 'BasePayCheckCalculator').
     * 
     * NOTA: Usare il pattern TEMPLATE va bene quando ho una singola funzionalità
     * che varia in modo polimorfico (qui i Calculator, il cui unico scopo
     * è calcolare l'ammontare della paga dato un Employee e un intervallo di riferimento).
     * Quando ho più funzionalità che variano in modo indipendente, è meglio usare STRATEGY.
     */
    class Program
    {
        static void Main(string[] args)
        {
            var employees = CreateMockEmployees();

            var paycheckRecords = new List<PaycheckRecord>();

            var date = new DateTime(2019, 8, 31);

            foreach (var e in employees)
            {
                if (e.IsPayDay(date))
                {
                    var paycheck = e.CalculatePay(date);

                    if (paycheck != 0)
                    {
                        var record = new PaycheckRecord(e.Id, DateTime.Today, paycheck);
                        paycheckRecords.Add(record);
                    }
                }
            }

            Console.Read();
        }

        static List<Employee> CreateMockEmployees()
        {
            var fs = new Employee
            {
                Id = 1,
                Name = "Mario Rossi",
                FixedSalary = 1500.00M,
                PayCheckCalculator = new FixedSalaryCalculator(),
                PayDayScheduler = new LastDayOfMonthScheduler(),
            };

            var hp = new Employee
            {
                Id = 2,
                Name = "Luigi Neri",
                HourlyRate = 20,
                PayCheckCalculator = new HourlyPaidCalculator(),
                PayDayScheduler = new SaturdayScheduler(),
            };
            hp.AddWorkedHours(2019, 8, 31, 4);
            hp.AddWorkedHours(2019, 8, 30, 6);
            hp.AddWorkedHours(2019, 8, 29, 2);
            hp.AddWorkedHours(2019, 8, 14, 5);

            var cp = new Employee
            {
                Id = 3,
                Name = "Anna Gialli",
                CommissionPercentage = 2,
                PayCheckCalculator = new CommissionPayCalculator(),
                PayDayScheduler = new DailyScheduler(),
            };
            cp.AddCommission(2019, 8, 31, 2000);
            cp.AddCommission(2019, 8, 31, 1500.50M);
            cp.AddCommission(2019, 8, 7, 3000);

            // creo un impiegato in più
            // con una combinazione nuova di Scheduler e Calculator
            var other = new Employee
            {
                Id = 4,
                Name = "Pino Verdi",
                CommissionPercentage = 4,
                PayCheckCalculator = new CommissionPayCalculator(),
                PayDayScheduler = new LastDayOfMonthScheduler(),
            };
            other.AddCommission(2019, 8, 31, 2000);
            other.AddCommission(2019, 8, 31, 1500.50M);
            other.AddCommission(2019, 7, 8, 3000);

            return new List<Employee> { fs, hp, cp, other };
        }
    }
}
