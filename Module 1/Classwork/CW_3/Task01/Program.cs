using System;

namespace Task01
{
    class Program
    {
        static bool Function1(bool p, bool q)
        {
            return !(p && q) && !(p || !q);
        }

        static void Function2(bool p, bool q, out bool F)
        {
           F = !(p && q) && !(p || !q);
        }

        static void Main(string[] args)
        {
            Console.WriteLine("p  q  F");
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    Console.WriteLine($"{i}  {j}  {Convert.ToInt32(Function1(Convert.ToBoolean(i), Convert.ToBoolean(j)))}");
                }
            }
        }
    }
}
