using System;

namespace Task03
{

    delegate double DelegateConvertTemperature(double a);

    class TemperatureConverterImp
    {
        public double CelsiusToFahrenheit(double degC)
        {
            return degC * 9 / 5.0 + 32;
        }

        public double FahrenheitToCelsius(double degF)
        {
            return (degF - 32) * 5 / 9.0;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            TemperatureConverterImp tci = new();
            DelegateConvertTemperature dct = tci.CelsiusToFahrenheit;
            dct += tci.FahrenheitToCelsius;
            double temp = 10;
            Console.WriteLine($"Temp in C {temp}");
            foreach (DelegateConvertTemperature meth in dct.GetInvocationList())
            {
                if (meth.Method.Name == "CelsiusToFahrenheight")
                    Console.WriteLine($"Temp in F {temp = meth(temp)}");
                else
                    Console.WriteLine($"Temp in C {temp = meth(temp)}");
            }
        }
    }
}
