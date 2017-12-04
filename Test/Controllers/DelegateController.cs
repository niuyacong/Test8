using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Test.Controllers
{
    public class DelegateController : Controller
    {
        //
        // GET: /Delegate/

        public ActionResult Index()
        {
            return View();
        }
        public void GreetPeople(string name)
        {
            EnglishGreeting(name);

        }
        public void EnglishGreeting(string name)
        {

            Console.WriteLine("Morning, " + name);

        }
        struct MyStruct
        {
            public string _name;
            public MyStruct(string name)
            {
                this._name = name;
            }
        }
        public void test()
        {
           

        }
    }
}
