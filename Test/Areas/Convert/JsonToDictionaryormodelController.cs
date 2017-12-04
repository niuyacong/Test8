using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace Test.Areas.Convert
{
    public class JsonToDictionaryormodelController : Controller
    {
        //
        // GET: /Convert/JsonToDictionaryormodel/

        public ActionResult Index()
        {
            return View();
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
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        /// <summary>
        /// 将json序列化为t:实体
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
