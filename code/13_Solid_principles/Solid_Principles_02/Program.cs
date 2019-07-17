using System;
using System.Collections.Generic;

namespace Solid_Principle_02
{
    // OPEN TO EXTENSION, CLOSED TO MODIFICATION
    // Una classe base dovrebbe essere tale per cui
    // una classe derivata può estendere o fare override dei membri,
    // ma senza necessità di modificare la classe base.
    class Program
    {
        static void Main(string[] args)
        {
            var wrongRect = new WRONG.Rectangle { Height = 3, Width = 7 };
            var wrongSquare = new WRONG.Square { Side = 5 };
            var wrongCircle = new WRONG.Circle { Radius = 4 };

            wrongRect.Print();
            wrongSquare.Print();
            wrongCircle.Print();

            var rect = new CORRECT.Rectangle { Height = 3, Width = 7 };
            var square = new CORRECT.Square { Side = 5 };
            var circle = new CORRECT.Circle { Radius = 4 };

            rect.Print();
            square.Print();
            circle.Print();

            var list = new List<string>();

            // Da fuori non si nota la differenza, perché in entrambi i casi chiamo Print() su Shape,
            // Però se aggiungo classi, la classe Shape assume troppi motivi per cambiare.

            Console.Read();
        }
    }

    namespace WRONG
    {
        abstract class Shape
        {
            public void Print()
            {
                if (this is Square square)
                {
                    Console.WriteLine();
                    for (int i = 0; i < square.Side; i++)
                    {
                        for(int j = 0; j < square.Side; j++)
                            Console.Write("O");
                        Console.WriteLine();
                    }
                    Console.WriteLine();
                }
                else if (this is Rectangle rect)
                {
                    Console.WriteLine();
                    for (int i = 0; i < rect.Height; i++)
                    {
                        for (int j = 0; j < rect.Width; j++)
                            Console.Write("O");
                        Console.WriteLine();
                    }
                    Console.WriteLine();
                }
                else if (this is Circle circle)
                {
                    Console.WriteLine();
                    Console.WriteLine($"Sono un cerchio di raggio {circle.Radius}");
                    Console.WriteLine();
                }
                else
                {
                    throw new InvalidOperationException();
                }
            }
        }

        class Square : Shape
        {
            public double Side { get; set; }
        }

        class Rectangle : Shape
        {
            public double Width { get; set; }
            public double Height { get; set; }
        }

        // aggiungo una terza classe:
        class Circle : Shape
        {
            public double Radius { get; set; }
        }
        // ma a questo punto devo modificare anche il metodo Print della classe base Shape!
    }

    namespace CORRECT
    {
        abstract class Shape
        {
            public abstract void Print();
        }

        class Square : Shape
        {
            public double Side { get; set; }

            public override void Print()
            {
                Console.WriteLine();

                for (int i = 0; i < Side; i++)
                {
                    for (int j = 0; j < Side; j++)
                        Console.Write("O");
                    Console.WriteLine();
                }

                Console.WriteLine();
            }
        }

        class Rectangle : Shape
        {
            public double Width { get; set; }
            public double Height { get; set; }

            public override void Print()
            {
                Console.WriteLine();

                for (int i = 0; i < Height; i++)
                {
                    for (int j = 0; j < Width; j++)
                        Console.Write("O");
                    Console.WriteLine();
                }

                Console.WriteLine();
            }
        }

        // aggiungendo una terza classe, sulla classe stessa faccio l'override di Print(),
        // e NON devo modificare la classe base Shape.
        class Circle : Shape
        {
            public double Radius { get; set; }

            public override void Print()
            {
                Console.WriteLine();
                Console.WriteLine($"Sono un cerchio di raggio {Radius}");
                Console.WriteLine();
            }
        }
    }

}
