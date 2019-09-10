using System;
using StackExchange.Redis;

namespace RedisCaching
{
    public class RedisCachManager
    {
        public void StartRedis()
        {
            var redis = ConnectionMultiplexer.Connect("localhost");
            var db = redis.GetDatabase();
            db.StringSet("aaa", "aa");
        }
    }
}
