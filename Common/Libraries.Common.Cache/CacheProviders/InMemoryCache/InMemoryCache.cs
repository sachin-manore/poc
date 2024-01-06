

namespace Libraries.Common.Cache
{
    public class InMemoryCache : ICacheProvider
    {
        private readonly IMemoryCache _cache;
       
        public InMemoryCache(IMemoryCache memoryCache)
        {
            _cache = memoryCache;
           
        }

        /// <summary>
        /// Gets data from the specified cache with the specified key.
        /// </summary>
        /// <typeparam name="T">The generic type of data which get from cache.</typeparam>
        /// <param name="key">The key to get the stored data from cache</param>
        /// <returns>The cache data from the stored cache key.</returns>
        public T GetData<T>(string key)
        {
            try
            {
                string _cacheData = Convert.ToString(_cache.Get(key));

                if (!string.IsNullOrEmpty(key) && !string.IsNullOrEmpty(_cacheData))
                    return JsonConvert.DeserializeObject<T>(_cacheData);

                return default(T);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Sets data in the specified cache with the specified key.
        /// </summary>
        /// <typeparam name="T">The generic type of data which sets in cache.</typeparam>
        /// <param name="key">The key to store the data in cache.</param>
        /// <param name="value">The data to store in the cache.</param>
        /// <returns>Boolean true on success and false on failure</returns>
        public bool SetData<T>(string key, T value)
        {
            bool response = true;
            try
            {

                var cacheEntryOptions = new MemoryCacheEntryOptions
                {
                    AbsoluteExpiration = DateTime.Now.AddHours(CacheSettings.AbsoluteExpiration),
                    SlidingExpiration = TimeSpan.FromMinutes(CacheSettings.SlidingExpiration)
                };

                if (!string.IsNullOrEmpty(key))
                {
                    _cache.Set(key, JsonConvert.SerializeObject(value, new JsonSerializerSettings() { ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore }), cacheEntryOptions);
                }
                else
                {
                    response = false;
                }
            }
            catch (Exception)
            {
                throw;
            }
            return response;
        }

       

        /// <summary>
        /// Removes the data from specified cache with the specified key.
        /// </summary>
        /// <param name="key">The key to dispose data from cache.</param>
        /// <returns>boolean true on success and false on failure</returns>
        public bool DisposeCacheByKey(string key)
        {
            try
            {
                if (!string.IsNullOrEmpty(key))
                {
                    _cache.Remove(key);
                    return true;
                }
            }
            catch (Exception)
            {
                throw;
            }
            return false;
        }

        public bool SetData<T>(string key, T value, DateTimeOffset absoluteExpiration)
        {
            throw new NotImplementedException();
        }

        public bool SetData<T>(string key, T value, TimeSpan slidingExpiration)
        {
            throw new NotImplementedException();
        }
    }
}
