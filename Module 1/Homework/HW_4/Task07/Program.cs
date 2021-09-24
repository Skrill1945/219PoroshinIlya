using System;

namespace Task07
{
    class Program
    {
        static int _gcd(int a, int b)
        {
            if (b == 0) return a;
            return _gcd(b, a % b);
        }

        static int _lcm(int a, int b)
        {
            return a * b / _gcd(a, b);
        }

        static void gcd_lcm(int a, int b, out int gcd, out int lcm)
        {
            gcd = _gcd(a, b);
            lcm = _lcm(a, b);
        }


        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
