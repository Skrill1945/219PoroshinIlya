using System;

namespace Task02
{
    class Program
    {
        static void Main()
        {
            string connectionString = "redis-18077.c282.east-us-mz.azure.cloud.redislabs.com:18077,password=XuTQ4bD3h1J4cOz5k5AagUkOqcWfwX3c,ConnectTimeout=10000,allowAdmin=true";
            RedisClient.Connect(connectionString);
            string input;
            do
            {
                input = Console.ReadLine();
                string[] args = input.Split();
                switch (args[0])
                {
                    case "add":
                        RedisClient.Add(args[1], args[2]);
                        break;
                    case "exist":
                        Console.WriteLine(RedisClient.Exists(args[1], args[2]) ? $"Product {args[2]} exists in storage {args[1]}" : $"Product {args[2]} does not exist in storage {args[1]}");
                        break;
                    case "get":
                        Console.WriteLine($"Storage {args[1]}:\n" + string.Join('\n', RedisClient.Get(args[1])));
                        break;
                    case "storages":
                        Console.WriteLine($"Storages:\n" + string.Join('\n', RedisClient.GetSorages()));
                        break;
                }
            } while (input != "exit");
        }
    }
}
