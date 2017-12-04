using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Test.Controllers
    //    public class test1Controller : Controller  测试通过
    //{
    //    //
    //    // GET: /test1/
    //public class filter : ActionFilterAttribute
    //{
    //    public override void OnActionExecuting(ActionExecutingContext filterContext)
    //    {
    //       IDictionary<string,object>model= filterContext.ActionParameters;
    //        base.OnActionExecuting(filterContext);
    //       // filterContext.Result = new RedirectResult("/account/login",false);
              //filterContext.Result = new JsonResult(){}；
    //    }

    //    public override void OnActionExecuted(ActionExecutedContext filterContext)
    //    {
    //        ContentResult model = (ContentResult)filterContext.Result;
    //    }
    //}
    //}

           //var parameters = filterContext.ActionDescriptor.GetParameters();
           //     foreach (var parameter in parameters)
           //     {
           //         if (parameter.ParameterType == typeof(string))
           //         {
           //             //获取字符串参数原值
           //             var orginalValue = filterContext.ActionParameters[parameter.ParameterName] as string;
           //             //使用过滤算法处理字符串
           //             var filteredValue = "测试";
           //             //将处理后值赋给参数
           //             filterContext.ActionParameters[parameter.ParameterName] = filteredValue;
           //         }
           //     }
{
    public class filtersController : Controller
    {
        //
        // GET: /filters/

        public ActionResult Index()
        {
            return View();
        }
        public class EncryptLoginAttribute : ActionFilterAttribute
        {
            private string username;
            private string password;
            private bool isAuthorized = false;
            private string longdate;
            private string lastTry;

            public override void OnActionExecuting(ActionExecutingContext filterContext)
            {
                username = filterContext.HttpContext.Request.Form["username"];
                password = filterContext.HttpContext.Request.Form["password"];
                MD5 md5Hash = MD5.Create();
                string md5Password = GetMD5Hash(md5Hash, password);
                bool result = Membership.ValidateUser(username, md5Password);
                if (result)
                {
                    FormsAuthentication.SetAuthCookie(username, false);
                    isAuthorized = true;
                    longdate = DateTime.Now.ToLongDateString();
                }
                else
                {
                    isAuthorized = false;
                    lastTry = DateTime.Now.ToShortDateString() + "-" + DateTime.Now.ToShortTimeString();
                }
            }

            public override void OnActionExecuted(ActionExecutedContext filterContext)
            {
                if (isAuthorized)
                {
                    filterContext.Result = new ViewResult() { ViewName = "Welcome" };
                }
                else
                {
                    ViewResult result = new ViewResult();
                    result.ViewName = "Index";
                    result.ViewBag.message = "Login fail";
                    filterContext.Result = result;
                }
            }

            public override void OnResultExecuted(ResultExecutedContext filterContext)
            {
                if (filterContext.Exception == null && !filterContext.Canceled)
                {
                    ViewResult result = (ViewResult)filterContext.Result;
                    if (result != null)
                    {
                        if (result.ViewName == "Welcome")
                        {
                            filterContext.HttpContext.Response.Write("<p style='color:Green;'><br/>Today is "
    + longdate + "<br/></p>");
                        }
                        else if (result.ViewName == "Index")
                        {
                            filterContext.HttpContext.Response.Write("<p style='color:Red;'><br />Last Login attemp at " + lastTry + "<br/></p>");
                        }
                        filterContext.Result = result;
                    }
                }
            }

            private static string GetMD5Hash(MD5 md5Hash, string input)
            {
                //string→byte[]
                byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));
                StringBuilder stringBuilder = new StringBuilder();
                foreach (byte b in data)
                {
                    stringBuilder.Append(b.ToString("x2"));
                }
                return stringBuilder.ToString();
            }
        }
    }
}
