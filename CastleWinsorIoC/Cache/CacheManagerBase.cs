using System;

namespace CastleWinsorIoC.Cache
{
    public abstract class CacheManagerBase : ICacheManager, ISingletonDependency
    {
        protected CacheManagerBase()
        {
            Console.WriteLine("CacheManagerBase");
        }

        public virtual void Dispose()
        {

        }

        public string GetCache()
        {
            return $"implementation is {CreateCacheImplementation()}";
        }

        /// <summary>
        /// Used to create actual cache implementation.
        /// </summary>
        /// <param name="name">Name of the cache</param>
        /// <returns>Cache object</returns>
        protected abstract string CreateCacheImplementation();
    }
}
