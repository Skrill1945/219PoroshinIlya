using System;

namespace Task01
{
    delegate double calculate(double calculate);

    interface IFunction
    {
        public double Function(double x);
    }

    class F : IFunction
    {
        public readonly calculate Calculate;

        public F(calculate calc)
        {
            Calculate = calc;
        }

        public double Function(double x)
        {
            return Calculate(x);
        }
    }

    class G
    {
        F f1;
        F f2;

        public G(calculate calc1, calculate calc2)
        {
            f1 = new(calc1);
            f2 = new(calc2);
        }

        public double GF(double x)
        {
            return f1.Function(f2.Function(x));
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            G g = new((x) => x * x - 4, (x) => Math.Sin(x));
            for (double i = 0; i <= Math.PI + Math.PI / 32; i += Math.PI / 16)
            {
                Console.WriteLine($"{g.GF(i):f4}");
            }
        }
    }
}
