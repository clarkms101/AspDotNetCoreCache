using Microsoft.Extensions.Caching.Memory;

namespace AspDotNetCoreCache.Cache
{
    public class MyMemoryCache
    {
        public MemoryCache Cache { get; set; }
        public MyMemoryCache()
        {
            Cache = new MemoryCache(new MemoryCacheOptions
            {
                // 提供2個單位作快取
                SizeLimit = 2
            });
        }
    }
}