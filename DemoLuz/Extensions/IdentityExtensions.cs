using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;

namespace DemoLuz.Extensions
{
    public static class IdentityExtensions
    {
        public static string GetCompanyName(this IIdentity identity)
        {
            return HttpContext.Current.GetOwinContext()
               .GetUserManager<ApplicationUserManager>()
               .FindById(identity.GetUserId()).Company;
        }
    }
}