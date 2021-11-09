using System;

namespace Task01
{
    class MyComplex
    {
        private double re, im;
        public double Real { get => re; set { re = value; } }
        public double Imaginary { get => im; set { im = value; } }

        public MyComplex(double _re, double _im)
        { Real = _re; Imaginary = _im; }

        public static MyComplex operator ++(MyComplex mc)
        {
            return new MyComplex(mc.re + 1, mc.im + 1);
        }

        public static MyComplex operator --(MyComplex mc)
        {
            return new MyComplex(mc.re - 1, mc.im - 1);
        }

        public static MyComplex operator +(MyComplex a, MyComplex b)
        {
            return new MyComplex(a.Real + b.Real, a.Imaginary + b.Imaginary);
        }

        public static MyComplex operator -(MyComplex a, MyComplex b)
        {
            return new MyComplex(a.Real - b.Real, a.Imaginary - b.Imaginary);
        }

        public static MyComplex operator *(MyComplex a, MyComplex b)
        {
            return new MyComplex(a.Real * b.Real - a.Imaginary * b.Imaginary, a.Imaginary * b.Real + a.Real * b.Imaginary);
        }

        public static MyComplex operator /(MyComplex a, MyComplex b)
        {
            return new MyComplex((a.Real * b.Real + a.Imaginary * b.Imaginary) / (b.Real * b.Real + b.Imaginary * b.Imaginary), (a.Imaginary * b.Real - a.Real * b.Imaginary) / (b.Real * b.Real + b.Imaginary * b.Imaginary));
        }

        public double Mod()
        {
            return Math.Abs(re * re + im * im);
        }

        public static bool operator true(MyComplex f)
        {
            if (f.Mod() > 1.0) return true;
            return false;
        }

        public static bool operator false(MyComplex f)
        {
            if (f.Mod() <= 1.0) return true;
            return false;
        }

        public override string ToString()
        {
            return $"Real: {re} Imaginary: {im}";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            MyComplex a = new MyComplex(1, 0.5), b = new MyComplex(0.5, 1);
            Console.WriteLine(a + b);
            Console.WriteLine(a - b);
            Console.WriteLine(a * b);
            Console.WriteLine(a / b);
        }
    }
}

