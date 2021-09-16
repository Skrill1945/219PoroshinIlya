using System;

namespace Task01
{
    class Program
    {
        static bool F(double x, double y)
        {
            if (x < 0) return false;
            if (y >= 0) return (((x * x + y * y) <= 4) && (y <= x));
            return true;
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
            /*
            int[,] arr = new int[120, 120];
            for (int i = 0; i < 120; i++)
            {
                for (int j = 0; j < 120; j++)
                {
                    arr[120 - i - 1, j] = Convert.ToInt32(F(j * 0.02 - 1, i * 0.02 - 1));
                }
            }
            for (int i = 0; i < 120; i++)
            {
                for (int j = 0; j < 120; j++)
                {
                    Console.Write(arr[i, j]);
                }
                Console.WriteLine();
            }*/
        }
    }
}
