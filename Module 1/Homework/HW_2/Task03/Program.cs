using System;

namespace Task03
{
    class Program
    {
        static void Main(string[] args)
        {
            double a, b, c;
            while (true)
            {
                string input = Console.ReadLine();
                string[] arg = input.Trim().Split();
                if (!(double.TryParse(arg[0], out a) && double.TryParse(arg[1], out b) && double.TryParse(arg[2], out c)))
                {
                    Console.WriteLine("Wrong input");
                }
                else break;
            }
            double D = b * b - 4 * a * c;

        }
    }
}
