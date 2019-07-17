using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace P15_Tests_01_Cup
{
    [TestClass]
    public class CupTest
    {
        [TestMethod]
        public void A_new_Cup_is_empty()
        {
            var cup = new Cup();

            Assert.IsFalse(cup.IsFull);

            // Idealmente, ogni metodo di test dovrebbe avere UN SOLO Assert,
            // in modo che se il test si rompe, ho una sola cosa da controllare.
            // Potrei avere più Assert, ma solo se comunque sto testando
            // una singola situazione, e non una sequenza di operazioni a più step.
        }

        [TestMethod]
        public void A_filled_Cup_is_full()
        {
            var cup = new Cup();
            cup.Fill();

            Assert.IsTrue(cup.IsFull);
        }

        [TestMethod]
        public void A_Cup_filled_and_drunk_is_empty()
        {
            var cup = new Cup();
            cup.Fill();
            cup.Drink();

            Assert.IsFalse(cup.IsFull);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Cannot_fill_two_consecutive_times()
        {
            var cup = new Cup();
            cup.Fill();
            cup.Fill();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Cannot_drink_from_empty_Cup()
        {
            var cup = new Cup();
            cup.Drink();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Cannot_drink_two_consecutive_times()
        {
            var cup = new Cup();
            cup.Fill();
            cup.Drink();
            cup.Drink();
        }

        [TestMethod]
        public void Can_fill_and_drink_infinite_times()
        {
            var cup = new Cup();

            for(int i = 0; i < 1000; i++)
            {
                cup.Fill();
                cup.Drink();
            }

            Assert.IsFalse(cup.IsFull);
        }
    }
}
