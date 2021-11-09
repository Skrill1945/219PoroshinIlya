using System;

namespace Task05
{
    class ConsolePlate
    {

        private char _plateChar;
        private ConsoleColor _plateColor = ConsoleColor.White;
        private ConsoleColor _backgroundColor = ConsoleColor.Black;

        public char PlateChar
        {
            get => _plateChar;
            set
            {
                _plateChar = value >= 'A' && value <= 'Z' ? value : 'A';
            }
        }
        public ConsoleColor PlateColor
        {
            get => _plateColor;
            set { _plateColor = value != _backgroundColor ? value : _plateColor; }
        }
        public ConsoleColor PlateBackgroundColor
        {
            get => _backgroundColor;
            set { _backgroundColor = value != _plateColor ? value : _backgroundColor; }
        }

        public ConsolePlate()
        {
            _plateChar = '+';
        }

        public ConsolePlate(char plateChar, ConsoleColor plateColor, ConsoleColor backgroundColor)
        {
            PlateChar = plateChar;
            PlateColor = plateColor;
            PlateBackgroundColor = backgroundColor;
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            ConsolePlate xcp = new ConsolePlate('X', ConsoleColor.White, ConsoleColor.Red);
            ConsolePlate ocp = new ConsolePlate('O', ConsoleColor.White, ConsoleColor.Magenta);
            while (true)
            {
                int n = int.Parse(Console.ReadLine());
                for (int i = 0; i < n; i++)
                {
                    // Изменил на n*2.18 ширину чтоб +- квадратненько выводило (мерял линейкой на n = 20, так что погрешность большая)
                    for (int j = 0; j < n * 2.18; j++)
                    {
                        if ((i + j) % 2 == 0)
                        {
                            Console.ForegroundColor = xcp.PlateColor;
                            Console.BackgroundColor = xcp.PlateBackgroundColor;
                            Console.Write(xcp.PlateChar);
                        }
                        else
                        {
                            Console.ForegroundColor = ocp.PlateColor;
                            Console.BackgroundColor = ocp.PlateBackgroundColor;
                            Console.Write(ocp.PlateChar);
                        }
                    }
                Console.ForegroundColor = ConsoleColor.White;
                Console.BackgroundColor = ConsoleColor.Black;
                    Console.WriteLine();
                }
            }
        }
    }
}
