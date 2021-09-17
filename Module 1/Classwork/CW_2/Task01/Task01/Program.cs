using System;

namespace Task01
{
    class Program
    {
        static double b = (1 - Math.Sqrt(5)) / 2;

        static double CalcBine(uint n)
        {
            return (int)(((Math.Pow(b, n) - Math.Pow(-b, -n)) / (2 * b - 1)) + 0.5);
        }

        static void Main(string[] args)
        {
            uint n;
            do
            {
                string input = Console.ReadLine();
                try
                {
                    n = uint.Parse(input);
                    return;
                } catch { }
            } while (true);
            Console.WriteLine(CalcBine(n));
        }
    }
}
