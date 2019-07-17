using System;
using System.Collections.Generic;
using System.Text;

namespace CnsAppPayments.Utilities
{
    public static class UtilDateTime
    {
        public static bool IsThisDayLastDayOfMonth(DateTime day) => (day.Day == DateTime.DaysInMonth(day.Year, day.Month));

        //public static bool IsThisDayLastDayOfMonth(DateTime day)
        //{
        //    return (day.Day == DateTime.DaysInMonth(day.Year, day.Month));
        //}
    }
}