using System;
using System.Collections.Generic;
using System.Text;

namespace CnsAppPayments.Employees
{
    class HourlyPaid : IEmployee
    {
        #region Dall_interfaccia
        public int ID { get; }
        public string Name { get; }
        public string Surname { get; }

        public decimal CalculatePay()
        {
            var now = DateTime.Today.AddDays(1);



            return 3.14m;
            //Vecchio metodo semplice
            //return HourlyPay * GetWorkedHours();
        }

        /* Viene pagato ogni Sabato. */
        public bool IsPayDay(DateTime day)
        {
            if (day.DayOfWeek == System.DayOfWeek.Saturday)
                return true;
            else
                return false;
        }

        public bool IsPayDay_b(DateTime day)
        { return (day.DayOfWeek == System.DayOfWeek.Saturday); }
        #endregion

        #region ctor
        public HourlyPaid(int iD, string name, string surname, decimal hourlyPay)
        {
            ID = iD;
            Name = name;
            Surname = surname;
            HourlyPay = hourlyPay;

            _WorkedTimes = new List<WorkedTime>();
        }

        public HourlyPaid(int iD, string name, string surname, decimal hourlyPay, decimal[] hrsWrkdPerDay)
        {
            ID = iD;
            Name = name;
            Surname = surname;
            HourlyPay = hourlyPay;
            //     throw new Exceptio(NotImplementedException);
            if (hrsWrkdPerDay.Length == 7)
            {
                _WorkedTimes = new List<WorkedTime>()
                {
                    new WorkedTime{ WorkedHours = hrsWrkdPerDay[0] },
                    new WorkedTime{ WorkedHours = hrsWrkdPerDay[1] },
                    new WorkedTime{ WorkedHours = hrsWrkdPerDay[2] },
                    new WorkedTime{ WorkedHours = hrsWrkdPerDay[3] },
                    new WorkedTime{ WorkedHours = hrsWrkdPerDay[4] },
                    new WorkedTime{ WorkedHours = hrsWrkdPerDay[5] },
                    new WorkedTime{ WorkedHours = hrsWrkdPerDay[6] }
                };
            }
            else
            {
                _WorkedTimes = new List<WorkedTime>()
                {
                    new WorkedTime{ WorkedHours = 0m },
                    new WorkedTime{ WorkedHours = 0m },
                    new WorkedTime{ WorkedHours = 0m },
                    new WorkedTime{ WorkedHours = 0m },
                    new WorkedTime{ WorkedHours = 0m },
                    new WorkedTime{ WorkedHours = 0m },
                    new WorkedTime{ WorkedHours = 0m }
                };
            }
        }
        #endregion

        public decimal HourlyPay { get; }
        /* _WorkedTimes = Lista di paghe giornaliere (D-S). */
        private List<WorkedTime> _WorkedTimes { get; set; }
        public IEnumerable<WorkedTime> WorkedTimes { get { return _WorkedTimes; } }

        /* Classe innestata WorkedTime. */
        public class WorkedTime
        {
            public decimal WorkedHours { get; set; }

            public void ResetWorkedHours()
            { WorkedHours = 0m; }

            public decimal GetWorkedHours()
            { return WorkedHours; }
        }
    }
}