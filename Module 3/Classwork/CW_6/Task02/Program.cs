using System;
using System.Linq;
using System.Collections.Generic;

namespace Task02
{
    interface IJump
    {
        public void Jump();
    }

    interface IRun
    {
        public void Run();
    }

    abstract class Animal : IComparable<Animal>
    {
        public int age;

        protected Animal(int age)
        {
            this.age = age;
        }

        public int CompareTo(Animal obj)
        {
            return age.CompareTo(obj.age);
        }
    }

    class Cockroach : Animal, IRun
    {
        public double speed;

        public Cockroach(int age, double speed = 1) : base(age)
        {
            this.speed = speed;
        }

        public void Run()
        {
            Console.WriteLine($"Cockroach ran {speed:f2} miles");
        }
    }

    class CockroachComparer : IComparer<Cockroach>
    {
        public int Compare(Cockroach a, Cockroach b)
        {
            if (a.speed > b.speed) return 1;
            return -1;
        }
    }

    class Kangaroo : Animal, IJump
    {
        public double height;

        public Kangaroo(int age, double height = 1) : base(age)
        {
            this.height = height;
        }

        public void Jump()
        {
            Console.WriteLine($"Kangaroo jumped {height:f2} meters high");
        }
    }

    class KangarooComparer : IComparer<Kangaroo>
    {
        public int Compare(Kangaroo a, Kangaroo b)
        {
            if (a.height > b.height) return 1;
            return -1;
        }
    }

    class Cheetah : Animal, IJump
    {
        public double speed;

        public double height;

        public Cheetah(int age, double speed = 1, double height = 1) : base(age)
        {
            this.speed = speed;
            this.height = height;
        }

        public void Run()
        {
            Console.WriteLine($"Cheetah ran {speed:f2} miles");
        }

        public void Jump()
        {
            Console.WriteLine($"Cheetah jumped {height:f2} meters high");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<Animal> animals = new();
            List<IRun> runners = new();
            List<IJump> jumpers = new();
            List<Cockroach> cockroaches = new();
            List<Kangaroo> kangaroos = new();
            Random rand = new Random();
            for (int i = 0; i < 20; i++)
            {
                int a = rand.Next(3);
                switch (a)
                {
                    case 0:
                        animals.Add(new Cockroach(rand.Next(1, 100), rand.NextDouble() * 10));
                        break;
                    case 1:
                        animals.Add(new Kangaroo(rand.Next(1, 100), rand.NextDouble() * 10));
                        break;
                    case 2:
                        animals.Add(new Cheetah(rand.Next(1, 100), rand.NextDouble() * 10, rand.NextDouble() * 10));
                        break;
                }
            }
            foreach (Animal animal in animals)
            {
                if (animal is IRun)
                {
                    runners.Add((IRun)animal);
                }
                else if (animal is IJump)
                {
                    jumpers.Add((IJump)animal);
                }
                if (animal is Cockroach)
                {
                    cockroaches.Add((Cockroach)animal);
                } else if (animal is Kangaroo)
                {
                    kangaroos.Add((Kangaroo)animal);
                }
            }
            foreach (IRun animal in runners)
            {
                animal.Run();
            }
            foreach (IJump animal in jumpers)
            {
                animal.Jump();
            }

            animals.Sort((a, b) => a.CompareTo(b));
            foreach (Animal animal in animals)
            {
                Console.Write(animal.age + " ");
            }
            Console.WriteLine();

            cockroaches.Sort(new CockroachComparer());
            foreach (Cockroach animal in cockroaches)
            {
                Console.Write(animal.speed + " ");
            }
            Console.WriteLine();

            kangaroos.Sort(new KangarooComparer());
            foreach (Kangaroo animal in kangaroos)
            {
                Console.Write(animal.height + " ");
            }
            Console.WriteLine();
        }
    }
}
