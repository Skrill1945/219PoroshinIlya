using System;
using System.Linq;

namespace Task01
{
    struct Person : IComparable
    {
        private string name;
        private string surname;
        private int age;

        public Person(string n, string sn, string a)
        {
            name = n;
            surname = sn;
            if (!int.TryParse(a, out age) || age < 0)
            {
                throw new ArgumentOutOfRangeException("Age is wrong. Must be greater or equal than zero.");
            }
        }

        public int CompareTo(object obj)
        {
            if (((Person)obj).age < age) return 1;
            return -1;
        }

        public override string ToString()
        {
            return $"{name} {surname} {age}";
        }
    }

    class Program
    {
        static Random rand = new();

        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[rand.Next(s.Length)]).ToArray());
        }
        
        public static string RandomNumberString(int length)
        {
            const string chars = "0123456789";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[rand.Next(s.Length)]).ToArray());
        }

        static void Main(string[] args)
        {
            int n = 5;
            Person[] characters = new Person[n];
            for (int i = 0; i < n; i++)
            {
                characters[i] = new(RandomString(rand.Next(5, 11)), RandomString(rand.Next(7, 11)), rand.Next(1, 101).ToString());
            }

            foreach (Person p in characters)
                Console.WriteLine(p);
            Console.WriteLine();

            Array.Sort(characters);
            foreach (Person p in characters)
                Console.WriteLine(p);
        }
    }
}
