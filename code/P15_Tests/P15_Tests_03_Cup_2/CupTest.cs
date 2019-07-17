using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace P15_Tests_03_Cup_2
{
    [TestClass]
    public class CupTest
    {
        [TestMethod]
        public void A_new_Cup_is_empty()
        {
            var cup = new Cup();

            Assert.IsFalse(cup.IsFull);
            Assert.AreEqual(0, cup.FillLevel);
        }

        [TestMethod]
        public void A_filled_Cup_is_full()
        {
            var cup = new Cup();
            cup.Fill();

            Assert.IsTrue(cup.IsFull);
            Assert.AreEqual(Cup.MAX_FILL_LEVEL, cup.FillLevel);
        }

        [TestMethod]
        public void A_Cup_filled_and_entirely_drunk_is_empty()
        {
            var cup = new Cup();
            cup.Fill();
            cup.Drink(10);

            Assert.IsFalse(cup.IsFull);
            Assert.AreEqual(0, cup.FillLevel);
        }

        [TestMethod]
        public void A_filled_Cup_can_be_drunk_partially_more_times()
        {
            var cup = new Cup();
            cup.Fill();
            cup.Drink(3);
            cup.Drink(5);

            Assert.IsFalse(cup.IsFull);
            Assert.AreEqual(2, cup.FillLevel);
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
        public void Cannot_drink_more_than_total_quantity()
        {
            var cup = new Cup();
            cup.Fill();
            cup.Drink(15);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Cannot_drink_more_multiple_times_more_than_total_quantity()
        {
            var cup = new Cup();
            cup.Fill();
            cup.Drink(5);
            cup.Drink(6);
        }

        [TestMethod]
        public void Filling_a_partially_drunk_Cup_puts_quantity_to_10()
        {
            var cup = new Cup();
            cup.Fill();
            cup.Drink(1);
            cup.Drink(6);
            cup.Fill();

            Assert.IsTrue(cup.IsFull);
            Assert.AreEqual(Cup.MAX_FILL_LEVEL, cup.FillLevel);
        }

        [TestMethod]
        public void Can_fill_and_drink_many_times()
        {
            var cup = new Cup();

            var drinkings = new[]
            {
                new[] { 1, 2 },
                new[] { 9 },
                new[] { 10 },
                new[] { 1, 1, 1, 1, 1, 2, 1, 1, 1 },
            };

            foreach(var drinking in drinkings)
            {
                cup.Fill();
                foreach (var d in drinking)
                    cup.Drink(d);
            }

            Assert.IsFalse(cup.IsFull);
            Assert.AreEqual(0, cup.FillLevel);
        }
    }
}
