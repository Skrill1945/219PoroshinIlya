using System;
using System.Collections.Generic;

namespace Task02
{
    class Program
    {
        public static int[] Divisors(int n)
        {
            List<int> divs = new List<int>();
            for (int i = 2; i <= Math.Sqrt(n); i++)
            {
                if (n % i == 0)
                {
                    divs.Add(i);
                    if (n / i != i)
                        divs.Add(n / i);
                }
            }
            divs.Sort();
            if (divs.Count == 0) return null;
            return divs.ToArray();
        }

        static double Sum(uint k)
        {
            double sum = 0;
            for (uint i = 1; i <= k; i++)
            {
                sum += (k + 0.3) / (3 * k * k + 5);
            }
            return sum;
        }
        
        static void Main(string[] args)
        {
            for (uint i = 0; i < 100; i++)
            {
                int[] a = Divisors((int)i);
                if (a != null)
                {
                    Console.Write(i + " ");
                    foreach (int aa in a)
                    {
                        Console.Write(aa + " ");
                    }
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine(i + " prime");
                }
            }
        }
    }
}
//  20
//  00010100
//  11101011
//  11101100
// 
//  25
//  00011001 &
//  00010100
//  00010000
//  
//  
//  20 + (-20)
//  00010100
//  11101100
// 100000000
// 
// 19
// 00010011
// 11101100
// 11101011
// 00010100
// 
// 
// 