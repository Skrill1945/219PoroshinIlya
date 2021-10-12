using System;

namespace Task04
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
            int off_l = 0, off_r = 0, off_t = 0, off_b = 0;
            int count = 1;
            while (count < n * n)
            {
                for (int j = off_l; j < n - off_r; j++)
                {
                    arr[off_t, j] = count++;
                }
                off_t++;
                for (int i = off_t; i < n - off_b; i++)
                {
                    arr[i, n - off_r - 1] = count++;
                }
                off_r++;
                for (int j = n - off_r - 1; j >= off_l; j--)
                {
                    arr[n - 1 - off_b, j] = count++;
                }
                off_b++;
                for (int i = n - off_b - 1; i >= off_t; i--)
                {
                    arr[i, off_l] = count++;
                }
                off_l++;
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
