using System;
using System.Collections.Generic;
using System.Text;

namespace PayDay_d.PayCheckCalculators
{
    /*
     * Nel pattern TEMPLATE abbiamo una classe base che espone un metodo pubblico.
     * Dentro questo metodo, ho l'algoritmo principale con le operazioni da fare.
     * - Alcune di queste operazioni possono essere già implementate in questa classe,
     *     ad esempio il metodo 'CheckParameters()' che è uguale per tutte le classi derivate;
     * - Alcune di queste operazioni invece sono specifiche dello specifico Calculator,
     *     quindi vengono dichiarate come metodi astratti, implementati nelle classi
     *     derivate (ad esempio il metodo 'CalculateAmount()').
     *  Le classi derivate devono solo implementare i singoli metodi protected abstract,
     *  senza bisogno di fare override dell'intero metodo pubblico.
     *  In questo modo "rinforzo" l'algoritmo di base,
     *  dando alle classi derivate solo la responsabilità di gestire i dettagli
     *  ognuna a modo suo.
     */
    abstract class BasePayCheckCalculator : IPayCheckCalculator
    {
        public decimal CalculatePay(Employee employee, DateTime startDate, DateTime endDate)
        {
            CheckParameters(employee, startDate, endDate);

            var amount = CalculateAmount(employee, startDate, endDate);

            return amount;
        }

        private void CheckParameters(Employee employee, DateTime startDate, DateTime endDate)
        {
            if (employee == null)
                throw new ArgumentNullException(nameof(employee));

            if (endDate < startDate)
                throw new ArgumentException(
                    $"{nameof(endDate)} < {nameof(startDate)}",
                    nameof(endDate));
        }

        protected abstract decimal CalculateAmount(Employee employee, DateTime startDate, DateTime endDate);
    }
}