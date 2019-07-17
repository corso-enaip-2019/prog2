using System;
using System.Collections.Generic;
using System.Text;

namespace P15_Tests_04_LinkedList
{
    public class MyLinkedList<T>
    {
        private Node _head;

        public MyLinkedList()
        {
            _head = new Node();
        }

        public void Add(T item)
        {
            var newNode = new Node { Item = item };

            var last = _head;

            while (last.Next != null)
                last = last.Next;

            last.Next = newNode;

            Count++;
        }

        public void Insert(T item, int index)
        {
            if (index < 0 || index > Count)
                throw new IndexOutOfRangeException();

            var previous = _head;

            for (int i = 0; i < index; i++)
                previous = previous.Next;

            var toInsert = new Node { Item = item };

            toInsert.Next = previous.Next;
            previous.Next = toInsert;

            Count++;
        }

        public T Get(int index)
        {
            if (index < 0 || index >= Count)
                throw new IndexOutOfRangeException();

            var toGet = _head.Next;

            for (int i = 0; i < index; i++)
                toGet = toGet.Next;

            return toGet.Item;
        }

        public void Remove(T item)
        {
            var previous = _head;
            var toRemove = _head.Next;

            while (toRemove != null && !object.Equals(toRemove.Item, item))
            {
                previous = toRemove;
                toRemove = previous.Next;
            }

            if (toRemove != null)
            {
                previous.Next = toRemove.Next;
                Count--;
            }
        }

        public int Count { get; private set; }

        private class Node
        {
            public T Item { get; set; }
            public Node Next { get; set; }
        }
    }
}
