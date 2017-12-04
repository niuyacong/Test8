using com.google.zxing;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using COMMON = com.google.zxing.common;
namespace Test.Areas.根据地址生成二维码
{
    public class ByPrintController : Controller
    {
        //
        // GET: /根据地址生成二维码/ByPrint/

        public ActionResult Index()
        {
            return View();
        }
        //根据地址生成二维码直接显示在网页上(此方法只能显示一个图片在网页上，且原网页内容被图片覆盖)
        public ActionResult Preview(int id = 0)
        {

            var content = "http://act.foodszs.cn/raffle/home/lead?id=" + id;

                        COMMON.ByteMatrix byteMatrix = new MultiFormatWriter().encode(content, BarcodeFormat.QR_CODE, 350, 350);
                        var path = DateTime.Now + ".png";
                        writeToFile(byteMatrix, path, Server.MapPath("/upload/qr/") +path, System.Drawing.Imaging.ImageFormat.Png);

            return View("/views/raffle/Raf_Reward/QR.html");
        }
        public void writeToFile(COMMON.ByteMatrix matrix, string path, string file, System.Drawing.Imaging.ImageFormat format)
        {
            Bitmap bmap = toBitmap(matrix);
            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            bmap.Save(file, format);
            System.Drawing.Image myimg = bmap;
            myimg.Save(ms, System.Drawing.Imaging.ImageFormat.Png);


            //Response.ClearContent();注释掉的只能显示一个二维码
            Response.ContentType = "image/png";
            Response.BinaryWrite(ms.ToArray());
            Response.Write("1");
            // Response.End();
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
