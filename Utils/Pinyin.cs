using Microsoft.International.Converters.PinYinConverter;
using System.Text;

namespace Utils
{
    public class Pinyin
    {
        /// <summary>
        /// 汤波
        /// 2015-4-22 20:41:27
        /// 获取字符串拼音全拼
        /// </summary>
        /// <param name="str">输入字符串</param>
        /// <returns></returns>
        public static string GetPinyin(string str)
        {
            StringBuilder strB = new StringBuilder();

            char[] tone = { '1', '2', '3', '4' };

            foreach (char item in str.ToCharArray())
            {
                if (!ChineseChar.IsValidChar(item))
                {
                    strB.Append(item);
                    continue;
                }

                ChineseChar c = new ChineseChar(item);

                strB.Append(c.Pinyins[0].TrimEnd(tone));
            }

            return strB.ToString();
        }
    }
}
