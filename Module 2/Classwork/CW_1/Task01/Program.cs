using System;
using System.Linq;

namespace Task01
{
    class RegularPolygon
    {
        private int numOfSides;
        public int numberOfSides
        {
            get => numOfSides;
            set
            {
                numOfSides = value >= 3 ? value : 3;
            }
        }
        private double sideLen;
        public double sideLength
        {
            get => sideLen;
            set
            {
                sideLen = value > 0 ? value : 1;
            }
        }
        private double radius;
        public double innerRadius
        {
            get => radius;
            set
            {
                radius = value > 0 ? value : 1;
            }
        }

        public RegularPolygon(int numOfSides = 3, double radius = 1)
        {
            numberOfSides = numOfSides;
            innerRadius = radius;
            sideLength = 2 * innerRadius * Math.Tan(Math.PI / numberOfSides);
        }

        public double GetArea() => sideLength * sideLength * numberOfSides / (4 * Math.Tan(180 / numberOfSides * (Math.PI / 180)));

        public double GetPerimeter() => numberOfSides * sideLength;
    }

    class Program
    {
        static void Main(string[] args)
        {
            RegularPolygon rp = new RegularPolygon(4, 2);
            int n;
            n = int.Parse(Console.ReadLine());
            RegularPolygon[] arr = new RegularPolygon[n];
            for (int i = 0; i < n; i++)
            {
                int numOfSides = int.Parse(Console.ReadLine());
                double radius = double.Parse(Console.ReadLine());
                arr[i] = new RegularPolygon(numOfSides, radius);
            }
            double[] areas = new double[n];
            for (int i = 0; i < n; i++)
            {
                areas[i] = arr[i].GetArea();
            }
            double min = areas.Min(), max = areas.Max();
            for (int i = 0; i < n; i++)
            {
                if (Math.Abs(areas[i] - min) < 0.00000001)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write(min.ToString() + " ");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else if (areas[i] == max)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write(max.ToString() + " ", ConsoleColor.Green);
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else Console.Write(areas[i] + " ");
            }
        }
    }
}
