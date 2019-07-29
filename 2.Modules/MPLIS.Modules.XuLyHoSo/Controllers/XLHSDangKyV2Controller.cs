using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MPLIS.Web.FrameWork.Base;
using MPLIS.Libraries.Data.XuLyHoSo.Models;
using MPLIS.Libraries.Services.XuLyHoSo.Classes;
using AutoMapper;
using AppCore.Models;

namespace MPLIS.Modules.XuLyHoSo.Controllers
{
    [SessionState(System.Web.SessionState.SessionStateBehavior.ReadOnly)]
    public class XLHSDangKyV2Controller : BaseController
    {
        // GET: XLHSDangKyV2
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult _DangKy()
        {
            return PartialView();
        }

        #region "Xử Lý Tab Danh Sách GCN Trong Đăng Ký"
        [HttpPost]
        public ActionResult _DonDangKy_DSGiayChungNhan()
        {
            BoHoSoModel bhs = (BoHoSoModel)Session["BoHoSo_" + CurrentUser.UserName];
            DSDangKyGiayChungNhanVM dSDangKyGiayChungNhanVM = new DSDangKyGiayChungNhanVM();
            dSDangKyGiayChungNhanVM.InitData(bhs);
            return PartialView(dSDangKyGiayChungNhanVM);
        }
        [HttpPost]
        public ActionResult DanhSachGCN_ThemGCN(string soPhatHanh, string maVach)
        {
            bool success = false;
            string message = "";
            if (maVach != "")
            {
                BoHoSoModel bhs = (BoHoSoModel)Session["BoHoSo_" + CurrentUser.UserName];
                success = DCDANGKYGCNServices.ThemGCNVaoDangKy(soPhatHanh, maVach, bhs, out message);
            }
            else
            {
                message = "Dữ liệu không đúng?";
            }
            return Json(new { success = success, message = message });
        }
        [HttpPost]
        public ActionResult DanhSachGCN_XoaGCN(string dangKyGCNID)
        {
            bool success = false;
            string message = "";
            BoHoSoModel bhs = (BoHoSoModel)Session["BoHoSo_" + CurrentUser.UserName];
            success = DCDANGKYGCNServices.XoaGCNTrongDangKy(dangKyGCNID, bhs, out message);
            return Json(new { success = success, message = message });
        }
        #endregion

        #region "Xử Lý Tab Danh Sách Chủ Trong Đăng Ký"
        [HttpPost]
        public ActionResult _DonDangKy_DSChu()
        {
            BoHoSoModel bhs = (BoHoSoModel)Session["BoHoSo_" + CurrentUser.UserName];
            DSChuDonVM dSChuDonVM = new DSChuDonVM();
            dSChuDonVM.InitData(bhs);
            ViewBag.dSLoaiChu = DONDANGKYServices.GetDM_LOAICHU();
            return PartialView(dSChuDonVM);
        }
        [HttpPost]
        public ActionResult _DanhSachChu_ChiTietChu(string dangKyNguoiID)
        {
            string message = "";
            if (dangKyNguoiID != "")
            {
                BoHoSoModel bhs = (BoHoSoModel)Session["BoHoSo_" + CurrentUser.UserName];
                DangKyNguoiVM dangKyNguoiVM = new DangKyNguoiVM();
                if(DCDANGKYNGUOIServices.XemThongTinChiTiet(dangKyNguoiID, bhs, dangKyNguoiVM))
                {
                    return PartialView(dangKyNguoiVM);
                }
            }
            message = "Dữ liệu không đúng?";
            return Json(new { message = message });
        }
        #endregion

    }
}