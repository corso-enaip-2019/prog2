using System;

namespace PayDay_d.PayDaySchedulers
{
    class NullScheduler : IPayDayScheduler
    {
        #region Singleton
        /* Istanza */
        private static NullScheduler _instance;

        /*  ctor privato. */
        private NullScheduler()
        {

        }

        public static NullScheduler Instance
        {
            get
            {
                if (_instance == null)
                    return new NullScheduler();
                return _instance;
            }
        }
        #endregion

        #region Metodi _inerti_
        public (DateTime Start, DateTime End) GetPayInterval(DateTime date)
        {
            var shift = ((int)DayOfWeek.Saturday) - ((int)date.DayOfWeek) + 1;

            var end = new DateTime(1);
            var start = new DateTime(2);

            return (start, end);
        }

        public bool IsPayDay(DateTime date)
        {
            return false;
        } 
        #endregion
    }
}