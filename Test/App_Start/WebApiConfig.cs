using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace Test
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
        //配置返回的时间类型数据格式
//        config.Formatters.JsonFormatter.SerializerSettings.Converters.Add(
//    new Newtonsoft.Json.Converters.IsoDateTimeConverter()
//    {
//        DateTimeFormat = "yyyy-MM-dd HH:mm:ss"
//    }
//);
    }

}
