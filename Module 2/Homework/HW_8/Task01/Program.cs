using System;
using System.Collections.Generic;

namespace Task01
{

    [Serializable]
    public class FullPocketException : Exception
    {
        public FullPocketException() { }
        public FullPocketException(string message) : base(message) { }
        public FullPocketException(string message, Exception inner) : base(message, inner) { }
        protected FullPocketException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }


    [Serializable]
    public class EmptySackException : Exception
    {
        public EmptySackException() { }
        public EmptySackException(string message) : base(message) { }
        public EmptySackException(string message, Exception inner) : base(message, inner) { }
        protected EmptySackException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }

    abstract class Person
    {
        protected Random rand;
        public string Name { get; set; }
        protected string pocket;

        public Person(string name)
        {
            Name = name;
            rand = new Random();
        }

        public abstract void Receive(string present);

        public override string ToString()
        {
            return Name;
        }
    }

    class SnowMaiden : Person
    {
        public SnowMaiden(string name) : base(name)
        {
            rand = new Random();
        }

        public string[] CreatePresents(int amount)
        {
            string[] presents = new string[amount];
            for (int i = 0; i < amount; i++)
            {
                char a1 = (char)rand.Next('A', 'Z' + 1);
                char a2 = (char)rand.Next('A', 'Z' + 1);
                char a3 = (char)rand.Next('A', 'Z' + 1);
                presents[i] = $"{a1}{a2}{a3}{a2}{a1}";
            }
            return presents;
        }
        public override void Receive(string present)
        {
            if (pocket != "")
                throw new FullPocketException("Snow maiden pocket is full.");
            pocket = present;
        }
    }

    class Santa : Person
    {
        List<string> sack;

        public Santa(string name) : base(name)
        {
            sack = new List<string>();
        }

        public override void Receive(string present)
        {
            if (pocket != "")
                throw new FullPocketException("Santa pocket is full.");
            pocket = present;
        }

        public void Request(SnowMaiden snowMaiden, int amount)
        {
            sack.AddRange(snowMaiden.CreatePresents(amount));
        }

        public void Give(Person person)
        {
            if (sack.Count <= 0)
                throw new EmptySackException("No presents left in sack.");
            int n = rand.Next(0, sack.Count);
            try
            {
                person.Receive(sack[n]);
            }
            catch
            {
                throw;
            }
            sack.RemoveAt(n);
        }
    }

    class Child : Person
    {
        public string AdditionalPocket;

        public Child(string name) : base(name) { }

        public override void Receive(string present)
        {
            if (pocket != "" && AdditionalPocket != "")
                throw new FullPocketException($"{Name} Pockets are full.");
            if (pocket == "")
                pocket = present;
            else
                AdditionalPocket = present;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Santa santa = new("John");
            SnowMaiden snowMaiden = new("Sheryl");
            int n = 10;
            List<Person> piple = new List<Person>(n);
            piple.Add(santa);
            piple.Add(snowMaiden);
            for (int i = 0; i < n; i++)
            {
                piple.Add(new Child($"Child #{i}"));
            }
            Random rand = new Random();
            while (!(!piple.Contains(santa) || piple.Count == 1))
            {
                int prob = rand.Next(10);
                if (prob == 0)
                {
                    try
                    {
                        santa.Give(santa);
                    }
                    catch (FullPocketException e)
                    {
                        Console.WriteLine(e.Message);
                        piple.Remove(santa);
                    }
                    catch (EmptySackException e)
                    {
                        Console.WriteLine(e.Message);
                        if (!piple.Contains(snowMaiden))
                        {
                            break;
                        }
                    }
                    santa.Request(snowMaiden, rand.Next(1, 5));
                }
                else
                {
                    int nextPerson = rand.Next(piple.Count - 1) + 1;
                    try
                    {
                        santa.Give(piple[nextPerson]);
                    }
                    catch (FullPocketException e)
                    {
                        Console.WriteLine(e.Message);
                        piple.RemoveAt(nextPerson);
                    }
                    catch (EmptySackException e)
                    {
                        Console.WriteLine(e.Message);
                        if (!piple.Contains(snowMaiden))
                        {
                            break;
                        }
                    }
                    santa.Request(snowMaiden, rand.Next(1, 5));
                }
            }
        }
    }
}
