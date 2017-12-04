using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Test.Controllers
{
    public class uploadimgForfileController : Controller
    {
        //
        // GET: /uploadimgForfile/

        public ActionResult Index()
        {
            return View();
        }
        #region 上传文件
        /// <summary>
        /// 上传文件
        /// </summary>
        /// <returns></returns>
        public string UploadFile()
        {
            string ulr = string.Empty;
            foreach (string f in Request.Files)
            {
                HttpPostedFileBase file = Request.Files[f];
                if (file != null && file.ContentLength > 0)
                {
                    ulr = UploadFile(file, "accessory");
                }
            }
            return ulr;
        }
        #endregion

        public static string UploadFile(HttpPostedFileBase file, string filePath)
        {
            string fileName = ""; string fileExtension = "", fileNewName = "";
            string path = "/File/Upload/" + filePath + "/" + DateTime.Now.ToString("yyyyMMdd") + "/";
            string directoryPath = System.Web.HttpContext.Current.Server.MapPath("~/" + path);
            if (!Directory.Exists(directoryPath)) Directory.CreateDirectory(directoryPath);
            if (file != null && file.ContentLength > 0)
            {
                fileName = file.FileName;
                fileExtension = Path.GetExtension(fileName);
                fileNewName = Guid.NewGuid().ToString() + fileExtension;
                filePath = Path.Combine(directoryPath, fileNewName);
                file.SaveAs(filePath);
            }

            //"http://" + System.Web.HttpContext.Current.Request.Url.Authority +
            return path + fileNewName;

        }

    }
}
