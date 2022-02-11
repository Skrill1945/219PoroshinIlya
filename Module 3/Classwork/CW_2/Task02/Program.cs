using System;

namespace Task02
{
    delegate int MyDel (int a, int b);

    public static class TestClass
    {
        public static int TestMethod(int a, int b)
        {
            return a > b ? a : b;
        }
    }

    public class TestClass1
    {
        public int TestMethod(int a, int b)
        {
            return a + b;
        }
    }

    /*
     В библиотеке классов:

–Объявите делегат-тип  MyDel, представляющий методы с двумя целочисленными параметрами (int) ,  возвращающие целочисленное значение (int);

–Объявите статический класс TestClass со статическим методом TestMethod(), возвращающим максимальное из двух переданных в качестве параметров целых чисел (int). 

–Объявите класс TestClass с нестатическим методом TestMethod(), возвращающим сумму чисел.

•В проекте консольного приложения:

–В методе Main() создать экземпляр делегата и связать с первым методом. Протестировать.

–Создать экземпляр делегата со вторым методом. Протестировать.

–Создать многоадресный. Протестировать.
     */

    class Program
    {
        static void Main(string[] args)
        {
            MyDel myDel = TestClass.TestMethod;
            Console.WriteLine(myDel(1, 2));
            MyDel myDel1 = new TestClass1().TestMethod;
            Console.WriteLine(myDel1(1, 2));
            MyDel myDel2 = TestClass.TestMethod;
            myDel2 += new TestClass1().TestMethod;
            Console.WriteLine(myDel2(4, 123));
            MyDel myDel3 = new TestClass1().TestMethod;
            myDel3 += TestClass.TestMethod;
            Console.WriteLine(myDel3(4, 123));

        }
    }
}
