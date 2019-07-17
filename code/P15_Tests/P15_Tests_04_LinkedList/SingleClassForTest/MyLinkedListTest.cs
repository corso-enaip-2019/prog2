using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace P15_Tests_04_LinkedList.SingleClassForTest
{
    [TestClass]
    public class MyLinkedListTest
    {
        [TestMethod]
        public void new_LinkedList_has_Count_0()
        {
            var ll = new MyLinkedList<string>();
            Assert.AreEqual(0, ll.Count);
        }

        [TestMethod]
        public void elements_are_added_in_order()
        {
            var ll = new MyLinkedList<string>();
            ll.Add("one");
            ll.Add("two");

            Assert.AreEqual("one", ll.Get(0));
            Assert.AreEqual("two", ll.Get(1));
        }

        [TestMethod]
        public void Add_updates_Count()
        {
            var ll = new MyLinkedList<string>();
            ll.Add("one");
            ll.Add("two");
            ll.Add("one");

            Assert.AreEqual(3, ll.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void Get_with_negative_index_throws_Exception()
        {
            var ll = new MyLinkedList<string>();
            ll.Add("one");

            ll.Get(-1);
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void Get_index_greater_than_Count_throws_Exception()
        {
            var ll = new MyLinkedList<string>();
            ll.Add("one");
            ll.Add("two");
            ll.Add("one");
            ll.Get(3);
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void Get_on_new_LinkedList_throws_Exception()
        {
            var ll = new MyLinkedList<string>();
            ll.Get(0);
        }

        [TestMethod]
        public void Remove_not_present_does_nothing()
        {
            var ll = new MyLinkedList<string>();
            ll.Add("one");
            ll.Add("two");
            ll.Add("one");
            ll.Remove("three");

            Assert.AreEqual("one", ll.Get(0));
            Assert.AreEqual("two", ll.Get(1));
            Assert.AreEqual("one", ll.Get(2));
        }

        [TestMethod]
        public void Remove_removes_first_occurrence()
        {
            var ll = new MyLinkedList<string>();
            ll.Add("one");
            ll.Add("two");
            ll.Add("one");
            ll.Remove("one");

            Assert.AreEqual("two", ll.Get(0));
            Assert.AreEqual("one", ll.Get(1));
        }

        [TestMethod]
        public void Remove_in_the_middle_works()
        {
            var ll = new MyLinkedList<string>();
            ll.Add("one");
            ll.Add("two");
            ll.Add("three");
            ll.Remove("two");

            Assert.AreEqual("one", ll.Get(0));
            Assert.AreEqual("three", ll.Get(1));
        }

        [TestMethod]
        public void Remove_last_works()
        {
            var ll = new MyLinkedList<string>();
            ll.Add("one");
            ll.Add("two");
            ll.Add("three");
            ll.Remove("three");

            Assert.AreEqual("one", ll.Get(0));
            Assert.AreEqual("two", ll.Get(1));
        }

        [TestMethod]
        public void Remove_updates_Count_if_item_present()
        {
            var ll = new MyLinkedList<string>();
            ll.Add("one");
            ll.Add("two");
            ll.Add("three");
            ll.Add("four");
            ll.Add("five");

            ll.Remove("one");
            Assert.AreEqual(4, ll.Count);

            ll.Remove("three");
            Assert.AreEqual(3, ll.Count);

            ll.Remove("five");
            Assert.AreEqual(2, ll.Count);
        }

        [TestMethod]
        public void Remove_doesnt_update_Count_if_item_not_present()
        {
            var ll = new MyLinkedList<string>();
            ll.Add("one");
            ll.Add("two");
            ll.Add("one");
            ll.Remove("three");

            Assert.AreEqual(3, ll.Count);
        }

        [TestMethod]
        public void Remove_null_works()
        {
            var ll = new MyLinkedList<string>();
            ll.Add(null);
            ll.Add("two");
            ll.Add("one");
            ll.Remove(null);

            Assert.AreEqual("two", ll.Get(0));
            Assert.AreEqual("one", ll.Get(1));
        }

        [TestMethod]
        public void Insert_first_works()
        {
            var ll = new MyLinkedList<string>();
            ll.Add("one");
            ll.Add("two");
            ll.Add("three");
            ll.Insert("inserted", 0);

            Assert.AreEqual("inserted", ll.Get(0));
            Assert.AreEqual("one", ll.Get(1));
        }

        [TestMethod]
        public void Insert_in_the_middle_works()
        {
            var ll = new MyLinkedList<string>();
            ll.Add("one");
            ll.Add("two");
            ll.Add("three");
            ll.Insert("inserted", 2);

            Assert.AreEqual("inserted", ll.Get(2));
            Assert.AreEqual("three", ll.Get(3));
        }

        [TestMethod]
        public void Insert_last_works()
        {
            var ll = new MyLinkedList<string>();
            ll.Add("one");
            ll.Add("two");
            ll.Add("three");
            ll.Insert("inserted", 3);

            Assert.AreEqual("three", ll.Get(2));
            Assert.AreEqual("inserted", ll.Get(3));
        }

        [TestMethod]
        public void Insert_updates_Count()
        {
            var ll = new MyLinkedList<string>();
            ll.Add("one");
            ll.Add("two");
            ll.Add("three");

            ll.Insert("inserted1", 0);
            Assert.AreEqual(4, ll.Count);

            ll.Insert("inserted2", 2);
            Assert.AreEqual(5, ll.Count);

            ll.Insert("inserted3", 5);
            Assert.AreEqual(6, ll.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void Insert_index_greater_than_Count_throws_Exception()
        {
            var ll = new MyLinkedList<string>();
            ll.Add("one");
            ll.Insert("two", 2);
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void Insert_on_negative_index_throws_Exception()
        {
            var ll = new MyLinkedList<string>();
            ll.Add("one");
            ll.Insert("two", -2);
        }
    }
}
