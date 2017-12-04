using Gma.QrCodeNet.Encoding;
using Gma.QrCodeNet.Encoding.Windows.Render;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Test.Areas.根据地址生成二维码
{
    public class QrCodeNetController : Controller
    {
        //
        // GET: /根据地址生成二维码/QrCodeNet/

        public ActionResult Index()
        {
            return View();
        }
        /// <summary>  
        /// 获取二维码  
        /// </summary>  
        /// <param name="strContent">待编码的字符</param>  
        /// <param name="ms">输出流</param>  
        ///<returns>True if the encoding succeeded, false if the content is empty or too large to fit in a QR code</returns>  
        public static bool GetQRCode(string strContent, MemoryStream ms)
        {
            ErrorCorrectionLevel Ecl = ErrorCorrectionLevel.M; //误差校正水平   
            string Content = strContent;//待编码内容  
            QuietZoneModules QuietZones = QuietZoneModules.Two;  //空白区域   
            int ModuleSize = 12;//大小  
            var encoder = new QrEncoder(Ecl);
            QrCode qr;
            if (encoder.TryEncode(Content, out qr))//对内容进行编码，并保存生成的矩阵  
            {
                var render = new GraphicsRenderer(new FixedModuleSize(ModuleSize, QuietZones));
                render.WriteToStream(qr.Matrix, ImageFormat.Png, ms);
            }
            else
            {
                return false;
            }
            return true;
        }
         public ActionResult test()
         {
             using (var ms = new MemoryStream())
             {
                 string stringtest = "中国inghttp://www.baidu.com/mvc.test?&";
                 GetQRCode(stringtest, ms);
                 //输出在页面上
                 //Response.ContentType = "image/Png";
                 //Response.OutputStream.Write(ms.GetBuffer(), 0, (int)ms.Length);
                 //Response.End();
                 //生成文件
                 var path = "test.png";
                 string Folder = System.Web.HttpContext.Current.Server.MapPath("~/upload/code/");
                 if (!Directory.Exists(Folder))
                 {
                     Directory.CreateDirectory(Folder);
                 }
                 string filePath = Folder + path;
                 Stream rs = ms;
                 System.Drawing.Image j = Image.FromStream(rs);
                 j.Save(filePath, System.Drawing.Imaging.ImageFormat.Png);
                 rs.Close();
                 j.Dispose();
             }
             return View("/views/raffle/Raf_Reward/test.html");
         }
    
    }

}
