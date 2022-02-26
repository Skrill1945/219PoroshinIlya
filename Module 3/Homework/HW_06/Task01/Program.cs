using System;

namespace Task01
{
    struct Point
    {
        public double x { get; init; }
        public double y { get; init; }

        public double RadiusVectorLength { get; private set; }

        public Point(double _x = 0, double _y = 0)
        {
            x = _x;
            y = _y;
            RadiusVectorLength = Math.Sqrt(x * x + y * y);
        }
        public static double Distance(Point p1, Point p2)
        {
            return p1.Distance(p2);
        }
        public double Distance(Point p)
        {
            return Math.Sqrt((x - p.x) * (x - p.x) + (y - p.y) * (y - p.y));
        }


        public override string ToString()
        {
            return $"{{{x}, {y}}}";
        }
    }

    struct Circle : IComparable
    {
        public readonly Point center;
        double rad;
        public double Rad { get => rad; set { rad = value; } }

        public Circle(double x, double y, double radius)
        {
            center = new(x, y);
            rad = radius;
        }

        public override string ToString()
        {
            return $"Circle: {center}, radius {rad}";
        }

        public int CompareTo(object obj)
        {
            if (obj.GetType() != typeof(Circle)) return 1;
            Circle a = (Circle)obj;
            if (a.center.RadiusVectorLength * a.Rad < center.RadiusVectorLength * Rad)
                return 1;
            return -1;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            int n = 5;
            Random rand = new();

            Circle[] circles = new Circle[n];
            for (int i = 0; i < n; i++)
            {
                circles[i] = new(rand.Next(-20, 21), rand.Next(-20, 21), rand.NextDouble()*10);
            }
            Array.Sort(circles, (a, b) =>
            {
                if (a.center.RadiusVectorLength * a.Rad > b.center.RadiusVectorLength * b.Rad)
                    return 1;
                return -1;
            });
            Array.Sort(circles);
            foreach (Circle c in circles)
            {
                Console.WriteLine(c);
            }
        }
    }
}
