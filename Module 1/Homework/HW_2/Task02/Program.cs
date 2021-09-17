using System;

namespace Task02
{
    class Program
    {
        static string maxPermut(int a)
        {
            string inp = a.ToString(), output = "";
            int[] nums = new int[inp.Length];
            for (int i = 0; i < inp.Length; i++)
            {
                nums[i] = inp[i] - '0';
            }
            Array.Sort(nums);
            for (int i = nums.Length - 1; i >= 0; i--)
            {
                output += nums[i];
            }
            return output;
        }

        static void Main(string[] args)
        {
            int x;
            string inp;
            while (true)
            {
                inp = Console.ReadLine();
                if (!int.TryParse(inp, out x) || x <= 0)
                    Console.WriteLine("Wrong input");
                else break;
            }
            Console.WriteLine(maxPermut(x));
        }
    }
}
