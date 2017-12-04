using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Test.Areas.study.Controllers
{
    public class ZtreeandhighchartsController : Controller
    {
        //
        // GET: /study/Ztreeandhighcharts/

        public ActionResult Index()
        {
            return View();
        }

        //一级树形：品类
        public class TopTree
        {
            public int topTreeCode { get; set; }
            public string topTreeName { get; set; }
            public List<SecondTree> second { get; set; }
        }
        //二级树形：品规
        public class SecondTree
        {
            public int secondTreeCode { get; set; }
            public string secondTreeName { get; set; }
            public List<product> productName { get; set; }
        }
        //三级树形：产品
        public class product
        {
            public string productName { get; set; }
        }
        //品类品规树形图数据  牛亚聪 2017-5-11 15:47:49
        //public string GetTreeList()
        //{
        //    var appendHtml = "";

        //    List<TopTree> toptreeList = new List<TopTree>();
        //    List<T_ProductCategory> Category = ProductCategoryManager.Instance.GetList();
        //    for (var i = 0; i < Category.Count(); i++)
        //    {

        //        TopTree toptree = new TopTree();
        //        var categoryId = Category[i].ID;
        //        var categoryName = Category[i].Name + (Category[i].Status == 0 ? "" : "(" + (Category[i].Status == 1 ? "禁用" : "已删除") + ")");
        //        toptree.topTreeCode = categoryId ?? 0;
        //        toptree.topTreeName = categoryName;

        //        List<T_ProductSpecification> Specification = ProductSpecificationManager.Instance.GetList(" ProductCategoryID=" + categoryId);
        //        appendHtml += "{name:\"" + categoryName + (Specification.Count.ToString() == "0" ? "\", isParent:true}," : "\", open:true,");
        //        if (Specification.Count > 0)
        //        {
        //            appendHtml += "children: [";
        //            List<SecondTree> secondtreeList = new List<SecondTree>();
        //            for (var j = 0; j < Specification.Count(); j++)
        //            {
        //                SecondTree secondtree = new SecondTree();
        //                var specificationID = Specification[j].ID;
        //                var specificationName = Specification[j].Name;
        //                secondtree.secondTreeCode = specificationID ?? 0;
        //                secondtree.secondTreeName = specificationName;

        //                List<T_Product> products = T_ProductManager.Instance.GetList(" ProductCategoryID=" + categoryId + "  and ProductSpecificationID=" + specificationID);
        //                appendHtml += "{name:\"" + specificationName + (products.Count.ToString() == "0" ? "\", isParent:true}," : "\", open:true,");

        //                if (products.Count > 0)
        //                {
        //                    appendHtml += "children: [";
        //                    List<product> productList = new List<product>();
        //                    for (var k = 0; k < products.Count(); k++)
        //                    {
        //                        product product = new product();
        //                        product.productName = products[k].Name;
        //                        appendHtml += "{name:\"" + products[k].Name + "\",click:\"here(\'" + categoryId + "\',\'" + specificationID + "\')\"},";
        //                        productList.Add(product);
        //                    }
        //                    appendHtml += "]}";
        //                    secondtree.productName = productList;
        //                }
        //                secondtreeList.Add(secondtree);
        //            }
        //            appendHtml += "]}";
        //            toptree.second = secondtreeList;
        //        }
        //        toptreeList.Add(toptree);
        //    }
        //    var html = "[" + appendHtml + "]";
        //    return html;
        //}
        ////折线图数据  牛亚聪  2017-5-11 15:47:26
        //public JsonResult CurrentMonthCount(int topId, int secondId)
        //{
        //    DateTime now = DateTime.Now;
        //    DateTime d1 = new DateTime(now.Year, now.Month, 1);
        //    DateTime d2 = DateTime.Now;
        //    var boxstr = "";
        //    var bottlestr = "";
        //    while (d2 >= d1)
        //    {
        //        DateTime newdate = d1.AddDays(1);
        //        var sch = " ProductCategoryID=" + topId + " and ProductSpecificationID=" + secondId + " and CodeType=2 and CreateTime>=\'" + d1 + "\' and CreateTime<=\'" + newdate + "\'";
        //        int boxcount = T_TraceCodesManager.Instance.GetCount(sch);
        //        boxstr += "" + boxcount + ",";
        //        int bottlecount = T_TraceCodesManager.Instance.GetCount(" ProductCategoryID=" + topId + " and ProductSpecificationID=" + secondId + "  and CodeType=1 and CreateTime>=\'" + d1 + "\' and CreateTime<=\'" + newdate + "\'");
        //        bottlestr += "" + bottlecount + ",";
        //        d1 = newdate;
        //    }
        //    var box = "[" + boxstr + "]";
        //    var bottle = "[" + bottlestr + "]";
        //    return Json(new { box = box, bottle = bottle }, JsonRequestBehavior.AllowGet);
        //}
    }
}
