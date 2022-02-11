using System;
using System.Linq;

namespace Task01
{
    public delegate void SquareSizeChanged(double a);

    class Square
    {
        double x_ul;
        public double X_ul { get => x_ul; set { x_ul = value; OnSizeChanged(GetWidth()); } }
        double y_ul;
        public double Y_ul { get => y_ul; set { y_ul = value; OnSizeChanged(GetHeight()); } }
        double x_dr;
        public double X_dr { get => x_dr; set { x_dr = value; OnSizeChanged(GetWidth()); } }
        double y_dr;
        public double Y_dr { get => y_dr; set { y_dr = value; OnSizeChanged(GetHeight()); } }

        public event SquareSizeChanged OnSizeChanged;

        public Square(double x1, double y1, double x2, double y2)
        {
            x_ul = x1;
            y_ul = y1;
            x_dr = x2;
            y_dr = y2;
        }

        double GetWidth()
        {
            return Math.Abs(x_dr - x_ul);
        }

        double GetHeight()
        {
            return Math.Abs(y_dr - y_ul);
        }
    }

    class Program
    {
        public static void SquareConsoleInfo(double a)
        {
            Console.WriteLine($"{a:f2}");
        }
        static void Main(string[] args)
        {
            int[] coords = Array.ConvertAll<string, int>(Console.ReadLine().Trim().Split(), (a) => int.Parse(a));
            Square square = new(coords[0], coords[1], coords[2], coords[3]);
            square.OnSizeChanged += SquareConsoleInfo;
            while (true)
            {
                coords = Array.ConvertAll<string, int>(Console.ReadLine().Trim().Split(), (a) => int.Parse(a));
                square.X_dr = coords[0];
                square.Y_dr = coords[1];
            }
        }
    }
}
