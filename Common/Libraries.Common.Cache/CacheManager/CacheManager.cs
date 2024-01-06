namespace Libraries.Common.Cache
{
    public class CacheManager : ICacheManager
    {
        protected ICacheProvider _cacheProvider;

        public CacheManager(ICacheProvider CacheProvider)
        {
            _cacheProvider = CacheProvider;
        }

        public bool DisposeCacheByKey(string key)
        {
            throw new NotImplementedException();
        }

        public T GetData<T>(string key)
        {
            throw new NotImplementedException();
        }

        public T GetData<T>(string key, bool isCacheRefreshSkip)
        {
            throw new NotImplementedException();
        }

        public bool SetData<T>(string key, T value)
        {
            throw new NotImplementedException();
        }

        public bool SetData<T>(string key, T value, DateTimeOffset absoluteExpiration)
        {
            throw new NotImplementedException();
        }

        private bool IsRefreshCache()
        {
            return true;
        }



    }
}
