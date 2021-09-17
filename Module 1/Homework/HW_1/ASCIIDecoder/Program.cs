using System;

namespace ASCIIDecoder
{
    class Program
    {
        static void Main(string[] args)
        {
            int code;
            while (true) {
                string input = Console.ReadLine();
                try
                {
                    code = int.Parse(input);
                    if (code >= 32 && code <= 127)
                    {
                        Console.WriteLine((char)code);
                        return;
                    }
                    Console.WriteLine("\nWrong number" + "\nTry again: ");
                }
                catch (Exception e)
                {
                    Console.WriteLine("\n" + e.Message + "\nTry again: ");
                } 
            }
        }
    }
}
