using System;
using System.Collections.Generic;
using System.Web;
using MultiTenant.Models;

namespace MultiTenant
{
    public class TCacheInternal<T> : ITCache<T>
    {
        internal static readonly object Locker = new object();

        public T Get(string cacheName, int cacheTimeoutSeconds, Func<T> p)
        {
            var obj = HttpContext.Current.Cache.Get(cacheName);
            if (obj != null)
            {
                return (T)obj;
            }

            lock (Locker)
            {
                obj = HttpContext.Current.Cache.Get(cacheName);
                if (obj != null)
                {
                    obj = p();
                    HttpContext.Current.Cache.Insert(cacheName, obj, null
                        , DateTime.Now.AddSeconds(cacheTimeoutSeconds), TimeSpan.Zero);
                }
                return (T)obj;
            }
        }

    }
}