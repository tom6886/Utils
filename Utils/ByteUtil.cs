using System;
using System.Collections.Generic;
using System.Text;

namespace Utils
{
    public class ByteUtil
    {
        /// <summary>
        /// 汤波
        /// 2016-9-17 16:06:38
        /// 将byte数组转化为16进制字符串
        /// </summary>
        /// <returns></returns>
        public static string ToHexString(byte[] bytes)
        {
            string hexString = string.Empty;

            if (bytes != null)
            {
                StringBuilder strB = new StringBuilder();

                for (int i = 0; i < bytes.Length; i++)
                {
                    strB.Append(bytes[i].ToString("X2"));
                }

                hexString = strB.ToString();
            }

            return hexString;
        }

        /// <summary>
        /// 汤波
        /// 2016-9-17 16:06:31
        /// 将16进制字符串转换为byte数组
        /// </summary>
        /// <param name="hexString"></param>
        /// <returns></returns>
        public static byte[] GetBytes(string hexString)
        {
            int discarded = 0;
            string newString = "";
            char c;
            // remove all none A-F, 0-9, characters
            for (int i = 0; i < hexString.Length; i++)
            {
                c = hexString[i];
                if (Uri.IsHexDigit(c))
                    newString += c;
                else
                    discarded++;
            }
            // if odd number of characters, discard last character
            if (newString.Length % 2 != 0)
            {
                discarded++;
                newString = newString.Substring(0, newString.Length - 1);
            }

            int byteLength = newString.Length / 2;
            byte[] bytes = new byte[byteLength];
            string hex;
            int j = 0;
            for (int i = 0; i < bytes.Length; i++)
            {
                hex = new String(new Char[] { newString[j], newString[j + 1] });
                bytes[i] = byte.Parse(hex, System.Globalization.NumberStyles.HexNumber);
                j = j + 2;
            }
            return bytes;
        }
    }
}
