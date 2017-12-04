
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Test.Controllers
{
    public class webServiceController : Controller
    {
        //
        // GET: /webService/

        public ActionResult Index()
        {
           
            return View();
        }
        //调用其他网站的
        public JsonResult test()
        {
            //报错：无法加载协定为“ServiceReference.WeatherWSSoap”的终结点配置部分，因为找到了该协定的多个终
            //web.config中有多个配置指向同一个地址，删除一个就可以了
            ServiceReference.WeatherWSSoapClient s = new ServiceReference.WeatherWSSoapClient();
            string[] arr = s.getRegionCountry();
            return Json(new{data=arr},JsonRequestBehavior.AllowGet);
        }
        public void downloadpic()
        {
            WebClient web = new WebClient();
            //将图片下载到本地
           // web.DownloadFile();
        }
    }
}
