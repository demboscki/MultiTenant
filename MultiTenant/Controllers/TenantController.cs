using MultiTenant.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MultiTenant.Controllers
{
    public class TenantController : BaseController
    {
        public ActionResult Index()
        {
            var tenants = new List<Tenant>() {
                new Tenant(1, "SUB_BRUNO", "www.bruno.teste.com.br", true )
                ,new Tenant(2, "SUB_jose", "jose.teste.com.br", false  )
                , new Tenant(3, "SUB_maria", "www.maria.teste.com.br", false  )
            };

            return View(tenants);
        }

    }
}