using System;

namespace Task02
{
    class Point
    {
        private double x;
        private double y;
        private double polarRadius;
        private double polarAngle;

        public double X { get => x; set { x = value; } }
        public double Y { get => y; set { y = value; } }
        public double PolarRadius { get => polarRadius; }
        public double PolarAngle { get => polarAngle; }

        public Point(double x, double y)
        {
            X = x;
            Y = y;
            if (x > 0 && y >= 0)
                polarAngle = Math.Atan(y / x);
            else if (x > 0 && y < 0)
                polarAngle = Math.Atan(y / x) + 2 * Math.PI;
            else if (x > 0 && y < 0)
                polarAngle = Math.Atan(y / x) + 2 * Math.PI;
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            
        }
    }
}
