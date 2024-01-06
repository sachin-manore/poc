
namespace Libraries.Common.Cache
{
    public interface ICacheProvider
    {
        /// <summary>
        /// Gets data from the specified cache with the specified key.
        /// </summary>
        /// <typeparam name="T">The generic type of data which get from cache.</typeparam>
        /// <param name="key">The key to get the stored data from cache</param>
        /// <returns>The cache data from the stored cache key.</returns>
        T GetData<T>(string key);

        /// <summary>
        /// Sets data in the specified cache with the specified key.
        /// </summary>
        /// <typeparam name="T">The generic type of data which sets in cache.</typeparam>
        /// <param name="key">The key to store the data in cache.</param>
        /// <param name="value">The data to store in the cache.</param>
        /// <returns>Boolean true on success and false on failure</returns>
        bool SetData<T>(string key, T value);

        /// <summary>
        /// Sets data in the specified cache with the specified key.
        /// </summary>
        /// <typeparam name="T">The generic type of data which sets in cache.</typeparam>
        /// <param name="key">The key to store the data in cache.</param>
        /// <param name="value">The data to store in the cache.</param>
        /// <param name="absoluteExpiration">It will expire the cache data after a set amount of time.</param>
        /// <returns>Boolean true on success and false on failure</returns>
        bool SetData<T>(string key, T value, DateTimeOffset absoluteExpiration);

        /// <summary>
        /// Sets data in the specified cache with the specified key.
        /// </summary>
        /// <typeparam name="T">The generic type of data which sets in cache.</typeparam>
        /// <param name="key">The key to store the data in cache.</param>
        /// <param name="value">The data to store in the cache.</param>
        /// <param name="slidingExpiration">It will expire the cache data if it hasn't been accessed in a set amount of time.</param>
        /// <returns>Boolean true on success and false on failure</returns>
        bool SetData<T>(string key, T value, TimeSpan slidingExpiration);

        /// <summary>
        /// Removes the data from specified cache with the specified key.
        /// </summary>
        /// <param name="key">The key to dispose data from cache.</param>
        /// <returns>boolean true on success and false on failure</returns>
        bool DisposeCacheByKey(string key);

      

    }
}
