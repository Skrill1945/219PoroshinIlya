using System;
using StackExchange.Redis;
using System.Collections.Generic;
using System.Linq;

namespace Task02
{
    static class RedisClient
    {
        private static ConnectionMultiplexer redis;
        private static IDatabase database;
        private static IServer server;

        public static void Connect(string connectionString = "localhost")
        {
            redis = ConnectionMultiplexer.Connect(connectionString);
            database = redis.GetDatabase();
            server = redis.GetServer("redis-18077.c282.east-us-mz.azure.cloud.redislabs.com", 18077);
        }

        private static string ConvertKey(string key)
        {
            return $"$Storage_{key}";
        }

        public static void Add(string key, string value)
        {
            key = ConvertKey(key);
            database.ListRightPush(key, value);
        }

        public static List<string> Get(string key)
        {
            key = ConvertKey(key);
            List<string> productNames = new();
            for (int i = 0; i < database.ListLength(key); i++)
            {
                productNames.Add(database.ListGetByIndex(key, i));
            }
            return productNames;
        }

        public static bool Exists(string key, string productName)
        {
            key = ConvertKey(key);
            return Get(key).Contains(productName);
        }

        public static List<string> GetSorages()
        {
            return new List<string>(server.Keys().ToList().Select(t => t.ToString()).Where(t => t.StartsWith("$Storage_")));
        }

    }
}
