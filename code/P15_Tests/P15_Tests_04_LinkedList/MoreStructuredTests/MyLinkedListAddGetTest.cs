using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace P15_Tests_04_LinkedList.MoreStructuredTests
{
    [TestClass]
    public class MyLinkedListAddGetTest : MyLinkedListBase
    {
        [TestMethod]
        public void new_LinkedList_has_Count_0()
        {
            Assert.AreEqual(0, _ll.Count);
        }

        [TestMethod]
        public void Add_adds_items_in_order()
        {
            _ll.Add("one");
            _ll.Add("two");

            Assert.AreEqual("one", _ll.Get(0));
            Assert.AreEqual("two", _ll.Get(1));
        }

        [TestMethod]
        public void Add_updates_Count()
        {
            _ll.Add("one");
            _ll.Add("two");
            _ll.Add("one");

            Assert.AreEqual(3, _ll.Count);
        }
    }
}
