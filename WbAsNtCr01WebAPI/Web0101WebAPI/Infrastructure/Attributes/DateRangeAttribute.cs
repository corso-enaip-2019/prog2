using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;

namespace Web0101WebAPI.Infrastructure.Attributes
{
    public class DateRangeAttribute : ValidationAttribute
    {
        private DateTime _start;

        public DateRangeAttribute(int startYear, int startMonth, int startDay)
        {
            _start = new DateTime(startYear, startMonth, startDay);
        }

        public override bool IsValid(object value)
        {
            return (value is DateTime date) && (_start < date && date < DateTime.Today);

            //E' possibile abbreviarla in una sola riga.
            /*if (value is DateTime date)
            {
                return (_start < date) && (date < DateTime.Today);
            }
            else
            {
                return false;
            }*/
        }
    }
}