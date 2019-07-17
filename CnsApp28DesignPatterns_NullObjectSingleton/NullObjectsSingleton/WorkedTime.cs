using System;

namespace PayDay_d

{
    public struct WorkedTime
    {
        public WorkedTime(int year, int month, int day, int hours)
        {
            Date = new DateTime(year, month, day);
            Hours = hours;
        }

        public WorkedTime(DateTime date, int hours)
        {
            Date = date;
            Hours = hours;
        }

        public DateTime Date { get; }
        public int Hours { get; }
    }
}