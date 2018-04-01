using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using TeknikServis.BLL.Account;
using TeknikServis.Entity.Enums;
using TeknikServis.Entity.IdentityModels;

namespace TeknikServis.WebMVC.UI
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            var roleManager = MembershipTools.NewRoleManager();
            var roller = Enum.GetNames(typeof(IdentityRoles));
            foreach (var rol in roller)
            {
                if (!roleManager.RoleExists(rol))
                    roleManager.Create(new ApplicationRole()
                    {
                        Name = rol
                    });
            }
        }
    }
}
