using System;
using System.Collections;
using System.Data;
using System.Security.Cryptography;
using System.Text;

namespace XUtils
{
    public class StringUtil
    {
        /// <summary>
        /// 汤波
        /// 2015-4-16 17:22:11
        /// 拼接字符串 
        /// example:输入:(["a","b","c"],",","'");输出:'a','b','c'
        /// </summary>
        /// <param name="c"></param>
        /// <param name="delimiter"></param>
        /// <param name="surround"></param>
        /// <returns></returns>
        public static string CollectionToDelimitedString(ICollection c, string delimiter, string surround)
        {
            string str = string.Empty;

            StringBuilder strB = new StringBuilder();

            foreach (var item in c)
            {
                strB.Append(surround);
                strB.Append(item);
                strB.Append(surround);
                strB.Append(delimiter);
            }

            str = strB.ToString();

            return str.Substring(0, str.Length - 1);
        }

        /// <summary>
        /// 汤波
        /// 2015-4-23 20:20:35
        /// 拼接URL字符串
        /// </summary>
        /// <param name="url1">输入的URL</param>
        /// <param name="urls">输入的URL</param>
        /// <returns></returns>
        public static string CombinUrl(string url1, params string[] urls)
        {
            StringBuilder strB = new StringBuilder();

            strB.Append(url1);

            foreach (string item in urls)
            {
                strB.Append("/");
                strB.Append(item);
            }

            return strB.ToString();
        }

        /// <summary>
        /// 2015年11月8日14:37:37
        /// 生成字符串类型唯一标识
        /// </summary>
        /// <returns></returns>
        public static string UniqueID()
        {
            return Guid.NewGuid().ToString("N");
        }

        /// <summary>
        ///  2016年8月30日10:29:11
        ///  MD5 加密
        /// </summary>
        /// <param name="str">输入字符串</param>
        /// <returns></returns>
        public static string Md5Encrypt(string str)
        {
            byte[] bytes = Encoding.Default.GetBytes(str.Trim());
            MD5 md = new MD5CryptoServiceProvider();
            return BitConverter.ToString(md.ComputeHash(bytes)).Replace("-", "");
        }
    }
}
