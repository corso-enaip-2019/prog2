using System;

namespace CnsAppPayments_b
{
    class Program
    {
        static void Main(string[] args)
        {
            List<IEmployee> empList = new List<IEmployee>(GenerateMockEmployees());
            DateTime day = DateTime.Now;


            bool rePlay = true;
            while (rePlay)
            {
                Console.WriteLine("Pagamenti d\'effettuare:");

                //decimal outPaydOfDay = GetOutPaydOfDay(day, empList);
                decimal outPaydOfDay = GetOutPaydOfDay_PlusCWSinglePayd(day, empList);

                Console.WriteLine();
                Console.WriteLine($"\t\t\tTOT: {outPaydOfDay} EUR");
                Console.WriteLine();

                Console.Write("Passa al prossimo giorno (immettere \"q\" per uscire): \a");
                day = day.AddDays(1d);
                rePlay = (Console.ReadLine() != "q") ? true : false;
                Console.WriteLine();
            }
        }

        public static List<IEmployee> GenerateMockEmployees()
        {
            /* Creati singolarmente per chiarezza. */
            IEmployee emp01 = new CommissionPaid(1, "Mario", "Rossi", 1200m);
            IEmployee emp02 = new CommissionPaid(2, "Maria", "Neri", 3200m);
            IEmployee emp03 = new CommissionPaid(3, "Marco", "Bianchi", 500m);
            IEmployee emp04 = new FixedSalary(4, "Gianna", "Red", 2200m);
            IEmployee emp05 = new FixedSalary(5, "Gianni", "Blak", 4400m);
            IEmployee emp06 = new FixedSalary(6, "Giovy", "White", 2600m);
            IEmployee emp07 = new HourlyPaid(7, "Ivan", "Rot", 25m, new decimal[] { 8m, 5m, 6.5m, 8m, 4.5m, 7m, 0m });
            IEmployee emp08 = new HourlyPaid(8, "Ifan", "Schwarz", 30m, new decimal[] { 0m, 0m, 8m, 8m, 4m, 0m, 0m });
            IEmployee emp09 = new HourlyPaid(9, "Ivanov", "Weiß", 18m, new decimal[] { 8m, 6.5m, 6.5m, 6.5m, 6.5m, 8m, 0m });

            return new List<IEmployee>() { emp01, emp02, emp03, emp04, emp05, emp06, emp07, emp08, emp09 };
        }

        public static decimal GetOutPaydOfDay_PlusCWSinglePayd(DateTime day, List<IEmployee> empList)
        {
            decimal totOutPaysToday = 0m;
            Console.WriteLine("Giorno: " + day.DayOfWeek.ToString() + ", " + day.ToString());
            Console.WriteLine("\t(It=Comm.->giorn., En=Fixed->mese, De=h->sett.)\n");

            foreach (IEmployee emp in empList)
            {
                if (emp.IsPayDay(day))
                {
                    Console.WriteLine($" ID: {emp.ID.ToString()}\t{emp.Name}\t{emp.Surname.ToUpper()}\t=> {emp.CalculatePay().ToString()} EUR ({emp.ToString()})");
                    totOutPaysToday += emp.CalculatePay();
                }

            }

            return totOutPaysToday;
        }

        public static Dictionary<string, int> GetMaxLength(List<IEmployee> inListOfEmployees)
        {
            //Dictionary<string, int> outDic = new Dictionary<string, int>()
            //{
            //    { "ID", 1},
            //    { "Name", 8},
            //    { "Surname", 8},
            //    { "Cost", 8},
            //    { "Type", 20}
            //};

            //return outDic;

            return new Dictionary<string, int>() { { "ID", 2 }, { "Name", 8 }, { "Surname", 8 }, { "Cost", 8 }, { "Type", 20 } };
        }
    }
}