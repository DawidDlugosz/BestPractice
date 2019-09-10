using System;
using RedisCaching;

namespace CacheConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var redisCache = new RedisCachManager();
            redisCache.StartRedis();
            redisCache.StartRedis();
            redisCache.StartRedis();
            redisCache.StartRedis();
            Console.ReadKey();
        }
    }
}
