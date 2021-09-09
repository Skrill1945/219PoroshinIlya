using System;

namespace Task04
{
    class Program
    {
        static void Main(string[] args)
        {
            double U, R;
            Console.WriteLine("Input U first, R second:");
            string input = Console.ReadLine();
            string[] arg = input.Trim().Split();
            if (!double.TryParse(arg[0], out U))
            {
                Console.WriteLine("Wrong U");
                return;
            }
            if (!double.TryParse(arg[1], out R))
            {
                Console.WriteLine("Wrong R");
                return;
            }
            Console.WriteLine($"I = {U / R}");
            Console.WriteLine($"P = {U * U / R}");
        }
    }
}
