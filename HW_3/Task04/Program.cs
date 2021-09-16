using System;

namespace Task04
{
    class Program
    {
        static int smallestRoom(int a, int b, int c)
        {
            int aa = a % 100, bb = b % 100, cc = c % 100;
            if (aa <= bb && aa <= cc) return a;
            if (bb <= aa && bb <= cc) return b;
            return c;
        }
        static void Main(string[] args)
        {
            int a, b, c;
            string input = Console.ReadLine();
            input = input.Replace(".", ",");
            string[] arg = input.Trim().Split();
            int.TryParse(arg[0], out a);
            int.TryParse(arg[1], out b);
            int.TryParse(arg[2], out c);
            Console.WriteLine(smallestRoom(a, b, c));
        }
    }
}
