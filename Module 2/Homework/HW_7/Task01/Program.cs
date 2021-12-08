using System;
using System.Text;

namespace Task01
{
    class Creature
    {
        protected string name;
        protected double speed;

        public Creature(string name, double speed)
        {
            this.name = name;
            this.speed = speed;
        }

        virtual protected string Run()
        {
            return $"I am running with the speed of {speed}";
        }

        public override string ToString()
        {
            return $"{Run()}. I'm {name}";
        }
    }

    class Dwarf : Creature
    {
        private int _strength;

        public int Strength
        {
            get => _strength;
            set
            {
                if (value <= 20 && value >= 1)
                {
                    _strength = value;
                }
                else
                {
                    _strength = new Random().Next(1, 21);
                }
            }
        }

        public Dwarf(string name, double speed, int strength) : base(name, speed)
        {
            Strength = strength;
        }

        protected override string Run()
        {
            return $"I am running with a speed of {speed}. My strength is {Strength}";
        }

        public void MakeNewStaff()
        {
            Console.WriteLine("I've created a new staff!");
        }
    }

    class Elf : Creature
    {
        private int age;
        private int yearsPerAdditionalSpeed = 77;

        public Elf(string name, double speed) : base(name, speed) 
        {
            age = new Random().Next(100, 201);
        }
        protected override string Run()
        {
            return $"I am running with a speed of {speed + age / yearsPerAdditionalSpeed}. My age is {age}";
        }
    }

    class Program
    {
        public static Random rand = new Random();

        static string GenerateName(int len = 3)
        {
            StringBuilder sb = new StringBuilder(len);
            sb.Append((char)rand.Next('A', 'Z' + 1));
            for (int i = 1; i < len; i++)
            {
                sb.Append((char)rand.Next('a', 'z' + 1));
            }
            return sb.ToString();
        }

        static void Main(string[] args)
        {
            // Я с времен паскаля готу не видел, захотелось)
            HERE:
            int n = int.Parse(Console.ReadLine());
            if (n < 1 || n > 100)
                goto HERE;
            Creature[] creatures = new Creature[n];
            for (int i = 0; i < n; i++)
            {
                int a = rand.Next(10);
                if (a < 2)
                {
                    creatures[i] = new Creature(GenerateName(rand.Next(3, 10)), rand.Next(10, 18));
                } 
                else if (a < 6)
                {
                    creatures[i] = new Dwarf(GenerateName(rand.Next(3, 10)), rand.Next(10, 18), rand.Next(-50, 51));
                }
                else
                {
                    creatures[i] = new Elf(GenerateName(rand.Next(3, 10)), rand.Next(10, 18));
                }
            }
            foreach (Creature c in creatures) 
            {
                Console.WriteLine(c);
                if (c.GetType() == typeof(Dwarf))
                {
                    ((Dwarf)c).MakeNewStaff();
                }
            }
        }
    }
}
