using System;

namespace Task05
{
    class Program
    {
        static void print(int[] arr)
        {
            foreach (int a in arr)
            {
                Console.Write(a.ToString().PadLeft(4, ' '));
            }
            Console.WriteLine();
        }
        static void print(double[] arr)
        {
            foreach (int a in arr)
            {
                Console.Write($"{a:f4} ");
            }
            Console.WriteLine();
        }
        static void Main(string[] args)
        {

            int[] nums = new int[10];
            Random rand = new Random();
            for (int i = 0; i < 10; i++)
            {
                nums[i] = rand.Next(-15, 16);
            }
            print(nums);
            Array.Sort(nums, (a, b) => a * a > b * b ? 1 : -1);
            print(nums);


            int[] A = new int[10];
            for (int i = 0; i < 10; i++)
            {
                A[i] = rand.Next(0, 21);
            }
            double[] B = Array.ConvertAll<int, double>(A, a => (1.0) / (double)a);
            print(A);
            print(B);

        }
    }
}
