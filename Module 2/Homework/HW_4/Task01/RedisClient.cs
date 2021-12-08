using System;
using StackExchange.Redis;

namespace Task01
{
    static class RedisClient
    {
        public const uint MaxCount = 5;
        private static ConnectionMultiplexer redis;
        private static IDatabase database;

        public static void Connect(string connectionString = "localhost")
        {
            redis = ConnectionMultiplexer.Connect(connectionString);
            database = redis.GetDatabase();
        }

        public static string Get(string key)
        {
            return database.ListGetByIndex(key, 0);
        }

        public static bool Exists(string key)
        {
            return database.KeyExists(key);
        }

        public static void Add(string key, string value)
        {
            if (database.ListLength(key) < MaxCount)
                database.ListLeftPush(key, value);
            else
                database.ListRightPopLeftPush(key, value);
        }

        public static string Back(string key)
        {
            Console.WriteLine("Versions in DB: " + database.ListLength(key));
            if (database.ListLength(key) < 2)
            {
                database.KeyDelete(key);
                throw new ArgumentException("There are no previous versions.");
            }
            database.ListLeftPop(key);
            return database.ListGetByIndex(key, 0);
        }

    }
}
