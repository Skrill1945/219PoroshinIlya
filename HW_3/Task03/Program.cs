using System;

namespace Task03
{
    class Program
    {
        static double F(double x, double y)
        {
            if (x <= 0.5) return 1;
            return Math.Sin(Math.PI * (x - 1) / 2);
        }

        static void Main(string[] args)
        {
            double x, y;
            string input = Console.ReadLine();
            input = input.Replace(".", ",");
            string[] arg = input.Trim().Split();
            double.TryParse(arg[0], out x);
            double.TryParse(arg[1], out y);
            Console.WriteLine(F(x, y));
        }
    }
}
