using MultiTenant.Models;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MultiTenant
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.Use(async (ctx, next) =>
            {
                Tenant tenant = GetTenantBasedOnUrl(ctx.Request.Uri.Host);
                if (tenant == null)
                {
                    throw new ApplicationException("tenant not found");
                }
                ctx.Environment.Add("MultiTenant", tenant);
                await next();
            });
        }

        public const string CACHE_NAME = "tenants-cache";
        public const int CACHE_TIMEOUT_SECONDS = 30;
        private Tenant GetTenantBasedOnUrl(string host)
        {
            if (String.IsNullOrEmpty(host)) { throw new ApplicationException("url host must be specified"); }

            List<Tenant> tenants = new TCache<List<Tenant>>().Get(CACHE_NAME, CACHE_TIMEOUT_SECONDS
                , () =>
                {
                    tenants = MultiTenantContext.Tenants;
                    return tenants;
                });

            //List<Tenant> tenants = (List<Tenant>)HttpContext.Current.Cache.Get(CACHE_NAME);
            //if (tenants == null)
            //{
            //    lock (Locker)
            //    {
            //        if (tenants == null)
            //        {
            //            tenants = MultiTenantContext.Tenants;
            //            HttpContext.Current.Cache.Insert(CACHE_NAME, tenants, null
            //                , DateTime.Now.AddSeconds(CACHE_TIMEOUT_SECONDS), TimeSpan.Zero);
            //        }
            //    }
            //}

            Tenant tenant = tenants.FirstOrDefault(p => p.DomainName.ToLower().Equals(host));
            if (tenant == null)
            {
                throw new ApplicationException("tenant not found based on url, no default found");
            }
            return tenant;
        }
    }
}