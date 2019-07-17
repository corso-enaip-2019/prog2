using System;

namespace P13_DesignPatterns_04.PayDaySchedulers
{
    class DailyScheduler : IPayDayScheduler
    {
        public (DateTime Start, DateTime End) GetPayInterval(DateTime date)
        {
            return (date.Date, date.Date.AddDays(1));
        }

        public bool IsPayDay(DateTime date)
        {
            return true;
        }
    }
}
