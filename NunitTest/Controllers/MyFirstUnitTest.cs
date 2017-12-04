using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace NunitTest.Controllers
{
   public class MyFirstUnitTest:Controller
    {
       public ActionResult Test()
       {
           return Content("test");
       }
    }
}
