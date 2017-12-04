using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Test.common;
namespace Test.Controllers
{
    //http://www.cnblogs.com/kissdodog/archive/2013/01/21/2869298.html
    //http://www.cnblogs.com/Leo_wl/p/5509751.html(不错)
    public class filter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);
            filterContext.Result = new RedirectResult("/account/login", false);
        }

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            filterContext.Result = new System.Web.Mvc.JsonResult() { Data = new { statusCode = 301 }, ContentEncoding = System.Text.Encoding.UTF8, JsonRequestBehavior = JsonRequestBehavior.AllowGet, ContentType = "json" };
        }
    }

    public class uploadSingleImgController : Controller
    {
        //
        // GET: /uploadSingleImg/
       [filter]
        public ActionResult Index()
        {
            return View();
        }
        
        public string upload(string imgOne)
        {

            string fileName = DateTime.Now.ToString("yyyyMMddhhmmssfff") + ".jpg";
            string Folder = System.Web.HttpContext.Current.Server.MapPath("~/Upload/img/" + DateTime.Now.ToString("yyyyMMdd") + "/");
            if (!Directory.Exists(Folder))
            {
                Directory.CreateDirectory(Folder);
            }
           int delLength = imgOne.IndexOf(',') + 1;  
                string str = imgOne.Substring(delLength, imgOne.Length - delLength);  
                Image returnImage = Base64StringToImage(str);
                returnImage.Save((Folder+ fileName), System.Drawing.Imaging.ImageFormat.Jpeg);
            return Folder+fileName;
        }
        private Image Base64StringToImage(string txt)
        {
            byte[] arr = Convert.FromBase64String(txt);
            MemoryStream ms = new MemoryStream(arr);
            Bitmap bmp = new Bitmap(ms);
            return bmp;
        }
     //还没测
        public  string ImgToBase64String(string Imagefilename)
        {
            try
            {
                Bitmap bmp = new Bitmap(Imagefilename);

                MemoryStream ms = new MemoryStream();
                bmp.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                byte[] arr = new byte[ms.Length];
                ms.Position = 0;
                ms.Read(arr, 0, (int)ms.Length);
                ms.Close();
                return Convert.ToBase64String(arr);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
