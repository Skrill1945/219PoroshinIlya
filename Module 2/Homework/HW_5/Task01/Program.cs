using System;
using System.Linq;
using System.Collections.Generic;

namespace Task01
{
    public static class Misc
    {
        public static Random rand;
        static Misc()
        {
            rand = new Random();
        }
    }

    public class Shape
    {
        public const double PI = Math.PI;
        protected double _x, _y;

        public Shape()
        {
        }

        public Shape(double x, double y)
        {
            _x = x;
            _y = y;
        }

        public virtual double Area()
        {
            return _x * _y;
        }
    }

    public class Circle : Shape
    {
        public Circle() : this(Misc.rand.NextDouble() * 10) { }
        public Circle(double r) : base(r, 0)
        {
        }

        public override double Area()
        {
            return PI * _x * _x;
        }
    }

    public class Sphere : Shape
    {
        public Sphere() : this(Misc.rand.NextDouble() * 10) { }
        public Sphere(double r) : base(r, 0)
        {
        }

        public override double Area()
        {
            return 4 * PI * _x * _x;
        }
    }

    public class Cylinder : Shape
    {
        public Cylinder() : this(Misc.rand.NextDouble() * 10, Misc.rand.NextDouble() * 10) {}

        public Cylinder(double r, double h) : base(r, h) {}

        public override double Area()
        {
            return 2 * PI * _x * _x + 2 * PI * _x * _y;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<Shape> shapes = new();
            for (int i = 0; i < Misc.rand.Next(3, 6); i++)
            {
                shapes.Add(new Circle());
            }
            for (int i = 0; i < Misc.rand.Next(3, 6); i++)
            {
                shapes.Add(new Sphere());
            }
            for (int i = 0; i < Misc.rand.Next(3, 6); i++)
            {
                shapes.Add(new Cylinder());
            }
            foreach (Shape s in shapes)
            {
                if (s is Circle)
                {
                    Console.Write("Circle ");
                }
                else if (s is Sphere)
                {
                    Console.Write("Sphere ");
                }
                else if (s is Cylinder)
                {
                    Console.Write("Cylinder ");
                }
                Console.WriteLine($"{s.Area():F2}");
            }
        }
    }
}
