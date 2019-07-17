using System;
using System.Linq;

namespace P13_DesignPatterns_04.PayCheckCalculators
{
    /*
     * Questa classe deriva dalla classe base di template,
     * Quindi deve fare override dell'unico metodo astratto dichiarato.
     */
    class CommissionPayCalculator : BasePayCheckCalculator
    {
        protected override decimal CalculateAmount(Employee employee, DateTime startDate, DateTime endDate)
        {
            return employee.SoldCommissions
                .Where(sc => startDate < sc.Date && sc.Date < endDate)
                .Sum(sc => sc.Amount) * employee.CommissionPercentage / 100;
        }
    }
}
