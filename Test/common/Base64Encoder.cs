using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Jeno.App.Common
{
    /// <summary>
    /// Base64编码类
    /// </summary>
    public class Base64Encoder
    {

        private static readonly HashSet<char> h = new HashSet<char>(){ 
    'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 
    'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z', 'a', 'b', 'c', 'd', 'e', 'f', 
    'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 
    'w', 'x', 'y', 'z', '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', '+', '/', 
    '='};
        /// <summary>
        /// 判断当前字符串是否是base64格式
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static bool IsBase64(string s)
        {
            if (string.IsNullOrEmpty(s))
                return false;
            else if (s.Any(c => !h.Contains(c)))
                return false;

            try
            {
                Convert.FromBase64String(s);
                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }        



        /// <summary>
        /// 转换成base64编码
        /// </summary>
        /// <returns></returns>
        public static string Encode(string plainText)
        {
            if (string.IsNullOrEmpty(plainText))
            {
                return null;
            }
            return Convert.ToBase64String(Encoding.UTF8.GetBytes(plainText));
        }
        /// <summary>
        /// 从base64编码转换
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static string Decode(string base64Text)
        {
            if (string.IsNullOrEmpty(base64Text))
            {
                return null;
            }
            return Encoding.UTF8.GetString(Convert.FromBase64String(base64Text));
        }


        /// <summary>
        /// 从base64编码转换
        /// </summary>
        /// <param name="input"></param>
        /// <param name="encode"></param>
        /// <returns></returns>
        public static string Base64Decrypt(string input, Encoding encode)
        {
            return encode.GetString(Convert.FromBase64String(input));
        }

    }
}
