using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Task01
{
    /*
    Класс Student (студент) включает фамилию и номер курса.
    Класс Group (группа) включает ее обозначение и список студентов.
    Определить две группы и сохранить их в файле, применяя двоичную сериализацию|xml|json.
    Прочитать данные из файла и восстановить объекты класса Группа.
    */

    [Serializable]
    public class Student
    {
        public string Surname { get; set; }
        public int Year { get; set; }

        public Student()
        {
            Surname = "";
            Year = 0;
        }

        public Student(string surname = "", int year = 0)
        {
            Surname = surname;
            Year = year;
        }

        public override string ToString()
        {
            return $"{Surname} {Year}";
        }
    }

    [Serializable]
    public class Group
    {
        public int Id { get; set; }
        [JsonInclude]
        public List<Student> students;

        public Group()
        {
            Id = 0;
            students = new();
        }

        public Group(int id, List<Student> students)
        {
            Id = id;
            this.students = students;
        }

        public override string ToString()
        {
            return $"Group {Id}: {string.Join(", ", students)}";
        }
    }

    class Program
    {
        async static Task Main(string[] args)
        {
            Student s1 = new("Ast", 1);
            Student s2 = new("Bst", 1);
            Student s3 = new("Cst", 2);
            Student s4 = new("Dst", 2);

            Group group1 = new(1, new List<Student>(new Student[] { s1, s2 }));
            Group group2 = new(2, new List<Student>(new Student[] { s3, s4 }));

            Group[] groups = new Group[] { group1, group2 };

            // BinaryFormatter
            Console.WriteLine("BinaryFormatter:");
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream file = new FileStream("binaryData.txt", FileMode.OpenOrCreate))
            {
                formatter.Serialize(file, groups);
            }
            using (FileStream file = new FileStream("binaryData.txt", FileMode.OpenOrCreate))
            {
                Group[] _groups = (Group[])formatter.Deserialize(file);
                Console.WriteLine(_groups[0]);
                Console.WriteLine(_groups[1]);
            }


            // XmlSerializer
            Console.WriteLine("XML serializer:");
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Group[]));

            using (FileStream file = new FileStream("XMLData.txt", FileMode.OpenOrCreate))
            {
                xmlSerializer.Serialize(file, groups);
            }
            using (FileStream file = new FileStream("XMLData.txt", FileMode.OpenOrCreate))
            {
                Group[] _groups = (Group[])xmlSerializer.Deserialize(file);
                Console.WriteLine(_groups[0]);
                Console.WriteLine(_groups[1]);
            }


            // JSON Serializer
            Console.WriteLine("JSON Serializer:");
            using (FileStream file = new FileStream("JSONData.txt", FileMode.OpenOrCreate))
            {
                await JsonSerializer.SerializeAsync(file, groups);
            }
            await Task.Delay(1000);
            using (FileStream file = new FileStream("JSONData.txt", FileMode.OpenOrCreate))
            {
                var p = await JsonSerializer.
                    DeserializeAsync<Group[]>(file);
                foreach (Group g in p)
                {
                    Console.WriteLine(g);
                }
            }
        }
    }
}
