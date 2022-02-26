using System;
using System.Linq;

namespace Task01
{
    delegate void CoordChanged(Dot dot);

    class Dot
    {
        double x;
        double y;

        public event CoordChanged OnCoordChanged;

        public Dot(double x, double y)
        {
            this.x = x;
            this.y = y;
        }

        public void DotFlow()
        {
            Random rand = new();
            for (int i = 0; i < 10; i++)
            {
                x = rand.NextDouble() * 20 - 10;
                y = rand.NextDouble() * 20 - 10;
                if (x < 0 && y < 0)
                {
                    OnCoordChanged(this);
                }
            }
        }

        public override string ToString()
        {
            return $"{x:f2} {y:f2}";
        }
    }

    class Program
    {
        public static void PrintInfo(Dot A)
        {
            Console.WriteLine(A);
        }

        static void Main(string[] args)
        {
            double[] xy = Console.ReadLine().Split().Select(double.Parse).ToArray();
            Dot D = new(xy[0], xy[1]);
            D.OnCoordChanged += PrintInfo;
            D.DotFlow();
        }
    }
}
