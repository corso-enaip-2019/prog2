using System;
using System.Collections.Generic;
using System.Linq;

namespace Solid_Principles_03
{
    class Program
    {
        static void Main(string[] args)
        {
            var square = new WrongSquare(5);
            Console.WriteLine($"square con lati: {square.Width}, {square.Height}");

            square.Width = 6;
            Console.WriteLine($"square con lati: {square.Width}, {square.Height}");

            var rectangles = new List<WrongRectangle>
            {
                new WrongRectangle(7, 2),
                new WrongRectangle(7, 10),
                new WrongSquare(7),
            };

            Console.WriteLine($"total height: {rectangles.Sum(x => x.Height)}");

            foreach (var r in rectangles)
                r.Width = 11;

            // essendo rettangoli, ci aspettiamo che, avendo modificato tutte le larghezze,
            // l'altezza totale resti uguale.
            // Invece cambia:
            Console.WriteLine($"total height: {rectangles.Sum(x => x.Height)}");

            // Perché uno dei rettangoli in realtà è un quadrato,
            // che ha cambiato la logica di indipendenza dei due lati, legandoli uno all'altro.

            // Quando una classe, nell'estendere un'altra,
            // cambia il comportamento della classe base in un modo che rompe la logica della classe base,
            // allora ereditare NON è stata una buona scelta.

            // Questo è il terzo principio SOLID, il principo di sostituzione di Liskov.

            Console.Read();
        }
    }

    // Intuitivamente, il quadrato deriva dal rettangolo,
    // perché ha le caratteristiche del rettangolo (gli angoli tutti uguali),
    // e aggiunge proprietà in più (i lati tutti uguali).

    // Quindi implementeremmo le due classi in questo modo:

    class WrongRectangle
    {
        public WrongRectangle(int width, int height)
        {
            Width = width;
            Height = height;
        }

        public virtual int Width { get; set; }
        public virtual int Height { get; set; }
    }

    class WrongSquare : WrongRectangle
    {
        public WrongSquare(int side)
            : base(side, side)
        {
            _side = side;
        }

        // Con gli override delle due proprietà dei lati,
        // mi assicuro che siano sempre uguali, come un quadrato deve essere.
        public override int Height
        {
            get { return _side; }
            set { _side = value; }
        }

        public override int Width
        {
            get { return _side; }
            set { _side = value; }
        }

        private int _side;
    }

    // Problema concettuale: mi trovo un quadrato che invece di avere una sola proprietà Lato,
    // ha due proprietà, Altezza e Larghezza, e questo non ha senso!
    // Vedi poi nel Main() come la modifica/override di Height e Width ha rotto la logica che ci si aspettava.

    // qui sotto un design migliore, le classi Rectangle e Shape sono indipendenti l'una dall'altra:

    abstract class Shape
    {
        public abstract int CalculateArea();
    }

    class Rectangle : Shape
    {
        public Rectangle() { }
        
        public Rectangle(int width, int height)
        {
            Width = width;
            Height = height;
        }

        public int Width { get; set; }
        public int Height { get; set; }

        public override int CalculateArea()
        {
            return Width * Height;
        }
    }

    class Square : Shape
    {
        public Square() { }

        public Square(int side)
        {
            Side = side;
        }

        public int Side { get; set; }

        public override int CalculateArea()
        {
            return Side * Side;
        }
    }
}
