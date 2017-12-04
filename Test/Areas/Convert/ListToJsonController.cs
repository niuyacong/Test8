using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace Test.Areas.Convert
{
    public class ListToJsonController : Controller
    {
        //
        // GET: /Convert/ListToJson/

        public ActionResult Index()
        {
            return View();
        }
        public void Convert<T>(List<T> model)
        {
            DataContractJsonSerializer json = new DataContractJsonSerializer(model.GetType());

            string szJson = "";

            //序列化

            using (MemoryStream stream = new MemoryStream())
            {

                json.WriteObject(stream, model);

                szJson = Encoding.UTF8.GetString(stream.ToArray());

            }
        }
    }
}
