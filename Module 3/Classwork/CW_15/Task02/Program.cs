using System;
using System.Linq;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace Task02
{
    class Program
    {
        private static readonly Random Random = new Random();
        private static double Integral(Func<double, double> func, int a, int b, int n)
        {
            int correct = 0; int minX = a, maxX = b;
            int maxY = (int)Math.Max(func(a), func(b)) + 1;
            for (int i = 0; i < n; i++)
            {
                double x = Random.Next(minX, maxX) + Random.NextDouble();
                double y = Random.Next(0, maxY) + Random.NextDouble();
                if (y <= func(x))
                {
                    correct++;
                }
            }
            return (double)correct / n * (maxX - minX) * maxY;
        }

        public static void Main(string[] args)
        {
            Stopwatch timer = new Stopwatch();
            timer.Start();
            Console.WriteLine("Integral");
            Console.WriteLine(Integral(x => x * x, 0, 4, (int)1e7));
            timer.Stop();
            Console.WriteLine(timer.ElapsedMilliseconds);
            timer.Reset();

            timer.Start();
            Console.WriteLine("Integral2");
            Console.WriteLine(Integral(x => x * x, 0, 2, (int)1e7)+Integral(x => x * x, 2, 4, (int)1e7));
            timer.Stop();
            Console.WriteLine(timer.ElapsedMilliseconds);
            timer.Reset();

            timer.Start();
            Console.WriteLine("Integral4");
            Console.WriteLine(Integral(x => x * x, 0, 1, (int)1e7)+Integral(x => x * x, 1, 2, (int)1e7)+ Integral(x => x * x, 2, 3, (int)1e7) + Integral(x => x * x, 3, 4, (int)1e7));
            timer.Stop();
            Console.WriteLine(timer.ElapsedMilliseconds);
            timer.Reset();

            timer.Start();
            Console.WriteLine("Integral4Parallel");
            Task<double[]> task = Task.WhenAll(
                Task.Run(() => Integral(x => x * x, 0, 1, (int)1e7)),
                Task.Run(() => Integral(x => x * x, 1, 2, (int)1e7)),
                Task.Run(() => Integral(x => x * x, 2, 3, (int)1e7)),
                Task.Run(() => Integral(x => x * x, 3, 4, (int)1e7)));
            Console.WriteLine(task.Result.Sum());
            timer.Stop();
            Console.WriteLine(timer.ElapsedMilliseconds);
            /*
             
            Integral
            21,3390528
            633
            Integral2
            21,339309599999996
            1041
            Integral4
            21,3319543
            2056
            Integral4Parallel
            33,9969744
            4650
            Очевидно что ничего он не параллелит, почему - думаю, пока не придумал...

             */

        }

    }
}
