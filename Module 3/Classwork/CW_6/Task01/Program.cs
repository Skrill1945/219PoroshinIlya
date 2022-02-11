using System;
using System.Linq;
using System.Collections.Generic;

namespace Task01
{
    class Point
    {
        public double X { get; init; }
        public double Y { get; init; }

        public Point()
        {
            X = 0;
            Y = 0;
        }

        public Point(double _x, double _y)
        {
            X = _x;
            Y = _y;
        }

        public static double Distance(Point p1, Point p2)
        {
            return p1.Distance(p2);
        }

        public double Distance(Point p)
        {
            return Math.Sqrt((X - p.X) * (X - p.X) + (Y - p.Y) * (Y - p.Y));
        }
    }

    class TriangleComp
    {
        public Point A, B, C;
        public double AB, AC, BC;

        private double area = -1;
        public double Area 
        { 
            get {
                if (area == -1)
                {
                    double p = (AB + AC + BC) / 2;
                    return area = Math.Sqrt(p * (p - AB) * (p - AC) * (p - BC));
                }
                return area;
            } 
        }

        public TriangleComp(Point _A, Point _B, Point _C)
        {
            A = _A;
            B = _B;
            C = _C;
            AB = A.Distance(B);
            AC = A.Distance(C);
            BC = B.Distance(C);
        }

        private double sign(Point p1, Point p2, Point p3)
        {
            return (p1.X - p3.X) * (p2.Y - p3.Y) - (p2.X - p3.X) * (p1.Y - p3.Y);
        }

        public bool PointInTriangle(Point pt)
        {
            double d1, d2, d3;
            bool has_neg, has_pos;

            d1 = sign(pt, A, B);
            d2 = sign(pt, B, C);
            d3 = sign(pt, C, A);

            has_neg = (d1 < 0) || (d2 < 0) || (d3 < 0);
            has_pos = (d1 > 0) || (d2 > 0) || (d3 > 0);

            return !(has_neg && has_pos);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<TriangleComp> triangleComps = new();
            Random rand = new Random();
            for (int i = 0; i < 100000; i++)
            {
                triangleComps.Add(new TriangleComp(
                    new Point(rand.NextDouble() * 10, rand.NextDouble() * 10), 
                    new Point(rand.NextDouble() * 10, rand.NextDouble() * 10), 
                    new Point(rand.NextDouble() * 10, rand.NextDouble() * 10)));
            }
            Console.WriteLine(triangleComps.Average(t => t.Area));
            triangleComps.Sort(delegate (TriangleComp a, TriangleComp b)
            {
                if (a.Area > b.Area) return 1;
                return -1;
            });
            Console.WriteLine(triangleComps[^1].Area);
        }
    }
}
