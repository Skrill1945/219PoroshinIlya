using System;

namespace Loops
{
    class Program
    {
        static void forLoop()
        {
            for (int i = 1; i <= 10; i++)
            {
                Console.Write(i * i + " ");
            }
            Console.WriteLine();
        }

        static void whileLoop()
        {
            int i = 1;
            while(i <= 10)
            {
                Console.Write(i * i + " ");
                i++;
            }
            Console.WriteLine();
        }

        static void doWhileLoop()
        {
            int i = 1;
            do
            { Console.Write(i * i + " ");
                i++;
               
            } while (i <= 10);
            Console.WriteLine();
        }
        static void Main(string[] args)
        {
            forLoop();
            whileLoop();
            doWhileLoop();
        }
    }
}
