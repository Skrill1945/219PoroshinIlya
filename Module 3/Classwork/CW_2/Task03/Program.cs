using System;

namespace Task03
{
    delegate double Sum(int n);
    class Program
    {
        static double LineSum1(int n)
        {
            double sum = 0;
            for (int i = 1; i <= n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    sum += 1 / (double)(i + 1);
                }
            }
            return sum;
        }

        static double LineSum2(int n)
        {
            double sum = 0;
            for (int i = 1; i <= n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    sum += 1 / Math.Pow(2, j + 1);
                }
            }
            return sum;
        }

        static void Main(string[] args)
        {
            Sum sum = LineSum1;
            Console.WriteLine(sum(4));
            Sum sum2 = LineSum2;
            Console.WriteLine(sum2(4));
        }
    }
}
