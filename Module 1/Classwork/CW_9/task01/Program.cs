using System;
using System.Text;

namespace task01
{
    class Program
    {
        static string vowels = "AEIOUYaeiouy";
        static void ShortWordParse(string str)
        {
            StringBuilder stringBuilder = new StringBuilder();
            string[] phrases = str.Split(';');
            foreach (var phrase in phrases)
            {
                phrase.Trim();
                string[] words = phrase.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                foreach (var word in words)
                {
                    string copy = word.ToUpper();
                    stringBuilder.Append(copy[0]);
                    copy = copy.ToLower();
                    for (int i = 1; i < copy.Length; i++)
                    {
                        if (vowels.Contains(copy[i]))
                        {
                            stringBuilder.Append(copy[i]);
                            break;
                        }
                    }
                }
                stringBuilder.Append('\n');
            }
            Console.WriteLine(stringBuilder.ToString());
        }

        static void Main(string[] args)
        {
            ShortWordParse(Console.ReadLine());
        }
    }
}
