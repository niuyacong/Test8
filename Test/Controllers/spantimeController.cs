using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Test.Controllers
{
    public class spantimeController : Controller
    {
        //
        // GET: /spantime/

        public ActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// 时间戳
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        private int GetCreatetime(DateTime? time)
        {
            DateTime DateStart = new DateTime(1970, 1, 1, 8, 0, 0);
            return Convert.ToInt32((DateTime.Parse(time.ToString()) - DateStart).TotalSeconds);
        } 
    }
}
