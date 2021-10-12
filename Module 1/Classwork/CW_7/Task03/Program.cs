using System;

namespace Task03
{
    class Program
    {
        static Random s_rand = new Random(Guid.NewGuid().GetHashCode());

        static int[] arr;

        static void SwapInt(ref int x, ref int y)
        {
            if (x != y)
            {
                x ^= y;
                y ^= x;
                x ^= y;
            }
        }
        static void GenerateNumber()
        {
            int[] availableNumbers = new int[100];
            arr = new int[100];
            for (int i = 0; i < 100; i++)
            {
                availableNumbers[i] = i + 1;
            }
            int idx, numsLeft = 100;
            for (int i = 0; i < 100; i++)
            {
                idx = s_rand.Next(0, numsLeft);
                arr[i] = availableNumbers[idx];
                SwapInt(ref availableNumbers[idx], ref availableNumbers[numsLeft - 1]);
                numsLeft--;
            }
            arr[s_rand.Next(0, 20)] = arr[s_rand.Next(20, 100)];
        }

        static void Main(string[] args)
        {
            GenerateNumber();
            int sum = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                sum += arr[i];
            }
            Console.WriteLine(5050 - sum);
        }
    }
}
