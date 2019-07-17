using System;

namespace P20_FactoryMethod
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Write("Che forma vuoi? ");

                string input = Console.ReadLine();

                //switch (shapeInput)
                //{
                //    case "circle":
                //        var circle = new Circle();
                //        circle.AskValues();
                //        Console.WriteLine($"Area: {circle.GetArea()}; perimetro: {circle.GetPerimeter()}");
                //        break;
                //    case "rectangle":
                //        var rect = new Rectangle();
                //        rect.AskValues();
                //        Console.WriteLine($"Area: {rect.GetArea()}; perimetro: {rect.GetPerimeter()}");
                //        break;
                //    case "square":
                //        var square = new Square();
                //        square.AskValues();
                //        Console.WriteLine($"Area: {square.GetArea()}; perimetro: {square.GetPerimeter()}");
                //        break;
                //    default:
                //        Console.WriteLine("Forma non valida");
                //        break;
                //} 

                Shape shape = CreateShape(input);
                shape.AskValues();
                Console.WriteLine($"Area: {shape.GetArea()}; perimetro: {shape.GetPerimeter()}");
            }
        }
        // FACTORY METHOD
        private static Shape CreateShape(string input)
        {
            switch (input)
            {
                case "circle":
                    return new Circle();
                case "rectangle":
                    return new Rectangle();
                case "square":
                    return new Square();
                default:
                    throw new Exception();
            }
        }
    }

    abstract class Shape
    {
        public abstract double GetArea();
        public abstract double GetPerimeter();
        public abstract void AskValues();

        protected double AskValue(string message)
        {
            Console.Write(message);

            while (true)
            {
                if (double.TryParse(Console.ReadLine(), out double value))
                    return value;
                Console.Write("Valore invalido, re-inserisci: ");
            }
        }
    }

    class Circle : Shape
    {
        public double Radius { get; set; }

        public override void AskValues()
        {
            Radius = AskValue("Raggio: ");
        }

        public override double GetArea()
        {
            return Radius * Radius * Math.PI;
        }

        public override double GetPerimeter()
        {
            return Radius * 2 * Math.PI;
        }
    }

    class Rectangle : Shape
    {
        public double Width { get; set; }
        public double Height { get; set; }

        public override void AskValues()
        {
            Width = AskValue("Larghezza: ");
            Height = AskValue("Altezza: ");
        }

        public override double GetArea()
        {
            return Width * Height;
        }

        public override double GetPerimeter()
        {
            return (Width + Height) * 2;
        }
    }

    class Square : Shape
    {
        public double Side { get; set; }

        public override void AskValues()
        {
            Side = AskValue("Lato: ");
        }

        public override double GetArea()
        {
            return Side * Side;
        }

        public override double GetPerimeter()
        {
            return Side * 4;
        }
    }
}
