using System;
using AspDotNetCoreCache.Config;
using Microsoft.Extensions.Options;
using StackExchange.Redis;

namespace AspDotNetCoreCache.Cache
{
    public sealed class MyRedisCache
    {
        private static string _redisConnectionString;
        private readonly Lazy<ConnectionMultiplexer> _lazyConnection = new Lazy<ConnectionMultiplexer>(()
            => ConnectionMultiplexer.Connect(_redisConnectionString));
        public ConnectionMultiplexer Connection => _lazyConnection.Value;

        public MyRedisCache(IOptions<RedisConfig> redisConfig)
        {
            _redisConnectionString = redisConfig.Value.RedisConnectionString;
        }
    }
}