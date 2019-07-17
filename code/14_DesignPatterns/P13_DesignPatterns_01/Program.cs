using P13_DesignPattern_01;
using P13_DesignPattern_01.Employees;
using System;
using System.Collections.Generic;
using System.Linq;
using static P13_DesignPattern_01.Employees.HourlyPaidEmpoyee;

namespace P13_DesignPattern_01
{
    /*
     * Esercizio: implementare un sistema di Payroll.
     * Un trigger chiama l'applicazione ogni giorno alle 23:59.
     * L'applicazione itera su tutti gli impiegati registrati,
     *     e in caso sia il loro giorno di paga, calcola la paga e registra un record con il pagamento.
     * Gli impiegati di base hanno Id e Nome. Sono di 3 tipi:
     * 1) A salario fisso
     *     - hanno una proprietà con il salario fisso mensile;
     *     - il giorno di paga è l'ultimo del mese.
     * 2) A ore
     *     - hanno una paga oraria, e un elenco di record che registra per ogni giorno lavorato il numero di ore lavorate;
     *     - il giorno di paga è sempre il sabato, e calcola la paga dei giorni lun-ven della settimana corrente;
     * 3) A commissione
     *     - la paga è una percentuale sulle vendite effettuate; hanno un elenco di record con l'ammontare di una vendita e la data.
     *     - la paga è giorno per giorno, sulle vendite di quel giorno.
     *     
     * Nel Main() è illustrato l'algoritmo che si vuole ottenere.
     */
    class Program
    {
        static void Main(string[] args)
        {
            var employees = CreateMockEmployees();

            var paycheckRecords = new List<PaycheckRecord>();

            var date = new DateTime(2019, 8, 31);

            foreach(var e in employees)
            {
                if (e.IsPayDay(date))
                {
                    var paycheck = e.CalculatePay(date);
                    var record = new PaycheckRecord(e.Id, DateTime.Today, paycheck);
                    paycheckRecords.Add(record);
                }
            }

            Console.Read();
        }

        static List<Employee> CreateMockEmployees()
        {
            var fs = new FixedSalaryEmployee
            {
                Id = 1,
                Name = "Mario Rossi",
                Salary = 1500.00M,
            };

            var hp = new HourlyPaidEmpoyee
            {
                Id = 2,
                Name = "Luigi Neri",
                HourlyRate = 20,
            };
            hp.AddWorkedHours(2019, 8, 31, 4);
            hp.AddWorkedHours(2019, 8, 30, 6);
            hp.AddWorkedHours(2019, 8, 29, 2);
            hp.AddWorkedHours(2019, 8, 14, 5);

            var cp = new CommissionPaidEmployee
            {
                Id = 3,
                Name = "Anna Gialli",
                Percentage = 2,
            };

            cp.AddCommission(2019, 8, 31, 2000);
            cp.AddCommission(2019, 8, 31, 1500.50M);
            cp.AddCommission(2019, 8, 7, 3000);

            return new List<Employee> { fs, hp, cp };
        }
    }
}
