using System;
using System.Collections.Generic;
using System.Text;

namespace PayDay_d.PayCheckCalculators
{
    class NullPayCalculator : BasePayCheckCalculator
    {
        #region Singleton
        /*  ctor privato. */
        private NullPayCalculator()
        {

        }

        /* Proprietà statica pubblica (istanza). */
        public static NullPayCalculator _Instance { get; }


        /* ctor  */
        /*
        public static _Instance
        {
            get
            {
                if (_Instance == null)
                    return new NullPayCalculator(); 

                return _Instance;
            }
        }       
        */

        /*
         static NullPayCheckCalculator()
    {
        Instance = new NullPayCheckCalculator();
    }

    public static NullPayCheckCalculator Instance { get; }

    private NullPayCheckCalculator() { }

    public decimal CalculatePay(Employee employee, DateTime startDate, DateTime endDate)
    {
        return 0;
    }
    */
        #endregion

        #region Metodi _inerti_
        protected override decimal CalculateAmount(Employee employee, DateTime startDate, DateTime endDate)
        {
            return 0m;
        }
        #endregion
    }
}