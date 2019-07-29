using MPLIS.Libraries.Data.SSO.Models;
using MPLIS.Libraries.Data.SSO.Params;
using MPLIS.Libraries.Services.SSO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace MPLIS.FileService.Controllers
{
    public class CheckSSOService
    {
        public async static Task<bool> PreProcessingRequest(HttpApplication app) //buoc 2
        {
            SSOUserStatus us;

            var request = app.Request;

            //Lấy thông tin xác thực từ request
            SSOHttpRequestParams par = SSOHTTPRequestService.GetRequestParams(request);

            //có lỗi xảy ra, ngừng phục vụ request
            if (par == null)
            {
                app.CompleteRequest();
                return false;
            }
            SSOHtTokenRequestData data = new SSOHtTokenRequestData();
            data.Token = par.Token;
            data.isTokenFromCookie = par.isTokenFromCookie;
            us = await SSOServices.getUserStatus(Config.INTERNAL_SSO_SITE_URL, par.Token);
            if (us != null)
            {
                if (us.UserLoggedIn) //người dùng vẫn đang logged in
                {
                    return true;
                }
                else //người dùng đã loged out
                {
                    app.CompleteRequest();
                    return false;
                }
            }
            else    //Không lấy được trạng thái login 
            {
                app.CompleteRequest();
                return false;
            }

        }

    }
}
