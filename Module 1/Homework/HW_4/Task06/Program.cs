using System;

namespace Task06
{
    class Program
    {
        static long Factorial(uint n)
        {
            long sum = 1;
            for (int i = 2; i <= n; i++)
            {
                sum *= i;
            }
            return sum;
        }

        static double Strange2PowFactSumDiff(double x)
        {
            uint n = 1;
            double curSum = x * x, nextSum = Math.Pow(-1, n) * (Math.Pow(2, 1 + 2*n) * Math.Pow(x, 2 + 2 * n)) / Factorial(2 + 2 * n);
            while (Math.Abs(nextSum - curSum) > 0.00000000001)
            {
                n++;
                curSum = nextSum;
                nextSum = Math.Pow(-1, n) * (Math.Pow(2, 1 + 2 * n) * Math.Pow(x, 2 + 2 * n)) / Factorial(2 + 2 * n);
            }
            return curSum;
        }

        static void Main(string[] args)
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(Strange2PowFactSumDiff(i));
            }
        }
    }
}
