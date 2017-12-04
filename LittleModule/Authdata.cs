using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LittleModule
{
   public  class Authdata
    {
        //第三方平台appid
       public string component_appid { get; set; }
       //第三方平台appsecret
       public string component_appsecret { get; set; }
       //微信后台推送的ticket，此ticket会定时推送
       public string component_verify_ticket { get; set; }
    }
}
