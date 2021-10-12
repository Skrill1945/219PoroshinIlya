using System;

namespace Task02
{
    class Program
    {
        static Random rand = new Random();
        static void Main(string[] args)
        {
            int n;
            n = int.Parse(Console.ReadLine());
            int[][] arr = new int[n][];
            for (int i = 0; i < n; i++)
            {
                int size = rand.Next(5, 16);
                arr[i] = new int[size];
                for (int j = 0; j < size; j++)
                {
                    arr[i][j] = rand.Next(-10, 11);
                }
            }
            Array.Sort(arr, (int[] a, int[] b) => a.Length > b.Length ? -1 : 1);
            Array.ForEach(arr, _arr =>
            {
                Array.Sort(_arr, (int a, int b) => a > b ? -1 : 1);
            });

            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = 0; j < arr[i].Length; j++)
                {
                    Console.Write(arr[i][j] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
