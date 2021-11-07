using System;
using System.Linq;

namespace Task01
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rand = new Random();
            int n = int.Parse(Console.ReadLine());
            int[] nums = new int[n];
            for (int i = 0; i < n; i++)
            {
                nums[i] = rand.Next(1, 10001);
            }
            nums = new int[10] { 1, 2, 1234, 3465, 121, 1111, 12, 94, 100, 7 };
            var twoDigitMulThreeReq = nums.Where(t => t < 100 && t > 9 && t % 3 == 0).OrderBy(t => t);
            var palidromeReq = nums.Where(num => num.ToString() == new String(num.ToString().Reverse().ToArray()));
            var sortedByDigitSum = nums.OrderBy(t =>
            {
                int sum = 0;
                while (t > 0)
                {
                    sum += t % 10;
                    t /= 10;
                }
                return sum;
            }).ThenBy(t => t);
            var sumOf4Digit = nums.Where(t => t < 10000 && t > 999).Sum();
            var minOf2Digit = nums.Where(t => t < 100 && t > 9).Min();
            var maxDigits = nums.Select(t => t.ToString().Select(c => (int)c - '0').Max());
            foreach(var item in twoDigitMulThreeReq)
            {
                Console.Write(item.ToString() + " ");
            }
            Console.WriteLine();
            foreach (var item in palidromeReq)
            {
                Console.Write(item.ToString() + " ");
            }
            Console.WriteLine();
            foreach (var item in sortedByDigitSum)
            {
                Console.Write(item.ToString() + " ");
            }
            Console.WriteLine();
            Console.WriteLine(sumOf4Digit);
            Console.WriteLine(minOf2Digit);
            foreach (var item in maxDigits)
            {
                Console.Write(item.ToString() + " ");
            }
            Console.WriteLine();
        }
    }
}
