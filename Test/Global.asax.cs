using log4net;
using SuperSocket.SocketBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;
using Test.common;
using Test.websocketService;
namespace Test
{
    // 注意: 有关启用 IIS6 或 IIS7 经典模式的说明，
    // 请访问 http://go.microsoft.com/?LinkId=9394801
    public class MvcApplication : System.Web.HttpApplication
    {
//        //全局的filters
//         public static void RegisterGlobalFilters(GlobalFilterCollection filters){      
//17             filters.Add(new Test.common.filter());
//18         }
        public static readonly log4net.ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            IActionFilter model =new  Test.common.filter();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            var appServer = new TestServer();
            //if (!appServer.Setup(2014)) //开启的监听端口
            //{
            //    return;
            //}
            //log.Error("打开状态："+appServer.Start());
            //if (!appServer.Start())
            //{
            //    return;
            //}
        }

    }
}