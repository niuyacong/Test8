using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace Test.Areas.littlewx
{
    public class HttpsPostController : Controller
    {
        //
        // GET: /littlewx/HttpsPost/

        public ActionResult Index()
        {
            return View();
        }
        #region 生成小程序二维码
        public void QR()
        {
            var str = "";
            Stream s_re = WebRequest.Create("https://api.weixin.qq.com/cgi-bin/token?grant_type=client_credential&appid=" + ConfigurationSettings.AppSettings["appid"] + "&secret=" + ConfigurationSettings.AppSettings["secret"]).GetResponse().GetResponseStream();
            StreamReader s_reader = new StreamReader(s_re, Encoding.UTF8);
            string[] s_out = (s_reader.ReadToEnd()).Split("{},".ToCharArray()).Distinct().ToArray();
            if (s_out.Length > 0)
            {
                if (s_out[1].IndexOf("access_token") > 0)
                {
                    var access_token = s_out[1].ToString().Substring(16, s_out[1].Length - 17);
                    BuildRequest(access_token);
                }
            }

        }

        public static void BuildRequest(string session)
        {
            Encoding code = Encoding.GetEncoding("utf-8");
            StringBuilder sb = new StringBuilder();
            sb.Append("{ \r\n");
            //sb.Append("    \"menu\": {\r\n");
            sb.Append("        \"path\": \"pages/details/details?id=0&tid=0&pid=0&fid=" + ConfigurationSettings.AppSettings["fid"] + "\",\r\n");
            sb.Append("        \"width\": \"430\"\r\n");
            sb.Append("}");
            //待请求参数数组字符串
            string strRequestData = sb.ToString();

            //把数组转换成流中所需字节数组类型
            byte[] bytesRequestData = code.GetBytes(strRequestData);

            //构造请求地址
            string strUrl = "https://api.weixin.qq.com/wxa/getwxacode?access_token=" + session;

            //请求远程HTTP
            string strResult = "";

            //设置HttpWebRequest基本信息
            HttpWebRequest myReq = (HttpWebRequest)HttpWebRequest.Create(strUrl);
            myReq.Method = "POST";
            myReq.ContentType = "application/x-www-form-urlencoded";

            //填充POST数据
            myReq.ContentLength = bytesRequestData.Length;
            Stream requestStream = myReq.GetRequestStream();
            requestStream.Write(bytesRequestData, 0, bytesRequestData.Length);
            requestStream.Close();

            //发送POST数据请求服务器
            HttpWebResponse HttpWResp = (HttpWebResponse)myReq.GetResponse();


            // 把 Stream 转换成 byte[]   
            string newFileName = DateTime.Now.ToString("yyyyMMddhhmmssfff") + ".jpg";
            string Folder = System.Web.HttpContext.Current.Server.MapPath("~/Upload/img/" + DateTime.Now.ToString("yyyyMMdd") + "/");
            if (!Directory.Exists(Folder))
            {
                Directory.CreateDirectory(Folder);
            }
            string filePath = Folder + newFileName;
            Stream rs = HttpWResp.GetResponseStream();
            System.Drawing.Image i = Image.FromStream(rs);
            i.Save(filePath, System.Drawing.Imaging.ImageFormat.Gif);
            rs.Close();
            i.Dispose();
        }

        #endregion
    }
}
