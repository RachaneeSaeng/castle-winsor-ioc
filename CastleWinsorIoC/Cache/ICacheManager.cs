using System;

namespace CastleWinsorIoC
{
    public interface ICacheManager : IDisposable
    {
        string GetCache();
    }
}
