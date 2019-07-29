using MPLIS.Libraries.Data.SSO.Models;
using MPLIS.Libraries.Data.SSO.Params;
using MPLIS.Libraries.Services.Utilities;
using MPLIS.Libraries.Services.QTHT.Service;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.SessionState;

namespace MPLIS.Libraries.Services.SSO
{
    public class SSORequestProcessing
    {
        public static async Task<bool> PreProcessingRequest(HttpApplication app, HttpResponse Response, HttpSessionState Session) //buoc 2
        {
            SSOUserLoginInfors ui;
            BSUserInfor bui;
            SSOUserStatus us;
            
            var request = app.Request;

            //Lấy thông tin xác thực từ request
            SSOHttpRequestParams par = SSOHTTPRequestService.GetRequestParams(request);

            //có lỗi xảy ra, ngừng phục vụ request
            if (par == null)
            {
                app.CompleteRequest();
                return true;
            }

            //Token thiếu, chưa xác thực, cần kiểm tra lại với SSO
            if (par.Token == null || par.Token.Equals(""))
            {
                Session["BSUserInfor"] = null;
                SSOServices.RedirectToLoginPage(request, Response, app.Session);
                app.CompleteRequest();
                return true;
            }

            //Logout request
            if (par.RequestUrl != null && par.RequestUrl.Contains("/Home/Logout"))
            {
                Session["BSUserInfor"] = null;
                SSOServices.Logout(request, Response, par.Token);

                app.CompleteRequest();
                return true;
            }

            SSOHtTokenRequestData data = new SSOHtTokenRequestData();
            data.Token = par.Token;
            data.isTokenFromCookie = par.isTokenFromCookie;
            //mới xác thực, cần lấy thông tin người dùng từ SSO về và kiểm tra
            if (Session["BSUserInfor"] == null)
            {
                ui = await SSOServices.getUserLoggedinInfors(Config.INTERNAL_SSO_SITE_URL, data);
                //var nguoiDungID = request.Params["NGUOIDUNGID"];
                //ui = UserManagerService.GetUserInfor(nguoiDungID);
                bui = new BSUserInfor();

                if (ui != null)
                {
                    if (ui.SuccessGetData)
                    {
                        bui.UserInfo = ui;
                        UpdateCookie(bui, Session, Response);
                    }
                    else
                    {
                        SSOServices.RedirectToLoginPage(request, Response, app.Session);
                        app.CompleteRequest();
                        return true;
                    }
                }
                else    //Không lấy được thông tin người dùng đã login - redirect tới trang login
                {
                    SSOServices.RedirectToLoginPage(request, Response, app.Session);
                    app.CompleteRequest();
                    return true;
                }
            }
            else //người dùng đã login, kiểm tra trạng thái login
            {
                us = await SSOServices.getUserStatus(Config.INTERNAL_SSO_SITE_URL, par.Token);
                if (us != null)
                {
                    if (us.UserLoggedIn) //người dùng vẫn đang logged in
                    {
                        bui = (BSUserInfor)Session["BSUserInfor"];
                        if (bui == null) //đã login từ trước, phiên làm việc chưa kết thúc, lấy lại thông tin user
                        {
                            ui = await SSOServices.getUserLoggedinInfors(Config.INTERNAL_SSO_SITE_URL, data);
                            bui = new BSUserInfor();
                            bui.UserInfo = ui;
                        }
                        UpdateCookie(bui, Session, Response);
                    }
                    else //người dùng đã loged out, trở về login page
                    {
                        SSOServices.RedirectToLoginPage(request, Response, app.Session);
                        app.CompleteRequest();
                        return true;
                    }
                }
                else    //Không lấy được trạng thái login - redirect tới trang login
                {
                    SSOServices.RedirectToLoginPage(request, Response, app.Session);
                    app.CompleteRequest();
                    return true;
                }
            }

            return true;
        }

        public static void UpdateCookie(BSUserInfor ui, HttpSessionState Session, HttpResponse Response)
        {
            HttpCookie aCookie = new HttpCookie(SSOConstants.Cookie.AUTH_COOKIE);
            aCookie.Expires = DateTime.Now.AddMinutes(Config.AUTH_COOKIE_TIMEOUT_IN_MINUTES);
            SSOCookieValues cv = new SSOCookieValues();
            cv.UserName = ui.UserInfo.User.TENDANGNHAP;
            cv.Token = ui.UserInfo.Token;
            cv.LastVisit = DateTime.Now;
            cv.Expires = aCookie.Expires;
            string retString = JsonConvert.SerializeObject(cv);
            string encrString = Utility.Encrypt(retString, true, Config.SECURITY_KEY);
            aCookie.Value = encrString;
            ui.UserInfo.UserCookie = aCookie;
            Session["BSUserInfor"] = ui;

            //cập nhật lại cookie tại web browser và SSO
            Response.Cookies.Add(aCookie);
            Task.Run(() => SSOServices.UpdateCookie(Config.INTERNAL_SSO_SITE_URL, ui.UserInfo.Token, aCookie.Expires));
        }
    }
}
