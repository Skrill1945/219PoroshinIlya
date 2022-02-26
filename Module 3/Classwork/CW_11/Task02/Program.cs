using System;
using System.IO;

namespace Task02
{
    class Program
    {
        static void Main(string[] args)
        {
            if (!File.Exists("data.txt"))
            {
                File.Create("data.txt").Close();
            }
            using (FileStream fileStream = new FileStream("data.txt", FileMode.Open, FileAccess.ReadWrite))
            {
                if (fileStream.Length == 0)
                {
                    fileStream.WriteByte((byte)'A');
                }
                else
                {
                    char c = '?';
                    byte[] buff = new byte[1];
                    while (fileStream.Read(buff, 0, 1) != 0)
                    {
                        c = (char)buff[0];
                        Console.Write(c);
                    }
                    fileStream.WriteByte((byte)(c+1));
                }
            }
        }
    }
}
