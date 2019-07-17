using System;

namespace P13_DesignPatterns_03.PayDaySchedulers
{
    class SaturdayScheduler : IPayDayScheduler
    {
        public (DateTime Start, DateTime End) GetPayInterval(DateTime date)
        {
            var shift = ((int)DayOfWeek.Saturday) - ((int)date.DayOfWeek) + 1;

            var end = date.Date.AddDays(shift);
            var start = end.AddDays(-7);

            return (start, end);
        }

        public bool IsPayDay(DateTime date)
        {
            return date.DayOfWeek == DayOfWeek.Saturday;
        }
    }
}
