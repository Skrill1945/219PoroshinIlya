using System;

namespace Task02
{
    class Program
    {

        static double CalcCircleArea(double r)
        {
            return Math.PI * r * r;
        }

        static double CalcCirclePerimeter(double r)
        {
            return 2 * Math.PI * r;
        }

        static void Main(string[] args)
        {
            double r;
            string inp;

            do
            {
                Console.Write("Radius: ");
                inp = Console.ReadLine();
            } while (!double.TryParse(inp, out r));

            Console.WriteLine($"Area = {CalcCircleArea(r):f4}\nPerimeter = {CalcCirclePerimeter(r):f4}");
        }
    }
}
