using Senparc.Weixin.MP.CommonAPIs;
using Senparc.Weixin.MP.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace Test.Areas.wxshare
{
    public class shareController : Controller
    {
        //
        // GET: /wxshare/share/

        public ActionResult Index()
        {
            return View();
        }
        public string share(string AppID, string AppSecret, string title, string link, string desc, string img = "")
        {
            var timestamp = JSSDKHelper.GetTimestamp();
            var nonceStr = JSSDKHelper.GetNoncestr();
            var accesstokenresult = CommonApi.GetToken(AppID,AppSecret);
            var accesstoken = accesstokenresult.access_token;
            var js_api_ticket_result = CommonApi.GetTicketByAccessToken(accesstoken);
            var js_api_ticket = js_api_ticket_result.ticket;

            var curl =Request.Url.ToString();
            var signature = JSSDKHelper.GetSignature(js_api_ticket, nonceStr, timestamp, curl);
            var sb = new StringBuilder();
            sb.AppendLine("<script src='https://res.wx.qq.com/open/js/jweixin-1.0.0.js'></script>");
            sb.AppendLine("<script type=\"text/javascript\"> ");
            sb.AppendLine("    wx.config({ ");
            sb.AppendLine("    debug: false, ");
            sb.AppendLine("    appId: '" + AppID + "', ");
            sb.AppendLine("    timestamp: '" + timestamp + "', ");
            sb.AppendLine("    nonceStr: '" + nonceStr + "', ");
            sb.AppendLine("    signature: '" + signature + "', ");
            sb.AppendLine("    jsApiList: ['onMenuShareTimeline', 'onMenuShareAppMessage'] ");
            sb.AppendLine("}); ");
            sb.AppendLine("var wx_title = '" + title + "'; ");
            sb.AppendLine("var wx_link='" + link + "'; ");
            sb.AppendLine("var wx_img = '" + img + "'; ");
            sb.AppendLine("var wx_desc = '" + desc + "'; ");

            sb.AppendLine("function wxshare(){ ");
            sb.AppendLine("    wx.ready(function () { ");
            sb.AppendLine("        wx.onMenuShareTimeline({ ");
            sb.AppendLine("            title: wx_title, ");
            sb.AppendLine("            link: wx_link, ");

            sb.AppendLine("            imgUrl: wx_img, ");
            sb.AppendLine("            desc: wx_desc, // 分享描述 ");
            sb.AppendLine("            success: function (res) { ");
            //sb.AppendLine("                jQuery.post('/sherlock/share', { openid: '" + openid + "',type:'" + type + "', id: '" + rowid + "' }, function (d) { ");
            //sb.AppendLine("                    $('.share_fixed').hide(); ");

            //sb.AppendLine("                }) ");
            sb.AppendLine("            }, ");
            sb.AppendLine("            cancel: function (res) { ");
            //sb.AppendLine("                $('.share_fixed').hide(); ");
            sb.AppendLine("            }, ");
            sb.AppendLine("            fail: function (res) { ");
            sb.AppendLine("                alert(JSON.stringify(res)); ");
            sb.AppendLine("            } ");
            sb.AppendLine("        }); ");
            sb.AppendLine("        wx.onMenuShareAppMessage({ ");
            sb.AppendLine("            title: wx_title, ");
            sb.AppendLine("            link: wx_link, ");
            sb.AppendLine("            imgUrl: wx_img, ");
            sb.AppendLine("            desc: wx_desc, // 分享描述 ");
            sb.AppendLine("            success: function (res) { ");
            //sb.AppendLine("                jQuery.post('/sherlock/share', {  openid: '" + openid + "',type:'" + type + "', id: '" + rowid + "' }, function (d) { ");
            //sb.AppendLine("                    $('.share_fixed').hide(); ");
            //sb.AppendLine("                }) ");
            sb.AppendLine("            }, ");
            sb.AppendLine("            cancel: function () { ");
            //sb.AppendLine("                $('.share_fixed').hide(); ");
            sb.AppendLine("            }, ");
            sb.AppendLine("            fail: function (res) { ");
            sb.AppendLine("                alert(JSON.stringify(res)); ");
            sb.AppendLine("            } ");
            sb.AppendLine("        }) ");
            sb.AppendLine("    }); ");
            sb.AppendLine("} ");

            sb.AppendLine("wxshare(); ");
            sb.AppendLine("</script>");

            return sb.ToString();
        }

    }
}
