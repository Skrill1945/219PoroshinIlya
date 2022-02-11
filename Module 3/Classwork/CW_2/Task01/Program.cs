using System;

namespace Task01
{
    delegate int[] Row(int a);
    delegate void Print(int[] a);

    class Program
    {
        /*
         В библиотеке классов определить два делегата-типа.
Первый с именем Row – для представления методов с целочисленным параметром, возвращающих ссылку на целочисленный массив.
Второй с именем Print для представления методов, параметр которых – ссылка на целочисленный массив, тип возвращаемого значения void.

В отдельной библиотеке классов объявить два статических метода.

Первый метод формирует по введённому числу массив его цифр.

Второй метод выводит массив на экран.

Для тестирования кода библиотеки разработайте консольное приложение.

В программе задайте пятизначное число и массив из 10 двузначных чисел. Создайте два экземпляра делегатов (первого и второго типа), свяжите с ними соответствующие методы из библиотеки. Протестируйте их (для этого были созданы массив и число).

Для каждого делегата выведите на печать результаты вызова свойств Method и Target.
         */
        static int[] ToDigitArray(int a)
        {
            int _a = a, len = 0;
            while (_a > 0)
            {
                len++;
                _a /= 10;
            }
            int[] digits = new int[len];
            for (int i = len - 1; i >= 0; i--)
            {
                digits[i] = a % 10;
                a /= 10;
            }
            return digits;
        }

        static void PrintOut(int[] digits)
        {
            Console.WriteLine(string.Join(' ', digits));
        }

        static void Main(string[] args)
        {
            int a = 37596;
            int[] nums = new int[10];
            Random rand = new Random();
            for (int i = 0; i < 10; i++)
            {
                nums[i] = rand.Next(10, 100);
            }
            Row rowDel = ToDigitArray;
            Print printDel = PrintOut;
            var q = rowDel.Invoke(a);
            printDel.Invoke(nums);
            printDel.Invoke(q);
        }
    }
}
