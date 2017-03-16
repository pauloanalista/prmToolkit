using System;
using System.Runtime.Caching;


namespace prmToolkit.AccessMultipleDatabaseWithAdoNet.Helpers.Mapper
{
    // This could be a static class I guess.
    public class CacheHelper : ICacheHelper
    {
        public void SaveToCache(string cacheKey, object savedItem, DateTime expirationTime)
        {
            MemoryCache.Default.Add(cacheKey, savedItem, expirationTime);
        }

        public T GetFromCache<T>(string cacheKey) where T : class
        {
            return MemoryCache.Default[cacheKey] as T;
        }

        public void RemoveFromCache(string cacheKey)
        {
            MemoryCache.Default.Remove(cacheKey);
        }

        public bool IsInCache(string cacheKey)
        {
            return MemoryCache.Default[cacheKey] != null;
        }
    }
}
