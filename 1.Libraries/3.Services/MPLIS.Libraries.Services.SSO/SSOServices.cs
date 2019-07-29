using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using MPLIS.Libraries.Services.Utilities;
using MPLIS.Libraries.Data.SSO.Params;
using MPLIS.Libraries.Data.SSO.Models;
using System.Web;
using System.Net;
using AppCore.Models;
using AutoMapper;
using System.Web.SessionState;

namespace MPLIS.Libraries.Services.SSO
{
    public static class SSOServices
    {
        #region "Private function"
        //Lấy dữ liệu người dùng - dữ liệu có mã hóa khi nhận
        private static async Task<string> getUserDataByToken_Decrypt(string url, string Token)
        {
            Stream InputStream = null;
            MemoryStream OutStream = null;
            Task task;
            HttpResponseMessage response;
            string retVal = "";

            try
            {
                using (var client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    response = await client.PostAsJsonAsync(url, Token);
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
                        if (OutStream != null) OutStream.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return retVal;
        }

        //Lấy dữ liệu người dùng - dữ liệu không có mã hóa khi nhận
        private static async Task<string> getUserDataByToken_NoDecrypt(string url, string Token)
        {
            Stream InputStream = null;
            MemoryStream OutStream = null;
            Task task;
            HttpResponseMessage response;
            string retVal = "";

            try
            {
                using (var client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    response = await client.PostAsJsonAsync(url, Token);
                    if (response.IsSuccessStatusCode)
                    {
                        task = response.Content.ReadAsStreamAsync().ContinueWith(t =>
                        {
                            InputStream = t.Result;
                            InputStream.Position = 0;
                            var sr = new StreamReader(InputStream);
                            retVal = sr.ReadToEnd();
                        });

                        await task;
                        task.Dispose();

                        if (InputStream != null) InputStream.Close();
                        if (OutStream != null) OutStream.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return retVal;
        }
        #endregion

        #region "SSO API services call"
        public static async Task<SSOUserStatus> getUserStatus(string SSOSiteUrl, string Token)
        {
            string retStr = await SSOHTTPRequestService.getSSOData(SSOSiteUrl + SSOConstants.SSOServicesParams.GET_USER_STATUS, Token);
            SSOUserStatus ret = SSOHTTPRequestService.getDataFromString<SSOUserStatus>(retStr);

            return ret;
        }

        public static async Task<SSOUserLoginInfors> getUserLoggedinInfors(string SSOSiteUrl, SSOHtTokenRequestData Token)//buoc 4
        {
            string retStr = await SSOHTTPRequestService.getSSOData(SSOSiteUrl + SSOConstants.SSOServicesParams.GET_USER_INFORS, Token);
            SSOUserLoginInfors ret = SSOHTTPRequestService.getDataFromString<SSOUserLoginInfors>(retStr);
            SSOHTTPRequestService.RestoreHashtableData(ret);

            return ret;
        }

        public static async Task<SSOReturnResult> LogoutUser(string SSOSiteUrl, string Token)
        {
            string retStr = await SSOHTTPRequestService.getSSOData(SSOSiteUrl + SSOConstants.SSOServicesParams.LOGOUT_USER, Token);
            SSOReturnResult ret = SSOHTTPRequestService.getDataFromString<SSOReturnResult>(retStr);

            return ret;
        }

        public static async Task<SSOReturnResult> UpdateCookie(string SSOSiteUrl, string Token, DateTime Expires)
        {
            SSOCookieInfor Us = new SSOCookieInfor();
            Us.Token = Token;
            Us.Expires = Expires;

            //Gửi dữ liệu cần cập nhật tới server
            string retStr = await SSOHTTPRequestService.getSSOData(SSOSiteUrl + SSOConstants.SSOServicesParams.UPDATE_COOKIE, Us);
            SSOReturnResult ret = SSOHTTPRequestService.getDataFromString<SSOReturnResult>(retStr);

            return ret;
        }
        #endregion

        #region "Web pages call"
        /// <summary>
        /// Redirect to Login page
        /// </summary>
        /// <param name="Urlpath"></param>
        public static void RedirectToLoginPage(HttpRequest Request, HttpResponse Response, HttpSessionState Session)
        {
            //Xóa authenticate cookie - nếu có
            SSOHTTPRequestService.RemoveCookie(SSOConstants.Cookie.AUTH_COOKIE, Response);

            //Before redirecting to login URL, remove the Token parameter value from the QueryString (If they are there)
            //that were appended by the SSO sites. Reason is, this parameter value is now expired. 
            //From the login screen, user will log in and the SSO site will re-generate the Token
            string originalRequestUrl = Request.Url.OriginalString;
            originalRequestUrl = UriUtil.RemoveParameter(originalRequestUrl, SSOConstants.UrlParams.TOKEN);

            //Current request is redirected from SSO site. So, do not further redirect to SSO site
            string p1 = string.Format("{0}?{1}={2}&{3}={4}", Config.SSO_SITE_URL + SSOConstants.SSOPageParams.LOGIN_PAGE,
                SSOConstants.UrlParams.RETURN_URL, HttpUtility.UrlEncode(originalRequestUrl),
                SSOConstants.UrlParams.ACTION, "Login");
            BSUserInfor bui = (BSUserInfor)Session["BSUserInfor"];
            if (bui != null && bui.UserInfo.Token != null && !bui.UserInfo.Token.Equals(""))
            {
                p1 = string.Format("{0}&{1}={2}", p1, SSOConstants.UrlParams.TOKEN, bui.UserInfo.Token);
            }

            Response.Redirect(p1, false);
        }

        /// <summary>
        /// Logs out the current user
        /// </summary>
        public static void Logout(HttpRequest Request, HttpResponse Response, string Token)
        {
            //Xóa authenticate cookie - nếu có
            SSOHTTPRequestService.RemoveCookie(SSOConstants.Cookie.AUTH_COOKIE, Response);

            string baseUrl = Request.Url.Scheme + "://" + Request.Url.Authority + Request.ApplicationPath.TrimEnd('/') + "/";
            //string currentURL = Request.Url.OriginalString;
            //currentURL = UriUtil.RemoveParameter(currentURL, SSOConstants.UrlParams.TOKEN);

            string ssoSiteUrl = string.Format("{0}?{1}={2}", Config.SSO_SITE_URL + SSOConstants.SSOPageParams.LOGOUT, SSOConstants.UrlParams.RETURN_URL, HttpUtility.UrlEncode(baseUrl));
            string LogoutUrl = string.Format("{0}&{1}={2}&{3}={4}", ssoSiteUrl, SSOConstants.UrlParams.ACTION, SSOConstants.ParamValues.LOGOUT, SSOConstants.UrlParams.TOKEN, Token);
            Response.Redirect(LogoutUrl, false);
        }
        #endregion

        #region "User manager services call"
        public static async Task<string> UpdateHtNguoiDung(string SSOSiteUrl, HT_NGUOIDUNG user)
        {
            SSOHtNguoiDung us = Mapper.Map<HT_NGUOIDUNG, SSOHtNguoiDung>(user);
            string retStr = await SSOHTTPRequestService.getSSOData(SSOSiteUrl + SSOConstants.SSOServicesParams.UPDATE_USER, us);

            return retStr;
        }
        #endregion
    }
}
