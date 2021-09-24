using System;

namespace Task02
{
    class Program
    {
        static double a, b, c;
        static double Func(double x)
        {
            if (x - 1.2 < 0.000001)
                return a * x * x + b * x + c;
            if (x - 1.2 > 0.000001)
                return (a + b * x) / Math.Sqrt(x * x + 1);
            return a / x + Math.Sqrt(x * x + 1);
        }

        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            input = input.Replace(",", ".");
            string[] arg = input.Trim().Split();
            double.TryParse(arg[0], out a);
            double.TryParse(arg[1], out b);
            double.TryParse(arg[2], out c);
            for (double x = 1; x - 2 <= 0.000001; x += 0.05)
            {
                Console.WriteLine(x + " " + Func(x));
            }

        }
    }
}
