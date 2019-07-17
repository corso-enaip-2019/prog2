using System;
using System.Collections.Generic;
using System.Text;

using CnsAppPayment_c;

namespace CnsAppPayments_c.Utilities
{
    public static class UtilitiesDateTimeRelated
    {
        public static bool IsThisDayLastDayOfItsMonth(DateTime day) => (day.Day == DateTime.DaysInMonth(day.Year, day.Month));

        //public static bool IsThisDayLastDayOfItsMonth(DateTime day)
        //{
        //    return (day.Day == DateTime.DaysInMonth(day.Year, day.Month));
        //}

        public static bool IsThis_Mod14Day_thDayOfThisYear(DateTime day) => (day.DayOfYear % 14 == 0);

        public static bool IsPaydayBasedOnPeriodOfPayment(DateTime day, PeriodOfPayment periodOfPayment)
        {
            bool isPayday = false;

            switch (periodOfPayment)
            {
                case PeriodOfPayment.OneOff:
                    { isPayday = true; break; }
                case PeriodOfPayment.Daily:
                    { isPayday = true; break; }
                case PeriodOfPayment.Weekly:
                    { isPayday = day.DayOfWeek == DayOfWeek.Saturday ? true : false; break; }
                case PeriodOfPayment.TwoWeeksPayd:
                    { isPayday = IsThis_Mod14Day_thDayOfThisYear(day); break; }
                case PeriodOfPayment.Monthly:
                    { isPayday = IsThisDayLastDayOfItsMonth(day); break; }
                case PeriodOfPayment.Other:
                    { isPayday = false; break; }

                default:
                    {
                        throw new NotImplementedException();
                        //break;
                    }
            }

            return isPayday;
        }

        public static void GetPeriodOfPay_CenteredOnDay_BasedOnPeriodOfPayment(DateTime inDay, PeriodOfPayment periodOfPayment, out DateTime startDate, out DateTime endDate)
        {
            startDate = new DateTime(1l);
            endDate = new DateTime(2l);

            bool isPayday = false;

            switch (periodOfPayment)
            {
                case PeriodOfPayment.OneOff:
                    {
                        startDate = new DateTime(inDay.Year, inDay.Month, inDay.Day, 0, 0, 0, 1);
                        endDate = new DateTime(inDay.Year, inDay.Month, inDay.Day, 23, 59, 59, 999);
                        break;
                    }
                case PeriodOfPayment.Daily:
                    {
                        startDate = new DateTime(inDay.Year, inDay.Month, inDay.Day, 0, 0, 0, 1);
                        endDate = new DateTime(inDay.Year, inDay.Month, inDay.Day, 23, 59, 59, 999);
                        break;
                    }
                case PeriodOfPayment.Weekly:
                    {
                        if (inDay.DayOfWeek == DayOfWeek.Saturday)
                        {
                            /* Devo sottrarre 7gg.*/
                            startDate = inDay.AddDays(-7);
                            startDate = new DateTime(startDate.Year, startDate.Month, startDate.Day, 0, 0, 0, 1);

                            /* L'endDate è già quasi pronto*/
                            endDate = new DateTime(inDay.Year, inDay.Month, inDay.Day, 23, 59, 59, 999);
                        }
                        else
                        {
                            /* Devo trovare il giorno iniziale (--giorno finché non lo trovo). */
                            startDate = inDay;
                            while (startDate.DayOfWeek != DayOfWeek.Saturday)
                            {
                                startDate = startDate.AddDays(-1);
                            }
                            startDate = new DateTime(startDate.Year, startDate.Month, startDate.Day, 0, 0, 0, 1);

                            /* Devo trovare il giorno finale (+7gg a startDate). */
                            endDate = startDate.AddDays(7);
                            endDate = new DateTime(endDate.Year, endDate.Month, endDate.Day, 23, 59, 59, 999);
                        }
                        break;
                    }
                case PeriodOfPayment.TwoWeeksPayd:
                    {
                        if (inDay.DayOfYear>=365)
                        {
                            startDate = new DateTime(inDay.Year, 12, 30, 0, 0, 0, 1);
                            startDate = new DateTime(inDay.Year, 12, 31, 23, 59, 59, 999);
                        }
                        else
                        {
                            if (IsThis_Mod14Day_thDayOfThisYear(inDay))
                            {
                                /* Devo sottrarre 14gg.*/
                                startDate = inDay.AddDays(-14);
                                startDate = new DateTime(startDate.Year, startDate.Month, startDate.Day, 0, 0, 0, 1);

                                /* L'endDate è già quasi pronto*/
                                endDate = new DateTime(inDay.Year, inDay.Month, inDay.Day, 23, 59, 59, 999);
                            }
                            else
                            {
                                /* Devo trovare il giorno iniziale (--giorno finché non lo trovo). */
                                startDate = inDay;
                                while (IsThis_Mod14Day_thDayOfThisYear(inDay))
                                {
                                    startDate = startDate.AddDays(-1);
                                }
                                startDate = new DateTime(startDate.Year, startDate.Month, startDate.Day, 0, 0, 0, 1);

                                /* Devo trovare il giorno finale (+14gg a startDate). */
                                endDate = startDate.AddDays(+14);
                                endDate = new DateTime(endDate.Year, endDate.Month, endDate.Day, 23, 59, 59, 999);
                            }
                        }
                        break;
                    }
                case PeriodOfPayment.Monthly:
                    {
                        /* La startDate è già quasi pronto*/
                        startDate = new DateTime(inDay.Year, inDay.Month, inDay.Day, 1, 0, 0, 1);

                        /* L'endDate è già quasi pronto*/
                        endDate = new DateTime(inDay.Year, inDay.Month, DateTime.DaysInMonth(inDay.Year, inDay.Month), 23, 59, 59, 999);

                        break;
                    }
                case PeriodOfPayment.Other:
                    {
                        throw new NotImplementedException();
                        //break;
                    }

                default:
                    {
                        throw new NotImplementedException();
                        //break;
                    }
            }

            return;
        }
    }
}