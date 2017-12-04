using Sider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Test.Areas.Redis
{ //1、Install-Package Sider -Version 0.10.2.22156
    public class redisTestController : Controller
    {
        //
        // GET: /Redis/Test/

        public ActionResult Index()
        {
            return View();
        }
       
        public void test()
        {
            var client = new RedisClient();// default host:port
            //client = new RedisClient("127.0.0.1", 6379); // custom host/port
            client.Set("HELLOOO", "WORLD!!!!");
            var print = client.Get("HELLOOO");
            Response.Write(print);
            client.Dispose(); // disconnect
        }
    }
}
