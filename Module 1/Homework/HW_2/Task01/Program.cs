using System;

namespace Task01
{
    class Program
    {
        static double stupidIntMul(double a, int b)
        {
            double sum = 0;
            for (int i = 0; i < b; i++)
            {
                sum += a;
            }
            return sum;
        }

        static void Main(string[] args)
        {
            double x;
            while (true)
            {
                string inp = Console.ReadLine();
                try
                {
                    x = double.Parse(inp);
                    break;
                }
                catch { Console.WriteLine("Wrong input"); }
            }
            double x2 = x * x;
            Console.WriteLine((stupidIntMul(x2, 3) * (stupidIntMul(x2, 4) + stupidIntMul(x, 3) - 1) + stupidIntMul((x-2), 2)).ToString("f6"));
        }
    }
}
