using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AppCore.ViewModels;

namespace MPLIS.Web.Controllers
{
    public class ErrorController : Controller
    {
        // GET: Error
        public ActionResult Index(string message, bool? IsPartial)
        {
            ErrorVM data = new ErrorVM();
            data.ErrorMessage = message;

            if (IsPartial == true)
                return PartialView(data);
            else
                return View(data);
        }
    }
}