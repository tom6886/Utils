using System.Collections;
using System.Data;
using System.Text;

namespace Utils
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
    }
}
