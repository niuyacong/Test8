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
    public class ByPrintMulController : Controller
    {
        //
        // GET: /根据地址生成二维码/ByPrintMul/

        public ActionResult Index()
        {
            return View();
        }
        //根据地址生成二维码,可以显示多张二维码，且网页内容不被覆盖（原理：将图片的base64字符串直接赋给img的src,网页上直接显示图片二维码）
        //tip:该方法在网页ctrl+s,直接保存一张网页，因为图片的路径是base字符串
        //tip:假设网页上的图片路径是地址路径，ctrl+s,则会把图片当资源保存下来，且保存的图片与原图片名称一致
        //tip:img src 需要data:image/png;base64,+base64
        public ActionResult Preview(int id = 0)
        {
            var datanew = new List<object>();
            if (id > 0)
            {
                var data = new List<object>();

                for (int i = 0; i < data.Count; i++)
                {
                        var content = "http://act.foodszs.cn/raffle/home/lead?id=" + id;

                        COMMON.ByteMatrix byteMatrix = new MultiFormatWriter().encode(content, BarcodeFormat.QR_CODE, 350, 350);
                        var path =DateTime.Now + ".png";


                        Bitmap bmap = toBitmap(byteMatrix);
                        System.IO.MemoryStream ms = new System.IO.MemoryStream();
                        bmap.Save(Server.MapPath("/upload/qr/") + path, ImageFormat.Png);
                        System.Drawing.Image myimg = bmap;
                        myimg.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                        var str = "data:image/png;base64," + System.Convert.ToBase64String(ms.ToArray());
                        datanew.Add(new
                        {
                           // name = data[i].name,
                            pic = str
                        });
                    }
                }
            ViewData["shop"] = datanew;
            return View("/views/raffle/Raf_Reward/QR.html");
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
