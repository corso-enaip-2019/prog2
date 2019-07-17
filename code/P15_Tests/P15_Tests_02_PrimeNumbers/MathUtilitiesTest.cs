using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace P15_Tests_02_PrimeNumbers
{
    [TestClass]
    public class MathUtilitiesTest
    {
        // per testare un insieme di numeri che hanno lo stesso output,
        // posso creare a mano un elenco e usare un foreach:
        [TestMethod]
        public void Positive_prime_numbers_return_true()
        {
            var primes = new[] { 2, 3, 5, 7, 11, 13, 17, 101, 1002523 };

            foreach (var p in primes)
                Assert.IsTrue(MathUtilities.IsPrime(p), $"input number: {p}");
        }

        // Possiamo anche parametrizzare lo stesso metodo di test:
        [TestMethod]
        [DataRow(4)]
        [DataRow(6)]
        [DataRow(8)]
        [DataRow(9)]
        [DataRow(10)]
        [DataRow(15)]
        [DataRow(77)]
        [DataRow(1002525)]
        public void Positive_non_prime_numbers_return_false(int i)
        {
            Assert.IsFalse(MathUtilities.IsPrime(i));
        }

        [TestMethod]
        public void Negative_numbers_return_false()
        {
            var negatives = new[] { -2, -3, -4, -8, -11 };

            foreach (var n in negatives)
                Assert.IsFalse(MathUtilities.IsPrime(n), $"input number: {n}");
        }

        [TestMethod]
        public void Zero_and_one_return_false()
        {
            Assert.IsFalse(MathUtilities.IsPrime(0));
            Assert.IsFalse(MathUtilities.IsPrime(1));
        }


        // Possiamo anche parametrizzare lo stesso metodo di test.
        // In questo modo, posso scrivere un unico metodo per tutti i numeri da testare:
        [TestMethod]
        [DataRow(-17, false)]
        [DataRow(0, false)]
        [DataRow(1, false)]
        [DataRow(2, true)]
        [DataRow(3, true)]
        [DataRow(4, false)]
        [DataRow(5, true)]
        [DataRow(6, false)]
        [DataRow(7, true)]
        [DataRow(8, false)]
        [DataRow(9, false)]
        [DataRow(10, false)]
        [DataRow(11, true)]
        [DataRow(13, true)]
        [DataRow(15, false)]
        [DataRow(17, true)]
        [DataRow(77, false)]
        [DataRow(101, true)]
        [DataRow(1002523, true)]
        [DataRow(1002525, false)]
        public void Numbers_is_correctly_recognized(int n, bool expectedResult)
        {
            Assert.AreEqual(expectedResult, MathUtilities.IsPrime(n));
        }

        // Questo modo di scrivere un singolo test per ogni singolo input,
        // in questo caso è un po' dispersivo,
        // perché la logica dei metodi di test è estremamente duplicata.

        //[TestMethod]
        //public void Negative_numbers_are_not_primes()
        //{
        //    Assert.IsFalse(MathUtilities.IsPrime(-17));
        //}

        //[TestMethod]
        //public void Number_0_is_not_prime()
        //{
        //    Assert.IsFalse(MathUtilities.IsPrime(0));
        //}

        //[TestMethod]
        //public void Number_1_is_not_prime()
        //{
        //    Assert.IsFalse(MathUtilities.IsPrime(1));
        //}

        //[TestMethod]
        //public void Number_2_is_prime()
        //{
        //    Assert.IsTrue(MathUtilities.IsPrime(2));
        //}

        //[TestMethod]
        //public void Number_3_is_prime()
        //{
        //    Assert.IsTrue(MathUtilities.IsPrime(3));
        //}

        //[TestMethod]
        //public void Number_4_is_not_prime()
        //{
        //    Assert.IsFalse(MathUtilities.IsPrime(4));
        //}

        //[TestMethod]
        //public void Number_5_is_prime()
        //{
        //    Assert.IsTrue(MathUtilities.IsPrime(5));
        //}

        //[TestMethod]
        //public void Number_8_is_not_prime()
        //{
        //    Assert.IsFalse(MathUtilities.IsPrime(8));
        //}

        //[TestMethod]
        //public void Number_17_is_prime()
        //{
        //    Assert.IsTrue(MathUtilities.IsPrime(17));
        //}

        //[TestMethod]
        //public void Number_1002523_is_prime()
        //{
        //    Assert.IsTrue(MathUtilities.IsPrime(1002523));
        //}

        //[TestMethod]
        //public void Number_1002525_is_not_prime()
        //{
        //    Assert.IsFalse(MathUtilities.IsPrime(1002525));
        //}
    }
}
