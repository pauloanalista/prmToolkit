using System;

namespace prmToolkit.AccessMultipleDatabaseWithAdoNet.Helpers.Mapper
{
    public interface ICacheHelper
    {
        void SaveToCache(string cacheKey, object savedItem, DateTime expirationTime);

        T GetFromCache<T>(string cacheKey) where T : class;

        void RemoveFromCache(string cacheKey);

        bool IsInCache(string cacheKey);
    }
}
