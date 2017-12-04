using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace Test.Areas.littlewx
{
    public class littleController : Controller
    {
        //
        // GET: /littlewx/little/

        public ActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// 获取openid
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public void GetUserInfo(string code)
        {
            Stream s_re = WebRequest.Create("https://api.weixin.qq.com/sns/jscode2session?appid=" + ConfigurationSettings.AppSettings["appid"] + "&secret=" + ConfigurationSettings.AppSettings["secret"] + "&js_code=" + code + "&grant_type=authorization_code").GetResponse().GetResponseStream();
            StreamReader s_reader = new StreamReader(s_re, Encoding.UTF8);
            string[] s_out = (s_reader.ReadToEnd()).Split("{},".ToCharArray()).Distinct().ToArray();
            if (s_out.Length > 0)
            {
                var aa = s_out[3].ToString();
                var flag = s_out[3].IndexOf("openid");
                if (flag > 0)
                {
                    var openid = s_out[3].Substring(10, 28);
                    var session_key = s_out[1].Substring(15, 24);
                    HttpCookie cookie = new HttpCookie("user");
                    cookie.Values.Add("openid", openid);
                    cookie.Values.Add("session_key", session_key);
                    cookie.Expires = DateTime.Now.AddMilliseconds(7200);
                    System.Web.HttpContext.Current.Response.Cookies.Add(cookie);
                    var data = new { openid = openid, session_key = session_key, nickname = "", head = "", country = "", prov = "", city = "" };
                }
            }
        }

        /// <summary>
        /// 将json数据反序列化为Dictionary
        /// </summary>
        /// <param name="jsonData">json数据</param>
        /// <returns></returns>
        private Dictionary<string, string> JsonToDictionary(string jsonData)
        {
            //实例化JavaScriptSerializer类的新实例
            JavaScriptSerializer jss = new JavaScriptSerializer();
            try
            {
                //将指定的 JSON 字符串转换为 Dictionary<string, object> 类型的对象
                return jss.Deserialize<Dictionary<string, string>>(jsonData);
                //也可序列化为实体
                //return jss.Deserialize<model>(jsonData);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        /// <summary>
        /// 将json反序列化为实体
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="postData"></param>
        /// <returns></returns>
        public static T GetModelForPostData<T>(string postData)
        {
            if (postData.Trim().Substring(0, 1) == "{")
            {
                return JsonConvert.DeserializeObject<T>(postData);
            }
            return default(T);
        }
    }
}
