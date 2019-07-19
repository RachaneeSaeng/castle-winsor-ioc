namespace CastleWinsorIoC.Cache
{
    public class AbpMemoryCacheManager : CacheManagerBase
    {

        /// <summary>
        /// Constructor.
        /// </summary>
        public AbpMemoryCacheManager()
            : base()
        {
        }

        protected override string CreateCacheImplementation()
        {
            return "AbpMemoryCacheManager";
        }
    }
}
