using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Task02
{
    /*
     В программе описать классы:
    •Human (имя);
    •Professor (наследник Human);
    •Department  (название, композиционно включает список сотрудников – объекты типа Human);
    •University (название, агрегационно включает список департаментов).
    •
    Задать массив университетов. Сериализовать и десериализовать бинарной/xml/json.
     */
    [Serializable]
    public class Human
    {
        public string Name { get; set; }

        public Human()
        {
            Name = "";
        }

        public Human(string name)
        {
            Name = name;
        }

        public override string ToString()
        {
            return $"A human called {Name}";
        }
    }

    [Serializable]
    public class Professor : Human
    {
        public Professor() : base() { }

        public Professor(string name) : base(name) { }

        public override string ToString()
        {
            return $"An honorable Porofessor called {Name}";
        }
    }

    [Serializable]
    public class Department
    {
        public string Name { get; set; }
        [JsonInclude]
        public List<Human> Staff;

        public Department()
        {
            Name = "";
            Staff = new();
        }

        public Department(string name, List<Human> staff)
        {
            Name = name;
            Staff = staff;
        }

        public override string ToString()
        {
            return $"Department {Name}.\nStaff list:\n{string.Join("\n\t", Staff)}";
        }
    }

    [Serializable]
    public class University
    {
        public string Name { get; set; }
        [JsonInclude]
        public List<Department> Departments;

        public University()
        {
            Name = "";
            Departments = new();
        }

        public University(string name, List<Department> departments)
        {
            Name = name;
            Departments = departments;
        }

        public override string ToString()
        {
            return $"University {Name}.\nDepartment list:\n{string.Join("\n\t", Departments)}";
        }
    }

    class Program
    {
        static Random rand = new Random();

        static string GenerateName(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[rand.Next(s.Length)]).ToArray());
        }

        static Human GenerateHuman()
        {
            return new Human(GenerateName(rand.Next(5, 8)));
        }

        static Professor GenerateProfessor()
        {
            return new Professor(GenerateName(rand.Next(5, 8)));
        }

        async static Task Main(string[] args)
        {
            List<Department> hseDeps = new();
            for (int i = 0; i < 4; i++)
            {
                Department d = new();
                d.Name = GenerateName(7);
                for (int _ = 0; _ < 3; _++)
                {
                    d.Staff.Add(rand.Next(2) == 0 ? GenerateHuman() : GenerateProfessor());
                }
                hseDeps.Add(d);
            }
            University hse = new("HSE", hseDeps);
            List<Department> msuDeps = new();
            for (int i = 0; i < 4; i++)
            {
                Department d = new();
                d.Name = GenerateName(7);
                for (int _ = 0; _ < 3; _++)
                {
                    d.Staff.Add(rand.Next(2) == 0 ? GenerateHuman() : GenerateProfessor());
                }
                msuDeps.Add(d);
            }
            University msu = new("HSE", hseDeps);

            University[] unis = { hse, msu };

            // BinaryFormatter
            Console.WriteLine("BinaryFormatter:");
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream file = new FileStream("binaryData.txt", FileMode.OpenOrCreate))
            {
                formatter.Serialize(file, unis);
            }
            using (FileStream file = new FileStream("binaryData.txt", FileMode.OpenOrCreate))
            {
                University[] _unis = (University[])formatter.Deserialize(file);
                Console.WriteLine(_unis[0]);
                Console.WriteLine(_unis[1]);
            }


            // XmlSerializer
            Console.WriteLine("XML serializer:");
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(University[]), new Type[] { typeof(Human), typeof(Professor) });

            using (FileStream file = new FileStream("XMLData.txt", FileMode.OpenOrCreate))
            {
                xmlSerializer.Serialize(file, unis);
            }
            using (FileStream file = new FileStream("XMLData.txt", FileMode.OpenOrCreate))
            {
                University[] _unis = (University[])xmlSerializer.Deserialize(file);
                Console.WriteLine(_unis[0]);
                Console.WriteLine(_unis[1]);
            }


            // JSON Serializer
            Console.WriteLine("JSON Serializer:");
            using (FileStream file = new FileStream("JSONData.txt", FileMode.OpenOrCreate))
            {
                await JsonSerializer.SerializeAsync(file, unis);
            }
            await Task.Delay(1000);
            using (FileStream file = new FileStream("JSONData.txt", FileMode.OpenOrCreate))
            {
                var p = await JsonSerializer.
                    DeserializeAsync<University[]>(file);
                foreach (University g in p)
                {
                    Console.WriteLine(g);
                }
            }
        }
    }
}
