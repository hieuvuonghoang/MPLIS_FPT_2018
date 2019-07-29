//using Microsoft.AspNet.Identity;
//using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MPLIS.Web.FrameWork.AttributeExtensions
{
    public class ActivityLogAttribute : ActionFilterAttribute
    {
        public string Activity { get; set; }
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {

        }

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            var _context = "";
            WriteActivityLog(_context);
        }
        protected void WriteActivityLog(string context)
        {
            //HttpRequest Request = HttpContext.Current.Request;
            //if (Request == null) return;
            //string clientip = Request.UserHostAddress;
            //string clientInfo = (Request.UserAgent != null
            //                         ? Request.UserAgent
            //                         : Request.Browser.Type != null
            //                               ? Request.Browser.Type
            //                               : String.Format("{0} {1}", Request.Browser.Id, Request.Browser.Version));
            //string url = Request.RawUrl;
            //var objActivity = new MPLIS.Data.Admin.Models.ACTIVITYLOG();
            //objActivity.ID = Guid.NewGuid();
            //objActivity.ACTIVITY = Activity + (string.IsNullOrEmpty(context) ? "" : ": " + context);
            //objActivity.ACTIVITYDATE = DateTime.Now;
            ////objActivity.ClientInfo = clientInfo;
            ////objActivity.ClientIp = clientip;
            ////objActivity.ClientMac = Helpers.UtilitiesHelper.GetMACAddress();
            ////objActivity.UserName = HttpContext.Current.User.Identity.Name;

            //var _activityLogService = new MPLIS.Services.Admin.ActivityLogService(new Data.Admin.Repository.ActivityLogRepository(new Data.Admin.Infrastructure.DatabaseFactory()), new MPLIS.Data.Admin.UnitOfWork.AdminUnitOfWork(new Data.Admin.Infrastructure.DatabaseFactory()));
            //_activityLogService.Add(objActivity);
        }
    }
}