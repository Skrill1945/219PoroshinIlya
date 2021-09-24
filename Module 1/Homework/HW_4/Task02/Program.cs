using System;

namespace Task02
{
    class Program
    {
        static bool Shift(ref char ch)
        {
            if ((int)ch < 97 || (int)ch > 122) return false;
            ch = (char)(((int)ch - 93) % 26 + 97);
            return true;
        }

        static void Main(string[] args)
        {
            for (int i = 0; i <= 255; i++)
            {
                char a = (char)i;
                if (Shift(ref a))
                    Console.WriteLine(a + " " + (int)a);
            }
        }
    }
}
