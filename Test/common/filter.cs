using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Test.common
{
    public class filter :IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
           
        }

        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
           
        }

        //public void OnResultExecuting(ResultExecutingContext filterContext)
        //{
        //}

        //public void OnResultExecuted(ResultExecutedContext filterContext)
        //{
        //}
    }


}