using System;
using System.Collections.Generic;
using System.Text;

namespace P13_DesignPatterns_03.PayDaySchedulers
{
    class LastDayOfMonthScheduler : IPayDayScheduler
    {
        public (DateTime Start, DateTime End) GetPayInterval(DateTime date)
        {
            var firstDayOfMonth = new DateTime(date.Year, date.Month, 1);
            return (firstDayOfMonth, firstDayOfMonth.AddMonths(1));
        }

        public bool IsPayDay(DateTime date)
        {
            return date.Day == DateTime.DaysInMonth(date.Year, date.Month);
        }
    }
}
