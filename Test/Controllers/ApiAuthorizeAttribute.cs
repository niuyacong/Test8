
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;

namespace WebApiControllers
{
    public class ApiAuthorizeAttribute : AuthorizeAttribute
    {
        //protected override bool IsAuthorized(HttpActionContext actionContext)
        //{
        //    if (ConfigurationManager.AppSettings["Token"] == "1")
        //    {
        //        var ts = actionContext.Request.Headers.Where(c => c.Key.ToLower() == "token").FirstOrDefault().Value;
        //        var user = SysUserManager.Instance.GetEntityByCondition(" Token='" + ts + "'");
        //        if (user == null)
        //        {
        //            return false;
        //        }
        //        if (user != null && user.TokenTime < DateTime.Now)
        //        {
        //            return false;
        //        }
        //    }
        //    return true;
        //}
    }
}