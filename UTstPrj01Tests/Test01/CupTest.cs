using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test01Cup
{
    [TestClass]
    public class CupTest
    {
        [TestMethod]
        public void A_new_cup_is_empty()
        {
            var cup = new Cup();

            /* Idealmente ogni metodo di test contiene un singolo "Assert.", in modo che se il test si rompe, ci sia una singola cosa da controllare.
             * E' possibile avere più "Asssert.", ma solo se comunque sis ta testando una singola situazione, non una sequenza d'operazioni a/e più step. */
            Assert.IsFalse(cup.IsFull);
        }

        [TestMethod]
        public void A_filled_cup_is_full()
        {
            var cup = new Cup();
            cup.Fill();

            Assert.IsTrue(cup.IsFull);
        }

        [TestMethod]
        public void A_drunk_cup_is_empty()
        {
            var cup = new Cup();
            cup.Fill();
            cup.Drink();

            Assert.IsFalse(cup.IsFull);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Cannot_fill_2_consecutive_times()
        {
            var cup = new Cup();
            cup.Fill();
            cup.Fill();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Cannot_drink_from_an_empty_cup()
        {
            var cup = new Cup();
            cup.Drink();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Cannot_drink_2_consecutive_times()
        {
            var cup = new Cup();
            cup.Fill();
            cup.Drink();
            cup.Drink();
        }

        [TestMethod]
        public void Can_do_multiple_fill_drink_cicles()
        {
            var cup = new Cup();

            int iterations = 10000;
            for (int i = 0; i < iterations; i++)
            {
                cup.Fill();
                cup.Drink();
            }

            Assert.IsFalse(cup.IsFull);
        }
    }
}