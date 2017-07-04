using System;
using System.IO;
using System.Runtime.CompilerServices;

namespace CSharp7
{
    public class OutSelfDeclaring
    {
        static void Main(string[] args)
        {

        }

        public (string A, string B, string C) LookupName(long id) // tuple return type
        {

            return ("", "", ""); // tuple literal
        }

        #region Before C#7
        public void PrintCoordinates(Point p)
        {
            int x, y; // have to "predeclare"
            p.GetCoordinatesIncresedByOne(out x, out y);
            Console.WriteLine($"({x}, {y})");
        }
        #endregion

        #region With C#7
        public void PrintCoordinatesNewVersion(Point p)
        {
            var g = LookupName(4);
            p.GetCoordinatesIncresedByOne(out x, out y);
            Console.WriteLine($"({x}, {y})");
        }
        #endregion

        public void PrintStars(Point p)
        {
            string s = "s";

            if (int.TryParse(s, out var i)) { Console.WriteLine(new string('*', i)); }
            else { Console.WriteLine("Cloudy - no stars tonight!"); }


            var (x, y) = p; // deconstructing declaration
        }

        public void TesteTupla()
        {
            //var tuple = Tuple.Create("foo", 42);
            //var (name, value) = tuple;

            var file = new FileInfo("c:/teste.txt");
            var (name, extension, length) = file;
                

        }

    }

    public static class ExtensionDesconstructor
    {
        public static void Deconstruct<T1, T2>(this Tuple<T1, T2> tuple, out T1 item1, out T2 item2)
        {
            item1 = tuple.Item1;
            item2 = tuple.Item2;
        }
        public static void Deconstruct(this FileInfo reader, out long length, out string name, out string extension)
        {
            length = reader.Length;
            name = reader.Name;
            extension = reader.Extension;
        }

    }

    public class Point
    {
        private int x;
        private int y;
        public int X
        {
            get { return x; }
            set { x = value; }
        }
        public int Y
        {
            get { return y; }
            set { y = value; }
        }
        internal Point(int x, int y)
        {
            X = x;
            Y = y;
        }
        public void Deconstruct(out int x, out int y)
        {
            x = X;
            y = Y;
        }

        public Point GetCoordinatesIncresedByOne(out int x, out int y)
        {
            x = X + 1;
            y = Y + 1;
            return new Point(x, y);
        }

    }
}
