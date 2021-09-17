using System;

namespace Task02
{
    class Program
    {

        static double ParabolaArea(double delta, double B, double A = 0)
        {
            double sum = 0;
            double x0 = A, x1 = A + delta, avg;
            while (x1 <= B)
            {
                avg = (x0 * x0 + x1 * x1) / 2;
                sum += avg * delta;
                x0 = x1;
                x1 += delta;
            }
            sum += (x0 * x0 + B * B) / 2 * delta;
            return sum;
        }

        static void Main(string[] args)
        {
            Console.WriteLine(ParabolaArea(0.0000001, 100, 0));
        }
    }
}
