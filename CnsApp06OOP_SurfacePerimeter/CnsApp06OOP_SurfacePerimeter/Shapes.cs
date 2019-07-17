using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CnsApp06OOP_SurfacePerimeter
{
    #region Interfaccia
    interface IShape
    {

    }


    #endregion

    #region Classe astratta equivalente all_interfaccia
    /*da scrivere meglio*/
    abstract class Shape
    {


        public float Surface { get; set; }
        public float Perimeter { get; set; }
        public string NameOfShape { get; set; }

        abstract public float CalculateSurface();
        abstract public float CalculatePerimeter();

    }
    #endregion

    //da scrivere bene class RegularShape : Shape
    //class RegularShape : Shape
    //{
    //    public float RSSide { get; set; }
    //    public int NumberOfSides { get; set; }



    //    public RegularShape(int inNumberOfSides, float inRSSide)
    //    {
    //        NumberOfSides = inNumberOfSides;
    //        RSSide = inRSSide;
    //    }


    //    /*
    //    float CalculateSurface(int inNumberOfSides, float inRSSide)
    //    { return rBase * rHeigh; }
    //    */

    //    float CalculatePerimeter(int numberOfSides, float rSSide)
    //    { return numberOfSides * rSSide; }

    //}

    class Rectangle : Shape
    {
        public float Width { get; set; }
        public float Height { get; set; }



        public Rectangle(float inRectangleWidth, float inRectangleHeigh)
        {
            NameOfShape = "rectangle";
            Width = inRectangleWidth;
            Height = inRectangleHeigh;
            Surface = CalculateSurface();
            Perimeter = CalculatePerimeter();
            //Surface = CalculateSurface(Width, Height);
            //Perimeter = CalculatePerimeter(Width, Height);
        }

        float CalulateSurface()
        { return Width * Height; }

        float CalculateSurface(float width, float height)
        { return width * height; }

        float CalculatePerimeter()
        { return (Width + Height) * 2; }

        float CalculatePerimeter(float Width, float Heigh)
        { return (Width + Heigh) * 2; }
    }
    
    class Square : Shape
    {
        public float Side { get; set; }



        public Square(float inSquareSide)
        {
            Side = inSquareSide;
            Surface = CalculateSurface(Side);
            Perimeter = CalculatePerimeter(Side);
        }



        float CalculateSurface(float side)
        { return side * side; }

        float CalculateSurface2(float side)
        {
            Double sideDou = (double)side;
            double surfaceDou = Math.Pow(sideDou, 2);
            float surface = (float)surfaceDou;
            return surface;
        }

        float CalculatePerimeter(float side)
        { return side * 4; }
    }
    
    class Circle : Shape
    {
        public float Radius { get; set; }
        public float Circumference { get; set; }



        public Circle(float inCircleRadius)
        {
            Radius = inCircleRadius;
            Surface = CalculateSurface(Radius);
            Circumference = CalculateCircumference(Radius);
            Perimeter = Circumference;
        }



        float CalculateCircumference(float radius)
        { return 2 * ((float)Math.PI) * Radius; }

        float CalculateCircumference2(float radius)
        {
            double radiusDou = (double)radius;
            double circumferenceDou = 2 * Math.PI * radiusDou;
            float circumference = (float)circumferenceDou;

            return circumference;
        }

        float CalculateSurface(float radius)
        { return ((float)Math.PI) * radius * radius; }

        float CalculateSurface2(float radius)
        {
            double radiusDou = (double)radius;
            double surfaceDou = Math.PI * Math.Pow(radius, 2);
            float surface = (float)surfaceDou;

            return surface;
        }
    }
    
    class Triangle : Shape
    {
        public float A { get; set; }
        public float B { get; set; }
        public float C { get; set; }

        #region ctor
        public Triangle(float inSideOfAnEquilateralTriangle)
        {
            A = inSideOfAnEquilateralTriangle;
            B = A;
            C = A;
            Surface = CalculateSurface(A);
            Perimeter = CalculatePerimeter(A);
        }

        public Triangle(float inBaseOfAnIsoscelesTriangle, float inSidesOfAnIsoscelesTriangle)
        {
            A = inBaseOfAnIsoscelesTriangle;
            B = inSidesOfAnIsoscelesTriangle;
            C = B;
            Surface = CalculateSurface(A, B);
            Perimeter = CalculatePerimeter(A, B);
        }

        public Triangle(float in_A_OfAScalenTriangle, float in_B_OfAScalenTriangle, float in_C_OfAScalenTriangle)
        {
            A = in_A_OfAScalenTriangle;
            B = in_B_OfAScalenTriangle;
            C = in_C_OfAScalenTriangle;
            Surface = CalculateSurface(A, B, C);
            Perimeter = CalculatePerimeter(A, B, C);
        }
        #endregion



        float CalculateSurface(float sideA, float sideB, float sideC)
        {
            /* [formula per area qualsiasi triangolo] */
            return -3.14f;
        }

        float CalculateSurface(float isoTriBase, float isoTriSide)
        {
            float b = isoTriBase;
            float l = isoTriSide;
            float h = CalculateCathetusOfARightTriangle(l,(b/2));
            float surface = b * h / 2;
            return surface;
        }

        float CalculateSurface(float equTriSide)
        {
            float l = equTriSide;
            float h = CalculateCathetusOfARightTriangle(l, (l/2));
            float surface = l * h / 2;
            return surface;
        }


        float CalculatePerimeter(float a, float b, float c)
        { return a + b + c; }

        float CalculatePerimeter(float isoTriBase, float isoTriSide)
        { return isoTriBase + 2 * isoTriSide; }

        float CalculatePerimeter(float equTriSide)
        { return equTriSide * 3; }


        float CalculateHypotenusesOfARightTriangle(float c1, float c2)
        {
            double c1Dou = (double)c1;
            double c2Dou = (double)c2;
            double hypotenusesDou = Math.Sqrt(Math.Pow(c1Dou, 2) + Math.Pow(c2Dou, 2));
            float hypotenuses = (float)hypotenusesDou;

            return hypotenuses;
        }

        float CalculateCathetusOfARightTriangle(float Hyp, float c2)
        {
            double HypDou = (double)Hyp;
            double c2Dou = (double)c2;
            double c1Dou = Math.Sqrt(Math.Pow(Hyp, 2) - Math.Pow(c2, 2));
            float c1 = (float)c1Dou;

            return c1;
        }
    }

}