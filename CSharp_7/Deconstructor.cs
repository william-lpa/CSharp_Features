using System;

namespace CSharp_7
{
    class Deconstructor //not Desconstructor
    {
        public Deconstructor()
        {
            BeforeDeconstructor();
            AfterDeconstructor();
        }

        public void BeforeDeconstructor()
        {
            var rectangle = new Rectangle(2, 5, 44, 60);
            Console.WriteLine($"Area:{rectangle.Area}, X:{rectangle.X}, Y:{rectangle.Y}");
        }
        public void AfterDeconstructor()
        {
            var (x, y, rectangleArea) = new Rectangle(2, 5, 44, 60);
            Console.WriteLine($"Area:{rectangleArea}, X:{x}, Y:{y}");
        }
    }

    struct Rectangle
    {
        public int X { get; private set; }
        public int Y { get; private set; }
        public int Width { get; private set; }
        public int Height { get; private set; }
        public double Area { get; }

        public Rectangle(int x, int y, int width, int height)
        {
            X = x;
            Y = y;
            Width = width;
            Height = height;
            Area = Height * Width;
        }
        public void Deconstruct(out int x, out int y, out double area)
        {
            x = X;
            y = Y;
            area = Area;
        }

    }
}

