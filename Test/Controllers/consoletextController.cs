using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Test.Controllers
{
    public class consoletextController : Controller
    {
        //
        // GET: /consoletext/

        public ActionResult Index()
        {
            string htmlText = "";
            byte[] myByte = System.Text.Encoding.UTF8.GetBytes(htmlText);
            MemoryStream theMemoryStream = new MemoryStream();
            theMemoryStream.Write(myByte, 0, myByte.Length);
            theMemoryStream.Flush();
            theMemoryStream.Position = 0;
            return File(theMemoryStream, "application/octet-stream", Server.UrlEncode("API.html"));
            return View();
        }

    }
}
