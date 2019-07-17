using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Text;

namespace P15_Tests_04_LinkedList.MoreStructuredTests
{
    [TestClass]
    public class MyLinkedListBase
    {
        protected MyLinkedList<string> _ll;

        [TestInitialize]
        public void MyLinkedListTestInitialize()
        {
            _ll = new MyLinkedList<string>();
        }

        [TestCleanup]
        public void MyLinkedListTestCleanup()
        {
            // ...
        }
    }
}
