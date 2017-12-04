using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Test.Controllers
{
    public class BootstrapMutiTreeController : Controller
    {
        //
        // GET: /BootstrapMutiTree/

        public ActionResult Index()
        {
            return View();
        }
        //后台拼接树方法
        //#region 获取组织机构列表
        ///// <summary>
        ///// 获取所有组织机构列表
        ///// </summary>
        //public void GetViewSysOrganization()
        //{


        //    string value = Request["value"];
        //    List<SysOrganization> OneSysOrganization = SysOrganizationManager.Instance.GetList(" ParentID is null ");
        //    string sHtml = "<div class=\"panel-group\" id=\"accordion\"><div class=\"panel panel-default public-ti\">";
        //    if (OneSysOrganization.Count > 0)
        //    {
        //        for (var i = 0; i < OneSysOrganization.Count(); i++)
        //        {
        //            sHtml += "<div class=\"panel-heading company Company-title public\"style=\"\" data-toggle=\"collapse\" data-parent=\"#accordion\" data-target=\"#" + OneSysOrganization[i].ID + "a\" onclick=\"panelheading(this)\" names=\"" + OneSysOrganization[i].Description + "\" ids=\"" + OneSysOrganization[i].ID + "\">";
        //            sHtml += "<input type='text' value='" + OneSysOrganization[i].Name + "' class='Name-input' readOnly='true' style='border: none;background: #fff;'/>";
        //            sHtml += LtTreeHelper.BindFunction(value, OneSysOrganization[i].ID.Value);
        //            sHtml += "</div>";
        //            var id = int.Parse(OneSysOrganization[i].ID.ToString());
        //            sHtml += LtTree(value, id);
        //        }
        //        sHtml += "</div></div>";
        //    }
        //    Response.Write(sHtml);
        //}
        ////递归树
        //public string LtTree(string value, int id)
        //{
        //    string str = "";
        //    List<SysOrganization> OneSysOrganization = SysOrganizationManager.Instance.GetList(" ParentID= " + id);
        //    if (OneSysOrganization.Count > 0)
        //    {
        //        str = "<div id=\"" + id + "a\" class=\"panel-collapse collapse  collapseOne\" >";
        //        for (var i = 0; i < OneSysOrganization.Count; i++)
        //        {
        //            str += "<div  class=\"panel-body public\" data-toggle=\"collapse\" data-target=\"#" + OneSysOrganization[i].ID + "a\" onclick=\"panelbody(this)\" names=\"" + OneSysOrganization[i].Description + "\" ids=\"" + OneSysOrganization[i].ID + "\">";
        //            str += "<img src=\"/Content/images/fff.jpg\" class=\"fff\"/>";
        //            str += "<img src=\"/Content/images/grey_squares.png\" class=\"rhomb-img\"/>";
        //            str += "<input type='text' value='" + OneSysOrganization[i].Name + "' class='Name-input' readOnly='true' style='border: none;background: #fff;'/>";
        //            str += LtTreeHelper.BindFunction(value, OneSysOrganization[i].ID.Value);
        //            str += "</div>";
        //            var parentid = int.Parse(OneSysOrganization[i].ID.ToString());
        //            str += LtTree(value, parentid);
        //        }
        //        str += "</div>";
        //    }
        //    return str;
        //}
        //#endregion
    }
}
