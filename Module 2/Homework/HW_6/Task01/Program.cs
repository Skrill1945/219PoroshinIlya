using System;
using System.IO;
using System.Collections.Generic;

namespace Task01
{
    [System.Serializable]
    public class MyException : Exception
    {
        public MyException() { }
        public MyException(string message) : base(message) { }
        public MyException(string message, Exception inner) : base(message, inner) { }
        protected MyException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
    class Program
    {
        static int GetZero() => 0;

        static void RecursiveDeath()
        {
            RecursiveDeath();
        }

        static void Main(string[] args)
        {
            try
            {
                int a = 1 / GetZero();
            } 
            catch (DivideByZeroException ex)
            {
                Console.WriteLine(ex.Message);
            }

            try
            {
                int[] arr = new int[1];
                arr[1] = 1;
            }
            catch (IndexOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
            }

            try
            {
                List<int> l = null;
                l.Add(1);
            }
            catch (NullReferenceException ex)
            {
                Console.WriteLine(ex.Message);
            }

            try
            {
                object a = "a";
                int ia = (int)a;
            }
            catch (InvalidCastException ex)
            {
                Console.WriteLine(ex.Message);
            }

            try
            {
                File.ReadAllText(@"asd");
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }

            try
            {
                File.ReadAllText(@"__|\\*_");
            }
            catch (IOException ex)
            {
                Console.WriteLine(ex.Message);
            }

            try
            {
                List<long[]> l = new();
                for (int i = 0; i < 100; i++)
                {
                    l.Add(new long[2000000000]);
                }
            }
            catch (OutOfMemoryException ex)
            {
                Console.WriteLine(ex.Message);
            }

            try
            {
                int a = int.Parse(null);
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine(ex.Message);
            }

            try
            {
                int a = int.Parse("poipoi");
            }
            catch (FormatException ex)
            {
                Console.WriteLine(ex.Message);
            }

            try
            {
                Math.Round(1.1, 1, (MidpointRounding)10);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }

            try
            {
                // Помню что стаковерфлоу отловить нельзя, так что оно закомменчено
                // Это 11 номер (так что как доп)
                //RecursiveDeath();
            }
            catch (StackOverflowException ex)
            {
                Console.WriteLine(ex.Message);
            }

            try
            {
                throw Console.ReadLine() == "ouinnynginneenueae" ? new MyException("Congrats! Correct answer!") : new MyException("Wrong answer!");
            }
            catch (MyException ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
    }
}
