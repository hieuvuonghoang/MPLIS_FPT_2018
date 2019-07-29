using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using MPLIS.Libraries.Services.SSO;
using System.Web.SessionState;
using System.Threading.Tasks;
using MPLIS.Libraries.Data.SSO.Models;
using MPLIS.Libraries.Data.SSO.Params;
using Newtonsoft.Json;
using MPLIS.Libraries.Services.Utilities;
using MPLIS.Libraries.Services.AutoMapperStartup;

namespace MPLIS.Web
{
    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            AutoMapperRegister.Run();
        }

        //protected void Application_Error(object sender, EventArgs e)
        //{
        //    Exception exception = Server.GetLastError();
        //    Response.Clear();

        //    // clear error on server
        //    Server.ClearError();

        //    Response.Redirect(String.Format("~/Error/Index/?message={0}&IsPartial={1}", Server.UrlEncode(exception.ToString()), true));
        //}

        //private static void UpdateCookie(BSUserInfor ui, HttpSessionState Session, HttpResponse Response)
        //{
        //    HttpCookie aCookie = new HttpCookie("VILISUserLoginInfo");
        //    SSOCookieValues cv = new SSOCookieValues();
        //    cv.UserName = ui.UserInfo.User.TENDANGNHAP;
        //    cv.Token = ui.UserInfo.Token;
        //    cv.LastVisit = DateTime.Now;
        //    string retString = JsonConvert.SerializeObject(cv);
        //    string encrString = Utility.Encrypt(retString, true, Config.SECURITY_KEY);
        //    aCookie.Value = encrString;
        //    aCookie.Expires = DateTime.Now.AddMinutes(Config.AUTH_COOKIE_TIMEOUT_IN_MINUTES);
        //    ui.UserInfo.UserCookie = aCookie;
        //    Session["BSUserInfor"] = ui;

        //    //cập nhật lại cookie tại web browser và SSO
        //    Response.Cookies.Add(aCookie);
        //    Task.Run(() => SSOServices.UpdateCookie(Config.INTERNAL_SSO_SITE_URL, ui.UserInfo.Token, aCookie.Expires));
        //}

        protected async void Application_PreRequestHandlerExecute(object sender, EventArgs e) //buoc1
        {
            if (Context.Handler is IRequiresSessionState || Context.Handler is IReadOnlySessionState)
            {
                HttpApplication app = (HttpApplication)sender;
                bool r = await SSORequestProcessing.PreProcessingRequest(app, Response, Session);
                //t.Wait();
            }
        }
    }
}
