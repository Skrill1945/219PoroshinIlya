using System;
using System.Linq;

namespace Task01
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
                arr[i] = random.Next(-10000, 10000);
            }

            foreach (int a in arr.Select(t => t % 10))
            {
                Console.Write(a + " ");
            }
            Console.WriteLine();
            var q1 = from a in arr
                     select a % 10;
            foreach (int a in q1)
            {
                Console.Write(a + " ");
            }
            Console.WriteLine();

            foreach (var col in arr.GroupBy(t => t % 10))
            {
                foreach (int a in col)
                {
                    Console.Write(a + " ");
                }
            }
            Console.WriteLine();
            var q2 = from a in arr
                     group a by a % 10 into newArr
                     select newArr;
            foreach (var col in q2)
            {
                foreach (int a in col)
                {
                    Console.Write(a + " ");
                }
            }
            Console.WriteLine();

            Console.Write(arr.Where(t => t % 2 == 0 && t > 0).Count());
            Console.WriteLine();
            var q3 = (from a in arr
                     where a % 2 == 0 && a > 0
                     select a).Count();
            Console.Write(q3);
            Console.WriteLine();

            Console.Write(arr.Where(t => t % 2 == 0).Sum());
            Console.WriteLine();
            var q4 = (from a in arr
                     where a % 2 == 0
                     select a).Sum();
            Console.Write(q4);
            Console.WriteLine();

            foreach (var a in arr.OrderBy(t => Math.Abs(t).ToString()[0] - 48).ThenBy(t => t % 10).ToArray())
            {
                Console.Write(a + " ");
            }
            Console.WriteLine();
            //Console.WriteLine();
            var q5 = from t in arr
                     orderby Math.Abs(t).ToString()[0] - 48, t % 10
                     select t;
            foreach (var a in q5)
            {
                Console.Write(a + " ");
            }
            Console.WriteLine();
        }
    }
}
