using MPLIS.Libraries.Data.SSO.Models;
using MPLIS.Libraries.Data.SSO.Params;
using MPLIS.Libraries.Services.Utilities;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace MPLIS.Libraries.Services.SSO
{
    public static class SSOHTTPRequestService
    {
        //Lấy thông tin xác thực từ request
        public static SSOHttpRequestParams GetRequestParams(HttpRequest Request) //buoc 3
        {
            SSOHttpRequestParams par = new SSOHttpRequestParams();

            try
            {
                par.Action = Request.Params[SSOConstants.UrlParams.ACTION];
                par.ReturnUrl = Request.Params[SSOConstants.UrlParams.RETURN_URL];
                par.RequestUrl = Request.Url.AbsoluteUri;
                par.Token = Request.Params[SSOConstants.UrlParams.TOKEN];
                HttpCookie aCookie = Request.Cookies[SSOConstants.Cookie.AUTH_COOKIE];

                if (aCookie != null)
                {
                    par.Cookie = aCookie;
                    string encrString = aCookie.Value;
                    string decString = Utility.Decrypt(encrString, true, Config.SECURITY_KEY);
                    SSOCookieValues cv = JsonConvert.DeserializeObject<SSOCookieValues>(decString);
                    if (!CheckExpired(cv))
                    {
                        par.Token = cv.Token;
                        par.UserName = cv.UserName;
                        par.isTokenFromCookie = true;
                    }
                }
            }
            catch (Exception ex)
            {
                par = null;
            }

            return par;
        }

        public static SSOHttpRequestParams GetRequestParams(HttpRequestBase Request)
        {
            SSOHttpRequestParams par = new SSOHttpRequestParams();
            try
            {
                par.Action = Request.Params[SSOConstants.UrlParams.ACTION];
                par.ReturnUrl = Request.Params[SSOConstants.UrlParams.RETURN_URL];
                par.RequestUrl = Request.Url.AbsoluteUri;

                HttpCookie aCookie = Request.Cookies[SSOConstants.Cookie.AUTH_COOKIE];
                if (aCookie != null)
                {
                    par.Cookie = aCookie;
                    string encrString = aCookie.Values["value"];
                    string decString = Utility.Decrypt(encrString, true, Config.SECURITY_KEY);
                    SSOCookieValues cv = JsonConvert.DeserializeObject<SSOCookieValues>(decString);
                    par.Token = cv.Token;
                    par.UserName = cv.UserName;
                }
                else
                    par.Token = Request.Params[SSOConstants.UrlParams.TOKEN];
            }
            catch (Exception ex)
            {
                par = null;
            }

            return par;
        }

        /// <summary>
        /// Determines whether the Cookie is expired or not
        /// </summary>
        /// <param name="aCookie"></param>
        /// <returns></returns>
        public static bool CheckExpired(SSOCookieValues cv)
        {
            return cv.Expires.CompareTo(DateTime.Now) < 0;
        }

        /// <summary>
        /// Determines whether the Cookie is expired or not
        /// </summary>
        /// <param name="aCookie"></param>
        /// <returns></returns>
        public static bool CheckExpired(HttpCookie aCookie)
        {
            return aCookie.Expires.CompareTo(DateTime.Now) < 0;
        }

        /// <summary>
        /// Determines whether the Token is expired or not
        /// </summary>
        /// <param name="expirytime"></param>
        /// <returns></returns>
        public static bool CheckExpired(SSOUserLoginInfors Us)
        {
            return Us.TokenExpires.CompareTo(DateTime.Now) < 0;
        }

        /// <summary>
        /// Removes Cookie from the response
        /// </summary>
        /// <param name="Cookie"></param>
        public static void RemoveCookie(string CookieName, HttpResponse Response)
        {
            Response.Cookies.Remove(CookieName);

            HttpCookie myCookie = new HttpCookie(CookieName);
            myCookie.Expires = DateTime.Now.AddDays(-1d);
            Response.Cookies.Add(myCookie);
        }

        /// <summary>
        /// Append Token to the URl and redirect
        /// </summary>
        /// <param name="Url"></param>
        /// <param name="Token"></param>
        /// <param name="Response"></param>
        public static void Redirect(string Url, string Token, HttpApplication app)
        {
            string redirectUrl = Url;
            if (Token != null && !Token.Equals("")) redirectUrl = Utility.GetAppendedQueryString(Url, SSOConstants.UrlParams.TOKEN, Token);

            app.Response.Redirect(redirectUrl, false);
            app.Response.StatusCode = 301;
            app.CompleteRequest();
        }

        #region "Các hàm phục vụ SSO Service
        public static string getDataInRequest(HttpRequestMessage Request)
        {
            string ret = "";
            bool Rslt = false;

            MultipartMemoryStreamProvider prvdr = new MultipartMemoryStreamProvider();
            Task readData = Request.Content.ReadAsMultipartAsync(prvdr).ContinueWith((readTask) =>
            {
                Rslt = readTask.IsCompleted;
            });

            readData.Wait();
            if (Rslt)
            {
                foreach (HttpContent ctnt in prvdr.Contents)
                {
                    // You would get hold of the inner memory stream here
                    Stream stream = ctnt.ReadAsStreamAsync().Result;

                    var sr = new StreamReader(stream);
                    var myStr = sr.ReadToEnd();
                    if (myStr != null && !myStr.Equals(""))
                    {
                        ret = Utility.Decrypt(myStr, true, Config.SECURITY_KEY);
                        break;
                    }
                }
            }

            return ret;
        }

        //Lấy dữ liệu từ service, dữ liệu trao đổi có mã hóa
        public static async Task<string> getSSOData(string url, object data)//buoc5
        {
            Stream InputStream = null;
            Task task;
            HttpResponseMessage response;
            string retVal = "";
            string a = Config.FILE_UPLOAD_PATH;
            try
            {
                MultipartFormDataContent content = prepareData(data);
                using (var client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Accept.Clear();
                     client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    response = await client.PostAsync(url, content);
                    if (response.IsSuccessStatusCode)
                    {
                        task = response.Content.ReadAsStreamAsync().ContinueWith(t =>
                        {
                            InputStream = t.Result;
                            InputStream.Position = 0;
                            var sr = new StreamReader(InputStream);
                            var myStr = sr.ReadToEnd();
                            retVal = Utilities.Utility.Decrypt(myStr, true, Config.SECURITY_KEY);
                        });

                        await task;
                        task.Dispose();
                        if (InputStream != null) InputStream.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return retVal;
        }

        //Lấy dữ liệu từ string trả về từ service
        public static T getDataFromString<T>(string input)
        {
            T ret;
            SsoApiServiceData data;

            try
            {
                data = JsonConvert.DeserializeObject<SsoApiServiceData>(input);
                if (checkReturnData(data))
                    ret = JsonConvert.DeserializeObject<T>(data.Value);
                else
                    ret = default(T);
            }
            catch (Exception ex)
            {
                ret = default(T);
            }

            return ret;
        }

        private static bool checkReturnData(SsoApiServiceData data)
        {
            if (data == null || data.TimeValid == null) return false;

            return data.TimeValid.CompareTo(DateTime.Now) > 0;
        }

        public static void RestoreHashtableData(SSOUserLoginInfors value)
        {
            value.AllUngDung = RestoreDataFromString<SSOHtUngDung>(value.AllUngDung);
            value.NguoiDungQuyen = RestoreDataFromString<SSOHtQuyen>(value.NguoiDungQuyen);
            value.ToChucMenu = RestoreDataFromString<List<SSOHtMenu>>(value.ToChucMenu);
            value.ToChucQuyen = RestoreDataFromString<SSOHtQuyen>(value.ToChucQuyen);
            value.ToChucKVHC = RestoreDataKVHCFromString(value.ToChucKVHC);
            value.DSUngDung = RestoreDataFromString<SSOHtUngDung>(value.DSUngDung);
            value.CauHinhNguoiDung = RestoreDataFromString<SSOHtCauHinhNguoiDung>(value.CauHinhNguoiDung);
        }

        //Lấy dữ liệu từ string trả về từ service
        public static Hashtable RestoreDataFromString<T>(Hashtable input)
        {
            Hashtable ret = new Hashtable();
            T item;
            string s;

            try
            {
                foreach (DictionaryEntry it in input)
                {
                    s = it.Value.ToString();
                    item = JsonConvert.DeserializeObject<T>(s);
                    ret.Add(it.Key, item);
                }
            }
            catch (Exception ex)
            {

            }

            return ret;
        }

        public static Hashtable RestoreDataKVHCFromString(Hashtable input)
        {
            Hashtable ret = new Hashtable();
            SSOHcTinh Tinh;
            SSOHcHuyen Huyen;
            SSOHcXa Xa;

            try
            {
                foreach (DictionaryEntry it in input)
                {
                    Tinh = TryDeserialize<SSOHcTinh>(it.Value.ToString());
                    if (Tinh != null)
                    {
                        switch (Tinh.MAKVHC.Length)
                        {
                            case 2:
                                ret.Add(it.Key, Tinh);
                                break;
                            case 5:
                                Huyen = TryDeserialize<SSOHcHuyen>((string)it.Value.ToString());
                                ret.Add(it.Key, Huyen);
                                break;
                            case 10:
                                Xa = TryDeserialize<SSOHcXa>((string)it.Value.ToString());
                                ret.Add(it.Key, Xa);
                                break;
                            default:
                                break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {

            }

            return ret;
        }

        public static T TryDeserialize<T>(string value)
        {
            T ret;

            try
            {
                ret = JsonConvert.DeserializeObject<T>(value);
            }
            catch (Exception ex)
            {
                ret = default(T);
            }

            return ret;
        }

        //Chuẩn bị dữ liệu gửi tới SSO
        //Tạo hai lớp bọc quanh tham số và mã hóa dữ liệu chuyển
        private static MultipartFormDataContent prepareData(object data)//buoc 6
        {
            MultipartFormDataContent ret = new MultipartFormDataContent();

            //Tạo tham số cho service 
            string retString = JsonConvert.SerializeObject(data);
            JsonConvert.DeserializeObject<string>("");
            SsoApiServiceData par = new SsoApiServiceData();
            par.TimeValid = DateTime.Now.AddMinutes(Config.AUTH_REQUEST_DATA_TIMEOUT_IN_MINUTES);
            par.Value = retString;
            retString = JsonConvert.SerializeObject(par);

            //Mã hóa và tạo đối tượng chuyển dữ liệu
            string encrString = Utility.Encrypt(retString, true, Config.SECURITY_KEY);
            MemoryStream stream = new MemoryStream();
            StreamWriter writer = new StreamWriter(stream);
            writer.Write(encrString);
            writer.Flush();
            stream.Position = 0;
            ret.Add(new StreamContent(stream));

            return ret;
        }
        #endregion
    }
}
