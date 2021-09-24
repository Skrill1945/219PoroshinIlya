using System;

namespace Task01
{
    class Program
    {
        static void Main(string[] args)
        {
            long a = long.Parse(Console.ReadLine());
            long copy = a;
            int length = 0;
            long nL, nR, diff;
            while (copy > 0)
            {
                length++;
                copy /= 10;
            }
            Console.WriteLine(length);
            for (int j = length - 1; j >= 0; j--)
                for (int i = 0; i < j; i++)
                {
                    nR = a / (long)Math.Pow(10, i) % 10;
                    nL = a / (long)Math.Pow(10, i + 1) % 10;
                    if (nL < nR)
                    {
                        diff = nR - nL;
                        a += diff * (long)Math.Pow(10, i + 1);
                        a -= diff * (long)Math.Pow(10, i);
                    }
                }
            Console.WriteLine(a);
        }
    }
}
