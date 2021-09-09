using System;

namespace Task05
{
    class Program
    {
        static void Main(string[] args)
        {
            double a, b;
            Console.WriteLine("Input sides:");
            string input = Console.ReadLine();
            string[] arg = input.Trim().Split();
            if (!double.TryParse(arg[0], out a))
            {
                Console.WriteLine("Wrong a");
                return;
            }
            if (!double.TryParse(arg[1], out b))
            {
                Console.WriteLine("Wrong b");
                return;
            }
            Console.WriteLine($"Hypotenuse = {Math.Sqrt(a * a + b * b).ToString("F6")}");

        }
    }
}
