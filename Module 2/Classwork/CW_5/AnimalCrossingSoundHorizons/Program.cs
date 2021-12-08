using System;

namespace AnimalCrossingSoundHorizons
{
    static class StaticStuff
    {
        public static Random rand;
        static StaticStuff()
        {
            rand = new Random();
        }
    }

    abstract class Animal
    {
        public abstract string Name { get; protected set; }
        public abstract int Age { get; protected set; }

        public abstract string AnimalSound();
        public abstract string AnimalInfo();

        public Animal(string name, int age)
        {
            Name = name;
            Age = age;
        }
    }

    class Dog : Animal
    {
        public override string Name { get; protected set; }
        public override int Age { get; protected set; }
        public string Breed { get; private set; }
        public bool isTrained { get; private set; }

        public Dog(string name, int age, string breed = "no breed") : base(name, age)
        {
            Breed = breed;
            isTrained = Convert.ToBoolean(StaticStuff.rand.Next(2));
        }

        public override string AnimalSound()
        {
            return "Woof-woof";
        }

        public override string AnimalInfo()
        {
            return $"Name: {Name}, Breed: {Breed}, Age: {Age}, Sound: {AnimalSound()}\n{(isTrained ? "Lucky! Your dog is trained." : "Unlucky! Your dog is not trained.")}";
        }
        public override string ToString()
        {
            return AnimalInfo();
        }
    }

    class Cow : Animal
    {
        public override string Name { get; protected set; }
        public override int Age { get; protected set; }
        public int MilkPerDay { get; private set; }

        public Cow(string name, int age, int mpd = -1) : base(name, age)
        {
            MilkPerDay = mpd == -1 ? StaticStuff.rand.Next(20) : mpd;
        }

        public override string AnimalSound()
        {
            return "Moo-Moo";
        }

        public override string AnimalInfo()
        {
            return $"Name: {Name}, Age: {Age}, Sound: {AnimalSound()}\n" +
                $"{(MilkPerDay > 10 ? $"Sheeesh, {MilkPerDay} liters of milk per day. Your cow is so productive!" : $"Well, {MilkPerDay} liters of milk per day. Could Be better.")}";
        }

        public override string ToString()
        {
            return AnimalInfo();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Dog dog = new Dog("Cuboid", 6);
            Cow cow = new Cow("Burenka", 10);
            Console.WriteLine(dog);
            Console.WriteLine(cow);
        }
    }
}
