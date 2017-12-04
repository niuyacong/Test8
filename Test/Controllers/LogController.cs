using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using log4net;
namespace Test.Controllers
{
    public class LogController : Controller
    {
        //
        // GET: /Log/

        public ActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// log对象
        /// </summary>
        public static readonly log4net.ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public void Test()
        {
            try
            {
                Response.Write("1");
                throw new Exception();
            }
            catch(Exception ex ){
                log.Error("测试"+ex);
            }
        }

        //捕捉全局错误异常
        //1、WinForm：在Program.cs文件里
         
        //[STAThread]
        //static void Main()
        //{
        //    //处理未捕获的异常  
        //    Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
        //    //处理UI线程异常  
        //    Application.ThreadException += Application_ThreadException;
        //    //处理非UI线程异常  
        //    AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;

        //    #region 应用程序的主入口点
        //    Application.EnableVisualStyles();
        //    Application.SetCompatibleTextRenderingDefault(false);
        //    Application.Run(new Form1());
        //    #endregion
        //}

        ////处理UI线程异常  
        //static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        //{
        //    Exception error = e.Exception as Exception;
        //    //记录日志  
        //}

        ////处理非UI线程异常  
        //static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        //{
        //    Exception error = e.ExceptionObject as Exception;
        //    //记录日志  
        //}  

        //2、mvc 放在filter.cs文件中
        /// <summary>  
        /// 自定义错误处理类  
        /// </summary>  
        //public class MyExceptionFilterAttribute : HandleErrorAttribute
        //{
        //    public override void OnException(ExceptionContext filterContext)
        //    {
        //        base.OnException(filterContext);
        //        //处理错误消息  
        //        Exception error = filterContext.Exception;
        //        //记录日志           
        //    }
        //} 
        //全局使用     FilterConfig.cs 文件中
        //public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        //{
        //    filters.Add(new HandleErrorAttribute());
        //    filters.Add(new MyExceptionFilterAttribute());
        //}

        //3、asp.net放在Global.asax.cs文件中
        //void Application_Error(object sender, EventArgs e)
        //{
        //    // 在出现未处理的错误时运行的代码  
        //    Exception error = Server.GetLastError().GetBaseException();
        //    //记录日志  
        //}  
    }
}
