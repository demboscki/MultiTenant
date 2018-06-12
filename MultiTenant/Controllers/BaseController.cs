using MultiTenant.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MultiTenant.Controllers
{
    public class BaseController : Controller
    {
        public Tenant Tenant
        {
            get
            {
                object multiTenant;
                if (!Request.GetOwinContext().Environment.TryGetValue("MultiTenant", out multiTenant))
                {
                    throw new ApplicationException("Could not find tenant");
                }

                return (Tenant)multiTenant;
            }
        }
    }
}