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

        private Tenant GetTenantBasedOnUrl(string host)
        {
            if (String.IsNullOrEmpty(host)) { throw new ApplicationException("url host must be specified"); }

            Tenant tenant = MultiTenantContext.Tenants.FirstOrDefault(p => p.DomainName.ToLower().Equals(host));
            if (tenant == null)
            {
                throw new ApplicationException("tenant not found based on url, no default found");
            }
            return tenant;
        }
    }
}