using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using WebApiControllers;

namespace Test.Controllers
{
    //接口权限信息
      [ApiAuthorize]
    public class apitestController : ApiController
    {
        //
        // GET: /apitest/

 
        //基于api接口的权限认证，首先接口的控制器要继承自ApiController
        //可以在start里面配置路由

        //介绍继承了webapi的控制器参数问题:https://docs.microsoft.com/en-us/aspnet/web-api/overview/formats-and-model-binding/parameter-binding-in-aspnet-web-api
    }
}
