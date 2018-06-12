using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MultiTenant.Models
{
    public class Tenant
    {
        public Tenant()
        {

        }
        public Tenant(int id, string name, string domainName, bool defaultDomain)
        {
            this.Id = id;
            this.DomainName = domainName;
            this.Name = name;
            this.Default = defaultDomain;
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string DomainName { get; set; }

        public bool Default { get; set; }
    }
}