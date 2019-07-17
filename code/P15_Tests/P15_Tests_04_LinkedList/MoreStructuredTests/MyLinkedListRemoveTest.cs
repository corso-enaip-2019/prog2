using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace P15_Tests_04_LinkedList.MoreStructuredTests
{
    [TestClass]
    public class MyLinkedListRemoveTest : MyLinkedListBase
    {
        [TestMethod]
        public void Remove_not_present_does_nothing()
        {
            _ll.Add("one");
            _ll.Add("two");
            _ll.Add("one");
            _ll.Remove("three");

            Assert.AreEqual("one", _ll.Get(0));
            Assert.AreEqual("two", _ll.Get(1));
            Assert.AreEqual("one", _ll.Get(2));
        }

        [TestMethod]
        public void Remove_removes_first_occurrence()
        {
            _ll.Add("one");
            _ll.Add("two");
            _ll.Add("one");
            _ll.Remove("one");

            Assert.AreEqual("two", _ll.Get(0));
            Assert.AreEqual("one", _ll.Get(1));
        }

        [TestMethod]
        public void Remove_in_the_middle_works()
        {
            _ll.Add("one");
            _ll.Add("two");
            _ll.Add("three");
            _ll.Remove("two");

            Assert.AreEqual("one", _ll.Get(0));
            Assert.AreEqual("three", _ll.Get(1));
        }

        [TestMethod]
        public void Remove_last_works()
        {
            _ll.Add("one");
            _ll.Add("two");
            _ll.Add("three");
            _ll.Remove("three");

            Assert.AreEqual("one", _ll.Get(0));
            Assert.AreEqual("two", _ll.Get(1));
        }

        [TestMethod]
        public void Remove_updates_Count_if_item_present()
        {
            _ll.Add("one");
            _ll.Add("two");
            _ll.Add("three");
            _ll.Add("four");
            _ll.Add("five");

            _ll.Remove("one");
            Assert.AreEqual(4, _ll.Count);

            _ll.Remove("three");
            Assert.AreEqual(3, _ll.Count);

            _ll.Remove("five");
            Assert.AreEqual(2, _ll.Count);
        }

        [TestMethod]
        public void Remove_doesnt_update_Count_if_item_not_present()
        {
            _ll.Add("one");
            _ll.Add("two");
            _ll.Add("one");
            _ll.Remove("three");

            Assert.AreEqual(3, _ll.Count);
        }

        [TestMethod]
        public void Remove_null_works()
        {
            _ll.Add(null);
            _ll.Add("two");
            _ll.Add("one");
            _ll.Remove(null);

            Assert.AreEqual("two", _ll.Get(0));
            Assert.AreEqual("one", _ll.Get(1));
        }
    }
}
