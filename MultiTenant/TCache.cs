using System;
using System.Collections.Generic;
using System.Web;
using MultiTenant.Models;

namespace MultiTenant
{
    public class TCache<T> : ITCache<T>
    {
        public T Get(string cacheName, int cacheTimeoutSeconds, Func<T> p)
        {
            var redisCache = true;
            if (redisCache)
            {
                return new TCacheInternal<T>().Get(cacheName, cacheTimeoutSeconds, p);
            }
            else
            {
                return new TCacheInternal<T>().Get(cacheName, cacheTimeoutSeconds, p);
            }
        }

    }
}