﻿using System.Collections.Generic;

namespace CSharp
{
    class DataStructures
    {
        public void Array()
        {
            string[] stringhe = new string[4];
            int[] interi = new int[10];
            double[] numeri;

            stringhe[0] = "uno";
            string primaStringa = stringhe[0];
            primaStringa = "due";

            int dim = 5;
            numeri = new double[dim];
        }

        public void List()
        {
            List<string> stringhe;
            stringhe = new List<string>();
            stringhe.Add("uno");
            //new List<string>();
            string uno = stringhe[0];

            List<int> interi = new List<int>();
            interi.Add(1);
            interi.Remove(1);
        }

        public void Queue()
        {
            Queue<string> codaStringhe = new Queue<string>();
            codaStringhe.Enqueue("uno");
            string nextElement = codaStringhe.Peek();
            nextElement = codaStringhe.Dequeue();
        }

        public void Stack()
        {
            Stack<int> stackInteri = new Stack<int>();
            stackInteri.Push(1);
            int first = stackInteri.Peek();
            first = stackInteri.Pop();
        }

        public void Dictionary()
        {
            Dictionary<int, string> dictionary = new Dictionary<int, string>();
            dictionary.Add(1, "uno");
            dictionary.Add(2, "due");

            System.Diagnostics.Debug.WriteLine(dictionary[2]);
        }
    }
}
