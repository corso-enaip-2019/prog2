using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test02Primes
{
    [TestClass]
    public class PrimeCalculatorTest
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Negative_argument_throws_ArgumentException()
        {
            int aNegativeInt = -17;
            PrimeCalculator pc = new PrimeCalculator();
            pc.IsPrime(aNegativeInt);
        }

        [TestMethod]
        public void Zero_is_not_prime()
        {
            PrimeCalculator pc = new PrimeCalculator();

            Assert.IsFalse(pc.IsPrime(0));
        }

        [TestMethod]
        public void One_is_not_prime()
        {
            PrimeCalculator pc = new PrimeCalculator();
            Assert.IsFalse(pc.IsPrime(1));
        }

        [TestMethod]
        public void Return_true_if_argument_is_prime()
        {
            int aPrimeInt = 17;
            PrimeCalculator pc = new PrimeCalculator();

            Assert.IsTrue(pc.IsPrime(aPrimeInt));
        }

        [TestMethod]
        public void Return_false_if_argument_is_not_prime()
        {
            int notAPrimeInt = 18;
            PrimeCalculator pc = new PrimeCalculator();

            Assert.IsFalse(pc.IsPrime(notAPrimeInt));
        }
    }
}