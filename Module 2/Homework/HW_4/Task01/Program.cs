using System;
using StackExchange.Redis;

namespace Task01
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
                    case "back":
                        Console.WriteLine("Restored to version: " + RedisClient.Back(args[1]));
                        break;
                    case "get":
                        Console.WriteLine("Current version: " + RedisClient.Get(args[1]));
                        break;
                }
            } while (input != "exit");
        }
    }
}
