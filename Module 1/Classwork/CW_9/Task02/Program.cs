using System;
using System.Text;

namespace Task02
{
    class Program
    {
        static string vowels = "AEIOUYaeiouy";

        static string StripRepeatedSpaces(string str)
        {
            StringBuilder sb = new StringBuilder(str.Length);
            sb.Append(str[0]);
            for (int i = 1; i < str.Length; i++)
            {
                if (!(str[i] == ' ' && str[i - 1] == ' '))
                {
                    sb.Append(str[i]);
                }
            }
            return sb.ToString();
        }

        static int CountLongWords(string str)
        {
            int wordCount = 0;
            int charCount = 0;
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == ' ')
                {
                    if (charCount > 4)
                        wordCount++;
                    charCount = 0;
                }
                else
                {
                    charCount++;
                }
            }
            if (charCount > 4)
                wordCount++;
            return wordCount;
        }

        static int CountWordsThatStartWithVowels(string str)
        {
            int wordCount = 0;
            if (vowels.Contains(str[0]))
                wordCount++;
            for (int i = 0; i < str.Length - 1; i++)
                if (str[i] == ' ' && vowels.Contains(str[i + 1]))
                    wordCount++;
            return wordCount;
        }

        static void Main(string[] args)
        {
            Console.Write(StripRepeatedSpaces("  asd   asd a as d yhyh   "));
            Console.Write(StripRepeatedSpaces("cv"));
            Console.WriteLine(StripRepeatedSpaces("jsdfhg  ajdsfh       5. 1 ... \\ ewwrw"));
            Console.WriteLine(CountLongWords("qwerty b  qwerty asd dfgh qwertyu"));
            Console.WriteLine(CountWordsThatStartWithVowels("u aawerty b z qwerty asd dfgh qwertyu a"));
        }
    }
}
