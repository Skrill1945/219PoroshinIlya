using System;

namespace Task03
{
    class Program
    {
        static int DigitCount(int a)
        {
            int n = 0;
            while (a > 0)
            {
                n += 1;
                a /= 10;
            }
            return n;
        }
        static void Main(string[] args)
        {
            int n;
            n = int.Parse(Console.ReadLine());
            int[,] arr = new int[n, n];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (i % 2 == 0)
                    {
                        arr[i, j] = i * n + j + 1;
                    }
                    else
                    {
                        arr[i, j] = (i + 1) * n - j;
                    }
                }
            }
            int ml = DigitCount(n * n);
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write(arr[i, j].ToString($"D{ml}") + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
