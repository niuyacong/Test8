using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace Test.Areas.readtextBYtab
{
    public class readandwriteController : Controller
    {
        //
        // GET: /readtextBYtab/readandwrite/

        public ActionResult Index()
        {
            return View();
        }
        public void read()
        {
            StreamReader sr = new StreamReader("F://test.txt", Encoding.Default);
            String line;
            FileStream fs = new FileStream("F://lala.txt", FileMode.Create);
            StreamWriter sw = new StreamWriter(fs);
            while ((line = sr.ReadLine()) != null)
            {
                string[] ccc = line.Split(new string[] { "\t" }, StringSplitOptions.None);
                sw.WriteLine("<option value=\"" + ccc[2] + "\">" + ccc[0] + "-" + ccc[1] + "</option>");
            }
            sw.Flush();
            //关闭流
            sw.Close();
            fs.Close();
        }
    }
}
