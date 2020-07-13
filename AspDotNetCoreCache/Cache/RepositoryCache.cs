using System;
using System.Collections.Generic;
using System.Linq;
using AspDotNetCoreCache.Model;
using Microsoft.Extensions.Caching.Memory;

namespace AspDotNetCoreCache.Cache
{
    public class RepositoryCache
    {
        private readonly IRepository _repository;
        private readonly MyRedisCache _redisCache;
        private readonly MemoryCache _memoryCache;

        public RepositoryCache(IRepository repository, MyMemoryCache memoryCache, MyRedisCache redisCache)
        {
            _repository = repository;
            _redisCache = redisCache;
            _memoryCache = memoryCache.Cache;
        }

        public int GetBooksCount()
        {
            const string cacheKey = "_BooksCount";
            if (!_memoryCache.TryGetValue(cacheKey, out int cacheResult))
            {
                // cacheKey不存在於快取,重取資料
                cacheResult = _repository.GetBooksCount();

                // 設定快取的使用量和到期時間
                var cacheEntryOptions = new MemoryCacheEntryOptions()
                    {
                        // 撐個十秒 (10秒一到自動清除)
                        AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(10)
                    }
                    // 使用1個單位
                    .SetSize(1);
                    // 撐個十秒 (10秒內如果都沒有被使用才會清除)
                    //.SetSlidingExpiration(TimeSpan.FromSeconds(10));

                // 將資料和快取設定加到快取裡面
                _memoryCache.Set(cacheKey, cacheResult, cacheEntryOptions);
            }
            return cacheResult;
        }

        public string GetBookTags()
        {
            const string cacheKey = "_BookTags";
            // 連線到 Redis
            var redisDb = _redisCache.Connection.GetDatabase();
            // 取得快取資料
            var cacheResult = redisDb.StringGet(cacheKey);

            if (string.IsNullOrWhiteSpace(cacheResult))
            {
                cacheResult = _repository.GetBookTags().Aggregate((i, j) => i + "," + j);
                // 重新加入快取資料並設定到期時間
                redisDb.StringSet(cacheKey, cacheResult, TimeSpan.FromSeconds(10));
            }

            return cacheResult;
        }
    }
}