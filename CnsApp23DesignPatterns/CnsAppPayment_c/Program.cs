using System;

using System.Collections.Generic;

namespace CnsAppPayment_c
{
    /* Weekly@Saturday, TwoWeeksPayd@every14thDayOfYear(gg365&366inBisettimanaExtra), Monthly@LastDayOfMonth */
    public enum PeriodOfPayment { OneOff = 0, Daily = 1, Weekly = 7, TwoWeeksPayd = 14, Monthly = 32, Other = 99 }
    public enum TypeOfEmployment { Commissioneer, Hourly, Fixed, Other }

    class Program
    {
        static void Main(string[] args)
        {
            bool rePlay = true;
            while (rePlay)
            {
                Console.Write("\"q\"? \a");
                rePlay = (Console.Read() != 'q') ? true : false;
            }
        }

        public static Dictionary<int, Employee> GenerateMockEmployees_Dictionary()
        {
            /* Creati singolarmente per chiarezza. */
            Employee emp01 = new Employee(1, "Mario", "Rossi", "Nota1", 2100m, 20m, 0.1m, 0.001m);
            Employee emp02 = new Employee(2, "Marco", "Nereo", "Nota2", 2100m, 30m, 0.2m, 0.001m);
            Employee emp03 = new Employee(3, "Maria", "Verdi", "Nota3", 3100m, 15m, 100m, 30.5m);
            Employee emp04 = new Employee(4, "Marck", "Weiss", "Nota4", 3100m, 30m, 200m, 30.5m);
            Employee emp05 = new Employee(5, "Marta", "Black", "Nota5", 2200m, 33m, 300m, 35.0m);
            Employee emp06 = new Employee(6, "Renzo", "Brown", "Nota6", 2000m, 22m, 400m, 35.0m);
            Employee emp07 = new Employee(7, "Fermo", "Grays", "Nota7", 2500m, 24m, 500m, 40.5m);
            Employee emp08 = new Employee(8, "Lucia", "Grays", "Nota8", 1100m, 30m, 600m, 40.5m);
            Employee emp09 = new Employee(9, "Lucio", "vdMrk", "Nota9", 5100m, 50m, 999m, 55.5m);

            return new Dictionary<int, Employee>() { { emp01.ID, emp01 }, { emp02.ID, emp02 }, { emp03.ID, emp03 }, { emp04.ID, emp04 }, { emp05.ID, emp05 }, { emp06.ID, emp06 }, { emp07.ID, emp07 }, { emp08.ID, emp08 }, { emp09.ID, emp09 } };
        }

        public static Dictionary<int, DayOfWork> Generate_MockPayRoll_Dictionary(Dictionary<int, Employee> empD)
        {
            #region temporaneo
            Employee emp01 = new Employee(1, "Mario", "Rossi", "Nota1", 2100m, 20m, 0.1m, 0.001m);
            Employee emp02 = new Employee(2, "Marco", "Nereo", "Nota2", 2100m, 30m, 0.2m, 0.001m);
            Employee emp03 = new Employee(3, "Maria", "Verdi", "Nota3", 3100m, 15m, 100m, 30.5m);
            Employee emp04 = new Employee(4, "Marck", "Weiss", "Nota4", 3100m, 30m, 200m, 30.5m);
            Employee emp05 = new Employee(5, "Marta", "Black", "Nota5", 2200m, 33m, 300m, 35.0m);
            Employee emp06 = new Employee(6, "Renzo", "Brown", "Nota6", 2000m, 22m, 400m, 35.0m);
            Employee emp07 = new Employee(7, "Fermo", "Grays", "Nota7", 2500m, 24m, 500m, 40.5m);
            Employee emp08 = new Employee(8, "Lucia", "Grays", "Nota8", 1100m, 30m, 600m, 40.5m);
            Employee emp09 = new Employee(9, "Lucio", "vdMrk", "Nota9", 5100m, 50m, 999m, 55.5m);

            Dictionary<int, Employee> ed = new Dictionary<int, Employee>() { { emp01.ID, emp01 }, { emp02.ID, emp02 }, { emp03.ID, emp03 }, { emp04.ID, emp04 }, { emp05.ID, emp05 }, { emp06.ID, emp06 }, { emp07.ID, emp07 }, { emp08.ID, emp08 }, { emp09.ID, emp09 } };
            #endregion

            /* Creati singolarmente per chiarezza. */
            DayOfWork iD = new DayOfWork(new DateTime(2018, 08, 11), ed[1], PeriodOfPayment.Daily, TypeOfEmployment.Commissioneer, 2500m, 8m, "Comissione per Azuz");

            return new Dictionary<int, DayOfWork>();
        }


        public static (Dictionary<int, Employee>, Dictionary<int, DayOfWork>) Generate_MockEmployees_AND_MockPayRoll_Dictionaries()
        {
            #region temporaneo
            Employee emp01 = new Employee(1, "Mario", "Rossi", "Nota1", 2100m, 20m, 0.1m, 0.001m);
            Employee emp02 = new Employee(2, "Marco", "Nereo", "Nota2", 2100m, 30m, 0.2m, 0.001m);
            Employee emp03 = new Employee(3, "Maria", "Verdi", "Nota3", 3100m, 15m, 100m, 30.5m);
            Employee emp04 = new Employee(4, "Marck", "Weiss", "Nota4", 3100m, 30m, 200m, 30.5m);
            Employee emp05 = new Employee(5, "Marta", "Black", "Nota5", 2200m, 33m, 300m, 35.0m);
            Employee emp06 = new Employee(6, "Renzo", "Brown", "Nota6", 2000m, 22m, 400m, 35.0m);
            Employee emp07 = new Employee(7, "Fermo", "Grays", "Nota7", 2500m, 24m, 500m, 40.5m);
            Employee emp08 = new Employee(8, "Lucia", "Grays", "Nota8", 1100m, 30m, 600m, 40.5m);
            Employee emp09 = new Employee(9, "Lucio", "vdMrk", "Nota9", 5100m, 50m, 999m, 55.5m);

            Dictionary<int, Employee> ed = new Dictionary<int, Employee>() { { emp01.ID, emp01 }, { emp02.ID, emp02 }, { emp03.ID, emp03 }, { emp04.ID, emp04 }, { emp05.ID, emp05 }, { emp06.ID, emp06 }, { emp07.ID, emp07 }, { emp08.ID, emp08 }, { emp09.ID, emp09 } };
            #endregion

            /* Creati singolarmente per chiarezza. */
            DayOfWork iD = new DayOfWork(new DateTime(2018, 08, 11), ed[1], PeriodOfPayment.Daily, TypeOfEmployment.Commissioneer, 2500m, 8m, "Comissione per Azuz");

            return (ed, new Dictionary<int, DayOfWork>());
        }
    }
}