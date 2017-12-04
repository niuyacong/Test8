using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace Test.Controllers
{
    public class xpController : Controller
    {
        //
        // GET: /xp/

        /// <summary>
        /// 调用方式 XP/module_controller_action
        /// </summary>
        /// <param name="module"></param>
        /// <returns></returns>
        public ActionResult Index(string module)
        {
            
            try
            {
                int mm = module.IndexOf("?");
                if (module.IndexOf("?") > 0)
                {
                    module = module.Substring(0, module.IndexOf("?") - 1);
                }

                string[] ps = module.Split('_');

               
                var dll =  ps[0];
                var className = ps[1];
                var method = ps[2];
                var p = Assembly.Load(dll);
                dynamic instance = Assembly.Load(dll).CreateInstance(dll + "." + className, true, BindingFlags.Instance | BindingFlags.Public, null, null, null, null);

                if (instance == null) return Content("404");

                var r = instance.GetType().InvokeMember(method, BindingFlags.Public | BindingFlags.IgnoreCase | BindingFlags.Instance | BindingFlags.InvokeMethod, null, instance, new object[] { });

                return r;
            }
            catch (Exception e)
            {
              
                return Content("500");
            }
        }
    }
}
