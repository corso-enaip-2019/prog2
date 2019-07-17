using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace P15_Tests_04_LinkedList.MoreStructuredTests
{
    [TestClass]
    public class MyLinkedListInsertTest : MyLinkedListBase
    {
        [TestInitialize]
        public void MyLinkedListInsertTestInitialize()
        {
            _ll.Add("one");
            _ll.Add("two");
            _ll.Add("three");
        }

        [TestMethod]
        public void Insert_first_works()
        {
            _ll.Insert("inserted", 0);

            Assert.AreEqual("inserted", _ll.Get(0));
            Assert.AreEqual("one", _ll.Get(1));
        }

        [TestMethod]
        public void Insert_in_the_middle_works()
        {
            _ll.Insert("inserted", 2);

            Assert.AreEqual("inserted", _ll.Get(2));
            Assert.AreEqual("three", _ll.Get(3));
        }

        [TestMethod]
        public void Insert_last_works()
        {
            _ll.Insert("inserted", 3);

            Assert.AreEqual("three", _ll.Get(2));
            Assert.AreEqual("inserted", _ll.Get(3));
        }

        [TestMethod]
        public void Insert_updates_Count()
        {
            _ll.Insert("inserted1", 0);
            Assert.AreEqual(4, _ll.Count);

            _ll.Insert("inserted2", 2);
            Assert.AreEqual(5, _ll.Count);

            _ll.Insert("inserted3", 5);
            Assert.AreEqual(6, _ll.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void Insert_index_greater_than_Count_throws_Exception()
        {
            _ll.Insert("two", 4);
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void Insert_on_negative_index_throws_Exception()
        {
            _ll.Insert("two", -2);
        }
    }
}
