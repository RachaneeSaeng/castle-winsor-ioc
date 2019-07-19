namespace CastleWinsorIoC.Cache
{
    public class RedisCacheManager : CacheManagerBase
    {

        /// <summary>
        /// Constructor.
        /// </summary>
        public RedisCacheManager()
            : base()
        {
        }

        protected override string CreateCacheImplementation()
        {
            return "RedisCacheManager";
        }
    }
}
