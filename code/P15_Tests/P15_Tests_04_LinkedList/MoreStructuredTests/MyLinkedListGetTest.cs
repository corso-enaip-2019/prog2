using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace P15_Tests_04_LinkedList.MoreStructuredTests
{
    [TestClass]
    public class MyLinkedListGetTest : MyLinkedListBase
    {
        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void Get_with_negative_index_throws_Exception()
        {
            _ll.Add("one");

            _ll.Get(-1);
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void Get_index_greater_than_Count_throws_Exception()
        {
            _ll.Add("one");
            _ll.Add("two");
            _ll.Add("one");
            _ll.Get(3);
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void Get_on_new_LinkedList_throws_Exception()
        {
            _ll.Get(0);
        }
    }
}
