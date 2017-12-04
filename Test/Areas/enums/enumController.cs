using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Test.Areas.enums
{
    public class enumController : Controller
    {
        //
        // GET: /enum/enum/

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult TestEnum()
        {
            //根据枚举值，获得枚举名称
            string name = Enum.GetName(typeof(ColorEnum.MyColorEnum), 1);
            //根据枚举名称，获得枚举值
           int flag=(int) Enum.Parse(typeof(ColorEnum.MyColorEnum), "red");
           return Content(name+flag);
        }
    }
}
