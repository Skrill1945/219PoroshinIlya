using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinderellaLib
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 0;
            try
            {
                n = int.Parse(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine("It must me an integer, you moron");
                return;
            }
            Random rand = new Random();
            Something[] somethings = new Something[n];
            for (int i = 0; i < n; i++)
            {
                somethings[i] = rand.Next(2) == 1 ? new Ashes(rand.NextDouble() * 1) : new Lentil(rand.NextDouble() * 2);
            }
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine(somethings[i]);
            }
            List<Ashes> ashes = new();
            List<Lentil> lentils = new();
            for (int i = 0; i < n; i++)
            {
                if (somethings[i].GetType() == typeof(Ashes))
                    ashes.Add((Ashes)somethings[i]);
                else
                    lentils.Add((Lentil)somethings[i]);
            }
            foreach (Ashes a in ashes)
            {
                Console.WriteLine(a);
            }
            foreach (Lentil a in lentils)
            {
                Console.WriteLine(a);
            }
        }
    }
}
