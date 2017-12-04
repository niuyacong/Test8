using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Test.Controllers
{
    public class downloadController : Controller
    {
        //
        // GET: /download/

        public ActionResult Index()
        {
            return View();
        }
        //TransmitFile实现下载 
         protected void Button1_Click1(object sender, EventArgs e) 
        { 
             
            string strFileName = "三部闲置设备管理系统操作手册IEMS.ppt"; 
            Response.ContentType = "application/x-zip-compressed"; 
            //Response.ContentEncoding = System.Text.Encoding.GetEncoding("gb2312"); 
            string filename = "";  
            //BLL.Config.PART_EM_UPLOAD_DOC 为路径   ("D:/EMUploadDoc/") 
            Response.AddHeader("Content-Disposition", "attachment;filename=" +Server.UrlPathEncode(strFileName)); 
           //Server.UrlPathEncode()解决文件名的乱码问题. 
             
            Response.TransmitFile(filename); 
        }    //WriteFile实现下载 

    }
}
