using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MPLIS.Web.FrameWork.Base;
using MPLIS.Libraries.Data.XuLyHoSo.Models;
using AppCore.Models;


namespace MPLIS.Modules.LuanChuyenHoSo.Controllers
{
    public class XuLyHoSoController : BaseController
    {
        // GET: XuLyHoSo
        public ActionResult Index()
        {
            BoHoSoModel bhs = (BoHoSoModel)Session["BoHoSo_" + CurrentUser.UserName];
            return View(bhs.HoSoTN);
        }
    }
}