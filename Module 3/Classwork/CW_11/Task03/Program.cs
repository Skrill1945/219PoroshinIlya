using System;
using System.IO;

namespace Task03
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rand = new();
            using (FileStream fileStream = new FileStream("Numbers.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite))
            {
                if (fileStream.Length == 0)
                {
                    BinaryWriter bw = new(fileStream);
                    for (int i = 0; i < 10; i++)
                    {
                        bw.Write(rand.Next(1, 101));
                    }
                }
                else
                {
                    BinaryReader br = new(fileStream);
                    BinaryWriter bw = new(fileStream);
                    int[] nums = new int[10];

                    for (int i = 0; i < 10; i++)
                    {
                        nums[i] = br.ReadInt32(); 
                        Console.Write(nums[i] + " ");
                    }

                    int a = int.Parse(Console.ReadLine());
                    int id = 0, minDiff = Math.Abs(a - nums[0]);
                    for (int i = 1; i < 10; i++)
                    {
                        if (Math.Abs(a - nums[0]) < minDiff)
                        {
                            id = i;
                        }
                    }
                    nums[id] = a;

                    fileStream.Position = 0;
                    for (int i = 0; i < 10; i++)
                    {
                        bw.Write(nums[i]);
                    }

                    fileStream.Position = 0;
                    for (int i = 0; i < 10; i++)
                    {
                        nums[i] = br.ReadInt32();
                        Console.Write(nums[i] + " ");
                    }
                }
            }
        }
    }
}
