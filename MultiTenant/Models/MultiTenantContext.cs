using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MultiTenant.Models
{
    public static class MultiTenantContext
    {
        private static List<Tenant> _tenants = new List<Tenant>() {
                new Tenant(1, "SUB_BRUNO", "www.bruno.teste.com.br", true )
                ,new Tenant(2, "SUB_jose", "jose.teste.com.br", false  )
                , new Tenant(3, "SUB_maria", "www.maria.teste.com.br", false  )
            };

        public static List<Tenant> Tenants { get { return _tenants; } }


    }
}