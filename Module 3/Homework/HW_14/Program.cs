using System;
using System.Linq;

namespace HW_14
{
    class Program
    {
        static void Main(string[] args)
        {
            Random random = new();
            int n = int.Parse(Console.ReadLine());
            int[] arr = new int[n];
            for (int i = 0; i < n; i++)
            {
                arr[i] = random.Next(-1000, 1000);
            }

            foreach (int a in arr.Select(t => t * t))
            {
                Console.Write(a + " ");
            }
            Console.WriteLine();

            foreach (int a in arr.Where(t => t < 100 && t > 9))
            {
                Console.Write(a + " ");
            }
            Console.WriteLine();

            foreach (int a in arr.Where(t => t % 2 == 0).OrderByDescending(t => t))
            {
                Console.Write(a + " ");
            }
            Console.WriteLine();

            foreach (var col in arr.GroupBy(t => { int a = Math.Abs(t), count = 1; while (a > 9) { count++; a /= 10; } return count; }))
            {
                foreach (int a in col)
                    Console.Write(a + " ");
            }
            Console.WriteLine();
        }
    }
}
