using System;
using System.Collections.Generic;
using System.Text;

namespace CnsAppPayments
{
    interface IEmployee
    {
        int ID { get; }
        string Name { get; }
        string Surname { get; }

        decimal CalculatePay();
        bool IsPayDay(DateTime day);
        bool IsPayDay_b(DateTime day);
    }
}
