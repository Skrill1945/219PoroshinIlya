using System;

namespace Task01
{
    class Program
    {
        static Random rand = new Random();
        static char[] Series(int n, int per)
        {
            char[] arr = new char[n];
            int letterCount = (int)(n * per / 100.0);

            for (int i = 0; i < letterCount; i++)
            {
                arr[i] = (char)rand.Next('a', 'z' + 1);
            }
            for (int i = letterCount; i < n; i++)
            {
                arr[i] = (char)rand.Next('0', '9' + 1);
            }
            return arr;
        }

        static void Main(string[] args)
        {
            string a = new string(Series(10, 30));
            Console.WriteLine(a);
        }
    }
}
