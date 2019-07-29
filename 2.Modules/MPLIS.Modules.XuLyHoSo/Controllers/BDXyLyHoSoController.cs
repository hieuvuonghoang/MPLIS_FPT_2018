using MPLIS.Libraries.Services.XuLyHoSo.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MPLIS.Web.FrameWork.Base;
using AppCore.Models;
using MPLIS.Libraries.Data.XuLyHoSo.Models;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace MPLIS.Modules.XuLyHoSo.Controllers
{
    public class BDXyLyHoSoController : BaseController
    {
        // GET: BDXyLyHoSo
        //public ActionResult Index(string HOSOTIEPNHANID)
        //{
        //    ViewBag.HOSOTIEPNHANID = HOSOTIEPNHANID;
        //    return View();
        //}
        public ActionResult Index()
        {
            //DCBIENDONGServices.setloaddatabiendong(0);
            //DCGIAYCHUNGNHANServices.setloaddatagiaychungnhan(0);
            //ViewBag.BienDongIDCall= "e924e5ac-4ca3-48c8-af8b-350ae68beba4";
            //ViewBag.DonDangKyIDCall = "A9D4630874C247EC8B670D62C2F61080";
            //ViewBag.HoSoTiepNhanIDCall = "2D921A9AF541474991F4380FAE31561F";
            //DCDONDANGKYServices.setloaddatadondangky(0);
            //long totalSessionBytes = 0;
            //BinaryFormatter b = new BinaryFormatter();
            //MemoryStream m;
            //foreach (string key in Session)
            //{
            //    var obj = Session[key];
            //    m = new System.IO.MemoryStream();
            //    b.Serialize(m, obj);
            //    totalSessionBytes += m.Length;
            //}
            //Session.Clear();

            BoHoSoModel bhs = (BoHoSoModel)Session["BoHoSo_" + CurrentUser.UserName];
            if (bhs == null)
            {
                bhs = new BoHoSoModel();
                bhs.HoSoTN = QTHOSOTIEPNHANServices.getAllHoSoTiepNhan("2D921A9AF541474991F4380FAE31561F");
                BOHOSOServices.initDataInBHS(bhs);
                var bienDongTemp = bhs.HoSoTN.BienDong;
                var dangKyTemp = bhs.HoSoTN.DonDangKy;

                var dsGCNDangKy = dangKyTemp.DSDangKyGCN;
                var dsChuDangKy = dangKyTemp.DSDangKyChu;
                var dsThuaDangKy = dangKyTemp.DSDangKyThua;
                var dsTaiSanDangKy = dangKyTemp.DSDangKyTaiSan;

                Session["BoHoSo_" + CurrentUser.UserName] = bhs;
            }
            return PartialView();
        }

        public ActionResult IndexByID(string HoSoTiepNhanID)
        {
            BoHoSoModel bhs = new BoHoSoModel();
            bhs.HoSoTN = QTHOSOTIEPNHANServices.getAllHoSoTiepNhan(HoSoTiepNhanID);
            Session["BoHoSo_" + CurrentUser.UserName] = bhs;
            return PartialView();
        }
    }
}