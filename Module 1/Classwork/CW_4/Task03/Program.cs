using System;

namespace Task03
{
    class Program
    {
        static int DigitCount(int a, int prev = 1)
        {
            if (a == 0 && prev == 0) return 0;
            return DigitCount(a /= 10, a) + 1;
        }

        static int Accerman(int m, int n)
        {
            if (m == 0) return n + 1;
            if (m > 0 && n == 0) return Accerman(m - 1, 1);
            return Accerman(m - 1, Accerman(m, n - 1));
        }

        static void Main(string[] args)
        {
            // Stack overflow from 4 1 and beyond
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    Console.WriteLine(i + " " + j + " " + Accerman(i, j));
                }
            }
        }
    }
}
