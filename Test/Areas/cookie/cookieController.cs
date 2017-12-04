using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Test.Areas.cookie
{
    public class cookieController : Controller
    {
        //
        // GET: /cookie/cookie/

        public ActionResult Index()
        {
            return View();
        }
        public void test()
        {
            //set
            HttpCookie cookie = new HttpCookie("user");
            cookie.Values.Add("openid", "j");
            cookie.Values.Add("session_key", "j");
            cookie.Expires = DateTime.Now.AddMilliseconds(7200);
            System.Web.HttpContext.Current.Response.Cookies.Add(cookie);

            //get
            var cookies = System.Web.HttpContext.Current.Request.Cookies["user"];
            int userid = 0;
            if (cookies != null)
            {
                userid = int.Parse(cookies.Values.Get("UserId"));
            }
        }
    }
}
