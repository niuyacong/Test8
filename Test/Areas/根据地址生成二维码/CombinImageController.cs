using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Test.Areas.根据地址生成二维码
{
    public class CombinImageController : Controller
    {
        //
        // GET: /根据地址生成二维码/CombinImage/

        public ActionResult Index()
        {
            return View();
        }
        public void CombinImage(string name, string str)
        {
            string sourceImg = System.Web.HttpContext.Current.Server.MapPath("~/upload/2.jpg");
            string destImg = System.Web.HttpContext.Current.Server.MapPath("~/upload/code/" + name);
            Image imgBack = System.Drawing.Image.FromFile(sourceImg);     //相框图片  
            Image img = System.Drawing.Image.FromFile(destImg);        //照片图片
            Graphics g = Graphics.FromImage(imgBack);
            Font font = new Font("宋体", 8);
            SolidBrush sbrush = new SolidBrush(Color.Black);
            g.DrawString(str, font, sbrush, new PointF(10, 10));
            g.DrawImage(img, 252, 484, 600, 600);
            GC.Collect();
            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            string file = System.Web.HttpContext.Current.Server.MapPath("~/upload/qr/") + name;
            imgBack.Save(file, ImageFormat.Png);
            System.Drawing.Image myimg = imgBack;
            myimg.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
        }
      
    }
}
