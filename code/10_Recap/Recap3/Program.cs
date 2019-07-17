using System;

namespace Recap3
{
    class Program
    {
        static void Main(string[] args)
        {
            int i = 1;

            // valori di base sono copiati tra i metodi,
            // quindi modificare i dentro Increment
            // NON cambia il valore i del Main
            // anche se il nome del parametro di Increment è lo stesso.
            Increment(i);

            // i del Main è rimasto a 1
            Console.WriteLine(i);

            // proviamo anche per gli array
            int[] intArray = new int[3];
            intArray[0] = 123;
            intArray[1] = -14;
            intArray[2] = 0;

            Increment(intArray);

            Console.WriteLine(intArray[0]);

            Console.Read();
        }

        static void Increment(int i)
        {
            i++;
        }

        static void Increment(int[] array)
        {
            array = new int[3];

            for(int i = 0; i < array.Length; i++)
            {
                array[i]++;
            }
        }
    }
}
