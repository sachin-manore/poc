

namespace Libraries.Common.Cache
{
    public static class CacheSettings
    {
        public static IConfigurationSection settings;

       
        public static int SlidingExpiration
        {
            get
            {
                return Convert.ToInt16(settings["SlidingExpiration"]);
            }
        }
        public static int AbsoluteExpiration
        {
            get
            {
                return Convert.ToInt16(settings["AbsoluteExpiration"]);
            }
        }

        

    }
}
