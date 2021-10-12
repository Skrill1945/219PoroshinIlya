using System;

namespace Task01
{
    class Program
    {
        static void Print(char[] arr)
        {
            foreach (var c in arr)
            {
                Console.Write(c);
            }
            Console.WriteLine();
        }
        static void Main(string[] args)
        {
            int len = 0;
            Random rand = new Random();
            while(!int.TryParse(Console.ReadLine(), out len)) { }
            char[] arr = new char[len];
            for (int i = 0; i < len; i++)
            {
                arr[i] = (char)rand.Next('A', 'Z' + 1);
            }
            Array.ForEach<char>(arr, 
                new Action<char>(
                (char c) => Console.Write(c)
                ));
            char[] copy = new char[len];
            Array.Copy(arr, copy, arr.Length);
            Array.Sort(copy);

            Print(arr);

            Array.Reverse(copy);

            Print(arr);
        }
    }
}
