using System;

namespace Task01
{

    class Program
    {
        static void Sums(uint number, out uint sumEven, out uint sumOdd)
        {
            sumEven = 0;
            sumOdd = 0;
            while (number > 0)
            {
                sumEven += number % 10;
                sumOdd += number / 10 % 10;
                number /= 100;
            }
        }

        static void Main(string[] args)
        {
            Sums(0, out uint se, out uint so);
            Console.WriteLine(se + " " + so);
        }
    }
}
