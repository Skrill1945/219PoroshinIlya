using System;

namespace Task01
{
    class Program
    {
        static Random rand = new Random();
        static int DigitCount(int a)
        {
            int n = 0;
            while(a > 0)
            {
                n += 1;
                a /= 10;
            }
            return n;
        }

        static int DigitSum(int a)
        {
            int n = 0;
            while (a > 0)
            {
                n += a % 10;
                a /= 10;
            }
            return n;
        }

        static void Main(string[] args)
        {
            int n;
            n = int.Parse(Console.ReadLine());
            int[] arr = new int[n];
            for (int i = 0; i < n; i++)
            {
                arr[i] = rand.Next(0, 1001);
            }
            Array.Sort(arr, (int a, int b) =>
            {
                return a % 2 == 0 ? -1 : 1;
            });
            Array.ForEach<int>(arr,
                new Action<int>(
                (int c) => Console.Write(c + " ")
                ));
            Console.WriteLine();

            Array.Sort(arr, (int a, int b) =>
            {
                return DigitCount(a) > DigitCount(b) ? -1 : 1;
            });
            Array.ForEach<int>(arr,
                new Action<int>(
                (int c) => Console.Write(c + " ")
                ));
            Console.WriteLine();

            Array.Sort(arr, (int a, int b) =>
            {
                return DigitSum(a) > DigitSum(b) ? -1 : 1;
            });
            Array.ForEach<int>(arr,
                new Action<int>(
                (int c) => Console.Write(c + " ")
                ));
            Console.WriteLine();
        }
    }
}
