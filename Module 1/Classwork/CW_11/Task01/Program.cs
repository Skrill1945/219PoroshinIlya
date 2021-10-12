using System;
using System.IO;
using System.Text;

namespace Task01
{
    class Program
    {
        static Random rand = new Random();
        static void Main(string[] args)
        {
            byte a = 255;
            Console.WriteLine(~a);
            Console.WriteLine((byte)~a);
            string path = @"Data.txt";

            // Создаем файл с данными
            if (File.Exists(path))
            {
                // Сейчас данные для записи вбиты в коде
                // TODO1: сохранить в файл целые случайные значения из диапазона [10;100)
                string createText = "";
                int n;
                while (!int.TryParse(Console.ReadLine(), out n)) { };
                for (int i = 0; i < n; i++)
                {
                    createText += rand.Next(10, 100) + " " + rand.Next(10, 100) + " " + rand.Next(10, 100) + " " + rand.Next(10, 100) + " " + rand.Next(10, 100) + " " + Environment.NewLine;
                }
                File.WriteAllText(path, createText, Encoding.UTF8);
            }

            // Open the file to read from
            if (File.Exists(path))
            {
                string readText = File.ReadAllText(path);
                string[] stringValues = readText.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                int[] arr = StringArrayToIntArray(stringValues);
                foreach (int i in arr)
                {
                    Console.Write(i + " ");
                }
                Console.WriteLine();

                // обрабатываем элементы массива
                int evenCount = 0, oddCount = 0;
                for (int i = 0; i < arr.Length; i++)
                {
                    if (arr[i] % 2 == 0) evenCount++;
                    else oddCount++;
                }

                // TODO2: Создать два массива по исходному
                int[] evens = new int[evenCount], odds = new int[oddCount];
                evenCount = oddCount = 0;

                // в первый поместить индексы чётных элементов, во второй - нечётных
                for (int i = 0; i < arr.Length; i++)
                {
                    if (arr[i] % 2 == 0)
                    {
                        evens[evenCount] = arr[i];
                        evenCount++;
                    }
                    else
                    {
                        odds[oddCount] = arr[i];
                        oddCount++;
                        // TODO3: Заменяем все нечётные числа исходного массива нулями
                        arr[i] = 0;
                    }
                }
                foreach (int i in evens)
                {
                    Console.Write(i + " ");
                }
                Console.WriteLine();
                foreach (int i in odds)
                {
                    Console.Write(i + " ");
                }
                Console.WriteLine();
                foreach (int i in arr)
                {
                    Console.Write(i + " ");
                }
            }
        } // end of Main()

        // преобразование массива строк в массив целых чисел
        public static int[] StringArrayToIntArray(string[] str)
        {
            int[] arr = null;
            if (str.Length != 0)
            {
                arr = new int[0];
                foreach (string s in str)
                {
                    int tmp;
                    if (int.TryParse(s, out tmp))
                    {
                        Array.Resize(ref arr, arr.Length + 1);
                        arr[arr.Length - 1] = tmp;
                    }
                } // end of foreach (string s in str)      
            }
            return arr;
        } // end of StringToIntArray()

    } // end of Program
}

