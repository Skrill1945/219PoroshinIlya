using System;

namespace Task02
{
    class Program
    {
        static double F(double x, double y)
        {
            if (x < y && x > 0) return x + Math.Sin(y);
            if (x > y && x < 0) return y - Math.Cos(x);
            return .5 * x * y;
        }

        static void Main(string[] args)
        {
            double x, y;
            string input = Console.ReadLine();
            input = input.Replace(".", ",");
            string[] arg = input.Trim().Split();
            double.TryParse(arg[0], out x);
            double.TryParse(arg[1], out y);
            Console.WriteLine(F(x, y));
            // Visualised proof that it works
            // Honestly, try it :)
            
            double sensitivity = 4.0;
            int[,] arr = new int[120, 120];
            for (int i = 0; i < 120; i++)
            {
                for (int j = 0; j < 120; j++)
                {
                    arr[120 - i - 1, j] = Convert.ToInt32(F(j * 0.02 - 1, i * 0.02 - 1) * sensitivity);
                }
            }
            for (int i = 0; i < 120; i++)
            {
                for (int j = 0; j < 120; j++)
                {
                    Console.Write(arr[i, j]);
                }
                Console.WriteLine();
            }
        }
    }
}
