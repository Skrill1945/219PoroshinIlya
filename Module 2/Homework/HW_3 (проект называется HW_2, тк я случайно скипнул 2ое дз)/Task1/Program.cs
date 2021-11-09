using System;
using System.Linq;

namespace Task1
{
    class VideoFile
    {
        
        private string _name;
        private int _duration;
        private int _quality;

        public int Size
        {
            get => _duration * _quality;
        }

        public VideoFile(string name, int duration, int quality)
        {
            _name = name;
            _duration = duration;
            _quality = quality;
        }

        public override string ToString()
        {
            return $"{_name}:\nDuration {_duration}\nQuality {_quality}\nSize {Size}\n";
        }

    }


    class Program
    {
        static void Main(string[] args)
        {
            do
            {
                Console.Clear();
                Random rand = new();
                VideoFile vf1 = new("Example Video", 120, 720);
                Console.WriteLine(vf1);
                int n = rand.Next(5, 16);
                VideoFile[] videoFiles = new VideoFile[n];
                for (int i = 0; i < n; i++)
                    videoFiles[i] = new VideoFile($"Video{i + 1}", rand.Next(60, 361), rand.Next(100, 1001));
                foreach (var vf in videoFiles.Where(f => f.Size > vf1.Size))
                {
                    Console.WriteLine(vf);
                }
            } while (Console.ReadKey().Key != ConsoleKey.Escape);
        }
    }
}
