using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Test.Controllers
{
    public class uploadifyImgController : Controller
    {
        //
        // GET: /uploadifyImg/

        public ActionResult Index()
        {
            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        [ActionName("uploadImages")]
        public JsonResult uploadImages()
        {

            try
            {
                var imagefileName = "";
                var url = "";
                var manyFileStream = System.Web.HttpContext.Current.Request.Files;
                for (var i = 0; i < manyFileStream.Count; i++)
                {
                    var filestream1 = System.Web.HttpContext.Current.Request.Files[i];


                    string newFileName = DateTime.Now.ToString("yyyyMMddhhmmssfff") + i + ".jpg";
                    string Folder = System.Web.HttpContext.Current.Server.MapPath("~/Upload/img/" + DateTime.Now.ToString("yyyyMMdd") + "/");
                    if (!Directory.Exists(Folder))
                    {
                        Directory.CreateDirectory(Folder);
                    }
                    string filePath = Folder + newFileName;
                    filestream1.SaveAs(Folder + newFileName);
                    if (i == manyFileStream.Count - 1)
                    {
                        url += "/Upload/img/" + DateTime.Now.ToString("yyyyMMdd") + "/" + newFileName;
                        imagefileName += filestream1.FileName;
                    }
                    else
                    {
                        url += "/Upload/img/" + DateTime.Now.ToString("yyyyMMdd") + "/" + newFileName + ",";
                        imagefileName += filestream1.FileName + ",";
                    }
                }

                return Json(new { url = url, fileName = imagefileName, code = 0 }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception eX)
            {
                return Json(new { message = eX.Message, code = 1 }, JsonRequestBehavior.AllowGet);
            }
        }





        /// <summary>
        /// 带缩略图的上传图片
        /// </summary>
        /// <param name="name">标题</param>
        /// <param name="order">排序</param>
        /// <returns></returns>
        /// 周晓娜  2016年8月15日14:47:25
        [AllowAnonymous]
        [HttpPost]
        [ActionName("uploadSLImage")]
        public string uploadSLImage()
        {
            int success = 0;
            string message = "";
            string time = DateTime.Now.ToString("yyyyMMdd");
            string uplaodpath = "/Upload/img/" + time + "/";
            string filename = "";
            string newfilename = "";   //去掉后缀的图片名
            string bmpFileName = "";     //缩略图名称 
            string returnName = "";
            string imgPath1 = "";
            string filename1 = "";
            var nowtime = "CP" + DateTime.Now.ToString("yyyyMMddHHmmssfff");
            try
            {
                HttpFileCollection hfc = System.Web.HttpContext.Current.Request.Files;
                if (hfc.Count > 0)
                {
                    for (int i = 0; i < hfc.Count; i++)
                    {
                        //string g = Guid.NewGuid().ToString();
                        filename = hfc[i].FileName.Substring(hfc[i].FileName.LastIndexOf('\\') + 1);
                        newfilename = filename.Split('.')[0]; //取出图片名称
                        returnName = filename.Split('.')[filename.Split('.').Length - 1]; //取出图片后缀
                        if (hfc[i].ContentLength > 0)
                        {
                            string showName = hfc[i].FileName; //取出图片全称
                            int pointIndex = showName.LastIndexOf("."); //取出.点的位置
                            string extendFileName = showName.Substring(pointIndex); //取出点之后的
                            //var relativeFileName = "/Content/upload/TP" + DateTime.Now.ToString("yyyyMMddHHmmssfff") + extendFileName;

                            string imgPath = ".." + uplaodpath + nowtime + "." + returnName;
                            if (!Directory.Exists(Server.MapPath(uplaodpath)))
                            {
                                Directory.CreateDirectory(Server.MapPath(uplaodpath));
                            }
                            string physicalPath = Server.MapPath(imgPath);

                            hfc[i].SaveAs(physicalPath);

                            //生成缩略图
                            //原始图片名称
                            string originalFilename = hfc[i].FileName;
                            //生成的高质量图片名称
                            string strFile = Server.MapPath(".." + uplaodpath) + nowtime + ".bmp";

                            //从文件取得图片对象
                            System.Drawing.Image image = System.Drawing.Image.FromStream(hfc[i].InputStream, true);

                            Double Width = 50;
                            Double Height = 50;
                            System.Double NewWidth, NewHeight;

                            if (image.Width > image.Height)
                            {
                                NewWidth = Width;
                                NewHeight = image.Height * (NewWidth / image.Width);
                            }
                            else
                            {
                                NewHeight = Height;
                                NewWidth = (NewHeight / image.Height) * image.Width;
                            }

                            if (NewWidth > Width)
                            {
                                NewWidth = Width;
                            }
                            if (NewHeight > Height)
                            {
                                NewHeight = Height;
                            }

                            System.Drawing.Size size = new Size((int)NewWidth, (int)NewHeight); // 图片大小
                            System.Drawing.Image bitmap = new System.Drawing.Bitmap(size.Width, size.Height); //新建bmp图片
                            System.Drawing.Graphics graphics = System.Drawing.Graphics.FromImage(bitmap); //新建画板
                            graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.High; //设置高质量插值法
                            graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality; //设置高质量,低速度呈现平滑程度
                            graphics.Clear(Color.White); //清空画布
                            //在指定位置画图
                            graphics.DrawImage(image, new System.Drawing.Rectangle(0, 0, bitmap.Width, bitmap.Height),
                            new System.Drawing.Rectangle(0, 0, image.Width, image.Height),
                            System.Drawing.GraphicsUnit.Pixel);

                            //保存缩略图
                            bitmap.Save(strFile, System.Drawing.Imaging.ImageFormat.Jpeg);
                            graphics.Dispose();
                            image.Dispose();
                            bitmap.Dispose();

                            string strPath = uplaodpath + nowtime + ".bmp";
                            imgPath1 += strPath + ",";
                            filename1 += imgPath + ",";
                        }
                        else
                        {
                            success = 1;
                            message = "未选中上传图片";
                        }
                    }

                }
                else
                {
                    success = 1;
                    message = "未选中上传图片";
                }
            }
            catch (Exception ex)
            {
                success = 2;
                message = ex.Message;
            }
            filename1 = string.Join(",", filename1.Split(',').Where(e => !string.IsNullOrEmpty(e)));
            imgPath1 = string.Join(",", imgPath1.Split(',').Where(e => !string.IsNullOrEmpty(e)));
            var reslut = new
            {
                success = success,
                message = message,
                value = new
                {
                    //System.Configuration.ConfigurationManager.AppSettings["SysDataUrl"]
                    //imgname = uplaodpath + nowtime + ".jpg",//
                    imgSLUrl = imgPath1,//缩略图
                    imgpngname = uplaodpath + nowtime + "." + returnName,//原图片路径
                }
            };

            return Newtonsoft.Json.JsonConvert.SerializeObject(reslut);
        }


        [AllowAnonymous]
        [HttpPost]
        [ActionName("uploadImages1")]
        public String uploadImages1()
        {

            try
            {
                var imagefileName = "";
                var url = "";
                var manyFileStream = System.Web.HttpContext.Current.Request.Files;
                for (var i = 0; i < manyFileStream.Count; i++)
                {
                    //图片格式限制
                    var jpgList = new List<string>();
                    jpgList.Add("jpg");
                    jpgList.Add("png");
                    jpgList.Add("jpeg");
                    jpgList.Add("bmp");


                    var filestream1 = System.Web.HttpContext.Current.Request.Files[i];

                    var filenames = filestream1.FileName.Split('.');

                    var lastnam = filenames.Last().ToLower();
                    var dd = jpgList.Contains(lastnam);
                    if (dd == false)
                    {
                        return "";
                    }
                    string newFileName = DateTime.Now.ToString("yyyyMMddhhmmssfff") + i + ".jpg";
                    string Folder = System.Web.HttpContext.Current.Server.MapPath("/Upload/img/" + DateTime.Now.ToString("yyyyMMdd") + "/");
                    if (!Directory.Exists(Folder))
                    {
                        Directory.CreateDirectory(Folder);
                    }
                    string filePath = Folder + newFileName;
                    filestream1.SaveAs(Folder + newFileName);
                    if (i == manyFileStream.Count - 1)
                    {
                        url += "/Upload/img/" + DateTime.Now.ToString("yyyyMMdd") + "/" + newFileName;
                        imagefileName += filestream1.FileName;
                    }
                    else
                    {
                        url += "/Upload/img/" + DateTime.Now.ToString("yyyyMMdd") + "/" + newFileName + ",";
                        imagefileName += filestream1.FileName + ",";
                    }
                }
                return url;
                //return Json(new { url = url, fileName = imagefileName,code=0 }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception eX)
            {
                return eX.Message;
                // return Json(new { message = eX.Message, code = 1 }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}
