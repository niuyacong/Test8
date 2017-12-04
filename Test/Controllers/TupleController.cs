using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Test.Controllers
{
    public class TupleController : Controller
    {
        //
        // GET: /Tuple/

        public ActionResult Index()
        {
            return View();
        }
        public void test()
        {
            var L = new List<Tuple<string, string, double>>();
            L.Add(Tuple.Create("a", "b", 10D));
        }
        //这个还看不懂
        public sealed class Tuple<T1, T2>
        {

            private readonly T1 item1;

            private readonly T2 item2;

            public T1 Item1 { get { return item1; } }

            public T2 Item2 { get { return item2; } }

            public Tuple(T1 item1, T2 item2)
            {

                this.item1 = item1;

                this.item2 = item2;

            }

        }


    }
}
