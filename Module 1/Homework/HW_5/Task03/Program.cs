using System;

namespace Task03
{
    class Program
    {
        static double[] arr;
        static int Factorial(int a)
        {
            int fact = 1;
            for (int x = 2; x <= a; x++)
            {
                fact *= x;
            }
            return fact;
        }
        static void SinSeq(int n)
        {
            arr = new double[n];
            for (int i = 0; i < n; i++)
            {
                arr[i] = Math.Pow(-1, i) * (Math.Pow(3.14, i * 2 + 1) / Factorial(i * 2 + 1));
            }
        }

        static double Sin(double x)
        {
            double sum = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                if (Math.Abs(arr[i]) < 0.0000000001 || arr[i] is double.NaN) return sum;
                sum += arr[i] * Math.Pow(x, i * 2 + 1);
            }
            return sum;
        }

        static void Main(string[] args)
        {
            SinSeq(20);
            double sum = 0;
            foreach(var a in arr)
            {
                Console.WriteLine($"{a} {sum+=a}");
            }
            Console.WriteLine($"{Sin(2)} {Math.Sin(2)}");
        }
    }
}
