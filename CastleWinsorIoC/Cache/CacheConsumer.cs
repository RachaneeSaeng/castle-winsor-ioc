namespace CastleWinsorIoC
{
    public class CacheConsumer
    {
        private readonly ICacheManager _cacheManager;
        public CacheConsumer(ICacheManager cacheManager)
        {
            _cacheManager = cacheManager;
        }

        public string GetCache()
        {
            return _cacheManager.GetCache();
        }
    }
}
