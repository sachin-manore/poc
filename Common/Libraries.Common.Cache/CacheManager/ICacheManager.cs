

namespace Libraries.Common.Cache
{
    public interface ICacheManager
    {
        /// <summary>
        /// Gets data from the specified cache with the specified key.
        /// </summary>
        /// <typeparam name="T">The generic type of data which get from cache.</typeparam>
        /// <param name="key">The key to get the stored data from cache</param>
        /// <returns>The cache data from the stored cache key.</returns>
        T GetData<T>(string key);

        /// <summary>
        /// Gets data from the specified cache with the specified key.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key">The key to get the stored data from cache</param>
        /// <param name="isCacheRefreshSkip">The isCacheRefreshSkip to skip the stored data from cache</param>
        /// <returns>The cache data from the stored cache key.</returns>

        T GetData<T>(string key, bool isCacheRefreshSkip);

        /// <summary>
        /// Sets data in the specified cache with the specified key.
        /// </summary>
        /// <typeparam name="T">The generic type of data which sets in cache.</typeparam>
        /// <param name="key">The key to store the data in cache.</param>
        /// <param name="value">The data to store in the cache.</param>
        /// <returns>Boolean true on success and false on failure</returns>
        bool SetData<T>(string key, T value);

        /// <summary>
        /// Sets a value with the given key.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key">A string identifying the requested value</param>
        /// <param name="value">The value to set in the cache.</param>
        /// <param name="absoluteExpiration">It will expire the cache data after a set amount of time.</param>
        /// <returns>Boolean true on success and false on failure</returns>
        bool SetData<T>(string key, T value, DateTimeOffset absoluteExpiration);

       
        /// <summary>
        /// Removes the data from specified cache with the specified key.
        /// </summary>
        /// <param name="key">The key to dispose data from cache.</param>
        /// <returns>boolean true on success and false on failure</returns>
        bool DisposeCacheByKey(string key);

       
    }
}