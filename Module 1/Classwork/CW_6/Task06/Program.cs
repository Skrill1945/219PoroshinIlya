using System;

namespace Task06
{
    class Program
    {
        static int[] CompressArray(int[] arr)
        {
            int len = arr.Length;
            for (int i = 0; i < len - 1; i++)
            {
                if ((arr[i] + arr[i + 1]) % 3 == 0)
                {
                    arr[i] = arr[i] * arr[i + 1];
                    for (int j = i + 1; j < len - 1; j++)
                    {
                        arr[j] = arr[j + 1];
                    }
                    len--;
                }
            }
            int[] res = new int[len];
            for (int i = 0; i < len; i++)
            {
                res[i] = arr[i];
            }
            return res;
        }

        static void Main(string[] args)
        {
            int[] a = CompressArray(new int[5] { 1, 2, 3, 4, 5 });
            for (int i = 0; i < a.Length; i++)
            {
                Console.WriteLine(a[i] + " ");
            }
        }
    }
}
