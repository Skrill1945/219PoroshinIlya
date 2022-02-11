using System;
using System.Linq;

namespace Task04
{
    public delegate string ConvertRule(string s);

    public class Converter
    {
        public string Convert(string str, ConvertRule cr)
        {
            return cr?.Invoke(str);
        }
    }

    /*
     •В библиотеке классов описать:

– делегат ConvertRule, представляющий методы, возвращающие строку, с одним параметром – строкой

–Класс Converter с нестатическим методом public string Convert(string str, ConvertRule cr). Метод преобразует строку str по правилу cr.

•В проекте консольного приложения описать два метода преобразования строк:

–public static string RemoveDigits(string str) – возвращает строку, полученную из str удалением цифр

– public static string RemoveSpaces(string str) – возвращает строку, полученную из str удалением пробелов

–В методе Main() описать массив тестовых строк, связать методы с объектом-делегатом типа ConvertRule и протестировать работу каждого метода.

–Связать один многоадресный делегат с обоими методами и протестировать вызовы на том же массиве строк.

–Добиться последовательного применения обоих преобразований к элементам массива на многоадресном делегате (использовать GetInvocationList).

     */

    class Program
    {
        public static string RemoveDigits(string str)
        {
            return string.Concat(str.Where(c => !char.IsDigit(c)).ToArray());
        }
        public static string RemoveSpaces(string str)
        {
            return string.Concat(str.Where(c => c != ' ').ToArray());
        }

        static void Main(string[] args)
        {
            string[] strs = new string[] { "12345sdfghj34nm", " 78y 2384 m8327l efh gy", "98nu0439vm    3452mv349" };
            ConvertRule convertRule1 = RemoveDigits;
            Console.WriteLine(convertRule1(strs[0]));
            ConvertRule convertRule2 = RemoveSpaces;
            Console.WriteLine(convertRule2(strs[1]));
            ConvertRule convertRule3 = RemoveDigits;
            convertRule3 += RemoveSpaces;
            string temp = strs[2];
            foreach (ConvertRule cr in convertRule3.GetInvocationList())
            {
                temp = cr(temp);
            }
            Console.WriteLine(temp);
        }
    }
}
