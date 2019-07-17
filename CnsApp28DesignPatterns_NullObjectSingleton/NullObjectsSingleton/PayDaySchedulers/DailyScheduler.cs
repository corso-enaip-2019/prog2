using System;

namespace PayDay_d.PayDaySchedulers
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