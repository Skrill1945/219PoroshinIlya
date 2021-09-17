using System;

namespace Task04
{
    class Program
    {
        static double Total(double k, double r, uint n)
        {
            if (n == 0) return k;
            return Total(k * (1 + r / 100), r, n - 1);
        }
        static void Main(string[] args)
        {
            Console.WriteLine(Total(100000, 5, 4));
        }
    }
}
