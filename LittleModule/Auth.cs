﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.WebPages;
using System.Web.Mvc;
namespace LittleModule
{
   public class Auth
   {
       #region 获取第三方平台component_access_token
       public void test()
       {
        

           // byte[] data = Request.BinaryRead(Request.TotalBytes);
           //string postData = Encoding.Default.GetString(data);

           // //公众号第三方平台的appid
           // string appId = ConfigurationManager.AppSettings["WeixinAppID"];
           // //第三方平台申请时填写的接收消息的校验token
           // string token = ConfigurationManager.AppSettings["WeixinToken"];
           // //第三方平台申请时填写的接收消息的加密symmetric_key
           // string encodingAesKey = ConfigurationManager.AppSettings["WeixinEncodingAESKey"];
           // string sMsg = "";//解密后的内容
           // var msg = new WXBizMsgCrypt(token, encodingAesKey, appId);
           // int ret = msg.DecryptMsg(
           //     Request.QueryString["msg_signature"],
           //     Request.QueryString["timestamp"],
           //     Request.QueryString["nonce"],
           //     postData,
           //     ref sMsg);
         
                                              //" appId：" + appId +
                                              //" token：" + token +
                                              //" encodingAesKey：" + encodingAesKey + " 解密参数：" +
                                              //" signature：" + Request.QueryString["signature"] +
                                              //" msg_signature：" + Request.QueryString["msg_signature"] +
                                              //" timestamp：" + Request.QueryString["timestamp"] +
                                              //" nonce：" + Request.QueryString["nonce"] +
                                              //" postData：" + postData
          
       }
       #endregion
   }
}
