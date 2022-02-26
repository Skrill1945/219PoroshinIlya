using System;
using System.Collections;
using System.Collections.Generic;

namespace Task01
{
    class Fibbonacci : IEnumerable, IEnumerator
    {
        int t1 = 0, t2 = 1;
        int n, currentN = -1;

        public Fibbonacci(int n)
        {
            this.n = n;
        }

        public object Current => t1;

        public IEnumerator GetEnumerator()
        {
            return this;
        }

        public bool MoveNext()
        {
            if (currentN < n - 1)
            {
                t2 = t1 + t2;
                t1 = t2 - t1;
                currentN++;
                return true;
            }
            Reset();
            return false;
        }

        public void Reset()
        {
            currentN = -1;
            t1 = 0;
            t2 = 1;
        }

        public IEnumerable Yield()
        {
            for (int i = 0; i < n; i++)
            {
                t2 = t1 + t2;
                t1 = t2 - t1;
                yield return t1;
            }
            Reset();
        }
    }

    class TriangleNums
    {
        public IEnumerable IEnumerableYield(int n)
        {
            for (int i = 1; i < n + 1; i++)
            {
                yield return i * (i + 1) / 2;
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Fibbonacci fibbonacci = new(10);
            foreach(int a in fibbonacci)
            {
                Console.Write(a + " ");
            }
            Console.WriteLine();
            foreach(int a in fibbonacci)
            {
                Console.Write(a + " ");
            }
            Console.WriteLine();

            Fibbonacci fibbonacci1 = new(10);
            List<int> fibs = new();
            foreach (int a in fibbonacci1.Yield())
            {
                Console.Write(a + " ");
                fibs.Add(a);
            }
            Console.WriteLine();

            TriangleNums tn = new();
            List<int> tns = new();
            foreach (int a in tn.IEnumerableYield(10))
            {
                Console.Write(a + " ");
                tns.Add(a);
            }
            Console.WriteLine();

            for (int i = 0; i < 10; i++)
            {
                Console.Write(fibs[i] + tns[i] + " ");
            }
        }
    }
}
