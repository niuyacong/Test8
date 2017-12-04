using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Test.Controllers
{
    public class ComonTestController : Controller
    {
        //
        // GET: /ComonTest/
        public static readonly log4net.ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult test()
        {
            lock(this){
                log.Error("ceshi");
                return Content("test");
            }
        }

    }
}
