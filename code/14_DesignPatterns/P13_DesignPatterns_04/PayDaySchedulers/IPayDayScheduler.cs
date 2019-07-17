using System;
using System.Collections.Generic;
using System.Text;

namespace P13_DesignPatterns_04.PayDaySchedulers
{
    interface IPayDayScheduler
    {
        bool IsPayDay(DateTime date);
        // con una tupla, posso evitare di creare un'intera classe
        // solo per raggruppare le due date di un intervallo di tempo.
        (DateTime Start, DateTime End) GetPayInterval(DateTime date);
    }
}
