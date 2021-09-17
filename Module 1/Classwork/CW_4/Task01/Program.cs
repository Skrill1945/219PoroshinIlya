using System;

namespace Task01
{

    class Program
    {
        static float InfSumF()
        {
            int i = 3;
            float p_sum = 1.0f / (1 * 2 * 3), n_sum = p_sum + 1.0f / (2 * 3 * 4);
            while (n_sum > p_sum)
            {
                p_sum = n_sum;
                n_sum = p_sum + 1.0f / (i * (i + 1) * (i + 2));
                i++;
            }
            return n_sum;
        }

        static double InfSumD()
        {
            int i = 3;
            double p_sum = 1.0f / (1 * 2 * 3), n_sum = p_sum + 1.0f / (2 * 3 * 4);
            while (n_sum > p_sum)
            {
                p_sum = n_sum;
                n_sum = p_sum + 1.0f / (i * (i + 1) * (i + 2));
                i++;
            }
            return n_sum;
        }

        static void Main(string[] args)
        {
            Console.WriteLine(InfSumF());
            Console.WriteLine(InfSumD());
        }
    }
}
