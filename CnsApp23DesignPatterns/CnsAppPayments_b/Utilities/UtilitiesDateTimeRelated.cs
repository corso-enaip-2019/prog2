using System;
using System.Collections.Generic;
using System.Text;

namespace CnsAppPayments_b.Utilities
{
    public static class UtilitiesDateTimeRelated
    {
        public static bool IsThisDayLastDayOfItsMonth(DateTime day) => (day.Day == DateTime.DaysInMonth(day.Year, day.Month));

        //public static bool IsThisDayLastDayOfItsMonth(DateTime day)
        //{
        //    return (day.Day == DateTime.DaysInMonth(day.Year, day.Month));
        //}
    }
}