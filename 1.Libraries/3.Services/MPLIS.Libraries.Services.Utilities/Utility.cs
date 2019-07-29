using MPLIS.Libraries.Data.SSO.Models;
using MPLIS.Libraries.Data.SSO.Params;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace MPLIS.Libraries.Services.Utilities
{
    public static class Utility
    {
        /// <summary>
        /// Appends a parameter to the QueryString
        /// </summary>
        /// <param name="Url"></param>
        /// <param name="Key"></param>
        /// <param name="Value"></param>
        /// <returns></returns>
        public static string GetAppendedQueryString(string Url, string Key, string Value)
        {
            if (Url.Contains("?"))
            {
                Url = string.Format("{0}&{1}={2}", Url, Key, Value);
            }
            else
            {
                Url = string.Format("{0}?{1}={2}", Url, Key, Value);
            }

            return Url;
        }

        /// <summary>
        /// Reads cookie value from the cookie
        /// </summary>
        /// <param name="cookie"></param>
        /// <returns></returns>
        public static string GetCookieValue(HttpCookie Cookie)
        {
            if (string.IsNullOrEmpty(Cookie.Value))
            {
                return Cookie.Value;
            }
            return Cookie.Value.Substring(0, Cookie.Value.IndexOf("|"));
        }

        /// <summary>
        /// Get cookie expiry date that was set in the cookie value 
        /// </summary>
        /// <param name="cookie"></param>
        /// <returns></returns>
        public static DateTime GetExpirationDate(HttpCookie Cookie)
        {
            if (string.IsNullOrEmpty(Cookie.Value))
            {
                return DateTime.MinValue;
            }
            string strDateTime = Cookie.Value.Substring(Cookie.Value.IndexOf("|") + 1);
            return Convert.ToDateTime(strDateTime);
        }

        /// <summary>
        /// Determines whether two string values are equals or not
        /// </summary>
        /// <param name="A"></param>
        /// <param name="B"></param>
        /// <returns></returns>
        public static bool StringEquals(string A, string B)
        {
            return string.Compare(A, B, true) == 0;
        }

        /// <summary>
        /// Set cookie value using the token and the expiry date
        /// </summary>
        /// <param name="Value"></param>
        /// <param name="Minutes"></param>
        /// <returns></returns>
        public static string BuildCookieValue(string Value, int Minutes)
        {
            return string.Format("{0}|{1}", Value, DateTime.Now.AddMinutes(Minutes).ToString());
        }

        public static string GetGuidHash()
        {
            return Guid.NewGuid().ToString().GetHashCode().ToString("x");
        }

        /// <summary>
        /// Mã hóa dữ liệu
        /// </summary>
        /// <param name="toEncrypt">Chuỗi cần mã hóa</param>
        /// <param name="useHashing">Có sử dụng hàm băm không</param>
        /// <param name="key">Khóa mã hóa</param>
        /// <returns>Chuỗi đã được mã hóa</returns>
        public static string Encrypt(string toEncrypt, bool useHashing, string key)
        {
            byte[] keyArray;
            byte[] toEncryptArray = UTF8Encoding.UTF8.GetBytes(toEncrypt);
            string base64 = Convert.ToBase64String(toEncryptArray);
            toEncryptArray = UTF8Encoding.UTF8.GetBytes(base64);

            //System.Windows.Forms.MessageBox.Show(key);
            //If hashing use get hashcode regards to your key
            if (useHashing)
            {
                MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
                keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));
                //Always release the resources and flush data
                // of the Cryptographic service provide. Best Practice

                hashmd5.Clear();
            }
            else
                keyArray = UTF8Encoding.UTF8.GetBytes(key);

            TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
            //set the secret key for the tripleDES algorithm
            tdes.Key = keyArray;
            //mode of operation. there are other 4 modes.
            //We choose ECB(Electronic code Book)
            tdes.Mode = CipherMode.ECB;
            //padding mode(if any extra byte added)

            tdes.Padding = PaddingMode.PKCS7;

            ICryptoTransform cTransform = tdes.CreateEncryptor();
            //transform the specified region of bytes array to resultArray
            byte[] resultArray =
              cTransform.TransformFinalBlock(toEncryptArray, 0,
              toEncryptArray.Length);
            //Release resources held by TripleDes Encryptor
            tdes.Clear();
            //Return the encrypted data into unreadable string format
            return Convert.ToBase64String(resultArray, 0, resultArray.Length);
        }

        /// <summary>
        /// Mã hóa dữ liệu
        /// </summary>
        /// <param name="cipherString">Chuỗi cần giải mã</param>
        /// <param name="useHashing">Có sử dụng hàm băm không</param>
        /// <param name="key">Khóa giải mã</param>
        /// <returns>Chuỗi đã được giải mã</returns>
        public static string Decrypt(string cipherString, bool useHashing, string key) // 3.1
        {
            byte[] keyArray;
            //get the byte code of the string

            byte[] toEncryptArray = Convert.FromBase64String(cipherString);

            if (useHashing)
            {
                //if hashing was used get the hash code with regards to your key
                MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
                keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));
                //release any resource held by the MD5CryptoServiceProvider

                hashmd5.Clear();
            }
            else
            {
                //if hashing was not implemented get the byte code of the key
                keyArray = UTF8Encoding.UTF8.GetBytes(key);
            }

            TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
            //set the secret key for the tripleDES algorithm
            tdes.Key = keyArray;
            //mode of operation. there are other 4 modes. 
            //We choose ECB(Electronic code Book)

            tdes.Mode = CipherMode.ECB;
            //padding mode(if any extra byte added)
            tdes.Padding = PaddingMode.PKCS7;

            ICryptoTransform cTransform = tdes.CreateDecryptor();
            byte[] resultArray = cTransform.TransformFinalBlock(
                                 toEncryptArray, 0, toEncryptArray.Length);
            //Release resources held by TripleDes Encryptor                
            tdes.Clear();
            //return the Clear decrypted TEXT
            string ret = UTF8Encoding.UTF8.GetString(resultArray);
            byte[] bytes = Convert.FromBase64String(ret);

            return UTF8Encoding.UTF8.GetString(bytes);
        }
    }
}
