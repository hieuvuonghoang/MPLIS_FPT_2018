using AppCore.Models;
using MPLIS.Libraries.Data.XuLyHoSo.Models;
using MPLIS.Libraries.Services.XuLyHoSo.Classes;
using MPLIS.Web.FrameWork.Base;
using System;
using System.IO;
using System.Net;
using System.Web.Mvc;
using AutoMapper;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace MPLIS.Modules.XuLyHoSo.Controllers
{
    public class XLHSGiayChungNhanController : BaseController
    {
        #region Giấy Chứng Nhận
        [HttpPost]
        public ActionResult InitCurGiayChungNhan(string gCNID, TaiGCN taiGCN)
        {
            BoHoSoModel bhs = (BoHoSoModel)Session["BoHoSo_" + CurrentUser.UserName];
            if (DCGIAYCHUNGNHANServices.InitBHSCurGCN(gCNID, taiGCN, bhs))
            {
                Session["BoHoSo_" + CurrentUser.UserName] = bhs;
                return PartialView("GiayChungNhan");
            }
            return Json(new { message = "Dữ liệu không đúng?" });
        }
        [HttpPost]
        public ActionResult GiayChungNhan(string iD, TaiGCN loaiGCN)
        {
            BoHoSoModel bhs = (BoHoSoModel)Session["BoHoSo_" + CurrentUser.UserName];
            bhs.initCurGCN(iD, loaiGCN);
            Session["BoHoSo_" + CurrentUser.UserName] = bhs;
            return PartialView();
        }
        public ActionResult GiayChungNhan_Main()
        {
            BoHoSoModel bhs = (BoHoSoModel)Session["BoHoSo_" + CurrentUser.UserName];
            GiayChungNhanLS giayChungNhanLS = Mapper.Map<DC_GIAYCHUNGNHAN, GiayChungNhanLS>(bhs.CurDC_GIAYCHUNGNHAN);
            ViewBag.dSTrangThaiXL = new SelectList(new List<SelectListItem>
            {
                new SelectListItem() {Selected = true, Text = "-- Chọn trạng thái xử lý --", Value = "" },
                new SelectListItem() {Selected = false, Text = "Đã phê duyệt, có tính pháp lý", Value = "Y" },
                new SelectListItem() {Selected = false, Text = "Không được phê duyệt, không có tính pháp lý", Value = "N" },
                new SelectListItem() {Selected = false, Text = "Đang xử lý, không có tính pháp lý", Value = "S" }
            }, "Value", "Text");
            Session["BoHoSo_" + CurrentUser.UserName] = bhs;
            return PartialView(giayChungNhanLS);
        }
        public ActionResult GiayChungNhan_Main_HanChe()
        {
            BoHoSoModel bhs = (BoHoSoModel)Session["BoHoSo_" + CurrentUser.UserName];
            GiayChungNhanLS giayChungNhanLS = Mapper.Map<DC_GIAYCHUNGNHAN, GiayChungNhanLS>(bhs.CurDC_GIAYCHUNGNHAN);
            return PartialView(giayChungNhanLS);
        }
        public ActionResult GiayChungNhan_Main_QLDat()
        {
            BoHoSoModel bhs = (BoHoSoModel)Session["BoHoSo_" + CurrentUser.UserName];
            GiayChungNhanLS giayChungNhanLS = Mapper.Map<DC_GIAYCHUNGNHAN, GiayChungNhanLS>(bhs.CurDC_GIAYCHUNGNHAN);
            return PartialView(giayChungNhanLS);
        }
        public ActionResult GiayChungNhan_Main_SDDat()
        {
            BoHoSoModel bhs = (BoHoSoModel)Session["BoHoSo_" + CurrentUser.UserName];
            GiayChungNhanLS giayChungNhanLS = Mapper.Map<DC_GIAYCHUNGNHAN, GiayChungNhanLS>(bhs.CurDC_GIAYCHUNGNHAN);
            return PartialView(giayChungNhanLS);
        }
        public ActionResult GiayChungNhan_Main_SHTaiSan()
        {
            BoHoSoModel bhs = (BoHoSoModel)Session["BoHoSo_" + CurrentUser.UserName];
            GiayChungNhanLS giayChungNhanLS = Mapper.Map<DC_GIAYCHUNGNHAN, GiayChungNhanLS>(bhs.CurDC_GIAYCHUNGNHAN);
            return PartialView(giayChungNhanLS);
        }
        [HttpPost]
        public ActionResult GiayChungNhan_Main_TLSH()
        {
            BoHoSoModel bhs = (BoHoSoModel)Session["BoHoSo_" + CurrentUser.UserName];
            GiayChungNhanLS giayChungNhanLS = Mapper.Map<DC_GIAYCHUNGNHAN, GiayChungNhanLS>(bhs.CurDC_GIAYCHUNGNHAN);
            return PartialView(giayChungNhanLS);
        }
        [HttpPost]
        public ActionResult Save_FormTTChungGCN(string data)
        {
            bool success = false;
            string message = "";
            try
            {
                GiayChungNhanLS giayChungNhanLS = JsonConvert.DeserializeObject<GiayChungNhanLS>(data);
                DC_GIAYCHUNGNHAN giayChungNhan = Mapper.Map<GiayChungNhanLS, DC_GIAYCHUNGNHAN>(giayChungNhanLS);
                BoHoSoModel bhs = (BoHoSoModel)Session["BoHoSo_" + CurrentUser.UserName];
                if (DCGIAYCHUNGNHANServices.UpdateTTGiayChungNhan(giayChungNhan, bhs, out message))
                {
                    Session["BoHoSo_" + CurrentUser.UserName] = bhs;
                    success = true;
                }
            }
            catch (Exception ex)
            {
                message = ex.Message;
            }
            return Json(new { success = success, message = message });
        }
        [HttpPost]
        public ActionResult DanhSachHanChe_ChiTietHanChe(string hanCheID)
        {
            BoHoSoModel bhs = (BoHoSoModel)Session["BoHoSo_" + CurrentUser.UserName];
            HanCheLS hanCheVM = null;
            foreach (var hanChe in bhs.CurDC_GIAYCHUNGNHAN.DSHanChe)
            {
                if (hanChe.HANCHEID == hanCheID)
                {
                    hanCheVM = Mapper.Map<DC_HANCHE, HanCheLS>(hanChe);
                    break;
                }
            }
            ViewBag.dSLoaiHanChe = DCTHUADATServices.get_Loaihanche();
            Session["BoHoSo_" + CurrentUser.UserName] = bhs;
            return PartialView("HanChe_ChiTiet", hanCheVM);
        }
        [HttpPost]
        public ActionResult DanhSachHanChe_ThemMoiHanChe()
        {
            BoHoSoModel bhs = (BoHoSoModel)Session["BoHoSo_" + CurrentUser.UserName];
            if (bhs.CurDC_GIAYCHUNGNHAN.ChinhSua)
            {
                ViewBag.dSLoaiHanChe = DCTHUADATServices.get_Loaihanche();
                return PartialView("HanChe_ChiTiet", Mapper.Map<DC_HANCHE, HanCheLS>(new DC_HANCHE()));
            }
            return Json(new { message = "Dữ liệu không đúng?" });
        }
        [HttpPost]
        public ActionResult HanChe_ChiTiet_SaveForm(string data)
        {
            bool success = false;
            string message = "";
            try
            {
                DC_HANCHE hanChe = JsonConvert.DeserializeObject<DC_HANCHE>(data);
                BoHoSoModel bhs = (BoHoSoModel)Session["BoHoSo_" + CurrentUser.UserName];
                if (success = DCHANCHEServices.DBInsertOrUpdateHanChe_GCN(hanChe, out message, bhs))
                    Session["BoHoSo_" + CurrentUser.UserName] = bhs;
            }
            catch (Exception ex)
            {
                message = ex.Message;
            }
            return Json(new { success = success, message = message });
        }
        [HttpPost]
        public ActionResult DanhSachHanChe_XoaHanChe(string hanCheID)
        {
            bool success = false;
            string message = "";
            BoHoSoModel bhs = (BoHoSoModel)Session["BoHoSo_" + CurrentUser.UserName];
            if (success = DCHANCHEServices.DBDeleteHanChe(hanCheID, bhs, out message))
                Session["BoHoSo_" + CurrentUser.UserName] = bhs;
            return Json(new { success = success, message = message });
        }
        #endregion
        #region "Popup"
        [HttpPost]
        public ActionResult Popup_ThemQuyenVaoGCN(QUYENTRENGCN iSQuyen)
        {
            BoHoSoModel bhs = (BoHoSoModel)Session["BoHoSo_" + CurrentUser.UserName];
            DC_GIAYCHUNGNHAN curGiayChungNhan = bhs.CurDC_GIAYCHUNGNHAN;
            if (curGiayChungNhan.ChinhSua)
            {
                if (iSQuyen == QUYENTRENGCN.QSDDAT || iSQuyen == QUYENTRENGCN.QQLDAT)
                {
                    ViewBag.Title = iSQuyen == QUYENTRENGCN.QSDDAT ? "Thêm Quyền Sử Dụng Đất" : "Thêm Quyền Quản Lý Đất";
                    DSThuaDatVM dSThuaDatVM = new DSThuaDatVM();
                    dSThuaDatVM.ISQuyen = iSQuyen;
                    dSThuaDatVM.InitData(bhs);
                    return PartialView("Popup_DSThua", dSThuaDatVM);
                }
                else if (iSQuyen == QUYENTRENGCN.QSHTS)
                {
                    DSTaiSanVM dSTaiSan = new DSTaiSanVM();
                    dSTaiSan.ISQuyen = iSQuyen;
                    dSTaiSan.InitData(bhs);
                    return PartialView("Popup_DSTaiSan", dSTaiSan);
                }
            }
            return Json(new { message = "Dữ liệu không đúng?" });
        }
        [HttpPost]
        public ActionResult Save_Popup_ThemQuyenVaoGCN(string data, QUYENTRENGCN iSQuyen, THUATHEO thuaTheo)
        {
            bool success = false;
            string message = "";
            try
            {
                List<string> dSID = JsonConvert.DeserializeObject<List<string>>(data);
                BoHoSoModel bhs = (BoHoSoModel)Session["BoHoSo_" + CurrentUser.UserName];
                if (iSQuyen == QUYENTRENGCN.QSDDAT)
                {
                    if (thuaTheo == THUATHEO.THUADATID)
                        success = DCGIAYCHUNGNHANServices.ThemQSDDatTheoThuaDatIDVaoGCN(dSID, bhs, out message);
                    else if (thuaTheo == THUATHEO.MDSDID)
                        success = DCGIAYCHUNGNHANServices.ThemQSDDatTheoMDSDIDVaoGCN(dSID, bhs, out message);
                }
                else if (iSQuyen == QUYENTRENGCN.QQLDAT)
                {
                    if (thuaTheo == THUATHEO.THUADATID)
                        success = DCGIAYCHUNGNHANServices.ThemQQLDatTheoThuaDatIDVaoGCN(dSID, bhs, out message);
                    else if (thuaTheo == THUATHEO.MDSDID)
                        success = DCGIAYCHUNGNHANServices.ThemQQLDatTheoMDSDIDVaoGCN(dSID, bhs, out message);
                }
                else if (iSQuyen == QUYENTRENGCN.QSHTS)
                {
                    success = DCGIAYCHUNGNHANServices.ThemQSHTSVaoGCN(dSID, bhs, out message);
                }
                if (success)
                    Session["BoHoSo_" + CurrentUser.UserName] = bhs;
            }
            catch (Exception ex)
            {
                message = ex.Message;
            }
            return Json(new { success = success, message = message });
        }
        [HttpPost]
        public ActionResult Popup_DSTaiSan()
        {
            BoHoSoModel bhs = (BoHoSoModel)Session["BoHoSo_" + CurrentUser.UserName];
            DSTaiSanVM dSTaiSan = new DSTaiSanVM();
            foreach (var temp in bhs.HoSoTN.DonDangKy.DSDangKyTaiSan)
                dSTaiSan.DSTaiSan.Add(Mapper.Map<DC_TAISANGANLIENVOIDAT, TaiSanGanLienVoiDatVM>(temp.TaiSanGanLienVoiDat));
            return PartialView(dSTaiSan);
        }

        [HttpPost]
        public ActionResult SaveForm_Popup_DSThuaTheoThuaID(string data)
        {
            bool success = false;
            string message = "";
            try
            {
                List<string> dSID = JsonConvert.DeserializeObject<List<string>>(data);
                BoHoSoModel bhs = (BoHoSoModel)Session["BoHoSo_" + CurrentUser.UserName];
                if (bhs.CurDC_GIAYCHUNGNHAN.IsQuyen == 1)
                {
                    DCGIAYCHUNGNHANServices.ThemQSDDatTheoThuaDatIDVaoGCN(dSID, bhs, out message);
                }
                else if (bhs.CurDC_GIAYCHUNGNHAN.IsQuyen == 2)
                {
                    DCGIAYCHUNGNHANServices.ThemQQLDatTheoThuaDatIDVaoGCN(dSID, bhs, out message);
                }
                Session["BoHoSo_" + CurrentUser.UserName] = bhs;
                success = true;
            }
            catch (Exception ex)
            {
                message = ex.Message;
            }
            return Json(new { success = success, message = message });
        }
        [HttpPost]
        public ActionResult SaveForm_Popup_DSThuaTheoMDSDID(string data)
        {
            bool success = false;
            string message = "";
            try
            {
                List<string> dSID = JsonConvert.DeserializeObject<List<string>>(data);
                BoHoSoModel bhs = (BoHoSoModel)Session["BoHoSo_" + CurrentUser.UserName];
                if (bhs.CurDC_GIAYCHUNGNHAN.IsQuyen == 1)
                {
                    DCGIAYCHUNGNHANServices.ThemQSDDatTheoMDSDIDVaoGCN(dSID, bhs, out message);
                }
                else if (bhs.CurDC_GIAYCHUNGNHAN.IsQuyen == 2)
                {
                    DCGIAYCHUNGNHANServices.ThemQQLDatTheoMDSDIDVaoGCN(dSID, bhs, out message);
                }
                Session["BoHoSo_" + CurrentUser.UserName] = bhs;
                success = true;
            }
            catch (Exception ex)
            {
                message = ex.Message;
            }
            return Json(new { success = success, message = message });
        }
        [HttpPost]
        public ActionResult SaveForm_Popup_DSTaiSan(string data)
        {
            BoHoSoModel bhs = (BoHoSoModel)Session["BoHoSo_" + CurrentUser.UserName];
            List<string> dSTSGLVDID = JsonConvert.DeserializeObject<List<string>>(data);
            DCGIAYCHUNGNHANServices.AddQuyenSoHuuTaiSan(bhs, dSTSGLVDID);
            return Json("");
        }
        [HttpPost]
        public ActionResult Popup_DSChu(string nguoiID)
        {
            BoHoSoModel bhs = (BoHoSoModel)Session["BoHoSo_" + CurrentUser.UserName];
            DSChuDonVM dSChuDonVM = new DSChuDonVM();
            foreach (var temp in bhs.HoSoTN.DonDangKy.DSDangKyChu)
                dSChuDonVM.DSDangKyChu.Add(Mapper.Map<DC_DANGKY_NGUOI, ChuDonVM>(temp));
            dSChuDonVM.NGUOIID = nguoiID;
            return PartialView(dSChuDonVM);
        }
        [HttpPost]
        public ActionResult SaveForm_Popup_DSChu(string nguoiID)
        {
            BoHoSoModel bhs = (BoHoSoModel)Session["BoHoSo_" + CurrentUser.UserName];
            bhs.CurDC_GIAYCHUNGNHAN.NGUOIID = nguoiID;
            if (bhs.CurDC_GIAYCHUNGNHAN.DSTyLeSoHuu != null)
                bhs.CurDC_GIAYCHUNGNHAN.DSTyLeSoHuu.Clear();
            else
                bhs.CurDC_GIAYCHUNGNHAN.DSTyLeSoHuu = new List<DC_GCN_TILESH>();
            Session["BoHoSo_" + CurrentUser.UserName] = bhs;
            return Json("ss");
        }
        [HttpPost]
        public ActionResult Popup_SetTLSH(string thanhVienID)
        {
            BoHoSoModel bhs = (BoHoSoModel)Session["BoHoSo_" + CurrentUser.UserName];
            if (thanhVienID != "" && bhs.CurDC_GIAYCHUNGNHAN.ChinhSua)
            {
                GCNTiLeSoHuuVM gCNTiLeSoHuuVM = new GCNTiLeSoHuuVM();
                foreach (var temp in bhs.CurDC_GIAYCHUNGNHAN.DSTyLeSoHuu)
                {
                    if (temp.THANHVIENID == thanhVienID)
                    {
                        Mapper.Map<DC_GCN_TILESH, GCNTiLeSoHuuVM>(temp, gCNTiLeSoHuuVM);
                        break;
                    }
                }
                ViewBag.dSLoaiMienGiam = DMLOAIDTMIENGIAMServices.GetDMLOAIDTMIENGIAM();
                return PartialView(gCNTiLeSoHuuVM);
            }
            return Json(new { message = "Dữ liệu không đúng!"});
        }
        [HttpPost]
        public ActionResult Save_Popup_SetTLSH(string data)
        {
            TyLeSoHuuLS tyLeSoHuu = JsonConvert.DeserializeObject<TyLeSoHuuLS>(data);
            DC_GCN_TILESH gCNTLSH = Mapper.Map<TyLeSoHuuLS, DC_GCN_TILESH>(tyLeSoHuu);
            BoHoSoModel bhs = (BoHoSoModel)Session["BoHoSo_" + CurrentUser.UserName];
            foreach (var temp in bhs.CurDC_GIAYCHUNGNHAN.DSTyLeSoHuu)
            {
                if (temp.GCNTILESHID == gCNTLSH.GCNTILESHID)
                {
                    temp.TILESOHUU = gCNTLSH.TILESOHUU;
                    temp.LOAIDTMIENGIAMID = gCNTLSH.LOAIDTMIENGIAMID;
                    break;
                }
            }
            Session["BoHoSo_" + CurrentUser.UserName] = bhs;
            return Json("");
        }
        #endregion
        #region "Xóa Quyền"
        [HttpPost]
        public ActionResult QuyenSuDungDat_XoaQuyen(string quyenSuDungDatID)
        {
            bool success = false;
            string message = "";
            BoHoSoModel bhs = (BoHoSoModel)Session["BoHoSo_" + CurrentUser.UserName];
            if (success = DCGIAYCHUNGNHANServices.XoaQSDatTrenGCN(quyenSuDungDatID, bhs, out message))
                Session["BoHoSo_" + CurrentUser.UserName] = bhs;
            return Json(new { success = success, message = message });
        }
        [HttpPost]
        public ActionResult QuyenSoHuuTaiSan_XoaQuyen(string quyenSoHuuTaiSanID)
        {
            bool success = false;
            string message = "";
            BoHoSoModel bhs = (BoHoSoModel)Session["BoHoSo_" + CurrentUser.UserName];
            if (success = DCGIAYCHUNGNHANServices.XoaQSHTaiSanTrenGCN(quyenSoHuuTaiSanID, bhs, out message))
                Session["BoHoSo_" + CurrentUser.UserName] = bhs;
            return Json(new { success = success, message = message });
        }
        [HttpPost]
        public ActionResult QuyenQuanLyDat_XoaQuyen(string quyenQuanLyDatID)
        {
            bool success = false;
            string message = "";
            BoHoSoModel bhs = (BoHoSoModel)Session["BoHoSo_" + CurrentUser.UserName];
            if (success = DCGIAYCHUNGNHANServices.XoaQQLDatTrenGCN(quyenQuanLyDatID, bhs, out message))
                Session["BoHoSo_" + CurrentUser.UserName] = bhs;
            return Json(new { success = success, message = message });
        }
        #endregion
        #region "Tỷ lệ sở hữu trên quyền"
        [HttpPost]
        public ActionResult Popup_SetTLSH_TrenQuyen(ISQuyen isQuyen, string ID)
        {
            BoHoSoModel bhs = (BoHoSoModel)Session["BoHoSo_" + CurrentUser.UserName];
            DC_GIAYCHUNGNHAN curGiayChungNhan = bhs.CurDC_GIAYCHUNGNHAN;
            DSTLSHTrenQuyenVM dSTLSHTrenQuyen = new DSTLSHTrenQuyenVM();
            dSTLSHTrenQuyen.ISQUYEN = isQuyen;
            foreach (var tempBDGCN in bhs.HoSoTN.BienDong.DSGcn)
            {
                if (tempBDGCN.GiayChungNhan.SOHUUCHUNGID == curGiayChungNhan.SOHUUCHUNGID && tempBDGCN.GiayChungNhan.TRANGTHAIXULY == "S")
                {
                    if (isQuyen == ISQuyen.QSDDAT)
                    {
                        foreach (var tempQSDDat in tempBDGCN.GiayChungNhan.DSQuyenSDDat)
                        {
                            if (tempQSDDat.MUCDICHSUDUNGDATID == ID)
                            {
                                dSTLSHTrenQuyen.DSTLSHTrenQuyen.Add(new TyLeSoHuuTrenQuyenVM(tempBDGCN.GiayChungNhan.SOPHATHANH, tempBDGCN.GiayChungNhan.MAVACH, tempQSDDat.QUYENSUDUNGDATID, tempQSDDat.TILESOHUU ?? 0M));
                                break;
                            }
                        }
                    }
                    else if (isQuyen == ISQuyen.QQLDAT)
                    {
                        foreach (var tempQQLDat in tempBDGCN.GiayChungNhan.DSQuyenQLDat)
                        {
                            if (tempQQLDat.MUCDICHSUDUNGID == ID)
                            {
                                dSTLSHTrenQuyen.DSTLSHTrenQuyen.Add(new TyLeSoHuuTrenQuyenVM(tempBDGCN.GiayChungNhan.SOPHATHANH, tempBDGCN.GiayChungNhan.MAVACH, tempQQLDat.QUYENQUANLYDATID, tempQQLDat.TILESOHUU ?? 0M));
                                break;
                            }
                        }
                    }
                    else if (isQuyen == ISQuyen.QSHTS)
                    {
                        foreach (var tempQSHTS in tempBDGCN.GiayChungNhan.DSQuyenSHTS)
                        {
                            if (tempQSHTS.TAISANGANLIENVOIDATID == ID)
                            {
                                dSTLSHTrenQuyen.DSTLSHTrenQuyen.Add(new TyLeSoHuuTrenQuyenVM(tempBDGCN.GiayChungNhan.SOPHATHANH, tempBDGCN.GiayChungNhan.MAVACH, tempQSHTS.QUYENSOHUUTAISANID, tempQSHTS.TILESOHUU ?? 0M));
                                break;
                            }
                        }
                    }
                }
            }
            return PartialView(dSTLSHTrenQuyen);
        }
        [HttpPost]
        public ActionResult SaveForm_Popup_SetTLSH_TrenQuyen(string data)
        {
            DSTLSHTrenQuyenVM dSTLSHTrenQuyen = JsonConvert.DeserializeObject<DSTLSHTrenQuyenVM>(data);
            BoHoSoModel bhs = (BoHoSoModel)Session["BoHoSo_" + CurrentUser.UserName];
            DC_GIAYCHUNGNHAN curGiayChungNhan = bhs.CurDC_GIAYCHUNGNHAN;
            foreach (var tempBDGCN in bhs.HoSoTN.BienDong.DSGcn)
            {
                if (tempBDGCN.GiayChungNhan.SOHUUCHUNGID == curGiayChungNhan.SOHUUCHUNGID && tempBDGCN.GiayChungNhan.TRANGTHAIXULY == "S")
                {
                    bool found = false;
                    foreach (var tempTLSHTrenQuyen in dSTLSHTrenQuyen.DSTLSHTrenQuyen)
                    {
                        if (dSTLSHTrenQuyen.ISQUYEN == ISQuyen.QSDDAT)
                        {
                            foreach (var tempQSDDat in tempBDGCN.GiayChungNhan.DSQuyenSDDat)
                            {
                                if (tempQSDDat.QUYENSUDUNGDATID == tempTLSHTrenQuyen.QUYENID)
                                {
                                    tempQSDDat.TILESOHUU = tempTLSHTrenQuyen.TILESOHUU;
                                    found = true;
                                    break;
                                }
                            }
                        }
                        else if (dSTLSHTrenQuyen.ISQUYEN == ISQuyen.QQLDAT)
                        {
                            foreach (var tempQQLDat in tempBDGCN.GiayChungNhan.DSQuyenQLDat)
                            {
                                if (tempQQLDat.QUYENQUANLYDATID == tempTLSHTrenQuyen.QUYENID)
                                {
                                    tempQQLDat.TILESOHUU = tempTLSHTrenQuyen.TILESOHUU;
                                    found = true;
                                    break;
                                }
                            }
                        }
                        else if (dSTLSHTrenQuyen.ISQUYEN == ISQuyen.QSHTS)
                        {
                            foreach (var tempQSHTS in tempBDGCN.GiayChungNhan.DSQuyenSHTS)
                            {
                                if (tempQSHTS.QUYENSOHUUTAISANID == tempTLSHTrenQuyen.QUYENID)
                                {
                                    tempQSHTS.TILESOHUU = tempTLSHTrenQuyen.TILESOHUU;
                                    found = true;
                                    break;
                                }
                            }
                        }
                        if (found)
                            break;
                    }
                }
            }
            return Json("");
        }
        #endregion
        private MplisEntities db = new MplisEntities();
        public static string idcbGCNchon = "";
        public string ftpUploadurl = (string)System.Configuration.ConfigurationManager.AppSettings["ftpUploadurl"]; // lấy đường dẫn lưu file chỉ định url
        public string ftpUsername = (string)System.Configuration.ConfigurationManager.AppSettings["ftpUsername"]; // lấy tài khoản đăng nhập
        public string ftpPassword = (string)System.Configuration.ConfigurationManager.AppSettings["ftpPassword"]; // lấy mật khẩu đăng nhập

        //GET: XLHSGiayChungNhan
        public ActionResult Index()
        {
            return PartialView();
        }

        public JsonResult ImportBanQuet()
        {
            var ite = Request.Files[0];
            string filenamesave = idcbGCNchon + ite.FileName;// + ite.FileName.Substring(ite.FileName.LastIndexOf("."));
            string duongdansv = ftpUploadurl + "XuLyHoSo/GiayChungNhan/";
            string ftpUrl = String.Format("{0}{1}", duongdansv, filenamesave);
            FtpWebRequest requestdeletefile = FtpWebRequest.Create(ftpUrl) as FtpWebRequest;
            requestdeletefile.Credentials = new NetworkCredential(ftpUsername, ftpPassword);
            try
            {
                requestdeletefile.Method = WebRequestMethods.Ftp.DeleteFile;
                FtpWebResponse response = (FtpWebResponse)requestdeletefile.GetResponse();
            }
            catch (Exception ex)
            {
            }
            Stream streamObj = ite.InputStream;
            byte[] buffer = new byte[ite.ContentLength];
            streamObj.Read(buffer, 0, buffer.Length);
            streamObj.Close();
            streamObj = null;
            FtpWebRequest request = FtpWebRequest.Create(ftpUrl) as FtpWebRequest;
            request.Credentials = new NetworkCredential(ftpUsername, ftpPassword);
            request.Method = WebRequestMethods.Ftp.UploadFile;
            Stream requestStream = request.GetRequestStream();
            requestStream.Write(buffer, 0, buffer.Length);
            requestStream.Flush();
            requestStream.Close();
            request = null;
            return Json("abc");
        }

        public ActionResult DownloadFileBanQuet(string id)
        {
            BoHoSoModel bhs = (BoHoSoModel)Session["BoHoSo_" + CurrentUser.UserName];
            string tenfilebaocao_zip = id + ".pdf";
            string filenamesave = idcbGCNchon + ".pdf";
            string duongdansv = ftpUploadurl + "XuLyHoSo/GiayChungNhan/";
            string ftpUrl = String.Format("{0}/{1}", duongdansv, filenamesave);
            WebClient request = new WebClient();
            request.Credentials = new NetworkCredential(ftpUsername, ftpPassword);
            byte[] fileData = request.DownloadData(ftpUrl);

            return File(fileData, System.Net.Mime.MediaTypeNames.Application.Octet, tenfilebaocao_zip);
        }

        public ActionResult _GiayChungNhan(string id, TaiGCN loaiGCN)
        {
            BoHoSoModel bhs = (BoHoSoModel)Session["BoHoSo_" + CurrentUser.UserName];
            bhs.initGCN(id, loaiGCN);
            ViewBag.DS_Nguoi_QuyenSDDAT = new SelectList(bhs.list_Droplist_Nguoi_QuyenSDDat, "ID", "NAME");
            ViewBag.DS_xulyhsgcn = new SelectList(bhs.list_Droplist_XLHSChon_GCN, "ID", "NAME");
            ViewBag.DM_TrangThaiXL = new SelectList(bhs.list_Droplist_TTXL, "ID", "NAME");
            Session["BoHoSo_" + CurrentUser.UserName] = bhs;
            return PartialView(bhs);
        }

        public ActionResult _GiayChungNhan_Main(string id_chon)
        {
            BoHoSoModel bhs = (BoHoSoModel)Session["BoHoSo_" + CurrentUser.UserName];
            bhs.initGCN(id_chon, TaiGCN.BIENDONG);
            ViewBag.DS_Nguoi_QuyenSDDAT = new SelectList(bhs.list_Droplist_Nguoi_QuyenSDDat, "ID", "NAME");
            ViewBag.DS_xulyhsgcn = new SelectList(bhs.list_Droplist_XLHSChon_GCN, "ID", "NAME");
            ViewBag.DM_TrangThaiXL = new SelectList(bhs.list_Droplist_TTXL, "ID", "NAME");
            Session["BoHoSo_" + CurrentUser.UserName] = bhs;
            return PartialView(bhs);
        }

        public ActionResult _GiayChungNhan_Main_SDDAT()
        {
            BoHoSoModel bhs = (BoHoSoModel)Session["BoHoSo_" + CurrentUser.UserName];
            return PartialView(bhs);
        }

        public ActionResult _GiayChungNhan_Main_SHTAISAN()
        {
            BoHoSoModel bhs = (BoHoSoModel)Session["BoHoSo_" + CurrentUser.UserName];
            return PartialView(bhs);
        }

        //[HttpPost]
        //public ActionResult _Popup_DSThuaTrongDK(string isQuyen)
        //{
        //    BoHoSoModel bhs = (BoHoSoModel)Session["BoHoSo_" + CurrentUser.UserName];
        //    DanhSachThuaVM dSThuaVM = new DanhSachThuaVM();
        //    dSThuaVM.initData(bhs, isQuyen);
        //    return PartialView(dSThuaVM);
        //}

        public ActionResult _Popup_DSTaiSanTrongDK()
        {
            BoHoSoModel bhs = (BoHoSoModel)Session["BoHoSo_" + CurrentUser.UserName];
            DanhSachTaiSanVM dSTaiSanVM = new DanhSachTaiSanVM();
            dSTaiSanVM.initData(bhs);
            return PartialView(dSTaiSanVM);
        }

        [HttpPost]
        public ActionResult Save_GCN_MAIN_TTCHUNG(DC_GIAYCHUNGNHAN CurDC_GIAYCHUNGNHAN)
        {
            BoHoSoModel bhs = (BoHoSoModel)Session["BoHoSo_" + CurrentUser.UserName];
            DCGIAYCHUNGNHANServices.SaveTTChungGiayChungNhan(bhs, CurDC_GIAYCHUNGNHAN);
            return Json(new { result = "success" }); //PartialView("_GiayChungNhan_Main_TTCHUNG", objVMGiayChungNhan);
        }

        [HttpPost]
        public ActionResult Save_GCN_MAIN_SDDAT(VM_XuLyHoSo_GCN formData)
        {
            return Json(new { result = "success" }); //PartialView("_GiayChungNhan_Main_SDDAT", objVMGiayChungNhan);
        }

        [HttpPost]
        public ActionResult Save_GCN_MAIN_SHTAISAN(VM_XuLyHoSo_GCN formData)
        {
            return Json(new { result = "success" }); //PartialView("_GiayChungNhan_Main_SHTAISAN", objVMGiayChungNhan);
        }

        [HttpPost]
        public ActionResult Remove_DSQUYENSDDAT_Row(string quyenSDDATID, string gcnID)
        {
            BoHoSoModel bhs = (BoHoSoModel)Session["BoHoSo_" + CurrentUser.UserName];
            DCGIAYCHUNGNHANServices.removeQuyenSDDatInGCN(quyenSDDATID, gcnID, bhs);
            Session["BoHoSo_" + CurrentUser.UserName] = bhs;
            return Json(new { RowID = quyenSDDATID });
            //return PartialView("_GiayChungNhan_Main_SDDAT", bhs);
        }

        public ActionResult Remove_DSSHTAISAN_Row(string quyenSHTSID, string gcnID)
        {
            BoHoSoModel bhs = (BoHoSoModel)Session["BoHoSo_" + CurrentUser.UserName];
            DCGIAYCHUNGNHANServices.removeQuyenSHTSInGCN(quyenSHTSID, gcnID, bhs);
            Session["BoHoSo_" + CurrentUser.UserName] = bhs;
            return Json(new { RowID = quyenSHTSID });
        }

        [HttpPost]
        public ActionResult Remove_DSQUYENQLDAT_Row(string quyenQLDatID, string gcnID)
        {
            BoHoSoModel bhs = (BoHoSoModel)Session["BoHoSo_" + CurrentUser.UserName];
            DCGIAYCHUNGNHANServices.removeQuyenQLDatInGCN(quyenQLDatID, gcnID, bhs);
            Session["BoHoSo_" + CurrentUser.UserName] = bhs;
            return Json(new { RowID = quyenQLDatID });
        }
        [HttpPost]
        public ActionResult updateDSQuyenSDDatInGCN(string gcnID)
        {
            BoHoSoModel bhs = (BoHoSoModel)Session["BoHoSo_" + CurrentUser.UserName];
            DCGIAYCHUNGNHANServices.updateDSQuyenSDDatInGCN(gcnID, bhs);
            return Json(new { result = "success" });
        }

        public ActionResult updateDSQuyenQLDatInGCN(string gcnID)
        {
            BoHoSoModel bhs = (BoHoSoModel)Session["BoHoSo_" + CurrentUser.UserName];
            DCGIAYCHUNGNHANServices.updateDSQuyenQLDatInGCN(gcnID, bhs);
            return Json(new { result = "success" });
        }

        public ActionResult updateDSQuyenSHTSInGCN(string gcnID)
        {
            BoHoSoModel bhs = (BoHoSoModel)Session["BoHoSo_" + CurrentUser.UserName];
            DCGIAYCHUNGNHANServices.updateDSQuyenSHTSInGCN(gcnID, bhs);
            return Json(new { result = "success" });
        }

        [HttpPost]
        public ActionResult Add_DSSDDAT_RTABLE_THUA(string[] dSThuaID, string GiayChungNhanID)
        {
            BoHoSoModel bhs = (BoHoSoModel)Session["BoHoSo_" + CurrentUser.UserName];
            DCGIAYCHUNGNHANServices.addQuyenSDDTheoThuaDatVaoGCN(dSThuaID, GiayChungNhanID, bhs);
            Session["BoHoSo_" + CurrentUser.UserName] = bhs;
            return PartialView("_GiayChungNhan_Main_SDDAT", bhs);
        }

        [HttpPost]
        public ActionResult Add_DSSDDAT_RTABLE_MUCDICH(string[] dSMDSDID, string GiayChungNhanID)
        {
            BoHoSoModel bhs = (BoHoSoModel)Session["BoHoSo_" + CurrentUser.UserName];
            DCGIAYCHUNGNHANServices.addQuyenSDDTheoMDSDDatVaoGCN(dSMDSDID, GiayChungNhanID, bhs);
            Session["BoHoSo_" + CurrentUser.UserName] = bhs;
            return PartialView("_GiayChungNhan_Main_SDDAT", bhs);
        }

        [HttpPost]
        public ActionResult Add_DSQLDAT_RTABLE_THUA(string[] dSThuaID, string GiayChungNhanID)
        {
            BoHoSoModel bhs = (BoHoSoModel)Session["BoHoSo_" + CurrentUser.UserName];
            DCGIAYCHUNGNHANServices.addQuyenQLDTheoThuaDatVaoGCN(dSThuaID, GiayChungNhanID, bhs);
            Session["BoHoSo_" + CurrentUser.UserName] = bhs;
            return PartialView("_GiayChungNhan_Main_QLDAT", bhs);
        }

        [HttpPost]
        public ActionResult Add_DSQLDAT_RTABLE_MUCDICH(string[] dSMDSDID, string GiayChungNhanID)
        {
            BoHoSoModel bhs = (BoHoSoModel)Session["BoHoSo_" + CurrentUser.UserName];
            DCGIAYCHUNGNHANServices.addQuyenQLDTheoMDSDDatVaoGCN(dSMDSDID, GiayChungNhanID, bhs);
            Session["BoHoSo_" + CurrentUser.UserName] = bhs;
            return PartialView("_GiayChungNhan_Main_QLDAT", bhs);
        }

        [HttpPost]
        public ActionResult Add_DSSHTAISAN_RTABLE_THUA(string[] dSSHTaiSan, string GiayChungNhanID)
        {
            BoHoSoModel bhs = (BoHoSoModel)Session["BoHoSo_" + CurrentUser.UserName];
            DCGIAYCHUNGNHANServices.addQuyenSHTSVaoGCN(dSSHTaiSan, GiayChungNhanID, bhs);
            Session["BoHoSo_" + CurrentUser.UserName] = bhs;
            return PartialView("_GiayChungNhan_Main_SHTAISAN", bhs);
        }
    }
}