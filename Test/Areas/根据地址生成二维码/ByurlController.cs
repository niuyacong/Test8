using com.google.zxing;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using COMMON = com.google.zxing.common;
namespace Test.Areas.根据地址生成二维码
{
    public class ByurlController : Controller
    {
        //
        // GET: /根据地址生成二维码/Byurl/

        public ActionResult Index()
        {
            return View();
        }
        //根据地址生成二维码图片保存在本地
        public void url(int id)
        {
            var content = "http://act.foodszs.cn/raffle/home/lead?id=" + id;
            COMMON.ByteMatrix byteMatrix = new MultiFormatWriter().encode(content, BarcodeFormat.QR_CODE, 350, 350);
            var path = DateTime.Now + ".png";
            writeToFile(byteMatrix, path, Server.MapPath("/upload/qr/") + path, System.Drawing.Imaging.ImageFormat.Png);

        }
        public void writeToFile(COMMON.ByteMatrix matrix, string path, string file, System.Drawing.Imaging.ImageFormat format)
        {
            Bitmap bmap = toBitmap(matrix);
            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            bmap.Save(file, format);
            System.Drawing.Image myimg = bmap;
            myimg.Save(ms, System.Drawing.Imaging.ImageFormat.Png);

            string Folder = System.Web.HttpContext.Current.Server.MapPath("~/upload/qr/");
            if (!Directory.Exists(Folder))
            {
                Directory.CreateDirectory(Folder);
            }
            string filePath = Folder + path;
            Stream rs = ms;
            System.Drawing.Image i = Image.FromStream(rs);
            i.Save(filePath, System.Drawing.Imaging.ImageFormat.Png);
            rs.Close();
            i.Dispose();

        }
        public Bitmap toBitmap(COMMON.ByteMatrix matrix)
        {
            int width = matrix.Width;
            int height = matrix.Height;
            Bitmap bmap = new Bitmap(width, height, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    bmap.SetPixel(x, y, matrix.get_Renamed(x, y) != -1 ? ColorTranslator.FromHtml("0xFF000000") : ColorTranslator.FromHtml("0xFFFFFFFF"));
                }
            }
            return bmap;
        }
    }
}
