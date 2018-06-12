using System;

namespace MultiTenant
{
    public interface ITCache<T>
    {
        T Get(string cacheKeyName, int cacheTimeoutSeconds, Func<T> func);
    }
}