using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace Test.Controllers
{
    public class AssemblyController : Controller
    {
        //
        // GET: /Assembly/

        public ActionResult Index()
        {
            return View();
        }

        //类Assembly的静态的方法
        //public static Assembly Load(string );
        //public static Assembly LoadFrom(string );

        ////获得程序集的实例
        //Assembly myAssembly=Assembly.Load("System.Drawing");

    }
}
