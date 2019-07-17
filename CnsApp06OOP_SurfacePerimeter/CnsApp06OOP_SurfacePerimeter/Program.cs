using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* 20190319 */

namespace CnsApp06OOP_SurfacePerimeter
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Shape> ListOfShapes = new List<Shape>();

            #region Pre-popolamento
            Rectangle rct01 = new Rectangle(24f, 0.1f);
            Rectangle rct02 = new Rectangle(222f, 300f);
            Rectangle rct03 = new Rectangle(32.25f, 111.1f);
            ListOfShapes.Add(rct01);
            ListOfShapes.Add(rct02);
            ListOfShapes.Add(rct03);

            Square sqr01 = new Square(45f);
            Square sqr02 = new Square(19.99f);
            Square sqr03 = new Square(31.779f);
            ListOfShapes.Add(sqr01);
            ListOfShapes.Add(sqr02);
            ListOfShapes.Add(sqr03);

            Circle crc01 = new Circle(12f);
            Circle crc02 = new Circle(300f);
            Circle crc03 = new Circle(24.12f);
            ListOfShapes.Add(crc01);
            ListOfShapes.Add(crc02);
            ListOfShapes.Add(crc03);

            Triangle tri01 = new Triangle(55.55f);
            Triangle tri02 = new Triangle(32.12f, 45f);
            Triangle tri03 = new Triangle(72.72f, 54.99f, 446.66f);
            ListOfShapes.Add(tri01);
            ListOfShapes.Add(tri01);
            ListOfShapes.Add(tri01);
            #endregion

            foreach (Shape shape in ListOfShapes)
            { WriteShapeText(shape); }

            Console.ReadLine();

            return;
        }

        private static void WriteShapeText(Shape shape)
        {
            string shapeName = ShapeName_En2It_IShape2String(shape);

            Console.WriteLine($"La figura è un {shapeName}.");
            Console.WriteLine($"\tLa sua area è {0:0.00}.", shape.Surface);

            if (shape is Circle)
            { Console.WriteLine($"\tLa sua circonferenza è {0:00}.", (shape as Circle).Perimeter); }
            else
            { Console.WriteLine($"\tIl suo perimetro è: {0:00}.", shape.Perimeter); }
            //Console.WriteLine();

            return;
        }

        private static string ShapeName_En2It_IShape2String(Shape inShape)
        {
            string outIta = "ND";
            switch (inShape.NameOfShape.ToLower())
            {
                case "regularshape":
                    {
                        outIta = "poligono regolare";
                        break;
                    }
                case "rectangle":
                    {
                        outIta = "rettangolo";
                        break;
                    }
                case "square":
                    {
                        outIta = "quadrato";
                        break;
                    }
                case "circle":
                    {
                        outIta = "cerchio";
                        break;
                    }
                case "triangle":
                    {
                        outIta = "triangolo";
                        break;
                    }

                case "NA":
                    {
                        outIta = "ND";
                        break;
                    }

                default:
                    {
                        outIta = "ND";
                        break;
                    }
            }

            return outIta;
        }

    }
}
