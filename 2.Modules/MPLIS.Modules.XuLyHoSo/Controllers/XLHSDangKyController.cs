using MPLIS.Libraries.Data.XuLyHoSo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MPLIS.Libraries.Services.XuLyHoSo.Classes;
using AppCore.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using AutoMapper;
using System.Collections;
using MPLIS.Web.FrameWork.Base;
using System.Data.Entity;
using MPLIS.Libraries.Data.XuLyHoSo.Models.XuLyHoSo.DangKy;

namespace MPLIS.Modules.XuLyHoSo.Controllers
{
    [SessionState(System.Web.SessionState.SessionStateBehavior.ReadOnly)]
    public class XLHSDangKyController : BaseController
    {

        #region Chủ trong đăng ký HieuVH2
        [HttpPost]
        public ActionResult Form_DanhSachChu()
        {
            BoHoSoModel bhs = (BoHoSoModel)Session["BoHoSo_" + CurrentUser.UserName];
            DSChuDonVM dSChuDonVM = new DSChuDonVM();
            foreach (var temp in bhs.HoSoTN.DonDangKy.DSDangKyChu)
                dSChuDonVM.DSDangKyChu.Add(Mapper.Map<DC_DANGKY_NGUOI, ChuDonVM>(temp));
            ViewBag.dSLoaiChu = DONDANGKYServices.GetDM_LOAICHU();
            return PartialView(dSChuDonVM);
        }
        [HttpPost]
        public ActionResult DanhSachChu_XoaChu(string dangKyNguoiID)
        {
            BoHoSoModel bhs = (BoHoSoModel)Session["BoHoSo_" + CurrentUser.UserName];
            List<DC_DANGKY_NGUOI> dSDangKyChu = bhs.HoSoTN.DonDangKy.DSDangKyChu;
            bool success = false;
            string mes = "";
            if (DCDANGKYNGUOIServices.XoaChuTrongDangKy(dangKyNguoiID, dSDangKyChu, out mes))
            {
                success = true;
                Session["dSDangKyChu" + CurrentUser.UserName] = dSDangKyChu;
            }
            return Json(new { success = success, mes = mes });
        }
        [HttpPost]
        public ActionResult DanhSachChu_ThemMoiChu(string loaiChuID)
        {
            BoHoSoModel bhs = (BoHoSoModel)Session["BoHoSo_" + CurrentUser.UserName];
            bhs.HoSoTN.DonDangKy.CurDangKyNguoi = new DC_DANGKY_NGUOI();
            DC_DANGKY_NGUOI dangKyNguoi = bhs.HoSoTN.DonDangKy.CurDangKyNguoi;
            dangKyNguoi.TRANGTHAI = 1;
            dangKyNguoi.DANGKYNGUOIID = Guid.NewGuid().ToString();
            dangKyNguoi.DONDANGKYID = bhs.HoSoTN.DonDangKy.DONDANGKYID;
            dangKyNguoi.ThemMoiChu(loaiChuID);
            DangKy_NguoiLS dangKyNguoiLS = Mapper.Map<DC_DANGKY_NGUOI, DangKy_NguoiLS>(dangKyNguoi);
            ViewBag.dSGioiTinh = DONDANGKYServices.GetDM_GIOITINH();
            ViewBag.dSDanToc = DONDANGKYServices.GetDM_DANTOC();
            ViewBag.dSQuocTich = DONDANGKYServices.GetDM_QUOCTICH();
            ViewBag.dSGiayToTuyThan = DONDANGKYServices.GetDM_LOAIGIAYTOTUYTHAN();
            ViewBag.dSDoiTuongSuDung = DONDANGKYServices.GetDM_DOITUONGSUDUNG(dangKyNguoi.LOAI ?? 0M);
            ViewBag.dSLoaiChuNhomNguoi = DONDANGKYServices.GetDM_LOAICHUNHOMNGUOI();
            Session["BoHoSo_" + CurrentUser.UserName] = bhs;
            return PartialView("DanhSachChu_ChiTietChu", dangKyNguoiLS);
        }
        [HttpPost]
        public ActionResult DanhSachChu_ChiTietChu(string dangKyNguoiID)
        {
            BoHoSoModel bhs = (BoHoSoModel)Session["BoHoSo_" + CurrentUser.UserName];
            List<DC_DANGKY_NGUOI> dSDangKyChu = bhs.HoSoTN.DonDangKy.DSDangKyChu;
            bhs.HoSoTN.DonDangKy.CurDangKyNguoi = null;
            foreach (var temp in dSDangKyChu)
            {
                if (temp.DANGKYNGUOIID == dangKyNguoiID)
                {
                    temp.TRANGTHAI = 2;
                    temp.Chu.TRANGTHAI = 2;
                    bhs.HoSoTN.DonDangKy.CurDangKyNguoi = Mapper.Map<DC_DANGKY_NGUOI, DC_DANGKY_NGUOI>(temp);
                    break;
                }
            }
            DangKy_NguoiLS dangKyNguoiLS = Mapper.Map<DC_DANGKY_NGUOI, DangKy_NguoiLS>(bhs.HoSoTN.DonDangKy.CurDangKyNguoi);
            ViewBag.dSGioiTinh = DONDANGKYServices.GetDM_GIOITINH();
            ViewBag.dSDanToc = DONDANGKYServices.GetDM_DANTOC();
            ViewBag.dSQuocTich = DONDANGKYServices.GetDM_QUOCTICH();
            ViewBag.dSGiayToTuyThan = DONDANGKYServices.GetDM_LOAIGIAYTOTUYTHAN();
            ViewBag.dSDoiTuongSuDung = DONDANGKYServices.GetDM_DOITUONGSUDUNG(bhs.HoSoTN.DonDangKy.CurDangKyNguoi.LOAI ?? 0M);
            ViewBag.dSLoaiChuNhomNguoi = DONDANGKYServices.GetDM_LOAICHUNHOMNGUOI();
            Session["BoHoSo_" + CurrentUser.UserName] = bhs;
            return PartialView(dangKyNguoiLS);
        }
        [HttpPost]
        public ActionResult ChiTietChu_XoaTrang()
        {
            BoHoSoModel bhs = (BoHoSoModel)Session["BoHoSo_" + CurrentUser.UserName];
            string curLoaiChuID = bhs.HoSoTN.DonDangKy.CurDangKyNguoi.Chu.LOAIDOITUONGID;
            bhs.HoSoTN.DonDangKy.CurDangKyNguoi = null;
            bhs.HoSoTN.DonDangKy.CurDangKyNguoi = new DC_DANGKY_NGUOI();
            DC_DANGKY_NGUOI dangKyNguoi = bhs.HoSoTN.DonDangKy.CurDangKyNguoi;
            dangKyNguoi.TRANGTHAI = 1;
            dangKyNguoi.DANGKYNGUOIID = Guid.NewGuid().ToString();
            dangKyNguoi.DONDANGKYID = bhs.HoSoTN.DonDangKy.DONDANGKYID;
            dangKyNguoi.ThemMoiChu(curLoaiChuID);
            DangKy_NguoiLS dangKyNguoiLS = Mapper.Map<DC_DANGKY_NGUOI, DangKy_NguoiLS>(dangKyNguoi);
            ViewBag.dSGioiTinh = DONDANGKYServices.GetDM_GIOITINH();
            ViewBag.dSDanToc = DONDANGKYServices.GetDM_DANTOC();
            ViewBag.dSQuocTich = DONDANGKYServices.GetDM_QUOCTICH();
            ViewBag.dSGiayToTuyThan = DONDANGKYServices.GetDM_LOAIGIAYTOTUYTHAN();
            ViewBag.dSDoiTuongSuDung = DONDANGKYServices.GetDM_DOITUONGSUDUNG(dangKyNguoi.LOAI ?? 0M);
            ViewBag.dSLoaiChuNhomNguoi = DONDANGKYServices.GetDM_LOAICHUNHOMNGUOI();
            Session["BoHoSo_" + CurrentUser.UserName] = bhs;
            return PartialView("DanhSachChu_ChiTietChu", dangKyNguoiLS);
        }
        [HttpPost]
        public ActionResult Save_FormChiTietChu(string data)
        {
            bool success = false;
            string mes = "";
            BoHoSoModel bhs = (BoHoSoModel)Session["BoHoSo_" + CurrentUser.UserName];
            List<DC_DANGKY_NGUOI> dSDangKyNguoi = bhs.HoSoTN.DonDangKy.DSDangKyChu;
            DC_DANGKY_NGUOI dangKyNguoi = bhs.HoSoTN.DonDangKy.CurDangKyNguoi;
            NguoiLS nguoiLS = JsonConvert.DeserializeObject<NguoiLS>(data);
            DC_NGUOI nguoi = Mapper.Map<NguoiLS, DC_NGUOI>(nguoiLS);
            switch (dangKyNguoi.Chu.LOAIDOITUONGID)
            {
                case "1":
                    dangKyNguoi.Chu = nguoi;
                    dangKyNguoi.Chu.CaNhan = nguoi.CaNhan;
                    break;
                case "2":
                    nguoi.HoGiaDinh.DSThanhVien = Mapper.Map<List<DC_HOGIADINH_THANHVIEN>, List<DC_HOGIADINH_THANHVIEN>>(dangKyNguoi.Chu.HoGiaDinh.DSThanhVien);
                    dangKyNguoi.Chu = nguoi;
                    dangKyNguoi.Chu.HoGiaDinh.SetThongTinHoGiaDinh();
                    break;
                case "3":
                    nguoi.VoChong.ChongCN = dangKyNguoi.Chu.VoChong.ChongCN;
                    nguoi.VoChong.VoCN = dangKyNguoi.Chu.VoChong.VoCN;
                    dangKyNguoi.Chu = nguoi;
                    break;
                case "4":
                    nguoi.ToChuc.NguoiDaiDien = dangKyNguoi.Chu.ToChuc.NguoiDaiDien;
                    dangKyNguoi.Chu = nguoi;
                    break;
                case "5":
                    nguoi.CongDong.NguoiDaiDien = dangKyNguoi.Chu.CongDong.NguoiDaiDien;
                    dangKyNguoi.Chu = nguoi;
                    break;
                case "6":
                    nguoi.NhomNguoi.DSThanhVien = dangKyNguoi.Chu.NhomNguoi.DSThanhVien;
                    dangKyNguoi.Chu = nguoi;
                    break;
                default:
                    break;
            }
            success = DCDANGKYNGUOIServices.SaveDangKyNguoi(dangKyNguoi, dSDangKyNguoi, out mes);
            Session["BoHoSo_" + CurrentUser.UserName] = bhs;
            return Json(new { success = success, mes = mes, obj = new { LOAI = dangKyNguoi.LOAI, DANGKYNGUOIID = dangKyNguoi.DANGKYNGUOIID, TENLOAICHU = dangKyNguoi.Chu_TenLoaiChu, TENCHU = dangKyNguoi.Chu_HoTen, CMT = dangKyNguoi.Chu_CMT } });
        }
        #region Hộ Gia Đình
        [HttpPost]
        public ActionResult HoGiaDinh_ThemMoiThanhVien()
        {
            BoHoSoModel bhs = (BoHoSoModel)Session["BoHoSo_" + CurrentUser.UserName];
            DC_HOGIADINH hoGiaDinh = bhs.HoSoTN.DonDangKy.CurDangKyNguoi.Chu.HoGiaDinh;
            hoGiaDinh.CurHGDThanhVien = null;
            hoGiaDinh.CurHGDThanhVien = new DC_HOGIADINH_THANHVIEN();
            DC_HOGIADINH_THANHVIEN hoGiaDinhThanhVien = hoGiaDinh.CurHGDThanhVien;
            hoGiaDinhThanhVien.HOGIADINHTVID = Guid.NewGuid().ToString();
            hoGiaDinhThanhVien.TRANGTHAI = 1;
            hoGiaDinhThanhVien.ThanhVien = new DC_CANHAN();
            DC_CANHAN thanhVien = hoGiaDinhThanhVien.ThanhVien;
            thanhVien.CANHANID = Guid.NewGuid().ToString();
            thanhVien.TRANGTHAI = 1;
            hoGiaDinhThanhVien.CANHANID = thanhVien.CANHANID;
            hoGiaDinhThanhVien.HOGIADINHID = hoGiaDinh.HOGIADINHID;
            ViewBag.dSGioiTinh = DONDANGKYServices.GetDM_GIOITINH();
            ViewBag.dSDanToc = DONDANGKYServices.GetDM_DANTOC();
            ViewBag.dSQuocTich = DONDANGKYServices.GetDM_QUOCTICH();
            ViewBag.dSGiayToTuyThan = DONDANGKYServices.GetDM_LOAIGIAYTOTUYTHAN();
            ViewBag.dSQuanHe = DONDANGKYServices.GetDM_QHVOICHUHO();
            Session["BoHoSo_" + CurrentUser.UserName] = bhs;
            return PartialView("HoGiaDinh_ChiTietThanhVien", Mapper.Map<DC_HOGIADINH_THANHVIEN, HoGiaDinhThanhVienLS>(hoGiaDinhThanhVien));
        }
        [HttpPost]
        public ActionResult HoGiaDinh_ChiTietThanhVien(string hoGiaDinhTVID)
        {
            BoHoSoModel bhs = (BoHoSoModel)Session["BoHoSo_" + CurrentUser.UserName];
            DC_HOGIADINH hoGiaDinh = bhs.HoSoTN.DonDangKy.CurDangKyNguoi.Chu.HoGiaDinh;
            foreach (var temp in hoGiaDinh.DSThanhVien)
            {
                if (temp.HOGIADINHTVID == hoGiaDinhTVID)
                {
                    temp.TRANGTHAI = 2;
                    hoGiaDinh.CurHGDThanhVien = Mapper.Map<DC_HOGIADINH_THANHVIEN, DC_HOGIADINH_THANHVIEN>(temp);
                    break;
                }
            }
            ViewBag.dSGioiTinh = DONDANGKYServices.GetDM_GIOITINH();
            ViewBag.dSDanToc = DONDANGKYServices.GetDM_DANTOC();
            ViewBag.dSQuocTich = DONDANGKYServices.GetDM_QUOCTICH();
            ViewBag.dSGiayToTuyThan = DONDANGKYServices.GetDM_LOAIGIAYTOTUYTHAN();
            ViewBag.dSQuanHe = DONDANGKYServices.GetDM_QHVOICHUHO();
            Session["BoHoSo_" + CurrentUser.UserName] = bhs;
            return PartialView("HoGiaDinh_ChiTietThanhVien", Mapper.Map<DC_HOGIADINH_THANHVIEN, HoGiaDinhThanhVienLS>(hoGiaDinh.CurHGDThanhVien));
        }
        [HttpPost]
        public ActionResult HoGiaDinh_XoaThanhVien(string hoGiaDinhTVID)
        {
            bool success = false;
            string mes = "";
            BoHoSoModel bhs = (BoHoSoModel)Session["BoHoSo_" + CurrentUser.UserName];
            DC_HOGIADINH hoGiaDinh = bhs.HoSoTN.DonDangKy.CurDangKyNguoi.Chu.HoGiaDinh;
            DC_HOGIADINH_THANHVIEN hoGiaDinhThanhVienTemp = null;
            foreach (var temp in hoGiaDinh.DSThanhVien)
            {
                if (temp.HOGIADINHTVID == hoGiaDinhTVID)
                {
                    hoGiaDinhThanhVienTemp = temp;
                    break;
                }
            }
            if (hoGiaDinhThanhVienTemp != null)
            {
                hoGiaDinh.DSThanhVien.Remove(hoGiaDinhThanhVienTemp);
                success = true;
                mes = "Xóa thành viên khỏi Hộ Gia Đình thành công!";
            }
            else
            {
                mes = "Dữ liệu gửi lên không tồn tại trong Session!";
            }
            Session["BoHoSo_" + CurrentUser.UserName] = bhs;
            return Json(new { success = success, mes = mes });
        }
        [HttpPost]
        public ActionResult Save_FormHGD_ChiTietTVID(string data)
        {
            bool success = false;
            string mes = "";
            BoHoSoModel bhs = (BoHoSoModel)Session["BoHoSo_" + CurrentUser.UserName];
            DC_HOGIADINH hoGiaDinh = bhs.HoSoTN.DonDangKy.CurDangKyNguoi.Chu.HoGiaDinh;
            HoGiaDinhThanhVienLS hoGiaDinhThanhVienLS = JsonConvert.DeserializeObject<HoGiaDinhThanhVienLS>(data);
            DC_HOGIADINH_THANHVIEN hoGiaDinhThanhVien = Mapper.Map<HoGiaDinhThanhVienLS, DC_HOGIADINH_THANHVIEN>(hoGiaDinhThanhVienLS);
            hoGiaDinhThanhVien.ThanhVien.setHoTen();
            if (hoGiaDinhThanhVien.TRANGTHAI == 2)
            {
                DC_HOGIADINH_THANHVIEN hoGiaDinhThanhVienTemp = null;
                foreach (var temp in hoGiaDinh.DSThanhVien)
                {
                    if (temp.HOGIADINHTVID == hoGiaDinhThanhVien.HOGIADINHTVID)
                    {
                        hoGiaDinhThanhVienTemp = temp;
                        break;
                    }
                }
                if (hoGiaDinhThanhVienTemp != null)
                {
                    hoGiaDinh.DSThanhVien.Remove(hoGiaDinhThanhVienTemp);
                    hoGiaDinh.DSThanhVien.Add(hoGiaDinhThanhVien);
                    success = true;
                    mes = "Cập nhật thông tin thành viên thành công!";
                }
                else
                {
                    mes = "Không tìm thấy dữ liệu được gửi lên trên Session?";
                }
            }
            else if (hoGiaDinhThanhVien.TRANGTHAI == 1)
            {
                hoGiaDinh.DSThanhVien.Add(hoGiaDinhThanhVien);
                hoGiaDinhThanhVien.TRANGTHAI = 2;
                mes = "Thêm mới thành viên vào Hộ Gia Đình thành công!";
                success = true;
            }
            if (success)
            {
                //ChuHo//Vo//Chong
                if (hoGiaDinhThanhVien.QHVOICHUHOID == "DBE8EB8DA18049ED8E253B2685769746")
                {
                    hoGiaDinh.ChuHoCN = hoGiaDinhThanhVien.ThanhVien;
                    hoGiaDinh.CMTCHUHO = hoGiaDinhThanhVien.ThanhVien.SOGIAYTO;
                    hoGiaDinhThanhVien.ThanhVien.setHoTen();
                    hoGiaDinh.CHUHO_HOTEN = hoGiaDinhThanhVien.ThanhVien.HOTEN;
                    hoGiaDinh.CHUHO = hoGiaDinhThanhVien.ThanhVien.CANHANID;
                    foreach (var temp in hoGiaDinh.DSThanhVien)
                    {
                        if (temp.HOGIADINHTVID != hoGiaDinhThanhVien.HOGIADINHTVID && temp.QHVOICHUHOID == hoGiaDinhThanhVien.QHVOICHUHOID)
                        {
                            temp.QHVOICHUHOID = "";
                        }
                    }
                }
                else if (hoGiaDinhThanhVien.QHVOICHUHOID == "CD487A3FFF9B45B3BAC998F80F68622C" || hoGiaDinhThanhVien.QHVOICHUHOID == "87D621F7C7004637BD871BAB0D97068D")
                {
                    hoGiaDinh.VoChongCN = hoGiaDinhThanhVien.ThanhVien;
                    hoGiaDinh.CMTVOCHONG = hoGiaDinhThanhVien.ThanhVien.SOGIAYTO;
                    hoGiaDinhThanhVien.ThanhVien.setHoTen();
                    hoGiaDinh.VOCHONG_HOTEN = hoGiaDinhThanhVien.ThanhVien.HOTEN;
                    hoGiaDinh.VOCHONG = hoGiaDinhThanhVien.ThanhVien.CANHANID;
                    foreach (var temp in hoGiaDinh.DSThanhVien)
                    {
                        if (temp.HOGIADINHTVID != hoGiaDinhThanhVien.HOGIADINHTVID && temp.QHVOICHUHOID == hoGiaDinhThanhVien.QHVOICHUHOID)
                        {
                            temp.QHVOICHUHOID = "";
                        }
                    }
                }
                Session["BoHoSo_" + CurrentUser.UserName] = bhs;
                return Json(new { success = success, mes = mes, obj = new { HOGIADINHTVID = hoGiaDinhThanhVien.HOGIADINHTVID, HOTEN = hoGiaDinhThanhVien.ThanhVien.HOTEN, SOGIAYTO = hoGiaDinhThanhVien.ThanhVien.SOGIAYTO, TenQuanHe = hoGiaDinhThanhVien.TenQuanHe } });
            }
            else
            {
                return Json(new { success = success, mes = mes });
            }
        }
        [HttpPost]
        public ActionResult HoGiaDinh_GetThongTin()
        {
            BoHoSoModel bhs = (BoHoSoModel)Session["BoHoSo_" + CurrentUser.UserName];
            DC_HOGIADINH hoGiaDinh = bhs.HoSoTN.DonDangKy.CurDangKyNguoi.Chu.HoGiaDinh;
            hoGiaDinh.SetThongTinHoGiaDinh();
            List<HoGiaDinhThanhVienDataTable> dSThanhVienHoGiaDinh = Mapper.Map<List<DC_HOGIADINH_THANHVIEN>, List<HoGiaDinhThanhVienDataTable>>(hoGiaDinh.DSThanhVien);
            Session["BoHoSo_" + CurrentUser.UserName] = bhs;
            return Json(new { HOGIADINHID = hoGiaDinh.HOGIADINHID, TRANGTHAI = hoGiaDinh.TRANGTHAI, CHUHO = hoGiaDinh.CHUHO, VOCHONG = hoGiaDinh.VOCHONG, CMTCHUHO = hoGiaDinh.CMTCHUHO, CHUHO_HOTEN = hoGiaDinh.CHUHO_HOTEN, CMTVOCHONG = hoGiaDinh.CMTVOCHONG, VOCHONG_HOTEN = hoGiaDinh.VOCHONG_HOTEN, dSThanhVienHoGiaDinh = dSThanhVienHoGiaDinh });
        }
        #endregion
        #region Vợ Chồng
        [HttpPost]
        public ActionResult VoChong_Chong()
        {
            BoHoSoModel bhs = (BoHoSoModel)Session["BoHoSo_" + CurrentUser.UserName];
            DC_VOCHONG voChong = bhs.HoSoTN.DonDangKy.CurDangKyNguoi.Chu.VoChong;
            if (voChong.ChongCN == null)
            {
                voChong.CurCaNhan = new DC_CANHAN();
                voChong.CurCaNhan.CANHANID = Guid.NewGuid().ToString();
                voChong.CurCaNhan.TRANGTHAI = 1;
            }
            else
            {
                voChong.CurCaNhan = Mapper.Map<DC_CANHAN, DC_CANHAN>(voChong.ChongCN);
            }
            VoChongLS voChongLS = Mapper.Map<DC_VOCHONG, VoChongLS>(voChong);
            ViewBag.dSGioiTinh = DONDANGKYServices.GetDM_GIOITINH();
            ViewBag.dSDanToc = DONDANGKYServices.GetDM_DANTOC();
            ViewBag.dSQuocTich = DONDANGKYServices.GetDM_QUOCTICH();
            ViewBag.dSGiayToTuyThan = DONDANGKYServices.GetDM_LOAIGIAYTOTUYTHAN();
            Session["BoHoSo_" + CurrentUser.UserName] = bhs;
            return PartialView(voChongLS);
        }
        [HttpPost]
        public ActionResult VoChong_Vo()
        {
            BoHoSoModel bhs = (BoHoSoModel)Session["BoHoSo_" + CurrentUser.UserName];
            DC_VOCHONG voChong = bhs.HoSoTN.DonDangKy.CurDangKyNguoi.Chu.VoChong;
            if (voChong.VoCN == null)
            {
                voChong.CurCaNhan = new DC_CANHAN();
                voChong.CurCaNhan.CANHANID = Guid.NewGuid().ToString();
                voChong.CurCaNhan.TRANGTHAI = 1;
            }
            else
            {
                voChong.CurCaNhan = Mapper.Map<DC_CANHAN, DC_CANHAN>(voChong.VoCN);
            }
            VoChongLS voChongLS = Mapper.Map<DC_VOCHONG, VoChongLS>(voChong);
            ViewBag.dSGioiTinh = DONDANGKYServices.GetDM_GIOITINH();
            ViewBag.dSDanToc = DONDANGKYServices.GetDM_DANTOC();
            ViewBag.dSQuocTich = DONDANGKYServices.GetDM_QUOCTICH();
            ViewBag.dSGiayToTuyThan = DONDANGKYServices.GetDM_LOAIGIAYTOTUYTHAN();
            Session["BoHoSo_" + CurrentUser.UserName] = bhs;
            return PartialView(voChongLS);
        }
        [HttpPost]
        public ActionResult Save_FormVoChong_ChiTietChongID(string data)
        {
            CaNhanLS caNhanLS = JsonConvert.DeserializeObject<CaNhanLS>(data);
            DC_CANHAN caNhan = Mapper.Map<CaNhanLS, DC_CANHAN>(caNhanLS);
            BoHoSoModel bhs = (BoHoSoModel)Session["BoHoSo_" + CurrentUser.UserName];
            DC_VOCHONG curVoChong = bhs.HoSoTN.DonDangKy.CurDangKyNguoi.Chu.VoChong;
            caNhan.setHoTen();
            curVoChong.ChongCN = caNhan;
            curVoChong.CHONG = caNhan.CANHANID;
            curVoChong.CMTCHONG = caNhan.SOGIAYTO;
            Session["BoHoSo_" + CurrentUser.UserName] = bhs;
            return PartialView("ChiTietChu_VoChong", Mapper.Map<DC_VOCHONG, VoChongLS>(curVoChong));
        }
        [HttpPost]
        public ActionResult Save_FormVoChong_ChiTietVoID(string data)
        {
            CaNhanLS caNhanLS = JsonConvert.DeserializeObject<CaNhanLS>(data);
            DC_CANHAN caNhan = Mapper.Map<CaNhanLS, DC_CANHAN>(caNhanLS);
            BoHoSoModel bhs = (BoHoSoModel)Session["BoHoSo_" + CurrentUser.UserName];
            DC_VOCHONG curVoChong = bhs.HoSoTN.DonDangKy.CurDangKyNguoi.Chu.VoChong;
            caNhan.setHoTen();
            curVoChong.VoCN = caNhan;
            curVoChong.VO = caNhan.CANHANID;
            curVoChong.CMTVO = caNhan.SOGIAYTO;
            Session["BoHoSo_" + CurrentUser.UserName] = bhs;
            return PartialView("ChiTietChu_VoChong", Mapper.Map<DC_VOCHONG, VoChongLS>(curVoChong));
        }
        [HttpPost]
        public ActionResult XoaTrang_FormVoChong_ChiTietChongID()
        {
            BoHoSoModel bhs = (BoHoSoModel)Session["BoHoSo_" + CurrentUser.UserName];
            DC_VOCHONG curVoChong = bhs.HoSoTN.DonDangKy.CurDangKyNguoi.Chu.VoChong;
            curVoChong.CurCaNhan = new DC_CANHAN();
            curVoChong.CurCaNhan.CANHANID = Guid.NewGuid().ToString();
            curVoChong.CurCaNhan.TRANGTHAI = 1;
            VoChongLS voChongLS = Mapper.Map<DC_VOCHONG, VoChongLS>(curVoChong);
            voChongLS.CHONG = null;
            ViewBag.dSGioiTinh = DONDANGKYServices.GetDM_GIOITINH();
            ViewBag.dSDanToc = DONDANGKYServices.GetDM_DANTOC();
            ViewBag.dSQuocTich = DONDANGKYServices.GetDM_QUOCTICH();
            ViewBag.dSGiayToTuyThan = DONDANGKYServices.GetDM_LOAIGIAYTOTUYTHAN();
            Session["BoHoSo_" + CurrentUser.UserName] = bhs;
            return PartialView("VoChong_Chong", voChongLS);
        }
        [HttpPost]
        public ActionResult XoaTrang_FormVoChong_ChiTietVoID()
        {
            BoHoSoModel bhs = (BoHoSoModel)Session["BoHoSo_" + CurrentUser.UserName];
            DC_VOCHONG curVoChong = bhs.HoSoTN.DonDangKy.CurDangKyNguoi.Chu.VoChong;
            curVoChong.CurCaNhan = new DC_CANHAN();
            curVoChong.CurCaNhan.CANHANID = Guid.NewGuid().ToString();
            curVoChong.CurCaNhan.TRANGTHAI = 1;
            VoChongLS voChongLS = Mapper.Map<DC_VOCHONG, VoChongLS>(curVoChong);
            voChongLS.VO = null;
            ViewBag.dSGioiTinh = DONDANGKYServices.GetDM_GIOITINH();
            ViewBag.dSDanToc = DONDANGKYServices.GetDM_DANTOC();
            ViewBag.dSQuocTich = DONDANGKYServices.GetDM_QUOCTICH();
            ViewBag.dSGiayToTuyThan = DONDANGKYServices.GetDM_LOAIGIAYTOTUYTHAN();
            Session["BoHoSo_" + CurrentUser.UserName] = bhs;
            return PartialView("VoChong_Vo", voChongLS);
        }
        [HttpPost]
        public ActionResult VoChong_XoaChong()
        {
            BoHoSoModel bhs = (BoHoSoModel)Session["BoHoSo_" + CurrentUser.UserName];
            DC_VOCHONG curVoChong = bhs.HoSoTN.DonDangKy.CurDangKyNguoi.Chu.VoChong;
            curVoChong.ChongCN = null;
            curVoChong.CHONG = null;
            curVoChong.CMTCHONG = "";
            Session["BoHoSo_" + CurrentUser.UserName] = bhs;
            return PartialView("ChiTietChu_VoChong", Mapper.Map<DC_VOCHONG, VoChongLS>(curVoChong));
        }
        [HttpPost]
        public ActionResult VoChong_XoaVo()
        {
            BoHoSoModel bhs = (BoHoSoModel)Session["BoHoSo_" + CurrentUser.UserName];
            DC_VOCHONG curVoChong = bhs.HoSoTN.DonDangKy.CurDangKyNguoi.Chu.VoChong;
            curVoChong.VoCN = null;
            curVoChong.VO = null;
            curVoChong.CMTVO = null;
            Session["BoHoSo_" + CurrentUser.UserName] = bhs;
            return PartialView("ChiTietChu_VoChong", Mapper.Map<DC_VOCHONG, VoChongLS>(curVoChong));
        }
        #endregion
        #region Tổ Chức
        [HttpPost]
        public ActionResult ToChuc_NguoiDaiDien()
        {
            BoHoSoModel bhs = (BoHoSoModel)Session["BoHoSo_" + CurrentUser.UserName];
            DC_TOCHUC toChuc = bhs.HoSoTN.DonDangKy.CurDangKyNguoi.Chu.ToChuc;
            if (toChuc.NguoiDaiDien == null)
            {
                toChuc.CurCaNhan = new DC_CANHAN();
                toChuc.CurCaNhan.CANHANID = Guid.NewGuid().ToString();
                toChuc.CurCaNhan.TRANGTHAI = 1;
            }
            else
            {
                toChuc.CurCaNhan = Mapper.Map<DC_CANHAN, DC_CANHAN>(toChuc.NguoiDaiDien);
            }
            ToChucLS toChucLS = Mapper.Map<DC_TOCHUC, ToChucLS>(toChuc);
            ViewBag.dSGioiTinh = DONDANGKYServices.GetDM_GIOITINH();
            ViewBag.dSDanToc = DONDANGKYServices.GetDM_DANTOC();
            ViewBag.dSQuocTich = DONDANGKYServices.GetDM_QUOCTICH();
            ViewBag.dSGiayToTuyThan = DONDANGKYServices.GetDM_LOAIGIAYTOTUYTHAN();
            Session["BoHoSo_" + CurrentUser.UserName] = bhs;
            return PartialView(toChucLS);
        }
        [HttpPost]
        public ActionResult XoaTrang_FormToChuc_ChiTietNguoiDaiDienID()
        {
            BoHoSoModel bhs = (BoHoSoModel)Session["BoHoSo_" + CurrentUser.UserName];
            DC_TOCHUC curToChuc = bhs.HoSoTN.DonDangKy.CurDangKyNguoi.Chu.ToChuc;
            curToChuc.CurCaNhan = new DC_CANHAN();
            curToChuc.CurCaNhan.CANHANID = Guid.NewGuid().ToString();
            curToChuc.CurCaNhan.TRANGTHAI = 1;
            ToChucLS toChucLS = Mapper.Map<DC_TOCHUC, ToChucLS>(curToChuc);
            toChucLS.NGUOIDAIDIENID = null;
            ViewBag.dSGioiTinh = DONDANGKYServices.GetDM_GIOITINH();
            ViewBag.dSDanToc = DONDANGKYServices.GetDM_DANTOC();
            ViewBag.dSQuocTich = DONDANGKYServices.GetDM_QUOCTICH();
            ViewBag.dSGiayToTuyThan = DONDANGKYServices.GetDM_LOAIGIAYTOTUYTHAN();
            Session["BoHoSo_" + CurrentUser.UserName] = bhs;
            return PartialView("ToChuc_NguoiDaiDien", toChucLS);
        }
        [HttpPost]
        public ActionResult Save_FormToChuc_ChiTietNguoiDaiDienID(string data)
        {
            CaNhanLS caNhanLS = JsonConvert.DeserializeObject<CaNhanLS>(data);
            DC_CANHAN caNhan = Mapper.Map<CaNhanLS, DC_CANHAN>(caNhanLS);
            BoHoSoModel bhs = (BoHoSoModel)Session["BoHoSo_" + CurrentUser.UserName];
            DC_TOCHUC curToChuc = bhs.HoSoTN.DonDangKy.CurDangKyNguoi.Chu.ToChuc;
            caNhan.setHoTen();
            curToChuc.NguoiDaiDien = caNhan;
            curToChuc.NGUOIDAIDIENID = caNhan.CANHANID;
            curToChuc.CMTNGUOIDAIDIEN = caNhan.SOGIAYTO;
            ViewBag.dSDoiTuongSuDung = DONDANGKYServices.GetDM_DOITUONGSUDUNG(bhs.HoSoTN.DonDangKy.CurDangKyNguoi.LOAI ?? 0M);
            Session["BoHoSo_" + CurrentUser.UserName] = bhs;
            return PartialView("ChiTietChu_ToChuc", Mapper.Map<DC_TOCHUC, ToChucLS>(curToChuc));
        }
        [HttpPost]
        public ActionResult ToChuc_XoaNguoiDaiDien()
        {
            BoHoSoModel bhs = (BoHoSoModel)Session["BoHoSo_" + CurrentUser.UserName];
            DC_TOCHUC curToChuc = bhs.HoSoTN.DonDangKy.CurDangKyNguoi.Chu.ToChuc;
            curToChuc.NguoiDaiDien = null;
            curToChuc.NGUOIDAIDIENID = null;
            curToChuc.CMTNGUOIDAIDIEN = null;
            ViewBag.dSDoiTuongSuDung = DONDANGKYServices.GetDM_DOITUONGSUDUNG(bhs.HoSoTN.DonDangKy.CurDangKyNguoi.LOAI ?? 0M);
            Session["BoHoSo_" + CurrentUser.UserName] = bhs;
            return PartialView("ChiTietChu_ToChuc", Mapper.Map<DC_TOCHUC, ToChucLS>(curToChuc));
        }
        #endregion
        #region Cộng Đồng
        [HttpPost]
        public ActionResult CongDong_NguoiDaiDien()
        {
            BoHoSoModel bhs = (BoHoSoModel)Session["BoHoSo_" + CurrentUser.UserName];
            DC_CONGDONG congDong = bhs.HoSoTN.DonDangKy.CurDangKyNguoi.Chu.CongDong;
            if (congDong.NguoiDaiDien == null)
            {
                congDong.CurCaNhan = new DC_CANHAN();
                congDong.CurCaNhan = new DC_CANHAN();
                congDong.CurCaNhan.CANHANID = Guid.NewGuid().ToString();
                congDong.CurCaNhan.TRANGTHAI = 1;
            }
            else
            {
                congDong.CurCaNhan = Mapper.Map<DC_CANHAN, DC_CANHAN>(congDong.NguoiDaiDien);
            }
            CongDongLS congDongLS = Mapper.Map<DC_CONGDONG, CongDongLS>(congDong);
            ViewBag.dSGioiTinh = DONDANGKYServices.GetDM_GIOITINH();
            ViewBag.dSDanToc = DONDANGKYServices.GetDM_DANTOC();
            ViewBag.dSQuocTich = DONDANGKYServices.GetDM_QUOCTICH();
            ViewBag.dSGiayToTuyThan = DONDANGKYServices.GetDM_LOAIGIAYTOTUYTHAN();
            Session["BoHoSo_" + CurrentUser.UserName] = bhs;
            return PartialView(congDongLS);
        }
        [HttpPost]
        public ActionResult XoaTrang_FormCongDong_ChiTietNguoiDaiDienID()
        {
            BoHoSoModel bhs = (BoHoSoModel)Session["BoHoSo_" + CurrentUser.UserName];
            DC_CONGDONG curCongDong = bhs.HoSoTN.DonDangKy.CurDangKyNguoi.Chu.CongDong;
            curCongDong.CurCaNhan = new DC_CANHAN();
            curCongDong.CurCaNhan.CANHANID = Guid.NewGuid().ToString();
            curCongDong.CurCaNhan.TRANGTHAI = 1;
            CongDongLS congDongLS = Mapper.Map<DC_CONGDONG, CongDongLS>(curCongDong);
            congDongLS.NGUOIDAIDIENID = null;
            ViewBag.dSGioiTinh = DONDANGKYServices.GetDM_GIOITINH();
            ViewBag.dSDanToc = DONDANGKYServices.GetDM_DANTOC();
            ViewBag.dSQuocTich = DONDANGKYServices.GetDM_QUOCTICH();
            ViewBag.dSGiayToTuyThan = DONDANGKYServices.GetDM_LOAIGIAYTOTUYTHAN();
            Session["BoHoSo_" + CurrentUser.UserName] = bhs;
            return PartialView("CongDong_NguoiDaiDien", congDongLS);
        }
        [HttpPost]
        public ActionResult Save_FormCongDong_ChiTietNguoiDaiDienID(string data)
        {
            CaNhanLS caNhanLS = JsonConvert.DeserializeObject<CaNhanLS>(data);
            DC_CANHAN caNhan = Mapper.Map<CaNhanLS, DC_CANHAN>(caNhanLS);
            BoHoSoModel bhs = (BoHoSoModel)Session["BoHoSo_" + CurrentUser.UserName];
            DC_CONGDONG curCongDong = bhs.HoSoTN.DonDangKy.CurDangKyNguoi.Chu.CongDong;
            caNhan.setHoTen();
            curCongDong.NguoiDaiDien = caNhan;
            curCongDong.NGUOIDAIDIENID = caNhan.CANHANID;
            curCongDong.CMTNGUOIDAIDIEN = caNhan.SOGIAYTO;
            ViewBag.dSDoiTuongSuDung = DONDANGKYServices.GetDM_DOITUONGSUDUNG(bhs.HoSoTN.DonDangKy.CurDangKyNguoi.LOAI ?? 0M);
            Session["BoHoSo_" + CurrentUser.UserName] = bhs;
            return PartialView("ChiTietChu_CongDong", Mapper.Map<DC_CONGDONG, CongDongLS>(curCongDong));
        }
        [HttpPost]
        public ActionResult CongDong_XoaNguoiDaiDien()
        {
            BoHoSoModel bhs = (BoHoSoModel)Session["BoHoSo_" + CurrentUser.UserName];
            DC_CONGDONG curCongDong = bhs.HoSoTN.DonDangKy.CurDangKyNguoi.Chu.CongDong;
            curCongDong.NguoiDaiDien = null;
            curCongDong.NGUOIDAIDIENID = null;
            curCongDong.CMTNGUOIDAIDIEN = null;
            ViewBag.dSDoiTuongSuDung = DONDANGKYServices.GetDM_DOITUONGSUDUNG(bhs.HoSoTN.DonDangKy.CurDangKyNguoi.LOAI ?? 0M);
            Session["BoHoSo_" + CurrentUser.UserName] = bhs;
            return PartialView("ChiTietChu_CongDong", Mapper.Map<DC_CONGDONG, CongDongLS>(curCongDong));
        }
        #endregion
        #region Nhóm Người
        [HttpPost]
        public ActionResult NhomNguoi_ThemMoiThanhVien(string loaiChuID)
        {
            BoHoSoModel bhs = (BoHoSoModel)Session["BoHoSo_" + CurrentUser.UserName];
            DC_NHOMNGUOI nhomNguoi = bhs.HoSoTN.DonDangKy.CurDangKyNguoi.Chu.NhomNguoi;
            nhomNguoi.CurNhomNguoiThanhVien = null;
            nhomNguoi.CurNhomNguoiThanhVien = new DC_NHOMNGUOI_THANHVIEN(loaiChuID);
            nhomNguoi.CurNhomNguoiThanhVien.NHOMNGUOIID = nhomNguoi.NHOMNGUOIID;
            NhomNguoiThanhVienLS nhomNguoiThanhVienLS = Mapper.Map<DC_NHOMNGUOI_THANHVIEN, NhomNguoiThanhVienLS>(nhomNguoi.CurNhomNguoiThanhVien);
            ViewBag.dSGioiTinh = DONDANGKYServices.GetDM_GIOITINH();
            ViewBag.dSDanToc = DONDANGKYServices.GetDM_DANTOC();
            ViewBag.dSQuocTich = DONDANGKYServices.GetDM_QUOCTICH();
            ViewBag.dSGiayToTuyThan = DONDANGKYServices.GetDM_LOAIGIAYTOTUYTHAN();
            ViewBag.dSQuanHe = DONDANGKYServices.GetDM_QHVOICHUHO();
            ViewBag.dSDoiTuongSuDung = DONDANGKYServices.GetDM_DOITUONGSUDUNG(4);
            ViewBag.dSVaiTroTVNN = DONDANGKYServices.GetDM_VAITRONN();
            Session["BoHoSo_" + CurrentUser.UserName] = bhs;
            return PartialView("NhomNguoi_ChiTietThanhVien", nhomNguoiThanhVienLS);
        }
        [HttpPost]
        public ActionResult NhomNguoi_ChiTietThanhVien(string nhomNguoiThanhVienID)
        {
            BoHoSoModel bhs = (BoHoSoModel)Session["BoHoSo_" + CurrentUser.UserName];
            DC_NHOMNGUOI nhomNguoi = bhs.HoSoTN.DonDangKy.CurDangKyNguoi.Chu.NhomNguoi;
            nhomNguoi.CurNhomNguoiThanhVien = null;
            foreach (var temp in nhomNguoi.DSThanhVien)
            {
                if (temp.NHOMNGUOITHANHVIENID == nhomNguoiThanhVienID)
                {
                    temp.TRANGTHAI = 2;
                    nhomNguoi.CurNhomNguoiThanhVien = Mapper.Map<DC_NHOMNGUOI_THANHVIEN, DC_NHOMNGUOI_THANHVIEN>(temp);
                    break;
                }
            }
            ViewBag.dSGioiTinh = DONDANGKYServices.GetDM_GIOITINH();
            ViewBag.dSDanToc = DONDANGKYServices.GetDM_DANTOC();
            ViewBag.dSQuocTich = DONDANGKYServices.GetDM_QUOCTICH();
            ViewBag.dSGiayToTuyThan = DONDANGKYServices.GetDM_LOAIGIAYTOTUYTHAN();
            ViewBag.dSQuanHe = DONDANGKYServices.GetDM_QHVOICHUHO();
            ViewBag.dSDoiTuongSuDung = DONDANGKYServices.GetDM_DOITUONGSUDUNG(4);
            ViewBag.dSVaiTroTVNN = DONDANGKYServices.GetDM_VAITRONN();
            Session["BoHoSo_" + CurrentUser.UserName] = bhs;
            return PartialView("NhomNguoi_ChiTietThanhVien", Mapper.Map<DC_NHOMNGUOI_THANHVIEN, NhomNguoiThanhVienLS>(nhomNguoi.CurNhomNguoiThanhVien));
        }
        [HttpPost]
        public ActionResult NhomNguoi_ChiTietThanhVien_XoaTrang()
        {
            BoHoSoModel bhs = (BoHoSoModel)Session["BoHoSo_" + CurrentUser.UserName];
            DC_NHOMNGUOI nhomNguoi = bhs.HoSoTN.DonDangKy.CurDangKyNguoi.Chu.NhomNguoi;
            string curLoaiChuID = nhomNguoi.CurNhomNguoiThanhVien.LOAIDOITUONG;
            nhomNguoi.CurNhomNguoiThanhVien = null;
            nhomNguoi.CurNhomNguoiThanhVien = new DC_NHOMNGUOI_THANHVIEN(curLoaiChuID);
            NhomNguoiThanhVienLS nhomNguoiThanhVienLS = Mapper.Map<DC_NHOMNGUOI_THANHVIEN, NhomNguoiThanhVienLS>(nhomNguoi.CurNhomNguoiThanhVien);
            ViewBag.dSGioiTinh = DONDANGKYServices.GetDM_GIOITINH();
            ViewBag.dSDanToc = DONDANGKYServices.GetDM_DANTOC();
            ViewBag.dSQuocTich = DONDANGKYServices.GetDM_QUOCTICH();
            ViewBag.dSGiayToTuyThan = DONDANGKYServices.GetDM_LOAIGIAYTOTUYTHAN();
            ViewBag.dSQuanHe = DONDANGKYServices.GetDM_QHVOICHUHO();
            ViewBag.dSDoiTuongSuDung = DONDANGKYServices.GetDM_DOITUONGSUDUNG(4);
            ViewBag.dSVaiTroTVNN = DONDANGKYServices.GetDM_VAITRONN();
            Session["BoHoSo_" + CurrentUser.UserName] = bhs;
            return PartialView("NhomNguoi_ChiTietThanhVien", nhomNguoiThanhVienLS);
        }
        [HttpPost]
        public ActionResult NhomNguoi_XoaThanhVien(string nhomNguoiThanhVienID)
        {
            bool success = false;
            string mes = "";
            BoHoSoModel bhs = (BoHoSoModel)Session["BoHoSo_" + CurrentUser.UserName];
            DC_NHOMNGUOI nhomNguoi = bhs.HoSoTN.DonDangKy.CurDangKyNguoi.Chu.NhomNguoi;
            DC_NHOMNGUOI_THANHVIEN nhomNguoiThanhVienTemp = null;
            foreach (var temp in nhomNguoi.DSThanhVien)
            {
                if (temp.NHOMNGUOITHANHVIENID == nhomNguoiThanhVienID)
                {
                    nhomNguoiThanhVienTemp = temp;
                    break;
                }
            }
            if (nhomNguoiThanhVienTemp != null)
            {
                nhomNguoi.DSThanhVien.Remove(nhomNguoiThanhVienTemp);
                success = true;
                mes = "Xóa thành viên khỏi Nhóm Người thành công!";
            }
            else
            {
                mes = "Dữ liệu gửi lên không tồn tại trong Session!";
            }
            Session["BoHoSo_" + CurrentUser.UserName] = bhs;
            return Json(new { success = success, mes = mes });
        }
        [HttpPost]
        public ActionResult Save_FormNN_ChiTietThanhVienID(string data)
        {
            NhomNguoiThanhVienLS nhomNguoiThanhVienLS = JsonConvert.DeserializeObject<NhomNguoiThanhVienLS>(data);
            DC_NHOMNGUOI_THANHVIEN nhomNguoiThanhVien = Mapper.Map<NhomNguoiThanhVienLS, DC_NHOMNGUOI_THANHVIEN>(nhomNguoiThanhVienLS);
            BoHoSoModel bhs = (BoHoSoModel)Session["BoHoSo_" + CurrentUser.UserName];
            DC_NHOMNGUOI nhomNguoi = bhs.HoSoTN.DonDangKy.CurDangKyNguoi.Chu.NhomNguoi;
            DC_NHOMNGUOI_THANHVIEN curNhomNguoiThanhVien = nhomNguoi.CurNhomNguoiThanhVien;
            string mes = "";
            if (nhomNguoiThanhVien.TRANGTHAI == 1)
            {
                mes += "Thêm mới thành viên ";
            }
            else if (nhomNguoiThanhVien.TRANGTHAI == 2)
            {
                mes += "Cập nhật thành viên ";
            }
            switch (curNhomNguoiThanhVien.LOAIDOITUONG)
            {
                case "1":
                    curNhomNguoiThanhVien = nhomNguoiThanhVien;
                    mes += "Cá Nhân ";
                    break;
                case "2":
                    nhomNguoiThanhVien.ThanhVienHoGiaDinh.ChuHoCN = curNhomNguoiThanhVien.ThanhVienHoGiaDinh.ChuHoCN;
                    nhomNguoiThanhVien.ThanhVienHoGiaDinh.DSThanhVien = curNhomNguoiThanhVien.ThanhVienHoGiaDinh.DSThanhVien;
                    curNhomNguoiThanhVien = nhomNguoiThanhVien;
                    mes += "Hộ Gia Đình ";
                    break;
                case "3":
                    nhomNguoiThanhVien.ThanhVienVoChong.ChongCN = curNhomNguoiThanhVien.ThanhVienVoChong.ChongCN;
                    nhomNguoiThanhVien.ThanhVienVoChong.VoCN = curNhomNguoiThanhVien.ThanhVienVoChong.VoCN;
                    curNhomNguoiThanhVien = nhomNguoiThanhVien;
                    mes += "Vợ Chồng ";
                    break;
                case "4":
                    nhomNguoiThanhVien.ThanhVienToChuc.NguoiDaiDien = curNhomNguoiThanhVien.ThanhVienToChuc.NguoiDaiDien;
                    curNhomNguoiThanhVien = nhomNguoiThanhVien;
                    mes += "Tổ Chức ";
                    break;
                case "5":
                    nhomNguoiThanhVien.ThanhVienCongDong.NguoiDaiDien = curNhomNguoiThanhVien.ThanhVienCongDong.NguoiDaiDien;
                    curNhomNguoiThanhVien = nhomNguoiThanhVien;
                    mes += "Cộng Đồng ";
                    break;
            }
            mes += "thành công!";
            if (curNhomNguoiThanhVien.ISNGUOIDAIDIEN == 1)
            {
                foreach (var temp in nhomNguoi.DSThanhVien)
                {
                    temp.ISNGUOIDAIDIEN = 0;
                }
            }
            DC_NHOMNGUOI_THANHVIEN nhomNguoiThanhVienTemp = null;
            foreach (var temp in nhomNguoi.DSThanhVien)
            {
                if (temp.NHOMNGUOITHANHVIENID == nhomNguoiThanhVien.NHOMNGUOITHANHVIENID)
                {
                    nhomNguoiThanhVienTemp = temp;
                    break;
                }
            }
            if (nhomNguoiThanhVienTemp != null)
                nhomNguoi.DSThanhVien.Remove(nhomNguoiThanhVienTemp);
            nhomNguoi.DSThanhVien.Add(curNhomNguoiThanhVien);
            Session["BoHoSo_" + CurrentUser.UserName] = bhs;
            return Json(new { success = true, mes = mes });
        }
        [HttpPost]
        public ActionResult NhomNguoi_GetThongTin()
        {
            BoHoSoModel bhs = (BoHoSoModel)Session["BoHoSo_" + CurrentUser.UserName];
            DC_NHOMNGUOI nhomNguoi = bhs.HoSoTN.DonDangKy.CurDangKyNguoi.Chu.NhomNguoi;
            nhomNguoi.NhomNguoiSetThongTin();
            List<NhomNguoiThanhVienDataTable> dSNhomNguoiThanhVien = Mapper.Map<List<DC_NHOMNGUOI_THANHVIEN>, List<NhomNguoiThanhVienDataTable>>(nhomNguoi.DSThanhVien);
            Session["BoHoSo_" + CurrentUser.UserName] = bhs;
            return Json(new { NHOMNGUOIID = nhomNguoi.NHOMNGUOIID, TRANGTHAI = nhomNguoi.TRANGTHAI, NGUOIDAIDIEN = nhomNguoi.NGUOIDAIDIEN, CMTNGUOIDAIDIEN = nhomNguoi.CMTNGUOIDAIDIEN, HoTenNguoiDaiDien = nhomNguoi.HoTenNguoiDaiDien, dSNhomNguoiThanhVien = dSNhomNguoiThanhVien });
        }
        #region NhomNguoi_HoGiaDinh
        [HttpPost]
        public ActionResult NhomNguoi_HoGiaDinh_ThemMoiThanhVien()
        {
            BoHoSoModel bhs = (BoHoSoModel)Session["BoHoSo_" + CurrentUser.UserName];
            DC_NHOMNGUOI nhomNguoi = bhs.HoSoTN.DonDangKy.CurDangKyNguoi.Chu.NhomNguoi;
            DC_HOGIADINH hoGiaDinh = nhomNguoi.CurNhomNguoiThanhVien.ThanhVienHoGiaDinh;
            hoGiaDinh.CurHGDThanhVien = null;
            hoGiaDinh.CurHGDThanhVien = new DC_HOGIADINH_THANHVIEN();
            DC_HOGIADINH_THANHVIEN hoGiaDinhThanhVien = hoGiaDinh.CurHGDThanhVien;
            hoGiaDinhThanhVien.HOGIADINHTVID = Guid.NewGuid().ToString();
            hoGiaDinhThanhVien.TRANGTHAI = 1;
            hoGiaDinhThanhVien.ThanhVien = new DC_CANHAN();
            DC_CANHAN thanhVien = hoGiaDinhThanhVien.ThanhVien;
            thanhVien.CANHANID = Guid.NewGuid().ToString();
            thanhVien.TRANGTHAI = 1;
            hoGiaDinhThanhVien.CANHANID = thanhVien.CANHANID;
            hoGiaDinhThanhVien.HOGIADINHID = hoGiaDinh.HOGIADINHID;
            ViewBag.dSGioiTinh = DONDANGKYServices.GetDM_GIOITINH();
            ViewBag.dSDanToc = DONDANGKYServices.GetDM_DANTOC();
            ViewBag.dSQuocTich = DONDANGKYServices.GetDM_QUOCTICH();
            ViewBag.dSGiayToTuyThan = DONDANGKYServices.GetDM_LOAIGIAYTOTUYTHAN();
            ViewBag.dSQuanHe = DONDANGKYServices.GetDM_QHVOICHUHO();
            Session["BoHoSo_" + CurrentUser.UserName] = bhs;
            return PartialView("NhomNguoi_HGD_ChiTietThanhVien", Mapper.Map<DC_HOGIADINH_THANHVIEN, HoGiaDinhThanhVienLS>(hoGiaDinhThanhVien));
        }
        [HttpPost]
        public ActionResult NhomNguoi_HoGiaDinh_ChiTietThanhVien(string hoGiaDinhTVID)
        {
            BoHoSoModel bhs = (BoHoSoModel)Session["BoHoSo_" + CurrentUser.UserName];
            DC_NHOMNGUOI nhomNguoi = bhs.HoSoTN.DonDangKy.CurDangKyNguoi.Chu.NhomNguoi;
            DC_HOGIADINH hoGiaDinh = nhomNguoi.CurNhomNguoiThanhVien.ThanhVienHoGiaDinh;
            foreach (var temp in hoGiaDinh.DSThanhVien)
            {
                if (temp.HOGIADINHTVID == hoGiaDinhTVID)
                {
                    temp.TRANGTHAI = 2;
                    hoGiaDinh.CurHGDThanhVien = Mapper.Map<DC_HOGIADINH_THANHVIEN, DC_HOGIADINH_THANHVIEN>(temp);
                    break;
                }
            }
            ViewBag.dSGioiTinh = DONDANGKYServices.GetDM_GIOITINH();
            ViewBag.dSDanToc = DONDANGKYServices.GetDM_DANTOC();
            ViewBag.dSQuocTich = DONDANGKYServices.GetDM_QUOCTICH();
            ViewBag.dSGiayToTuyThan = DONDANGKYServices.GetDM_LOAIGIAYTOTUYTHAN();
            ViewBag.dSQuanHe = DONDANGKYServices.GetDM_QHVOICHUHO();
            return PartialView("NhomNguoi_HGD_ChiTietThanhVien", Mapper.Map<DC_HOGIADINH_THANHVIEN, HoGiaDinhThanhVienLS>(hoGiaDinh.CurHGDThanhVien));
        }
        [HttpPost]
        public ActionResult NhomNguoi_HoGiaDinh_XoaThanhVien(string hoGiaDinhTVID)
        {
            bool success = false;
            string mes = "";
            BoHoSoModel bhs = (BoHoSoModel)Session["BoHoSo_" + CurrentUser.UserName];
            DC_NHOMNGUOI nhomNguoi = bhs.HoSoTN.DonDangKy.CurDangKyNguoi.Chu.NhomNguoi;
            DC_HOGIADINH hoGiaDinh = nhomNguoi.CurNhomNguoiThanhVien.ThanhVienHoGiaDinh;
            DC_HOGIADINH_THANHVIEN hoGiaDinhThanhVienTemp = null;
            foreach (var temp in hoGiaDinh.DSThanhVien)
            {
                if (temp.HOGIADINHTVID == hoGiaDinhTVID)
                {
                    hoGiaDinhThanhVienTemp = temp;
                    break;
                }
            }
            if (hoGiaDinhThanhVienTemp != null)
            {
                hoGiaDinh.DSThanhVien.Remove(hoGiaDinhThanhVienTemp);
                success = true;
                mes = "Xóa thành viên khỏi Hộ Gia Đình thành công!";
            }
            else
            {
                mes = "Dữ liệu gửi lên không tồn tại trong Session!";
            }
            Session["BoHoSo_" + CurrentUser.UserName] = bhs;
            return Json(new { success = success, mes = mes });
        }
        [HttpPost]
        public ActionResult NhomNguoi_Save_FormHGD_ChiTietTVID(string data)
        {
            bool success = false;
            string mes = "";
            BoHoSoModel bhs = (BoHoSoModel)Session["BoHoSo_" + CurrentUser.UserName];
            DC_NHOMNGUOI nhomNguoi = bhs.HoSoTN.DonDangKy.CurDangKyNguoi.Chu.NhomNguoi;
            DC_HOGIADINH hoGiaDinh = nhomNguoi.CurNhomNguoiThanhVien.ThanhVienHoGiaDinh;
            HoGiaDinhThanhVienLS hoGiaDinhThanhVienLS = JsonConvert.DeserializeObject<HoGiaDinhThanhVienLS>(data);
            DC_HOGIADINH_THANHVIEN hoGiaDinhThanhVien = Mapper.Map<HoGiaDinhThanhVienLS, DC_HOGIADINH_THANHVIEN>(hoGiaDinhThanhVienLS);
            hoGiaDinhThanhVien.ThanhVien.setHoTen();
            if (hoGiaDinhThanhVien.TRANGTHAI == 2)
            {
                DC_HOGIADINH_THANHVIEN hoGiaDinhThanhVienTemp = null;
                foreach (var temp in hoGiaDinh.DSThanhVien)
                {
                    if (temp.HOGIADINHTVID == hoGiaDinhThanhVien.HOGIADINHTVID)
                    {
                        hoGiaDinhThanhVienTemp = temp;
                        break;
                    }
                }
                if (hoGiaDinhThanhVienTemp != null)
                {
                    hoGiaDinh.DSThanhVien.Remove(hoGiaDinhThanhVienTemp);
                    hoGiaDinh.DSThanhVien.Add(hoGiaDinhThanhVien);
                    success = true;
                    mes = "Cập nhật thông tin thành viên thành công!";
                }
                else
                {
                    mes = "Không tìm thấy dữ liệu được gửi lên trên Session?";
                }
            }
            else if (hoGiaDinhThanhVien.TRANGTHAI == 1)
            {
                hoGiaDinh.DSThanhVien.Add(hoGiaDinhThanhVien);
                hoGiaDinhThanhVien.TRANGTHAI = 2;
                mes = "Thêm mới thành viên vào Hộ Gia Đình thành công!";
                success = true;
            }
            if (success)
            {
                //ChuHo//Vo//Chong
                if (hoGiaDinhThanhVien.QHVOICHUHOID == "DBE8EB8DA18049ED8E253B2685769746")
                {
                    hoGiaDinh.ChuHoCN = hoGiaDinhThanhVien.ThanhVien;
                    hoGiaDinh.CMTCHUHO = hoGiaDinhThanhVien.ThanhVien.SOGIAYTO;
                    hoGiaDinhThanhVien.ThanhVien.setHoTen();
                    hoGiaDinh.CHUHO_HOTEN = hoGiaDinhThanhVien.ThanhVien.HOTEN;
                    hoGiaDinh.CHUHO = hoGiaDinhThanhVien.ThanhVien.CANHANID;
                    foreach (var temp in hoGiaDinh.DSThanhVien)
                    {
                        if (temp.HOGIADINHTVID != hoGiaDinhThanhVien.HOGIADINHTVID && temp.QHVOICHUHOID == hoGiaDinhThanhVien.QHVOICHUHOID)
                        {
                            temp.QHVOICHUHOID = "";
                        }
                    }
                }
                else if (hoGiaDinhThanhVien.QHVOICHUHOID == "CD487A3FFF9B45B3BAC998F80F68622C" || hoGiaDinhThanhVien.QHVOICHUHOID == "87D621F7C7004637BD871BAB0D97068D")
                {
                    hoGiaDinh.VoChongCN = hoGiaDinhThanhVien.ThanhVien;
                    hoGiaDinh.CMTVOCHONG = hoGiaDinhThanhVien.ThanhVien.SOGIAYTO;
                    hoGiaDinhThanhVien.ThanhVien.setHoTen();
                    hoGiaDinh.VOCHONG_HOTEN = hoGiaDinhThanhVien.ThanhVien.HOTEN;
                    hoGiaDinh.VOCHONG = hoGiaDinhThanhVien.ThanhVien.CANHANID;
                    foreach (var temp in hoGiaDinh.DSThanhVien)
                    {
                        if (temp.HOGIADINHTVID != hoGiaDinhThanhVien.HOGIADINHTVID && temp.QHVOICHUHOID == hoGiaDinhThanhVien.QHVOICHUHOID)
                        {
                            temp.QHVOICHUHOID = "";
                        }
                    }
                }
                Session["BoHoSo_" + CurrentUser.UserName] = bhs;
                return Json(new { success = success, mes = mes, obj = new { HOGIADINHTVID = hoGiaDinhThanhVien.HOGIADINHTVID, HOTEN = hoGiaDinhThanhVien.ThanhVien.HOTEN, SOGIAYTO = hoGiaDinhThanhVien.ThanhVien.SOGIAYTO, TenQuanHe = hoGiaDinhThanhVien.TenQuanHe } });
            }
            else
            {
                return Json(new { success = success, mes = mes });
            }
        }
        [HttpPost]
        public ActionResult NhomNguoi_HoGiaDinh_GetThongTin()
        {
            BoHoSoModel bhs = (BoHoSoModel)Session["BoHoSo_" + CurrentUser.UserName];
            DC_NHOMNGUOI nhomNguoi = bhs.HoSoTN.DonDangKy.CurDangKyNguoi.Chu.NhomNguoi;
            DC_HOGIADINH hoGiaDinh = nhomNguoi.CurNhomNguoiThanhVien.ThanhVienHoGiaDinh;
            hoGiaDinh.SetThongTinHoGiaDinh();
            return Json(new { HOGIADINHID = hoGiaDinh.HOGIADINHID, TRANGTHAI = hoGiaDinh.TRANGTHAI, CHUHO = hoGiaDinh.CHUHO, VOCHONG = hoGiaDinh.VOCHONG, CMTCHUHO = hoGiaDinh.CMTCHUHO, CHUHO_HOTEN = hoGiaDinh.CHUHO_HOTEN, CMTVOCHONG = hoGiaDinh.CMTVOCHONG, VOCHONG_HOTEN = hoGiaDinh.VOCHONG_HOTEN });
        }
        #endregion
        #region NhomNguoi_VoChong
        [HttpPost]
        public ActionResult NhomNguoi_VoChong_Chong()
        {
            BoHoSoModel bhs = (BoHoSoModel)Session["BoHoSo_" + CurrentUser.UserName];
            DC_NHOMNGUOI nhomNguoi = bhs.HoSoTN.DonDangKy.CurDangKyNguoi.Chu.NhomNguoi;
            DC_VOCHONG voChong = nhomNguoi.CurNhomNguoiThanhVien.ThanhVienVoChong;
            if (voChong.ChongCN == null)
            {
                voChong.CurCaNhan = new DC_CANHAN();
                voChong.CurCaNhan.CANHANID = Guid.NewGuid().ToString();
                voChong.CurCaNhan.TRANGTHAI = 1;
            }
            else
            {
                voChong.CurCaNhan = Mapper.Map<DC_CANHAN, DC_CANHAN>(voChong.ChongCN);
            }
            VoChongLS voChongLS = Mapper.Map<DC_VOCHONG, VoChongLS>(voChong);
            ViewBag.dSGioiTinh = DONDANGKYServices.GetDM_GIOITINH();
            ViewBag.dSDanToc = DONDANGKYServices.GetDM_DANTOC();
            ViewBag.dSQuocTich = DONDANGKYServices.GetDM_QUOCTICH();
            ViewBag.dSGiayToTuyThan = DONDANGKYServices.GetDM_LOAIGIAYTOTUYTHAN();
            Session["BoHoSo_" + CurrentUser.UserName] = bhs;
            return PartialView(voChongLS);
        }
        [HttpPost]
        public ActionResult NhomNguoi_VoChong_Vo()
        {
            BoHoSoModel bhs = (BoHoSoModel)Session["BoHoSo_" + CurrentUser.UserName];
            DC_NHOMNGUOI nhomNguoi = bhs.HoSoTN.DonDangKy.CurDangKyNguoi.Chu.NhomNguoi;
            DC_VOCHONG voChong = nhomNguoi.CurNhomNguoiThanhVien.ThanhVienVoChong;
            if (voChong.VoCN == null)
            {
                voChong.CurCaNhan = new DC_CANHAN();
                voChong.CurCaNhan.CANHANID = Guid.NewGuid().ToString();
                voChong.CurCaNhan.TRANGTHAI = 1;
            }
            else
            {
                voChong.CurCaNhan = Mapper.Map<DC_CANHAN, DC_CANHAN>(voChong.VoCN);
            }
            VoChongLS voChongLS = Mapper.Map<DC_VOCHONG, VoChongLS>(voChong);
            ViewBag.dSGioiTinh = DONDANGKYServices.GetDM_GIOITINH();
            ViewBag.dSDanToc = DONDANGKYServices.GetDM_DANTOC();
            ViewBag.dSQuocTich = DONDANGKYServices.GetDM_QUOCTICH();
            ViewBag.dSGiayToTuyThan = DONDANGKYServices.GetDM_LOAIGIAYTOTUYTHAN();
            Session["BoHoSo_" + CurrentUser.UserName] = bhs;
            return PartialView(voChongLS);
        }
        [HttpPost]
        public ActionResult NhomNguoi_VoChong_XoaChong()
        {
            BoHoSoModel bhs = (BoHoSoModel)Session["BoHoSo_" + CurrentUser.UserName];
            DC_NHOMNGUOI nhomNguoi = bhs.HoSoTN.DonDangKy.CurDangKyNguoi.Chu.NhomNguoi;
            DC_VOCHONG curVoChong = nhomNguoi.CurNhomNguoiThanhVien.ThanhVienVoChong;
            curVoChong.ChongCN = null;
            curVoChong.CHONG = null;
            curVoChong.CMTCHONG = "";
            Session["BoHoSo_" + CurrentUser.UserName] = bhs;
            return PartialView("NhomNguoi_VoChong", Mapper.Map<DC_VOCHONG, VoChongLS>(curVoChong));
        }
        [HttpPost]
        public ActionResult NhomNguoi_VoChong_XoaVo()
        {
            BoHoSoModel bhs = (BoHoSoModel)Session["BoHoSo_" + CurrentUser.UserName];
            DC_NHOMNGUOI nhomNguoi = bhs.HoSoTN.DonDangKy.CurDangKyNguoi.Chu.NhomNguoi;
            DC_VOCHONG curVoChong = nhomNguoi.CurNhomNguoiThanhVien.ThanhVienVoChong;
            curVoChong.VoCN = null;
            curVoChong.VO = null;
            curVoChong.CMTVO = null;
            Session["BoHoSo_" + CurrentUser.UserName] = bhs;
            return PartialView("NhomNguoi_VoChong", Mapper.Map<DC_VOCHONG, VoChongLS>(curVoChong));
        }
        [HttpPost]
        public ActionResult NhomNguoi_Save_FormVoChong_ChiTietChongID(string data)
        {
            CaNhanLS caNhanLS = JsonConvert.DeserializeObject<CaNhanLS>(data);
            DC_CANHAN caNhan = Mapper.Map<CaNhanLS, DC_CANHAN>(caNhanLS);
            BoHoSoModel bhs = (BoHoSoModel)Session["BoHoSo_" + CurrentUser.UserName];
            DC_NHOMNGUOI nhomNguoi = bhs.HoSoTN.DonDangKy.CurDangKyNguoi.Chu.NhomNguoi;
            DC_VOCHONG curVoChong = nhomNguoi.CurNhomNguoiThanhVien.ThanhVienVoChong;
            caNhan.setHoTen();
            curVoChong.ChongCN = caNhan;
            curVoChong.CHONG = caNhan.CANHANID;
            curVoChong.CMTCHONG = caNhan.SOGIAYTO;
            Session["BoHoSo_" + CurrentUser.UserName] = bhs;
            return PartialView("NhomNguoi_VoChong", Mapper.Map<DC_VOCHONG, VoChongLS>(curVoChong));
        }
        [HttpPost]
        public ActionResult NhomNguoi_Save_FormVoChong_ChiTietVoID(string data)
        {
            CaNhanLS caNhanLS = JsonConvert.DeserializeObject<CaNhanLS>(data);
            DC_CANHAN caNhan = Mapper.Map<CaNhanLS, DC_CANHAN>(caNhanLS);
            BoHoSoModel bhs = (BoHoSoModel)Session["BoHoSo_" + CurrentUser.UserName];
            DC_NHOMNGUOI nhomNguoi = bhs.HoSoTN.DonDangKy.CurDangKyNguoi.Chu.NhomNguoi;
            DC_VOCHONG curVoChong = nhomNguoi.CurNhomNguoiThanhVien.ThanhVienVoChong;
            caNhan.setHoTen();
            curVoChong.VoCN = caNhan;
            curVoChong.VO = caNhan.CANHANID;
            curVoChong.CMTVO = caNhan.SOGIAYTO;
            Session["BoHoSo_" + CurrentUser.UserName] = bhs;
            return PartialView("NhomNguoi_VoChong", Mapper.Map<DC_VOCHONG, VoChongLS>(curVoChong));
        }
        [HttpPost]
        public ActionResult NhomNguoi_XoaTrang_FormVoChong_ChiTietChongID()
        {
            BoHoSoModel bhs = (BoHoSoModel)Session["BoHoSo_" + CurrentUser.UserName];
            DC_NHOMNGUOI nhomNguoi = bhs.HoSoTN.DonDangKy.CurDangKyNguoi.Chu.NhomNguoi;
            DC_VOCHONG curVoChong = nhomNguoi.CurNhomNguoiThanhVien.ThanhVienVoChong;
            curVoChong.CurCaNhan = new DC_CANHAN();
            curVoChong.CurCaNhan.CANHANID = Guid.NewGuid().ToString();
            curVoChong.CurCaNhan.TRANGTHAI = 1;
            VoChongLS voChongLS = Mapper.Map<DC_VOCHONG, VoChongLS>(curVoChong);
            voChongLS.CHONG = null;
            ViewBag.dSGioiTinh = DONDANGKYServices.GetDM_GIOITINH();
            ViewBag.dSDanToc = DONDANGKYServices.GetDM_DANTOC();
            ViewBag.dSQuocTich = DONDANGKYServices.GetDM_QUOCTICH();
            ViewBag.dSGiayToTuyThan = DONDANGKYServices.GetDM_LOAIGIAYTOTUYTHAN();
            Session["BoHoSo_" + CurrentUser.UserName] = bhs;
            return PartialView("NhomNguoi_VoChong_Chong", voChongLS);
        }
        [HttpPost]
        public ActionResult NhomNguoi_XoaTrang_FormVoChong_ChiTietVoID()
        {
            BoHoSoModel bhs = (BoHoSoModel)Session["BoHoSo_" + CurrentUser.UserName];
            DC_NHOMNGUOI nhomNguoi = bhs.HoSoTN.DonDangKy.CurDangKyNguoi.Chu.NhomNguoi;
            DC_VOCHONG curVoChong = nhomNguoi.CurNhomNguoiThanhVien.ThanhVienVoChong;
            curVoChong.CurCaNhan = new DC_CANHAN();
            curVoChong.CurCaNhan.CANHANID = Guid.NewGuid().ToString();
            curVoChong.CurCaNhan.TRANGTHAI = 1;
            VoChongLS voChongLS = Mapper.Map<DC_VOCHONG, VoChongLS>(curVoChong);
            voChongLS.VO = null;
            ViewBag.dSGioiTinh = DONDANGKYServices.GetDM_GIOITINH();
            ViewBag.dSDanToc = DONDANGKYServices.GetDM_DANTOC();
            ViewBag.dSQuocTich = DONDANGKYServices.GetDM_QUOCTICH();
            ViewBag.dSGiayToTuyThan = DONDANGKYServices.GetDM_LOAIGIAYTOTUYTHAN();
            Session["BoHoSo_" + CurrentUser.UserName] = bhs;
            return PartialView("NhomNguoi_VoChong_Vo", voChongLS);
        }
        #endregion
        #region NhomNguoi_ToChuc
        [HttpPost]
        public ActionResult NhomNguoi_ToChuc_NguoiDaiDien()
        {
            BoHoSoModel bhs = (BoHoSoModel)Session["BoHoSo_" + CurrentUser.UserName];
            DC_NHOMNGUOI nhomNguoi = bhs.HoSoTN.DonDangKy.CurDangKyNguoi.Chu.NhomNguoi;
            DC_TOCHUC toChuc = nhomNguoi.CurNhomNguoiThanhVien.ThanhVienToChuc;
            if (toChuc.NguoiDaiDien == null)
            {
                toChuc.CurCaNhan = new DC_CANHAN();
                toChuc.CurCaNhan.CANHANID = Guid.NewGuid().ToString();
                toChuc.CurCaNhan.TRANGTHAI = 1;
            }
            else
            {
                toChuc.CurCaNhan = Mapper.Map<DC_CANHAN, DC_CANHAN>(toChuc.NguoiDaiDien);
            }
            ToChucLS toChucLS = Mapper.Map<DC_TOCHUC, ToChucLS>(toChuc);
            ViewBag.dSGioiTinh = DONDANGKYServices.GetDM_GIOITINH();
            ViewBag.dSDanToc = DONDANGKYServices.GetDM_DANTOC();
            ViewBag.dSQuocTich = DONDANGKYServices.GetDM_QUOCTICH();
            ViewBag.dSGiayToTuyThan = DONDANGKYServices.GetDM_LOAIGIAYTOTUYTHAN();
            Session["BoHoSo_" + CurrentUser.UserName] = bhs;
            return PartialView(toChucLS);
        }
        [HttpPost]
        public ActionResult NhomNguoi_XoaTrang_FormToChuc_ChiTietNguoiDaiDienID()
        {
            BoHoSoModel bhs = (BoHoSoModel)Session["BoHoSo_" + CurrentUser.UserName];
            DC_NHOMNGUOI nhomNguoi = bhs.HoSoTN.DonDangKy.CurDangKyNguoi.Chu.NhomNguoi;
            DC_TOCHUC curToChuc = nhomNguoi.CurNhomNguoiThanhVien.ThanhVienToChuc;
            curToChuc.CurCaNhan = new DC_CANHAN();
            curToChuc.CurCaNhan.CANHANID = Guid.NewGuid().ToString();
            curToChuc.CurCaNhan.TRANGTHAI = 1;
            ToChucLS toChucLS = Mapper.Map<DC_TOCHUC, ToChucLS>(curToChuc);
            toChucLS.NGUOIDAIDIENID = null;
            ViewBag.dSGioiTinh = DONDANGKYServices.GetDM_GIOITINH();
            ViewBag.dSDanToc = DONDANGKYServices.GetDM_DANTOC();
            ViewBag.dSQuocTich = DONDANGKYServices.GetDM_QUOCTICH();
            ViewBag.dSGiayToTuyThan = DONDANGKYServices.GetDM_LOAIGIAYTOTUYTHAN();
            Session["BoHoSo_" + CurrentUser.UserName] = bhs;
            return PartialView("NhomNguoi_ToChuc_NguoiDaiDien", toChucLS);
        }
        [HttpPost]
        public ActionResult NhomNguoi_Save_FormToChuc_ChiTietNguoiDaiDienID(string data)
        {
            CaNhanLS caNhanLS = JsonConvert.DeserializeObject<CaNhanLS>(data);
            DC_CANHAN caNhan = Mapper.Map<CaNhanLS, DC_CANHAN>(caNhanLS);
            BoHoSoModel bhs = (BoHoSoModel)Session["BoHoSo_" + CurrentUser.UserName];
            DC_NHOMNGUOI nhomNguoi = bhs.HoSoTN.DonDangKy.CurDangKyNguoi.Chu.NhomNguoi;
            DC_TOCHUC curToChuc = nhomNguoi.CurNhomNguoiThanhVien.ThanhVienToChuc;
            caNhan.setHoTen();
            curToChuc.NguoiDaiDien = caNhan;
            curToChuc.NGUOIDAIDIENID = caNhan.CANHANID;
            curToChuc.CMTNGUOIDAIDIEN = caNhan.SOGIAYTO;
            ViewBag.dSDoiTuongSuDung = DONDANGKYServices.GetDM_DOITUONGSUDUNG(bhs.HoSoTN.DonDangKy.CurDangKyNguoi.LOAI ?? 0M);
            Session["BoHoSo_" + CurrentUser.UserName] = bhs;
            return PartialView("NhomNguoi_ToChuc", Mapper.Map<DC_TOCHUC, ToChucLS>(curToChuc));
        }
        [HttpPost]
        public ActionResult NhomNguoi_ToChuc_XoaNguoiDaiDien()
        {
            BoHoSoModel bhs = (BoHoSoModel)Session["BoHoSo_" + CurrentUser.UserName];
            DC_NHOMNGUOI nhomNguoi = bhs.HoSoTN.DonDangKy.CurDangKyNguoi.Chu.NhomNguoi;
            DC_TOCHUC curToChuc = nhomNguoi.CurNhomNguoiThanhVien.ThanhVienToChuc;
            curToChuc.NguoiDaiDien = null;
            curToChuc.NGUOIDAIDIENID = null;
            curToChuc.CMTNGUOIDAIDIEN = null;
            ViewBag.dSDoiTuongSuDung = DONDANGKYServices.GetDM_DOITUONGSUDUNG(bhs.HoSoTN.DonDangKy.CurDangKyNguoi.LOAI ?? 0M);
            Session["BoHoSo_" + CurrentUser.UserName] = bhs;
            return PartialView("NhomNguoi_ToChuc", Mapper.Map<DC_TOCHUC, ToChucLS>(curToChuc));
        }
        #endregion
        #region NhomNguoi_CongDong
        [HttpPost]
        public ActionResult NhomNguoi_CongDong_NguoiDaiDien()
        {
            BoHoSoModel bhs = (BoHoSoModel)Session["BoHoSo_" + CurrentUser.UserName];
            DC_NHOMNGUOI nhomNguoi = bhs.HoSoTN.DonDangKy.CurDangKyNguoi.Chu.NhomNguoi;
            DC_CONGDONG congDong = nhomNguoi.CurNhomNguoiThanhVien.ThanhVienCongDong;
            if (congDong.NguoiDaiDien == null)
            {
                congDong.CurCaNhan = new DC_CANHAN();
                congDong.CurCaNhan = new DC_CANHAN();
                congDong.CurCaNhan.CANHANID = Guid.NewGuid().ToString();
                congDong.CurCaNhan.TRANGTHAI = 1;
            }
            else
            {
                congDong.CurCaNhan = Mapper.Map<DC_CANHAN, DC_CANHAN>(congDong.NguoiDaiDien);
            }
            CongDongLS congDongLS = Mapper.Map<DC_CONGDONG, CongDongLS>(congDong);
            ViewBag.dSGioiTinh = DONDANGKYServices.GetDM_GIOITINH();
            ViewBag.dSDanToc = DONDANGKYServices.GetDM_DANTOC();
            ViewBag.dSQuocTich = DONDANGKYServices.GetDM_QUOCTICH();
            ViewBag.dSGiayToTuyThan = DONDANGKYServices.GetDM_LOAIGIAYTOTUYTHAN();
            Session["BoHoSo_" + CurrentUser.UserName] = bhs;
            return PartialView(congDongLS);
        }
        [HttpPost]
        public ActionResult NhomNguoi_XoaTrang_FormCongDong_ChiTietNguoiDaiDienID()
        {
            BoHoSoModel bhs = (BoHoSoModel)Session["BoHoSo_" + CurrentUser.UserName];
            DC_NHOMNGUOI nhomNguoi = bhs.HoSoTN.DonDangKy.CurDangKyNguoi.Chu.NhomNguoi;
            DC_CONGDONG curCongDong = nhomNguoi.CurNhomNguoiThanhVien.ThanhVienCongDong;
            curCongDong.CurCaNhan = new DC_CANHAN();
            curCongDong.CurCaNhan.CANHANID = Guid.NewGuid().ToString();
            curCongDong.CurCaNhan.TRANGTHAI = 1;
            CongDongLS congDongLS = Mapper.Map<DC_CONGDONG, CongDongLS>(curCongDong);
            congDongLS.NGUOIDAIDIENID = null;
            ViewBag.dSGioiTinh = DONDANGKYServices.GetDM_GIOITINH();
            ViewBag.dSDanToc = DONDANGKYServices.GetDM_DANTOC();
            ViewBag.dSQuocTich = DONDANGKYServices.GetDM_QUOCTICH();
            ViewBag.dSGiayToTuyThan = DONDANGKYServices.GetDM_LOAIGIAYTOTUYTHAN();
            Session["BoHoSo_" + CurrentUser.UserName] = bhs;
            return PartialView("NhomNguoi_CongDong_NguoiDaiDien", congDongLS);
        }
        [HttpPost]
        public ActionResult NhomNguoi_Save_FormCongDong_ChiTietNguoiDaiDienID(string data)
        {
            CaNhanLS caNhanLS = JsonConvert.DeserializeObject<CaNhanLS>(data);
            DC_CANHAN caNhan = Mapper.Map<CaNhanLS, DC_CANHAN>(caNhanLS);
            BoHoSoModel bhs = (BoHoSoModel)Session["BoHoSo_" + CurrentUser.UserName];
            DC_NHOMNGUOI nhomNguoi = bhs.HoSoTN.DonDangKy.CurDangKyNguoi.Chu.NhomNguoi;
            DC_CONGDONG curCongDong = nhomNguoi.CurNhomNguoiThanhVien.ThanhVienCongDong;
            caNhan.setHoTen();
            curCongDong.NguoiDaiDien = caNhan;
            curCongDong.NGUOIDAIDIENID = caNhan.CANHANID;
            curCongDong.CMTNGUOIDAIDIEN = caNhan.SOGIAYTO;
            ViewBag.dSDoiTuongSuDung = DONDANGKYServices.GetDM_DOITUONGSUDUNG(bhs.HoSoTN.DonDangKy.CurDangKyNguoi.LOAI ?? 0M);
            Session["BoHoSo_" + CurrentUser.UserName] = bhs;
            return PartialView("NhomNguoi_CongDong", Mapper.Map<DC_CONGDONG, CongDongLS>(curCongDong));
        }
        [HttpPost]
        public ActionResult NhomNguoi_CongDong_XoaNguoiDaiDien()
        {
            BoHoSoModel bhs = (BoHoSoModel)Session["BoHoSo_" + CurrentUser.UserName];
            DC_NHOMNGUOI nhomNguoi = bhs.HoSoTN.DonDangKy.CurDangKyNguoi.Chu.NhomNguoi;
            DC_CONGDONG curCongDong = nhomNguoi.CurNhomNguoiThanhVien.ThanhVienCongDong;
            curCongDong.NguoiDaiDien = null;
            curCongDong.NGUOIDAIDIENID = null;
            curCongDong.CMTNGUOIDAIDIEN = null;
            ViewBag.dSDoiTuongSuDung = DONDANGKYServices.GetDM_DOITUONGSUDUNG(bhs.HoSoTN.DonDangKy.CurDangKyNguoi.LOAI ?? 0M);
            Session["BoHoSo_" + CurrentUser.UserName] = bhs;
            return PartialView("NhomNguoi_CongDong", Mapper.Map<DC_CONGDONG, CongDongLS>(curCongDong));
        }
        #endregion
        #endregion
        #region Tìm Kiếm Chủ
        [HttpPost]
        public ActionResult TimKiem_CaNhan(string soGiayTo)
        {
            List<DC_CANHAN> dSCaNhan = DCCANHANServices.GetDSCaNhan(soGiayTo);
            DSCaNhanVM dSCaNhanVM = new DSCaNhanVM();
            foreach (var temp in dSCaNhan)
            {
                dSCaNhanVM.DSCaNhan.Add(temp);
            }
            Session["dSCaNhan"] = dSCaNhan;
            return PartialView("_Popup_KetQuaTimKiemCaNhan", dSCaNhanVM);
        }
        #endregion
        #endregion

        #region V2.0
        ///
        // GET: XLHSDangKy
        private MplisEntities dbo = new MplisEntities();

        //public static List<list_DSLienQuanBD> list_DoiTuong_xoa = new List<list_DSLienQuanBD>();
        public ActionResult Index()
        {
            return PartialView();
        }
        public ActionResult _DangKy()
        {
            BoHoSoModel bhs = (BoHoSoModel)Session["BoHoSo_" + CurrentUser.UserName];
            //_hid_HSTNID = "2D921A9AF541474991F4380FAE31561F";
            VM_XuLyHoSo_DK objVMDonDangKy = new VM_XuLyHoSo_DK();
            //int _loaddangky = DCDONDANGKYServices.getsetloaddatadondangky();
            //int _loaddangky = 0;
            //if (_loaddangky == 0)
            //{

            //DC_DONDANGKY objdondangky = new DC_DONDANGKY();
            //   DC_DONDANGKY objdondangky1 = new DC_DONDANGKY();
            // DCDONDANGKYServices.setloaddatadondangky(1);
            //objdondangky = DCDONDANGKYServices.getDonDangKyByHoSoTiepNhanID(_hid_HSTNID);
            // objdondangky = DCDONDANGKYServices.update_HSTN_DonDangky(objdondangky);
            if (bhs.HoSoTN.DonDangKy == null)
            {
                objVMDonDangKy.CHU_DANGKY = new List<DC_DANGKY_NGUOI>();
                objVMDonDangKy.GCN_DANGKY = new List<VM_GCN_DK>();
                objVMDonDangKy.GCN_DK = new List<DC_DANGKY_GCN>();
                objVMDonDangKy.TAISAN_DANGKY = new List<DC_DANGKY_TAISAN>();
                objVMDonDangKy.THUA_DANGKY = new List<DC_DANGKY_THUA>();
            }
            else
            {
                DC_DONDANGKY objdondangky = bhs.HoSoTN.DonDangKy;
                //   objdondangky1 = bhs.HoSoTN.DonDangKy;
                objVMDonDangKy.DONDANGKYID = objdondangky.DONDANGKYID;
                //Get thông tin đăng ký giấy chứng nhận
                foreach (var gcndk in objdondangky.DC_DANGKY_GCN)
                {
                    VM_GCN_DK obj = new VM_GCN_DK();
                    obj.gcnid = gcndk.GIAYCHUNGNHANID;
                    obj.mavach = gcndk.MaVach;
                    obj.sophathanh = gcndk.SoPhatHanh;
                    obj.trangthai = gcndk.TrangThai;
                    objVMDonDangKy.GCN_DANGKY.Add(obj);
                }
                objVMDonDangKy.GCN_DK = objdondangky.DSDangKyGCN;
                objVMDonDangKy.CHU_DANGKY = objdondangky.DSDangKyChu;

                //}
                Session["lstDsChuDk_" + CurrentUser.UserName] = objVMDonDangKy;
                //danh sách thửa
                Session["DsThua"] = objVMDonDangKy.THUA_DANGKY = bhs.HoSoTN.DonDangKy.DSDangKyThua;
                //get thoong tin nha
                objVMDonDangKy.TAISAN_DANGKY = objdondangky.DSDangKyTaiSan;
                //gán ds tài sản đăng ký
                foreach (var item in objdondangky.DSDangKyTaiSan)
                {
                    item.trangthaitaisan = 0;
                    if (item.TaiSanGanLienVoiDat != null)
                    {
                        //nhà riêng lẻ
                        if (item.TaiSanGanLienVoiDat.LOAITAISAN == "1")
                        {
                            if (item.TaiSanGanLienVoiDat.NhaRiengLe != null)
                            {
                                item.TaiSanGanLienVoiDat.NhaRiengLe.NHARIENGLEID = item.TaiSanGanLienVoiDat.TAISANID;
                                objVMDonDangKy.HienThiDangKyTaiSan.lstNhaRiengLe.Add(item.TaiSanGanLienVoiDat.NhaRiengLe);
                            }
                        }
                        if (item.TaiSanGanLienVoiDat.LOAITAISAN == "2")
                        {
                            if (item.TaiSanGanLienVoiDat.KhuChungCu != null)
                            {
                                item.TaiSanGanLienVoiDat.KhuChungCu.KHUCHUNGCUID = item.TaiSanGanLienVoiDat.TAISANID;
                                objVMDonDangKy.HienThiDangKyTaiSan.lstKhuChungCu.Add(item.TaiSanGanLienVoiDat.KhuChungCu);
                            }
                        }
                        if (item.TaiSanGanLienVoiDat.LOAITAISAN == "3")
                        {
                            if (item.TaiSanGanLienVoiDat.NhaChungCu != null)
                            {
                                item.TaiSanGanLienVoiDat.NhaChungCu.NHACHUNGCUID = item.TaiSanGanLienVoiDat.TAISANID;
                                objVMDonDangKy.HienThiDangKyTaiSan.lstNhaChungCu.Add(item.TaiSanGanLienVoiDat.NhaChungCu);
                            }
                        }
                        //căn hộ
                        if (item.TaiSanGanLienVoiDat.LOAITAISAN == "4")
                        {
                            item.TaiSanGanLienVoiDat.CanHo.CANHOID = item.TaiSanGanLienVoiDat.TAISANID;
                            objVMDonDangKy.HienThiDangKyTaiSan.lstCanHo.Add(item.TaiSanGanLienVoiDat.CanHo);
                        }
                        if (item.TaiSanGanLienVoiDat.LOAITAISAN == "5")
                        {
                            if (item.TaiSanGanLienVoiDat.HangMucNgoaiCanHo != null)
                            {
                                item.TaiSanGanLienVoiDat.HangMucNgoaiCanHo.HANGMUCSOHUUCHUNGID = item.TaiSanGanLienVoiDat.TAISANID;
                                objVMDonDangKy.HienThiDangKyTaiSan.lstHangMucNgoaiCanHo.Add(item.TaiSanGanLienVoiDat.HangMucNgoaiCanHo);
                            }
                        }
                        if (item.TaiSanGanLienVoiDat.LOAITAISAN == "7")
                        {
                            if (item.TaiSanGanLienVoiDat.CongTrinhNgam != null)
                            {
                                item.TaiSanGanLienVoiDat.CongTrinhNgam.CONGTRINHNGAMID = item.TaiSanGanLienVoiDat.TAISANID;
                                objVMDonDangKy.HienThiDangKyTaiSan.lstCongTrinhNgam.Add(item.TaiSanGanLienVoiDat.CongTrinhNgam);
                            }
                        }
                        if (item.TaiSanGanLienVoiDat.LOAITAISAN == "8")
                        {
                            if (item.TaiSanGanLienVoiDat.HangMucCongTrinh != null)
                            {
                                item.TaiSanGanLienVoiDat.HangMucCongTrinh.HANGMUCCONGTRINHID = item.TaiSanGanLienVoiDat.TAISANID;
                                objVMDonDangKy.HienThiDangKyTaiSan.lstHangMucCongTrinh.Add(item.TaiSanGanLienVoiDat.HangMucCongTrinh);
                            }
                        }
                        //Rừng trồng
                        if (item.TaiSanGanLienVoiDat.LOAITAISAN == "9")
                        {
                            if (item.TaiSanGanLienVoiDat.RungTrong != null)
                            {
                                item.TaiSanGanLienVoiDat.RungTrong.RUNGTRONGID = item.TaiSanGanLienVoiDat.TAISANID;
                                objVMDonDangKy.HienThiDangKyTaiSan.lstRungTrong.Add(item.TaiSanGanLienVoiDat.RungTrong);
                            }
                        }
                        //cây lâu năm
                        if (item.TaiSanGanLienVoiDat.LOAITAISAN == "10")
                        {
                            if (item.TaiSanGanLienVoiDat.CayLauNam != null)
                            {
                                item.TaiSanGanLienVoiDat.CayLauNam.CAYLAUNAMID = item.TaiSanGanLienVoiDat.TAISANID;
                                objVMDonDangKy.HienThiDangKyTaiSan.lstCayLauNam.Add(item.TaiSanGanLienVoiDat.CayLauNam);
                            }
                        }
                        //Công trình xây dựng
                        if (item.TaiSanGanLienVoiDat.LOAITAISAN == "6")
                        {
                            if (item.TaiSanGanLienVoiDat.CongTrinhXayDung != null)
                            {
                                item.TaiSanGanLienVoiDat.CongTrinhXayDung.CONGTRINHXAYDUNGID = item.TaiSanGanLienVoiDat.TAISANID;
                                objVMDonDangKy.HienThiDangKyTaiSan.lstCongTrinhXayDung.Add(item.TaiSanGanLienVoiDat.CongTrinhXayDung);
                            }
                        }
                        //tài sản gán liền với đất
                        objVMDonDangKy.HienThiDangKyTaiSan.taisanganlienvoidat_ID = item.TaiSanGanLienVoiDat.TAISANGANLIENVOIDATID;
                    }
                }
                Session["Dstaisandangky"] = objdondangky.DSDangKyTaiSan;
                Session["Dstaisanhienthi"] = objVMDonDangKy.HienThiDangKyTaiSan;
            }
            return PartialView("_DangKy", objVMDonDangKy);
        }

        #region Thông tin đăng ký GCN

        public ActionResult ADD_GCNDANGKY(string sph, string mv, string dondangky_id)
        {
            BoHoSoModel bhs = (BoHoSoModel)Session["BoHoSo_" + CurrentUser.UserName];
            if (sph == null)
            {
                sph = "";
            }
            if (mv == null)
            {
                mv = "";
            }
            DC_GIAYCHUNGNHAN objGCN = DCGIAYCHUNGNHANServices.getGiayChungNhan(sph, mv);
            //check giấy chứng nhận trong đăng ký
            if (objGCN != null)
            {
                var objdkgcn = (from item in bhs.HoSoTN.DonDangKy.DSDangKyGCN where item.GIAYCHUNGNHANID == objGCN.GIAYCHUNGNHANID && item.DONDANGKYID == dondangky_id select item).FirstOrDefault();
                VM_GCN_DK gcn = new VM_GCN_DK();
                if (objdkgcn == null)
                {
                    DCGIAYCHUNGNHANServices.AddGCNDK(bhs, objGCN);
                    Session["BoHoSo_" + CurrentUser.UserName] = bhs;
                    VM_XuLyHoSo_DK GCNVM = new VM_XuLyHoSo_DK();
                    GCNVM.initData(bhs);
                    return PartialView("_DonDangKy_DSGCN", GCNVM);
                }
                else
                {
                    return Json(true, JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }

        // xóa người đăng ký
        public JsonResult XOA_NGUOIDANGKY(string nguoi, string dondangky_id)
        {

            try
            {
                var objVMDonDangKy = (VM_XuLyHoSo_DK)Session["lstDsChuDk_" + CurrentUser.UserName];
                nguoi = nguoi.Trim();

                foreach (var item in objVMDonDangKy.CHU_DANGKY)
                {
                    if (nguoi == item.NGUOIID)
                    {
                        //Đối tượng bị xóa
                        item.Chu.TRANGTHAI_NGUOI = 3;
                        break;
                    }
                }
                return Json("true", JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {

                throw;
            }

        }
        public ActionResult XOA_GCNDANGKY(string gcn, string dondangky_id)
        {
            try
            {
                BoHoSoModel bhs = (BoHoSoModel)Session["BoHoSo_" + CurrentUser.UserName];
                gcn = gcn.Trim();
                foreach (var item in bhs.HoSoTN.DonDangKy.DSDangKyGCN)
                {
                    if (item.GIAYCHUNGNHANID == gcn)
                    {
                        if (item.themxoa == 1)
                        {
                            item.themxoa = 4;
                            if (item.GiayChungNhan.SOHUUCHUNGID != null)
                            {
                                foreach (var i in bhs.HoSoTN.DonDangKy.DSDangKyGCN)
                                {
                                    if (i.GiayChungNhan.SOHUUCHUNGID == item.GiayChungNhan.SOHUUCHUNGID)
                                        i.themxoa = 4;
                                }
                            }
                        }
                        else
                        {
                            item.themxoa = 3;
                            if (item.GiayChungNhan.SOHUUCHUNGID != null)
                            {
                                foreach (var a in bhs.HoSoTN.DonDangKy.DSDangKyGCN)
                                {
                                    if (a.GiayChungNhan.SOHUUCHUNGID == item.GiayChungNhan.SOHUUCHUNGID)
                                    {
                                        a.themxoa = 3;
                                    }
                                }
                            }
                        }
                    }
                }
                for (var i = 0; i <= bhs.HoSoTN.DonDangKy.DSDangKyGCN.Count - 1; i++)
                {
                    if (bhs.HoSoTN.DonDangKy.DSDangKyGCN[i].themxoa == 4)
                    {
                        bhs.HoSoTN.DonDangKy.DSDangKyGCN.RemoveAt(i);
                    }
                }
                Session["BoHoSo_" + CurrentUser.UserName] = bhs;
                VM_XuLyHoSo_DK GCNVM = new VM_XuLyHoSo_DK();
                GCNVM.initData(bhs);
                return PartialView("_DonDangKy_DSGCN", GCNVM);
            }
            catch (Exception ex)
            {

                throw;
            }

        }

        public void add_objdoituong(string doituong, string sophathanh, string mavach, string dondangkyid)
        {
            switch (doituong)
            {
                case "GCN":
                    #region

                    #endregion
                    break;
                case "CHU":

                    break;
                case "THUA":

                    break;
                default:
                    break;
            }
        }
        public JsonResult Save_formDonDangKy_DSGCN()
        {
            VM_SAVE save = new VM_SAVE();
            BoHoSoModel bhs = (BoHoSoModel)Session["BoHoSo_" + CurrentUser.UserName];

            save = DCGIAYCHUNGNHANServices.SaveDangKyGCN(bhs);
            if (save.save)
            {
                for (var i = 0; i <= save.bhs.HoSoTN.DonDangKy.DSDangKyGCN.Count - 1; i++)
                {
                    if (save.bhs.HoSoTN.DonDangKy.DSDangKyGCN[i].themxoa == 3)
                    {
                        save.bhs.HoSoTN.DonDangKy.DSDangKyGCN.RemoveAt(i);
                    }
                    else
                    {
                        save.bhs.HoSoTN.DonDangKy.DSDangKyGCN[i].themxoa = 0;
                    }
                }
                Session["BoHoSo_" + CurrentUser.UserName] = save.bhs;
                return Json("true", JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json("false", JsonRequestBehavior.AllowGet);
            }
        }
        #endregion
        #region THông tin thửa đăng ký
        #region mục đích sử dụng
        public ActionResult _ThuaMDSDDat(DC_THUADAT models)
        {
            DC_THUADAT thuamoi = (DC_THUADAT)Session["ThuaTimKiem"];
            ViewBag.mdsddat = DONDANGKYServices.getdm_MDSD();
            ViewBag.mdsdnguongoc = DONDANGKYServices.getdm_LOAINGUONGOC();
            ViewBag.mdsdquyhoach = DONDANGKYServices.getdm_LOAIQUYHOACH();
            ViewBag.mdsdhinhthuc = DCTHUADATServices.get_Loaihinhthuc();
            return PartialView("_DonDangKy_DSThua_TTChiTietThua_MDSD", thuamoi);
        }
        public ActionResult ChiTietMDSD(string idmdsdthuadat)
        {
            ViewBag.mdsddat = DONDANGKYServices.getdm_MDSD();
            ViewBag.mdsdnguongoc = DONDANGKYServices.getdm_LOAINGUONGOC();
            ViewBag.mdsdquyhoach = DONDANGKYServices.getdm_LOAIQUYHOACH();
            ViewBag.mdsdhinhthuc = DCTHUADATServices.get_Loaihinhthuc();
            var objthua = (DC_THUADAT)Session["ThuaTimKiem"];
            DC_THUADAT obj = new DC_THUADAT();
            if (idmdsdthuadat != null)
            {
                idmdsdthuadat = idmdsdthuadat.Trim();
                obj.CurMDSDDAT = (from item in objthua.DSMucDichSuDungDat where item.MUCDICHSUDUNGDATID == idmdsdthuadat select item).FirstOrDefault();
            }
            return PartialView("DonDangKy_DSThua_ChiTietMDSD", obj);
        }
        public ActionResult ThemMoiMDSD(DC_THUADAT models, string TenMDSD)
        {
            DC_THUADAT thuamoi = (DC_THUADAT)Session["ThuaTimKiem"];
            DC_MUCDICHSUDUNGDAT mdsd = new DC_MUCDICHSUDUNGDAT();
            DCTHUADATServices.ThemMDSD(models, thuamoi, TenMDSD);
            ViewBag.mdsddat = DONDANGKYServices.getdm_MDSD();
            ViewBag.mdsdnguongoc = DONDANGKYServices.getdm_LOAINGUONGOC();
            ViewBag.mdsdquyhoach = DONDANGKYServices.getdm_LOAIQUYHOACH();
            ViewBag.mdsdhinhthuc = DCTHUADATServices.get_Loaihinhthuc();
            Session["ThuaTimKiem"] = thuamoi;
            return PartialView("_DonDangKy_DSThua_TTChiTietThua_MDSD", thuamoi);
        }
        public ActionResult XoaMDSDThua(string mucdichid)
        {
            ViewBag.mdsddat = DONDANGKYServices.getdm_MDSD();
            ViewBag.mdsdnguongoc = DONDANGKYServices.getdm_LOAINGUONGOC();
            ViewBag.mdsdquyhoach = DONDANGKYServices.getdm_LOAIQUYHOACH();
            ViewBag.mdsdhinhthuc = DCTHUADATServices.get_Loaihinhthuc();
            DC_THUADAT thuamoi = (DC_THUADAT)Session["ThuaTimKiem"];
            var mucdichxoa = (from item in thuamoi.DSMucDichSuDungDat where item.MUCDICHSUDUNGDATID == mucdichid select item).FirstOrDefault();
            thuamoi.DSMucDichSuDungDat.Remove(mucdichxoa);
            Session["ThuaTimKiem"] = thuamoi;
            return PartialView("_DonDangKy_DSThua_TTChiTietThua_MDSD", thuamoi);
        }
        public ActionResult ChiTietDSNguon(DC_THUADAT thua)
        {

            ViewBag.mdsddat = DONDANGKYServices.getdm_MDSD();
            ViewBag.mdsdnguongoc = DONDANGKYServices.getdm_LOAINGUONGOC();
            ViewBag.mdsdquyhoach = DONDANGKYServices.getdm_LOAIQUYHOACH();
            ViewBag.mdsdhinhthuc = DCTHUADATServices.get_Loaihinhthuc();
            string NGUONGOCSDTH;
            if (thua.CurMDSDDAT.NguonID != null)
                NGUONGOCSDTH = DCTHUADATServices.GetLoaiNguonGocToString(thua.CurMDSDDAT.NguonID);
            else
                NGUONGOCSDTH = "";

            return Json(NGUONGOCSDTH, JsonRequestBehavior.AllowGet);

        }
        #region Vị trí
        public ActionResult DanhSachViTri(string idmdsdthuadat)
        {
            ViewBag.mdsddat = DONDANGKYServices.getdm_MDSD();
            ViewBag.mdsdnguongoc = DONDANGKYServices.getdm_LOAINGUONGOC();
            ViewBag.mdsdquyhoach = DONDANGKYServices.getdm_LOAIQUYHOACH();
            ViewBag.mdsdhinhthuc = DCTHUADATServices.get_Loaihinhthuc();
            var objthua = (DC_THUADAT)Session["ThuaTimKiem"];
            DC_THUADAT obj = new DC_THUADAT();
            if (idmdsdthuadat != null)
            {
                idmdsdthuadat = idmdsdthuadat.Trim();
                objthua.CurMDSDDAT = (from item in objthua.DSMucDichSuDungDat where item.MUCDICHSUDUNGDATID == idmdsdthuadat select item).FirstOrDefault();
                objthua.DSViTri = objthua.CurMDSDDAT.DSViTriMDSD;
            }
            return PartialView("DonDangKy_DSThua_ViTri", objthua);
        }
        public ActionResult LoadViTri(string mucdichid)
        {
            DC_THUADAT obj = new DC_THUADAT();
            DC_VITRITHUADAT mdsd = new DC_VITRITHUADAT();
            obj.CurViTri = mdsd;
            if (mucdichid != null)
                obj.CurViTri.MUCDICHSUDUNGDATID = mucdichid;
            return PartialView("DonDangKy_DSThua_ChiTietViTri", obj);
        }
        public ActionResult XoaViTri(string vitriid)
        {
            DC_THUADAT thuamoi = (DC_THUADAT)Session["ThuaTimKiem"];
            foreach (var a in thuamoi.DSMucDichSuDungDat)
            {
                var vitrixoa = (from item in a.DSViTriMDSD where item.VITRIID == vitriid select item).FirstOrDefault();
                if (vitrixoa != null)
                {
                    a.DSViTriMDSD.Remove(vitrixoa);
                    thuamoi.DSViTri = a.DSViTriMDSD;
                }
            }
            Session["ThuaTimKiem"] = thuamoi;
            return PartialView("DonDangKy_DSThua_ViTri", thuamoi);
        }
        public ActionResult ThemMoiViTri(DC_THUADAT models)
        {
            DC_THUADAT thuamoi = (DC_THUADAT)Session["ThuaTimKiem"];
            DCTHUADATServices.ThemViTri(models, thuamoi);
            Session["ThuaTimKiem"] = thuamoi;
            return PartialView("DonDangKy_DSThua_ViTri", thuamoi);
        }
        public ActionResult ChiTietViTri(string idvitri)
        {
            var objthua = (DC_THUADAT)Session["ThuaTimKiem"];
            DC_THUADAT obj = new DC_THUADAT();
            if (idvitri != null)
            {
                idvitri = idvitri.Trim();
                obj.CurViTri = (from item in objthua.DSViTri where item.VITRIID == idvitri select item).FirstOrDefault();
            }
            return PartialView("DonDangKy_DSThua_ChiTietViTri", obj);

        }
        #endregion
        #endregion
        #region giá đất
        public ActionResult _ThuaGiaDat(DC_THUADAT models)
        {
            ViewBag.loaigiadat = DONDANGKYServices.getdm_loaigiadat();
            var objthua = (DC_THUADAT)Session["ThuaTimKiem"];
            return PartialView("_DonDangKy_DSThua_GiaDat", objthua);
        }
        public ActionResult ChiTietGiaDat(string idgiadatthuadat)
        {
            ViewBag.loaigiadat = DONDANGKYServices.getdm_loaigiadat();
            var objthua = (DC_THUADAT)Session["ThuaTimKiem"];
            DC_THUADAT obj = new DC_THUADAT();
            if (idgiadatthuadat != null)
            {
                idgiadatthuadat = idgiadatthuadat.Trim();
                obj.CurGiaDat = (from item in objthua.DSGiaDat where item.GIATHUADATID == idgiadatthuadat select item).FirstOrDefault();
            }
            return PartialView("DonDangKy_DSThua_ChiTietGiaDat", obj);
        }
        public ActionResult ThemMoiGiaDat(DC_THUADAT models)
        {
            ViewBag.loaigiadat = DONDANGKYServices.getdm_loaigiadat();
            DC_THUADAT thuamoi = (DC_THUADAT)Session["ThuaTimKiem"];
            GD_GIATHUADAT giadat = new GD_GIATHUADAT();
            DCTHUADATServices.ThemGiaDat(models, thuamoi);
            Session["ThuaTimKiem"] = thuamoi;
            return PartialView("_DonDangKy_DSThua_GiaDat", thuamoi);
        }
        public ActionResult XoaGiaThua(string giadatid)
        {
            ViewBag.loaigiadat = DONDANGKYServices.getdm_loaigiadat();
            DC_THUADAT thuamoi = (DC_THUADAT)Session["ThuaTimKiem"];
            var giathuaxoa = (from item in thuamoi.DSGiaDat where item.GIATHUADATID == giadatid select item).FirstOrDefault();
            thuamoi.DSGiaDat.Remove(giathuaxoa);
            Session["ThuaTimKiem"] = thuamoi;
            return PartialView("_DonDangKy_DSThua_GiaDat", thuamoi);
        }

        #endregion
        #region Hạn chế
        public ActionResult _ThuaHanChe(DC_THUADAT models)
        {
            DC_THUADAT thuamoitimkiem = (DC_THUADAT)Session["ThuaTimKiem"];
            ViewBag.mdsdhanche = DCTHUADATServices.get_Loaihanche();
            return PartialView("_DonDangKy_DSThua_TranhChap", thuamoitimkiem);
        }
        public ActionResult ChiTietHanChe(string idhanchethuadat)
        {
            var objthua = (DC_THUADAT)Session["ThuaTimKiem"];
            DC_THUADAT obj = new DC_THUADAT();
            if (idhanchethuadat != null)
            {
                idhanchethuadat = idhanchethuadat.Trim();
                obj.CurHanChe = (from item in objthua.DSHanCheThua where item.HANCHEID == idhanchethuadat select item).FirstOrDefault();// DCTHUADATServices.getMDSDbyID(idmdsdthuadat);
            }
            ViewBag.mdsdhanche = DCTHUADATServices.get_Loaihanche();
            return PartialView("DonDangKy_DSThua_ChiTietTranhChap", obj);

        }
        public ActionResult XoaHanChe(string tranhchapid)
        {
            DC_THUADAT thuamoi = (DC_THUADAT)Session["ThuaTimKiem"];
            var hanchexoa = (from item in thuamoi.DSHanCheThua where item.HANCHEID == tranhchapid select item).FirstOrDefault();
            thuamoi.DSHanCheThua.Remove(hanchexoa);
            decimal ttHanChe = 0;
            foreach (var item in thuamoi.DSHanCheThua)
            {
                if (item == null)
                {
                    thuamoi._DANGTRANHCHAP = false;
                    thuamoi.DANGTRANHCHAP = "N";
                }
                else
                {
                    if (item._ConHieuLuc == true)
                        ttHanChe = ttHanChe + 1;
                }
            }
            if (ttHanChe == 0)
            {
                thuamoi._DANGTRANHCHAP = false;
                thuamoi.DANGTRANHCHAP = "N";
            }
            else
            {
                thuamoi._DANGTRANHCHAP = true;
                thuamoi.DANGTRANHCHAP = "Y";
            }
            Session["ThuaTimKiem"] = thuamoi;
            ViewBag.mdsdhanche = DCTHUADATServices.get_Loaihanche();
            return PartialView("_DonDangKy_DSThua_TranhChap", thuamoi);
        }
        public ActionResult ThemMoiHanChe(DC_THUADAT models)
        {
            DC_THUADAT thuamoi = (DC_THUADAT)Session["ThuaTimKiem"];
            DC_TRANHCHAP tranhchap = new DC_TRANHCHAP();
            DCTHUADATServices.ThemHanChe(models, thuamoi);
            Session["ThuaTimKiem"] = thuamoi;
            ViewBag.mdsdhanche = DCTHUADATServices.get_Loaihanche();
            return PartialView("_DonDangKy_DSThua_TranhChap", thuamoi);
        }

        #endregion
        #region Tài liệu đo đạc
        public ActionResult SaveDoDac(DC_TAILIEUDODAC models)
        {
            var objthua = (DC_THUADAT)Session["ThuaTimKiem"];
            DC_TAILIEUDODAC objtailieu = new DC_TAILIEUDODAC();
            using (MplisEntities dbo = new MplisEntities())
            {
                if (models.TAILIEUDODACID == null || models.TAILIEUDODACID == "")
                {
                    objtailieu = models;
                    objtailieu.TAILIEUDODACID = Guid.NewGuid().ToString();
                    dbo.DC_TAILIEUDODAC.Add(objtailieu);
                }
                else
                {
                    objtailieu = models;
                    dbo.Entry(objtailieu).State = EntityState.Modified;
                }
                dbo.SaveChanges();
            }

            objthua.TAILIEUDODACID = objtailieu.TAILIEUDODACID;
            //objtailieu = DCTHUADATServices.getTaiLieuDoDac(tailieudodacid);
            objtailieu.THUADATID = objthua.THUADATID;
            ViewBag.loaibando = DCTHUADATServices.GetLoaiBanDo();
            return PartialView("_TaiLieuDoDac", objtailieu);
        }
        public ActionResult _Popup_TaiLieuDoDac(string thuaDatID, string taiLieuDoDacID)
        {
            DC_TAILIEUDODAC objTaiLieu = new DC_TAILIEUDODAC();
            objTaiLieu = DCTHUADATServices.getTaiLieuDoDac(taiLieuDoDacID);
            objTaiLieu.THUADATID = thuaDatID;
            ViewBag.loaibando = DCTHUADATServices.GetLoaiBanDo();
            return PartialView("_Popup_TaiLieuDoDac", objTaiLieu);
        }
        public ActionResult LamMoiDoDac(string THUAID)
        {
            DC_TAILIEUDODAC objtailieu = new DC_TAILIEUDODAC();
            //objtailieu = DCTHUADATServices.getTaiLieuDoDac(tailieudodacid);
            objtailieu.THUADATID = THUAID;
            ViewBag.loaibando = DCTHUADATServices.GetLoaiBanDo();
            return PartialView("_TaiLieuDoDac", objtailieu);
        }
        #endregion
        public ActionResult TimKiem_THUADAT(string SttThua, string SoToBanDo, string KhuVucHanhChinh)
        {
            BoHoSoModel bhs = (BoHoSoModel)Session["BoHoSo_" + CurrentUser.UserName];
            List<DC_THUADAT> thuadat = new List<DC_THUADAT>();
            DC_THUADAT thua = new DC_THUADAT();
            if (SttThua != null && SoToBanDo != null && SttThua != "" && SoToBanDo != "")
            {
                thua = DCTHUADATServices.getthuatimkiem(SttThua, SoToBanDo, KhuVucHanhChinh);
            }
            if (thua.TRANGTHAI == "Y")
            {
                thua = DCTHUADATServices.CloneThuaDatTimKiem(thua);
                thua.TRANGTHAI = "S";
            }
            else
            {
                thua._TRONGDB = 1;
            }
            var thudk = (from item in bhs.HoSoTN.DonDangKy.DSDangKyThua where item.XAID == thua.XAID && item.SOHIEUTOBANDO == thua.SOHIEUTOBANDO && item.SOTHUTHUTHUA == thua.SOTHUTUTHUA && item.THUADATID == thua.THUADATID select item).FirstOrDefault();
            if (thudk != null)
            {
                thua._TRONGDANGKY = 1;
            }
            Session["ThuaTimKiem"] = thua;
            ViewBag.listloaithua = DONDANGKYServices.getloaithuadat();
            ViewBag.listxa = Session["HC_XA"];
            ViewBag.listduong = DCTHUADATServices.get_listduong(bhs.HoSoTN.DONVIHANHCHINHID);
            ViewBag.listkhuvuc = DCTHUADATServices.get_listkhuvuc(bhs.HoSoTN.DONVIHANHCHINHID);
            if (thua.DUONG != null)
            {
                ViewBag.listdoanduong = DCTHUADATServices.get_listdoanduong(thua.DUONG);
            }
            else
            {
                ViewBag.listdoanduong = new List<DC_DOANDUONG>();
            }
            return PartialView("_DonDangKy_DSThua_TTChiTietThua_TTChung", thua);
        }
        public JsonResult Save_formDonDangKy_DSTHUA()
        {
            bool save = false;
            BoHoSoModel bhs = (BoHoSoModel)Session["BoHoSo_" + CurrentUser.UserName];

            save = DCTHUADATServices.SaveDangKyThua(bhs);

            if (save)
            {
                for (var i = 0; i <= bhs.HoSoTN.DonDangKy.DSDangKyThua.Count - 1; i++)
                {
                    if (bhs.HoSoTN.DonDangKy.DSDangKyThua[i].TRANGTHAITHUA == "3")
                    {
                        bhs.HoSoTN.DonDangKy.DSDangKyThua.RemoveAt(i);
                    }
                    else
                    {
                        bhs.HoSoTN.DonDangKy.DSDangKyThua[i].TRANGTHAITHUA = "0";
                    }
                }
                return Json("true", JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json("false", JsonRequestBehavior.AllowGet);
            }

        }
        public ActionResult _DonDangKy_ChiTietThua()
        {
            return PartialView("_DonDangKy_ChiTietThua");
        }
        public ActionResult _DonDangKy_DSThua_TTChiTietThua_TTChung(string huyenID, string _hid_ThuaID)
        {
            BoHoSoModel bhs = (BoHoSoModel)Session["BoHoSo_" + CurrentUser.UserName];
            DC_THUADAT Thua = (DC_THUADAT)Session["ThuaTimKiem"];
            var objThua = new DC_THUADAT();
            if (Thua != null)
            {
                if (_hid_ThuaID == Thua.THUADATID)
                {
                    objThua = Thua;
                }
            }
            else
            {
                objThua.THUADATID = Guid.NewGuid().ToString();
                Session["ThuaTimKiem"] = objThua;
            }
            Session["DsThua"] = bhs.HoSoTN.DonDangKy.DSDangKyThua;
            Session["HC_XA"] = ViewBag.listxa = DONDANGKYServices.getdm_HC_XA(bhs.HoSoTN.DONVIHANHCHINHID);
            ViewBag.listduong = DCTHUADATServices.get_listduong(bhs.HoSoTN.DONVIHANHCHINHID);
            ViewBag.listkhuvuc = DCTHUADATServices.get_listkhuvuc(bhs.HoSoTN.DONVIHANHCHINHID);
            ViewBag.listloaithua = DONDANGKYServices.getloaithuadat();
            if (objThua.DUONG != null)
            {
                ViewBag.listdoanduong = DCTHUADATServices.get_listdoanduong(objThua.DUONG);
            }
            else
            {
                ViewBag.listdoanduong = new List<DC_DOANDUONG>();
            }
            return PartialView(objThua);
        }
        //xóa thửa khỏi đăng ký
        public ActionResult XOA_THUA(string thuadangkyid, string dondangky_id)
        {
            BoHoSoModel bhs = (BoHoSoModel)Session["BoHoSo_" + CurrentUser.UserName];
            foreach (var item in bhs.HoSoTN.DonDangKy.DSDangKyThua)
            {
                if (item.DANGKYTHUAID == thuadangkyid && item.DONDANGKYID == dondangky_id)
                {
                    item.TRANGTHAITHUA = "3";
                }
            }
            Session["BoHoSo_" + CurrentUser.UserName] = bhs;
            VM_XuLyHoSo_DK GCNVM = new VM_XuLyHoSo_DK();
            GCNVM.initData(bhs);
            return PartialView("_DonDangKy_DSThua_DSThua", GCNVM);
        }
        //làm mới thửa
        public ActionResult LamMoiTHua()
        {
            BoHoSoModel bhs = (BoHoSoModel)Session["BoHoSo_" + CurrentUser.UserName];
            DC_THUADAT objthua = new DC_THUADAT();
            objthua.THUADATID = Guid.NewGuid().ToString();
            ViewBag.listxa = Session["HC_XA"];
            ViewBag.listduong = DCTHUADATServices.get_listduong(bhs.HoSoTN.DONVIHANHCHINHID);
            ViewBag.listkhuvuc = DCTHUADATServices.get_listkhuvuc(bhs.HoSoTN.DONVIHANHCHINHID);
            ViewBag.listloaithua = DONDANGKYServices.getloaithuadat();
            ViewBag.listdoanduong = new List<DC_DOANDUONG>();
            return PartialView("_DonDangKy_DSThua_TTChiTietThua_TTChung", objthua);
        }
        // chi tiết thửa
        public ActionResult ChiTietThuaDangKy(string thuaDatID, string donDangKyID, string dangKyThuaID)
        {
            BoHoSoModel bhs = (BoHoSoModel)Session["BoHoSo_" + CurrentUser.UserName];
            DC_THUADAT objThua = null;
            DC_THUADAT objThuagoc = (from item in bhs.HoSoTN.DonDangKy.DSDangKyThua.Where(a => a.THUADATID.Equals(thuaDatID)) select item).FirstOrDefault().Thua;
            if (objThuagoc != null)
            {
                if (objThuagoc.TAILIEUDODACID != null)
                {
                    objThuagoc.TENTAILIEUDD = DCTHUADATServices.GetTenTaiLieuDoDac(objThuagoc.TAILIEUDODACID);
                }
                if (objThuagoc.TRANGTHAI == "Y")
                {
                    objThua = DCTHUADATServices.CloneThuaDatTimKiem(objThuagoc);
                    objThua.TRANGTHAI = "S";
                    objThua._TRONGDANGKY = 0;
                }
                else
                {
                    objThua = objThuagoc;
                    objThua._TRONGDANGKY = 1;
                }
                Session["ThuaTimKiem"] = objThua;
            }
            objThua._KIEMTRA = 1;

            ViewBag.listxa = Session["HC_XA"];
            ViewBag.listduong = DCTHUADATServices.get_listduong(bhs.HoSoTN.DONVIHANHCHINHID);
            ViewBag.listkhuvuc = DCTHUADATServices.get_listkhuvuc(bhs.HoSoTN.DONVIHANHCHINHID);
            ViewBag.listloaithua = DONDANGKYServices.getloaithuadat();
            if (objThua.DUONG != null)
            {
                ViewBag.listdoanduong = DCTHUADATServices.get_listdoanduong(objThua.DUONG);
            }
            else
            {
                ViewBag.listdoanduong = new List<DC_DOANDUONG>();
            }
            return PartialView("_DonDangKy_DSThua_TTChiTietThua_TTChung", objThua);
        }
        public ActionResult ChonThua(string thuaDatID)
        {
            ViewBag.listloaithua = DONDANGKYServices.getloaithuadat();
            ViewBag.listxa = Session["HC_XA"];
            DC_THUADAT thuamoi = (DC_THUADAT)Session["ThuaTimKiem"];
            thuamoi._KIEMTRA = 1;
            return PartialView("_DonDangKy_DSThua_TTChiTietThua_TTChung", thuamoi);
        }
        public ActionResult ChonDoanDuong(DC_THUADAT thua)
        {
            BoHoSoModel bhs = (BoHoSoModel)Session["BoHoSo_" + CurrentUser.UserName];
            ViewBag.listxa = Session["HC_XA"];
            ViewBag.listduong = DCTHUADATServices.get_listduong(bhs.HoSoTN.DONVIHANHCHINHID);
            ViewBag.listkhuvuc = DCTHUADATServices.get_listkhuvuc(bhs.HoSoTN.DONVIHANHCHINHID);
            ViewBag.listloaithua = DONDANGKYServices.getloaithuadat();
            ViewBag.listdoanduong = DCTHUADATServices.get_listdoanduong(thua.DUONG);
            return PartialView("_DonDangKy_DSThua_TTChiTietThua_TTChung", thua);
        }
        public ActionResult _ThuaHoSoQuet(DC_THUADAT thua)
        {
            DC_THUADAT thuamoi = (DC_THUADAT)Session["ThuaTimKiem"];
            return PartialView("_DonDangKy_DSThua_HoSoLK", thuamoi);
        }

        public ActionResult LuuDuLieuThua(DC_THUADAT models)
        {
            BoHoSoModel bhs = (BoHoSoModel)Session["BoHoSo_" + CurrentUser.UserName];
            DC_THUADAT thuamoi = (DC_THUADAT)Session["ThuaTimKiem"];
            bool check = DCTHUADATServices.CheckDuLieuThua(models);

            if (check == true)
            {
                if (models._TRONGDANGKY == 1)
                    return Json(true, JsonRequestBehavior.AllowGet);
                else
                    return Json(false, JsonRequestBehavior.AllowGet);
            }
            else
            {
                DCTHUADATServices.ThemThua(models, thuamoi, bhs);
                Session["BoHoSo_" + CurrentUser.UserName] = bhs;
                VM_XuLyHoSo_DK GCNVM = new VM_XuLyHoSo_DK();
                GCNVM.initData(bhs);
                return PartialView("_DonDangKy_DSThua_DSThua", GCNVM);
            }
        }
        #endregion
        #region giấy tờ tùy thân
        //Thêm giấy tờ tùy thân
        public ActionResult GenInfoCaNhan_GTTT(DC_CANHAN model)
        {
            DC_CANHAN models = new DC_CANHAN();
            //model.CurGiayToTuyThan.LAGIAYTOINGCN = model.CurGiayToTuyThan._LAGIAYTOINGCN;
            models = (DC_CANHAN)Session["Dk_ChuCaNhan"];
            VM_XuLyHoSo_DK GetObject = (VM_XuLyHoSo_DK)Session["lstDsChuDk_" + CurrentUser.UserName];
            using (MplisEntities db = new MplisEntities())
            {
                var loaigiayto = (from item in dbo.DM_LOAIGIAYTOTUYTHAN where item.LOAIGIAYTOTUYTHANID == model.CurGiayToTuyThan.LOAIGIAYTOTUYTHANID select item).FirstOrDefault();
                model.CurGiayToTuyThan.TenGiayToTuyThan = loaigiayto.TENLOAIGIAYTOTUYTHAN;
            }
            //thêm thông tin giấy tờ liên quan
            if ((model.CurGiayToTuyThan.CANHANID != null && model.CurGiayToTuyThan.GIAYTOTUYTHANID != null) && (model.CurGiayToTuyThan.CANHANID != "" && model.CurGiayToTuyThan.GIAYTOTUYTHANID != ""))
            {
                foreach (var item in models.DSGiayToTuyThan)
                {
                    if (item.GIAYTOTUYTHANID == model.CurGiayToTuyThan.GIAYTOTUYTHANID)
                    {
                        Mapper.Map<DC_GIAYTOTUYTHAN, DC_GIAYTOTUYTHAN>(model.CurGiayToTuyThan, item);
                        item.LAGIAYTOINGCN = model.CurGiayToTuyThan._LAGIAYTOINGCN;
                        break;
                    }
                }
            }
            //thêm mới giấy tờ
            else
            {
                if (models.DSGiayToTuyThan == null)
                {
                    models.DSGiayToTuyThan = new List<DC_GIAYTOTUYTHAN>();
                }
                model.CurGiayToTuyThan.GIAYTOTUYTHANID = Guid.NewGuid().ToString();
                model.CurGiayToTuyThan.CANHANID = models.CANHANID;
                model.CurGiayToTuyThan.LAGIAYTOINGCN = model.CurGiayToTuyThan._LAGIAYTOINGCN;
                models.DSGiayToTuyThan.Add(model.CurGiayToTuyThan);
            }
            if (model.TYPE_CHU == "1")
            {
                foreach (var item in GetObject.CHU_DANGKY)
                {
                    {
                        if (item.Chu.CaNhan != null)
                        {
                            if (item.Chu.CaNhan.CANHANID == model.CurGiayToTuyThan.CANHANID)
                            {
                                if (item.LOAI == 1)
                                    //trạng thái chủ là sửa trạng thái = 2;
                                    if (item.Chu.TRANGTHAI_NGUOI != 1)
                                    {
                                        item.Chu.TRANGTHAI_NGUOI = 2;
                                        item.Chu.CaNhan.TRANGTHAI = 2;
                                    }
                            }
                        }
                    }
                }

            }
            // Giấy tờ loại chủ hộ gia đình
            else if (model.TYPE_CHU == "2")
            {

                DC_HOGIADINH objhogiadinh = new DC_HOGIADINH();
                objhogiadinh = (DC_HOGIADINH)Session["Dk_ChuHoGiaDinh"];


                foreach (var item in GetObject.CHU_DANGKY)
                {
                    if (item.LOAI == 2)
                    {

                        if (item.Chu.HoGiaDinh.HOGIADINHID == objhogiadinh.HOGIADINHID)
                        {
                            //trạng thái chủ là sửa trạng thái = 2;
                            if (item.Chu.TRANGTHAI_NGUOI != 1)
                            {
                                item.Chu.TRANGTHAI_NGUOI = 2;
                                //item.Chu.CaNhan.TRANGTHAI = 2;
                                break;
                            }
                        }
                    }

                }
            }
            // loại chủ vợ chồng
            else if (model.TYPE_CHU == "3")
            {

                DC_VOCHONG objvochong = new DC_VOCHONG();
                objvochong = (DC_VOCHONG)Session["ChuVoChong"];

                foreach (var item in GetObject.CHU_DANGKY)
                {
                    if (item.LOAI == 3)
                    {
                        if (item.Chu.VoChong.VOCHONGID == objvochong.VOCHONGID)
                        {
                            //trạng thái chủ là sửa trạng thái = 2;
                            if (item.Chu.TRANGTHAI_NGUOI != 1)
                            {
                                item.Chu.TRANGTHAI_NGUOI = 2;
                                //item.Chu.CaNhan.TRANGTHAI = 2;
                                break;
                            }
                        }
                    }

                }
            }
            // loại chủ tổ chức
            else if (model.TYPE_CHU == "4")
            {
                foreach (var item in GetObject.CHU_DANGKY)
                {
                    if (item.LOAI == 4)
                    {
                        if (item.Chu.ToChuc.NGUOIDAIDIENID == models.CANHANID)
                        {
                            if (item.Chu.TRANGTHAI_NGUOI != 1)
                            {
                                //  item.Chu.CaNhan.TRANGTHAI = 2;
                                item.Chu.TRANGTHAI_NGUOI = 2;
                                break;
                            }

                        }
                    }

                }
            }
            // loại chủ tổ chức
            else if (model.TYPE_CHU == "5")
            {
                foreach (var item in GetObject.CHU_DANGKY)
                {
                    if (item.LOAI == 5)
                    {
                        if (item.Chu.CongDong.NGUOIDAIDIENID == models.CANHANID)
                        {
                            if (item.Chu.TRANGTHAI_NGUOI != 1)
                            {
                                //  item.Chu.CaNhan.TRANGTHAI = 2;
                                item.Chu.TRANGTHAI_NGUOI = 2;
                                break;
                            }

                        }
                    }


                }
            }
            else if (model.TYPE_CHU == "6")
            {
                using (MplisEntities dbo = new MplisEntities())
                {

                    foreach (var objgiayto in models.DSGiayToTuyThan)
                    {
                        if (objgiayto != null)
                        {
                            var checkgiayto = (from item in dbo.DC_GIAYTOTUYTHAN where item.CANHANID == objgiayto.CANHANID && item.GIAYTOTUYTHANID == objgiayto.GIAYTOTUYTHANID select item).FirstOrDefault();
                            if (checkgiayto == null)
                            {
                                dbo.DC_GIAYTOTUYTHAN.Add(objgiayto);
                                dbo.SaveChanges();
                                break;
                            }
                        }
                    }

                }
                ViewBag.loaigiaytotuythan = DONDANGKYServices.getdm_loaigiaytotuythan();
                return PartialView("_GiayToTuyThan", models);
            }
            ViewBag.loaigiaytotuythan = DONDANGKYServices.getdm_loaigiaytotuythan();
            return PartialView("_GiayToTuyThan", models);
        }
        //xóa giấy tờ tùy thân
        public JsonResult XoaGiayToTuyThanCaNhan(string giaytoid, string idcanhan)
        {
            DC_CANHAN models = new DC_CANHAN();
            models = (DC_CANHAN)Session["Dk_ChuCaNhan"];
            ViewBag.loaigiaytotuythan = DONDANGKYServices.getdm_loaigiaytotuythan();
            giaytoid = giaytoid.Trim();
            idcanhan = idcanhan.Trim();
            DC_GIAYTOTUYTHAN moveobj = new DC_GIAYTOTUYTHAN();
            foreach (var item in models.DSGiayToTuyThan)
            {
                if (item.GIAYTOTUYTHANID == giaytoid)
                {
                    // models.GTTT_listFind.Remove(item);
                    moveobj = item;
                }
            }
            if (moveobj.GIAYTOTUYTHANID != null)
            {
                models.DSGiayToTuyThan.Remove(moveobj);
            }
            Session["Dk_ChuCaNhan"] = models;
            VM_XuLyHoSo_DK GetObject = (VM_XuLyHoSo_DK)Session["lstDsChuDk_" + CurrentUser.UserName];
            foreach (var item in GetObject.CHU_DANGKY)
            {
                if (item.LOAI == 1)
                {
                    if (item.Chu.CaNhan.CANHANID == idcanhan)
                    {
                        if (item.Chu.CaNhan.TRANGTHAI != 1)
                        {
                            item.Chu.CaNhan.TRANGTHAI = 2;
                            item.Chu.TRANGTHAI_NGUOI = 2;
                        }


                    }

                }
                else if (item.LOAI == 4)
                {
                    if (item.Chu.ToChuc.NGUOIDAIDIENID == idcanhan)
                    {
                        if (item.Chu.CaNhan.TRANGTHAI != 1)
                        {
                            //  item.Chu.CaNhan.TRANGTHAI = 2;
                            item.Chu.TRANGTHAI_NGUOI = 2;
                        }


                    }
                }
                else if (item.LOAI == 5)
                {
                    if (item.Chu.CongDong.NGUOIDAIDIENID == idcanhan)
                    {
                        if (item.Chu.CaNhan.TRANGTHAI != 1)
                        {
                            //  item.Chu.CaNhan.TRANGTHAI = 2;
                            item.Chu.TRANGTHAI_NGUOI = 2;
                        }


                    }
                }
            }
            return Json(models, JsonRequestBehavior.AllowGet);
        }
        //sửa giấy tờ tùy thân cá nhân
        public JsonResult SuaGiayToTuyThanCaNhan(string giaytoid, string idcanhan)
        {
            ViewBag.loaigiaytotuythan = DONDANGKYServices.getdm_loaigiaytotuythan();
            DC_GIAYTOTUYTHAN models = new DC_GIAYTOTUYTHAN();
            giaytoid = giaytoid.Trim();
            idcanhan = idcanhan.Trim();
            if (giaytoid != "")
            {
                using (MplisEntities dbo = new MplisEntities())
                {
                    var objgiaytotuythan = (from item in dbo.DC_GIAYTOTUYTHAN where item.CANHANID == idcanhan && item.GIAYTOTUYTHANID == giaytoid select item).FirstOrDefault();
                    if (objgiaytotuythan != null)
                    {
                        Mapper.Map<DC_GIAYTOTUYTHAN, DC_GIAYTOTUYTHAN>(objgiaytotuythan, models);
                        //models.SOGIAYTOTUYTHAN = objgiaytotuythan.SOGIAYTO;
                        //models.NOICAPTUYTHAN = objgiaytotuythan.NOICAP;
                        //models.NGAYCAPTUYTHAN = objgiaytotuythan.NGAYCAP;
                    }
                    else
                    {
                        DC_CANHAN getmodels = new DC_CANHAN();
                        getmodels = (DC_CANHAN)Session["Dk_ChuCaNhan"];
                        foreach (var item in getmodels.DSGiayToTuyThan)
                        {
                            if (item.GIAYTOTUYTHANID == giaytoid)
                            {
                                Mapper.Map<DC_GIAYTOTUYTHAN, DC_GIAYTOTUYTHAN>(item, models);
                                models.CANHANID = idcanhan;
                                models.GIAYTOTUYTHANID = giaytoid;
                                break;
                            }
                        }
                        // return Json(models, JsonRequestBehavior.AllowGet);

                    }
                    //    return PartialView("_GiayToTuyThan", models);
                    return Json(models, JsonRequestBehavior.AllowGet);
                }
            }
            else
                return Json(null, JsonRequestBehavior.AllowGet);


        }
        #endregion
        #region Thông tin chủ đăng ký
        #region chủ cá nhân
        // lưu thông tin chủ
        public JsonResult Save_formDonDangKy_DSCHU()
        {
            try
            {
                VM_XuLyHoSo_DK GetObject = (VM_XuLyHoSo_DK)Session["lstDsChuDk_" + CurrentUser.UserName];
                var ketqua = DONDANGKYServices.SaveChuDangky(GetObject);


                if (ketqua == true)
                {
                    BoHoSoModel bhs = (BoHoSoModel)Session["BoHoSo_" + CurrentUser.UserName];
                    bhs.HoSoTN.DonDangKy.DSDangKyChu = GetObject.CHU_DANGKY;
                    for (var i = 0; i <= GetObject.CHU_DANGKY.Count - 1; i++)
                    {
                        if (GetObject.CHU_DANGKY[i].Chu.TRANGTHAI_NGUOI == 3)
                        {
                            GetObject.CHU_DANGKY.RemoveAt(i);
                        }
                        else
                        {
                            GetObject.CHU_DANGKY[i].Chu.TRANGTHAI_NGUOI = 0;
                        }
                    }
                    return Json("true", JsonRequestBehavior.AllowGet);
                }
                else
                { return Json("false", JsonRequestBehavior.AllowGet); }

            }
            catch (Exception ex)
            {
                return Json("false", JsonRequestBehavior.AllowGet);
                throw;
            }

        }

        public ActionResult _Dk_ChuCaNhan_GiayTo()
        {
            var models = new DC_CANHAN();
            ViewBag.listdantoc = DONDANGKYServices.getdm_dantoc();
            ViewBag.listquoctich = DONDANGKYServices.getdm_quoctich();

            ViewBag.loaigiaytotuythan = DONDANGKYServices.getdm_loaigiaytotuythan();
            ViewBag.gioitinh = DONDANGKYServices.getdm_gioitinh();
            models.CANHANID = Guid.NewGuid().ToString();
            //   models.DSGiayToTuyThan = new List<DC_GIAYTOTUYTHAN>();
            //models.NGUOIID = Guid.NewGuid().ToString();
            Session["Dk_ChuCaNhan"] = models;
            return PartialView("_Dk_ChuCaNhan_GiayTo", models);
        }
        public ActionResult _Dk_ChuCaNhan()
        {
            ViewBag.listdantoc = DONDANGKYServices.getdm_dantoc();
            ViewBag.listquoctich = DONDANGKYServices.getdm_quoctich();
            ViewBag.gioitinh = DONDANGKYServices.getdm_gioitinh();
            //ViewBag.listdenghi = getdm_denghi();
            //ViewBag.listLoai = getdm_lachu();

            return PartialView("_Dk_ChuCaNhan");
        }

        public ActionResult ThemMoiDK_CaNhan(DC_CANHAN models)
        {
            VM_XuLyHoSo_DK GetObject = (VM_XuLyHoSo_DK)Session["lstDsChuDk_" + CurrentUser.UserName];

            DC_CANHAN cur = new DC_CANHAN();
            // Session["Dk_ChuCaNhan"] = models;
            cur = (DC_CANHAN)Session["Dk_ChuCaNhan"];
            models.DSGiayToTuyThan = cur.DSGiayToTuyThan;
            var them = false;
            string nguoiid = "", canhanid = "", hoten = "", cmt = "";
            //using (MplisEntities db = new MplisEntities())
            //{
            if (models.CANHANID == null || models.CANHANID == "" || models.NGUOIID == null || models.NGUOIID == "")
            {
                them = true;
                DC_DANGKY_NGUOI objdknguoi = new DC_DANGKY_NGUOI();
                DC_NGUOI objchu = new DC_NGUOI();
                objchu.CaNhan = new DC_CANHAN();
                //  models.GIOITINH = decimal.Parse(models.GIOITINH.Value.ToString());
                objchu.CaNhan = models;
                objchu.TRANGTHAI_NGUOI = 1;
                objchu.LOAIDOITUONGID = "1";
                canhanid = models.CANHANID;
                nguoiid = objdknguoi.NGUOIID = objchu.NGUOIID = Guid.NewGuid().ToString();
                objdknguoi.LOAI = 1;
                objdknguoi.DONDANGKYID = GetObject.DONDANGKYID;
                cmt = objdknguoi.Chu_CMT = models.SOGIAYTO;
                objdknguoi.Chu_DiaChi = models.DIACHI;
                objdknguoi.Chu_TenLoaiChu = "Cá nhân";

                hoten = objdknguoi.Chu_HoTen = models.HODEM + " " + models.TEN;
                objdknguoi.Chu = objchu;
                GetObject.CHU_DANGKY.Add(objdknguoi);
            }
            //Cập nhật cá nhân đăng ký
            else
            {
                //int i = 0;
                foreach (var item in GetObject.CHU_DANGKY)
                {
                    if (item.NGUOIID == models.NGUOIID)
                    {
                        // var objcanhan = (from a in GetObject.CHU_DANGKY[i].lst_ChuCaNhan where a.CANHANID == models.CANHANID select a).FirstOrDefault();
                        if (item.Chu.CaNhan != null)
                        {
                            //trạng thái chủ là sửa trạng thái = 2;
                            if (item.Chu.TRANGTHAI_NGUOI != 1)
                            {
                                item.Chu.TRANGTHAI_NGUOI = 2;
                            }
                            canhanid = item.Chu.CaNhan.CANHANID;
                            //    item.Chu.CaNhan.GIOITINH = decimal.Parse(item.Chu.CaNhan.GIOITINH.Value.ToString());
                            Mapper.Map<DC_CANHAN, DC_CANHAN>(models, item.Chu.CaNhan);
                            hoten = item.Chu.CaNhan.HOTEN = item.Chu.CaNhan.HODEM + " " + item.Chu.CaNhan.TEN;
                            cmt = item.Chu.CaNhan.SOGIAYTO;
                            nguoiid = models.NGUOIID;
                            item.LOAI = 1;
                            break;
                        }
                    }
                }
            }
            var result = new { NGUOIID = nguoiid, CANHANID = canhanid, HOTEN = hoten, CMT = cmt, LOAICHU = "Cá nhân", themmoi = them, LOAICHUID = "1" };
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        // tìm kiếm cá nhân
        public ActionResult SearchCaNhan(string socmt)
        {
            // List<DC_NGUOI_CaNhan> listCaNhan1 = new List<DC_NGUOI_CaNhan>();
            //  IQueryable<DC_NGUOI_CaNhan> listCaNhan1;
            var CNN_listFind = new List<DC_NGUOI_SearchNguoi>();
            CNN_listFind = DONDANGKYServices.searchcanhan(socmt);
            return Json(CNN_listFind);
        }
        // giay to tuy than
        public ActionResult _GiayToTuyThan()
        {
            //var models = new DC_NGUOI_CreateGIAYTOTUYTHAN();
            //ViewBag.loaigiaytotuythan = getdm_loaigiaytotuythan();
            ViewBag.loaigiaytotuythan = DONDANGKYServices.getdm_loaigiaytotuythan();
            return PartialView("_GiayToTuyThan");
        }
        public ActionResult _TimKiemCaNhan()
        {
            return PartialView("_TimKiemCaNhan");
        }

        public ActionResult ChiTietChuCaNhan(string idnguoi, string dondangkyid)
        {
            idnguoi = idnguoi.Trim();
            VM_XuLyHoSo_DK objVMDonDangKy = new VM_XuLyHoSo_DK();
            objVMDonDangKy = (VM_XuLyHoSo_DK)Session["lstDsChuDk_" + CurrentUser.UserName];
            DC_CANHAN models = new DC_CANHAN();
            //cá nhân
            if (idnguoi != "")
            {
                foreach (var item in objVMDonDangKy.CHU_DANGKY)
                {
                    if (item.NGUOIID == idnguoi)
                    {
                        models = item.Chu.CaNhan;
                        models.DSGiayToTuyThan = DONDANGKYServices.getgiaytotuythan(models.DSGiayToTuyThan);
                        break;
                    }
                }


            }
            ViewBag.listdantoc = DONDANGKYServices.getdm_dantoc();
            ViewBag.listquoctich = DONDANGKYServices.getdm_quoctich();
            ViewBag.gioitinh = DONDANGKYServices.getdm_gioitinh();
            ViewBag.loaigiaytotuythan = DONDANGKYServices.getdm_loaigiaytotuythan();
            // models.GTTT_listFind
            //return Json(models, JsonRequestBehavior.AllowGet);
            models.isHasHeader = true;
            Session["Dk_ChuCaNhan"] = models;
            //models.GIOITINH = decimal.Parse(models.GIOITINH.Value.ToString());
            return PartialView("_Dk_ChuCaNhan_GiayTo", models);
        }


        // hiển thị tìm kiếm cá nhân
        public ActionResult ChonCaNhan(string canhanid)
        {
            var models = new DC_CANHAN();
            ViewBag.listdantoc = DONDANGKYServices.getdm_dantoc();
            ViewBag.listquoctich = DONDANGKYServices.getdm_quoctich();
            ViewBag.gioitinh = DONDANGKYServices.getdm_gioitinh();
            ViewBag.listdenghi = DONDANGKYServices.getdm_denghi();
            ViewBag.listLoai = DONDANGKYServices.getdm_lachu();
            ViewBag.loaigiaytotuythan = DONDANGKYServices.getdm_loaigiaytotuythan();
            using (MplisEntities dbo = new MplisEntities())
            {
                var objcanhan = (from item in dbo.DC_CANHAN where item.CANHANID == canhanid select item).FirstOrDefault();
                if (objcanhan != null)
                {
                    Mapper.Map<DC_CANHAN, DC_CANHAN>(objcanhan, models);
                    var lstgiayto = (from item in dbo.DC_GIAYTOTUYTHAN where item.CANHANID == objcanhan.CANHANID select item);
                    //models.GTTT_listFind = new List<DC_NGUOI_CreateGIAYTOTUYTHAN>();
                    foreach (var c in lstgiayto)
                    {
                        DC_GIAYTOTUYTHAN objgiayto = new DC_GIAYTOTUYTHAN();
                        Mapper.Map<DC_GIAYTOTUYTHAN, DC_GIAYTOTUYTHAN>(c, objgiayto);
                        //get tên giấy tờ tùy thân
                        var objtengiayto = (from item in dbo.DM_LOAIGIAYTOTUYTHAN where item.LOAIGIAYTOTUYTHANID == c.LOAIGIAYTOTUYTHANID select item).FirstOrDefault();
                        if (objtengiayto != null)
                        {
                            objgiayto.TenGiayToTuyThan = objtengiayto.TENLOAIGIAYTOTUYTHAN;
                        }
                        models.DSGiayToTuyThan.Add(objgiayto);
                    }
                }
                Session["Dk_ChuCaNhan"] = models;
            }
            return PartialView("_Dk_ChuCaNhan_GiayTo", models);
        }
        #endregion

        #region Chủ hộ gia đình
        public ActionResult LoadHoGiaDinh()
        {
            var objcanhan = new DC_CANHAN();
            Session["Dk_ChuCaNhan"] = objcanhan;
            var models = new DC_HOGIADINH();
            //Session["Dk_ChuCaNhan"] = models;
            models.TRANGTHAI = 1;
            Session["Dk_ChuHoGiaDinh"] = models;
            // models.HOGIADINHID = Guid.NewGuid().ToString();
            ViewBag.listdantoc = DONDANGKYServices.getdm_dantoc();
            ViewBag.listquoctich = DONDANGKYServices.getdm_quoctich();
            ViewBag.gioitinh = DONDANGKYServices.getdm_gioitinh();
            ViewBag.loaigiaytotuythan = DONDANGKYServices.getdm_loaigiaytotuythan();
            return PartialView("_Dk_HoGiaDinh_CaNhan", models);
        }
        //public ActionResult LuuThanhVienHoGiaDinh(DC_CANHAN models)
        //{
        //    var objhogiadinh = new DC_HOGIADINH();
        //    DC_CANHAN curcanhan = new DC_CANHAN();
        //    curcanhan = (DC_CANHAN)Session["Dk_ChuCaNhan"];
        //    objhogiadinh = (DC_HOGIADINH)Session["Dk_ChuHoGiaDinh"];

        //    //thêm mới cá nhân cho chủ hộ
        //    if (models.NGUOIID == null || models.NGUOIID == "")
        //    {
        //        models.DSGiayToTuyThan = curcanhan.DSGiayToTuyThan;

        //        models.NGUOIID = Guid.NewGuid().ToString();
        //        //  models.CANHANID = Guid.NewGuid().ToString();
        //        if (models.DSGiayToTuyThan != null)
        //        {
        //            foreach (var item in models.DSGiayToTuyThan)
        //            {
        //                if (item != null)
        //                    item.CANHANID = models.CANHANID;
        //            }
        //        }
        //        // objhogiadinh.DSThanhVien = new List<DC_HOGIADINH_THANHVIEN>();
        //        //1: chủ hộ 
        //        //2 : vợ/chồng
        //        //3 : thành viên
        //        if (models.DOI_TUONG == "1")
        //        {
        //            models.TRANGTHAI = 1;
        //            objhogiadinh.ChuHoCN = models;
        //            objhogiadinh.ChuHoCN.HOTEN = models.HODEM + " " + models.TEN;
        //            objhogiadinh.CHUHO = models.CANHANID;
        //            DC_HOGIADINH_THANHVIEN objthanhvien = new DC_HOGIADINH_THANHVIEN();
        //            objthanhvien.ThanhVien = models;
        //            objthanhvien.HOGIADINHID = objhogiadinh.HOGIADINHID;
        //            objthanhvien.CANHANID = models.CANHANID;
        //            objthanhvien.QUANHEVOICHUHO = "Chủ hộ";
        //            objhogiadinh.DSThanhVien.Add(objthanhvien);
        //            //     objhogiadinh.ChuHoCN.CANHANID = models.CANHANID;
        //        }
        //        else if (models.DOI_TUONG == "2")
        //        {
        //            models.TRANGTHAI = 1;
        //            objhogiadinh.VoChongCN = models;
        //            objhogiadinh.VoChongCN.HOTEN = models.HODEM + " " + models.TEN;
        //            objhogiadinh.VOCHONG = models.CANHANID;
        //            DC_HOGIADINH_THANHVIEN objthanhvien = new DC_HOGIADINH_THANHVIEN();
        //            objthanhvien.ThanhVien = models;
        //            objthanhvien.HOGIADINHID = objhogiadinh.HOGIADINHID;
        //            objthanhvien.CANHANID = models.CANHANID;
        //            objthanhvien.QUANHEVOICHUHO = "Vợ/Chồng";
        //            objhogiadinh.DSThanhVien.Add(objthanhvien);
        //        }
        //        else if (models.DOI_TUONG == "3")
        //        {
        //            DC_HOGIADINH_THANHVIEN objthanhvien = new DC_HOGIADINH_THANHVIEN();
        //            objthanhvien.QUANHEVOICHUHO = "Con";
        //            objthanhvien.HOGIADINHID = objhogiadinh.HOGIADINHID;
        //            objthanhvien.ThanhVien = new DC_CANHAN();
        //            Mapper.Map<DC_CANHAN, DC_CANHAN>(models, objthanhvien.ThanhVien);
        //            objthanhvien.ThanhVien.TRANGTHAI = 1;
        //            objthanhvien.CANHANID = objthanhvien.ThanhVien.CANHANID;
        //            objhogiadinh.DSThanhVien.Add(objthanhvien);
        //        }
        //    }
        //    else
        //    {
        //        models.DSGiayToTuyThan = curcanhan.DSGiayToTuyThan;
        //        //1: chủ hộ 
        //        //2 : vợ/chồng
        //        //3 : thành viên
        //        if (models.DOI_TUONG == "1")
        //        {
        //            models.TRANGTHAI = 2;
        //            Mapper.Map<DC_CANHAN, DC_CANHAN>(models, objhogiadinh.ChuHoCN);
        //            objhogiadinh.ChuHoCN.HOTEN = models.HODEM + " " + models.TEN;
        //            // objhogiadinh.CHUHO = models.CANHANID;
        //        }
        //        else if (models.DOI_TUONG == "2")
        //        {
        //            models.TRANGTHAI = 2;
        //            Mapper.Map<DC_CANHAN, DC_CANHAN>(models, objhogiadinh.VoChongCN);
        //        }
        //        else if (models.DOI_TUONG == "3")
        //        {

        //            foreach (var item in objhogiadinh.DSThanhVien)
        //            {
        //                if (item.CANHANID == models.CANHANID)
        //                {
        //                    Mapper.Map<DC_CANHAN, DC_CANHAN>(models, item.ThanhVien);
        //                    item.ThanhVien.TRANGTHAI = 2;
        //                }
        //            }
        //        }

        //    }
        //    Session["Dk_ChuCaNhan"] = models;
        //    //get danh sách hiển thị hộ gia đình
        //    objhogiadinh = DONDANGKYServices.getdshienthi(objhogiadinh);
        //    ViewBag.listdantoc = DONDANGKYServices.getdm_dantoc();
        //    ViewBag.listquoctich = DONDANGKYServices.getdm_quoctich();
        //    ViewBag.loaigiaytotuythan = DONDANGKYServices.getdm_loaigiaytotuythan();
        //    ViewBag.gioitinh = DONDANGKYServices.getdm_gioitinh();
        //    return PartialView("_Dk_HoGiaDinh_CaNhan", objhogiadinh);

        //}

        public ActionResult Loadcanhanhogiadinh(string canhan)
        {
            canhan = canhan.Trim();
            var objhogiadinh = new DC_HOGIADINH();
            DC_CANHAN curcanhan = new DC_CANHAN();
            //curcanhan = (DangKyChuCaNhan)Session["Dk_ChuCaNhan"];
            objhogiadinh = (DC_HOGIADINH)Session["Dk_ChuHoGiaDinh"];
            //load chủ hộ
            if (canhan == objhogiadinh.CHUHO)
            {

                curcanhan = objhogiadinh.ChuHoCN;
                curcanhan.DOI_TUONG = "1";
                if (objhogiadinh.ChuHoCN.DSGiayToTuyThan != null)
                {
                    if (objhogiadinh.ChuHoCN.DSGiayToTuyThan.Count > 0)
                    {
                        objhogiadinh.ChuHoCN.DSGiayToTuyThan = DONDANGKYServices.getgiaytotuythan(objhogiadinh.ChuHoCN.DSGiayToTuyThan);
                    }
                }

            }
            //load vợ chồng
            else if (canhan == objhogiadinh.VOCHONG)
            {
                curcanhan = objhogiadinh.VoChongCN;
                curcanhan.DOI_TUONG = "2";
                if (objhogiadinh.VoChongCN.DSGiayToTuyThan != null)
                {
                    if (objhogiadinh.VoChongCN.DSGiayToTuyThan.Count > 0)
                    {
                        objhogiadinh.VoChongCN.DSGiayToTuyThan = DONDANGKYServices.getgiaytotuythan(objhogiadinh.VoChongCN.DSGiayToTuyThan);
                    }
                }
            }
            else
            {
                foreach (var item in objhogiadinh.DSThanhVien)
                {
                    if (canhan == item.ThanhVien.CANHANID)
                    {
                        curcanhan = item.ThanhVien;
                        curcanhan.DOI_TUONG = "3";
                        if (item.ThanhVien.DSGiayToTuyThan.Count > 0)
                        {
                            item.ThanhVien.DSGiayToTuyThan = DONDANGKYServices.getgiaytotuythan(item.ThanhVien.DSGiayToTuyThan);
                        }
                        break;
                    }
                }
            }

            Session["Dk_ChuCaNhan"] = curcanhan;
            ViewBag.listdantoc = DONDANGKYServices.getdm_dantoc();
            ViewBag.listquoctich = DONDANGKYServices.getdm_quoctich();
            ViewBag.loaigiaytotuythan = DONDANGKYServices.getdm_loaigiaytotuythan();
            ViewBag.gioitinh = DONDANGKYServices.getdm_gioitinh();
            return PartialView("_Dk_ChuCaNhan_GiayTo", curcanhan);
            // return View();

        }


        public ActionResult ThemDanhSachHoGiaDinh(string diachi, string dondangky)
        {
            string nguoiid = "", canhanid = "", hoten = "", cmt = "";
            bool them = false;
            VM_XuLyHoSo_DK GetObject = (VM_XuLyHoSo_DK)Session["lstDsChuDk_" + CurrentUser.UserName];
            var objhogiadinh = new DC_HOGIADINH();
            objhogiadinh = (DC_HOGIADINH)Session["Dk_ChuHoGiaDinh"];
            bool tontaihocosan = false;
            for (int i = 0; i < GetObject.CHU_DANGKY.Count; i++)
            {
                if (GetObject.CHU_DANGKY[i].LOAI == 2)
                {
                    if (objhogiadinh.HOGIADINHID == GetObject.CHU_DANGKY[i].Chu.HoGiaDinh.HOGIADINHID)
                    {
                        tontaihocosan = true;
                        break;
                    }
                }
            }

            if (objhogiadinh.HOGIADINHID == "" || objhogiadinh.HOGIADINHID == null)
            {
                them = true;
                objhogiadinh.HOGIADINHID = Guid.NewGuid().ToString();
                objhogiadinh.DIACHI = diachi;

                //objhogiadinh.HOGIADINHID = Guid.NewGuid().ToString();
                DC_DANGKY_NGUOI objdangkynguoi = new DC_DANGKY_NGUOI();
                nguoiid = objdangkynguoi.NGUOIID = Guid.NewGuid().ToString();
                objdangkynguoi.LOAI = 2;
                objdangkynguoi.Chu = new DC_NGUOI();
                objdangkynguoi.Chu.HoGiaDinh = new DC_HOGIADINH();
                objdangkynguoi.Chu.HoGiaDinh = objhogiadinh;
                hoten = objdangkynguoi.Chu_HoTen = objhogiadinh.ChuHoCN.TEN + "," + objhogiadinh.VoChongCN.TEN;
                cmt = objdangkynguoi.Chu_CMT = objhogiadinh.ChuHoCN.SOGIAYTO + "," + objhogiadinh.VoChongCN.SOGIAYTO;
                objdangkynguoi.Chu_TenLoaiChu = "Hộ gia đình";
                objdangkynguoi.Chu.NGUOIID = Guid.NewGuid().ToString();
                objdangkynguoi.Chu.CHITIETID = objhogiadinh.HOGIADINHID;
                objdangkynguoi.Chu.LOAIDOITUONGID = "2";
                objdangkynguoi.Chu.TRANGTHAI_NGUOI = 1;
                objdangkynguoi.Chu.HoGiaDinh.CMTCHUHO = objhogiadinh.ChuHoCN.SOGIAYTO;
                objdangkynguoi.Chu.HoGiaDinh.CMTVOCHONG = objhogiadinh.VoChongCN.SOGIAYTO;
                objdangkynguoi.DONDANGKYID = dondangky;
                GetObject.CHU_DANGKY.Add(objdangkynguoi);
            }
            else if (objhogiadinh.HOGIADINHID != "" && objhogiadinh.HOGIADINHID != null && tontaihocosan == false)
            {
                them = true;
                //   objhogiadinh.HOGIADINHID = Guid.NewGuid().ToString();
                objhogiadinh.DIACHI = diachi;

                //objhogiadinh.HOGIADINHID = Guid.NewGuid().ToString();
                DC_DANGKY_NGUOI objdangkynguoi = new DC_DANGKY_NGUOI();
                nguoiid = objdangkynguoi.NGUOIID = Guid.NewGuid().ToString();
                objdangkynguoi.LOAI = 2;
                objdangkynguoi.Chu = new DC_NGUOI();
                objdangkynguoi.Chu.HoGiaDinh = new DC_HOGIADINH();
                objdangkynguoi.Chu.HoGiaDinh = objhogiadinh;
                hoten = objdangkynguoi.Chu_HoTen = objhogiadinh.ChuHoCN.TEN + "," + objhogiadinh.VoChongCN.TEN;
                cmt = objdangkynguoi.Chu_CMT = objhogiadinh.ChuHoCN.SOGIAYTO + "," + objhogiadinh.VoChongCN.SOGIAYTO;
                objdangkynguoi.Chu_TenLoaiChu = "Hộ gia đình";
                objdangkynguoi.Chu.NGUOIID = Guid.NewGuid().ToString();
                objdangkynguoi.Chu.CHITIETID = objhogiadinh.HOGIADINHID;
                objdangkynguoi.Chu.LOAIDOITUONGID = "2";
                objdangkynguoi.Chu.TRANGTHAI_NGUOI = 1;
                objdangkynguoi.Chu.HoGiaDinh.CMTCHUHO = objhogiadinh.ChuHoCN.SOGIAYTO;
                objdangkynguoi.Chu.HoGiaDinh.CMTVOCHONG = objhogiadinh.VoChongCN.SOGIAYTO;
                objdangkynguoi.DONDANGKYID = dondangky;
                GetObject.CHU_DANGKY.Add(objdangkynguoi);
            }
            //cập nhật
            else
            {

                for (int i = 0; i < GetObject.CHU_DANGKY.Count; i++)
                {
                    if (GetObject.CHU_DANGKY[i].LOAI == 2)
                    {
                        if (GetObject.CHU_DANGKY[i].Chu.HoGiaDinh.HOGIADINHID == objhogiadinh.HOGIADINHID)
                        {
                            GetObject.CHU_DANGKY[i].Chu.TRANGTHAI_NGUOI = 2;
                            objhogiadinh.DIACHI = diachi;
                            // Mapper.Map<DangKyChuHoGiaDinh, DangKyChuHoGiaDinh>(objhogiadinh, GetObject.CHU_DANGKY[i].lst_HoGiaDinh[0]);
                            GetObject.CHU_DANGKY[i].Chu.HoGiaDinh = objhogiadinh;
                            nguoiid = GetObject.CHU_DANGKY[i].NGUOIID;
                            hoten = objhogiadinh.ChuHoCN.TEN + " ," + objhogiadinh.VoChongCN.TEN;

                            cmt = objhogiadinh.ChuHoCN.SOGIAYTO + " ," + objhogiadinh.VoChongCN.SOGIAYTO;
                            //  GetObject.CHU_DANGKY[i].DONDANGKYID = GetObject.CHU_DANGKY[0].DONDANGKYID;
                            break;
                        }
                    }
                }

            }
            var result = new { NGUOIID = nguoiid, CANHANID = canhanid, HOTEN = hoten, CMT = cmt, LOAICHU = "Hộ gia đình", themmoi = them, LOAICHUID = "2" };
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        // chi tiết 
        public ActionResult ChiTietHoGiaDinh(string idnguoi, string loaichu)
        {
            VM_XuLyHoSo_DK GetObject = (VM_XuLyHoSo_DK)Session["lstDsChuDk_" + CurrentUser.UserName];
            var models = new DC_HOGIADINH();


            foreach (var item in GetObject.CHU_DANGKY)
            {
                //loại chủ hộ gia đình
                if (loaichu == "2")
                {
                    if (item.NGUOIID == idnguoi)
                    {
                        models = item.Chu.HoGiaDinh;
                        //  models= DONDANGKYServices.DsHienThi(models);
                        break;
                    }
                }
            }
            ViewBag.listdantoc = DONDANGKYServices.getdm_dantoc();
            ViewBag.listquoctich = DONDANGKYServices.getdm_quoctich();
            ViewBag.gioitinh = DONDANGKYServices.getdm_gioitinh();
            models = DONDANGKYServices.getdshienthi(models);
            Session["Dk_ChuHoGiaDinh"] = models;
            ViewBag.loaigiaytotuythan = DONDANGKYServices.getdm_loaigiaytotuythan();
            return PartialView("_Dk_HoGiaDinh_CaNhan", models);
        }
        //xóa thành viên hộ gia đình
        public ActionResult Xoathanhvien(string idcanhan)
        {
            var models = new DC_HOGIADINH();
            //Session["Dk_ChuCaNhan"] = models;
            models = (DC_HOGIADINH)Session["Dk_ChuHoGiaDinh"];
            idcanhan = idcanhan.Trim();
            if (models.TRANGTHAI == 1)
            {
                if (idcanhan == models.CHUHO)
                {
                    var dstv = models.DSThanhVien;
                    foreach (var objthanhvien in models.DSThanhVien)
                    {
                        if (idcanhan == objthanhvien.CANHANID)
                        {
                            dstv.Remove(objthanhvien);
                            break;
                        }
                    }
                    models.DSThanhVien = dstv;
                    models.CHUHO = null;
                    models.ChuHoCN = new DC_CANHAN();
                }
                else if (idcanhan == models.VOCHONG)
                {
                    var dstv = models.DSThanhVien;
                    foreach (var objthanhvien in models.DSThanhVien)
                    {
                        if (idcanhan == objthanhvien.CANHANID)
                        {
                            dstv.Remove(objthanhvien);
                            break;
                        }
                    }
                    models.DSThanhVien = dstv;
                    models.VOCHONG = null;
                    models.VoChongCN = new DC_CANHAN();
                }
                else
                {
                    foreach (var objthanhvien in models.DSThanhVien)
                    {
                        if (idcanhan == objthanhvien.CANHANID)
                        {
                            models.DSThanhVien.Remove(objthanhvien);
                        }
                    }
                    foreach (var objhienthi in models.DSHienThi)
                    {
                        if (idcanhan == objhienthi.CANHANID)
                        {
                            models.DSHienThi.Remove(objhienthi);
                        }
                    }
                }
            }
            else
            {
                //item.Chu.TRANGTHAI_NGUOI = 2;
                if (idcanhan == models.CHUHO)
                {

                    models.TRANGTHAI = 3;
                }
                else if (idcanhan == models.VOCHONG)
                {

                    models.VoChongCN.TRANGTHAI = 3;
                }
                else
                {
                    foreach (var objthanhvien in models.DSThanhVien)
                    {
                        if (idcanhan == objthanhvien.CANHANID)
                        {
                            objthanhvien.ThanhVien.TRANGTHAI = 3;
                            break;
                        }
                    }
                    foreach (var objhienthi in models.DSHienThi)
                    {
                        if (idcanhan == objhienthi.CANHANID)
                        {
                            models.DSHienThi.Remove(objhienthi);
                        }
                    }
                }

            }
            VM_XuLyHoSo_DK GetObject = (VM_XuLyHoSo_DK)Session["lstDsChuDk_" + CurrentUser.UserName];
            foreach (var item in GetObject.CHU_DANGKY)
            {
                if (item.LOAI == 2)
                {
                    if (item.Chu.HoGiaDinh.HOGIADINHID == models.HOGIADINHID)
                    {
                        if (item.Chu.TRANGTHAI_NGUOI != 1)
                        {
                            item.Chu.TRANGTHAI_NGUOI = 2;

                        }
                        item.Chu.HoGiaDinh = models;
                        break;
                    }
                }
            }
            return Json(models, JsonRequestBehavior.AllowGet);
        }

        // tìm kiếm hộ gia đình

        public ActionResult SearchHoGiaDinh(string socmt)
        {
            // List<DC_NGUOI_CaNhan> listCaNhan1 = new List<DC_NGUOI_CaNhan>();
            //  IQueryable<DC_NGUOI_CaNhan> listCaNhan1;
            var CNN_listFind = new List<DC_NGUOI_SearchHoGiaDinh>();
            CNN_listFind = DONDANGKYServices.searchHogiadinh(socmt);
            return Json(CNN_listFind);
        }
        //Chọn hộ gia đình

        public ActionResult ChonHoGiaDinh(string HOGIADINHID)
        {
            var models = new DC_HOGIADINH();
            ViewBag.listdantoc = DONDANGKYServices.getdm_dantoc();
            ViewBag.listquoctich = DONDANGKYServices.getdm_quoctich();
            ViewBag.gioitinh = DONDANGKYServices.getdm_gioitinh();
            DC_NGUOI objnguoi = new DC_NGUOI();
            objnguoi = DONDANGKYServices.GetNguoi(HOGIADINHID);
            models = objnguoi.HoGiaDinh;

            models = DONDANGKYServices.getdshienthi(models);
            Session["Dk_ChuHoGiaDinh"] = models;
            ViewBag.loaigiaytotuythan = DONDANGKYServices.getdm_loaigiaytotuythan();
            return PartialView("_Dk_HoGiaDinh_CaNhan", models);
        }
        #endregion

        #region chủ vợ chồng
        public ActionResult LoadVoChong()
        {
            var objcanhan = new DC_CANHAN();
            Session["Dk_ChuCaNhan"] = objcanhan;
            var models = new DC_VOCHONG();
            //Session["Dk_ChuCaNhan"] = models;
            models.TRANGTHAI = 1;
            Session["ChuVoChong"] = models;
            // models.HOGIADINHID = Guid.NewGuid().ToString();
            ViewBag.listdantoc = DONDANGKYServices.getdm_dantoc();
            ViewBag.listquoctich = DONDANGKYServices.getdm_quoctich();
            ViewBag.gioitinh = DONDANGKYServices.getdm_gioitinh();
            ViewBag.loaigiaytotuythan = DONDANGKYServices.getdm_loaigiaytotuythan();
            return PartialView("_Dk_VoChong_CaNhan", models);
        }
        public ActionResult LuuThanhVienVoChong(DC_CANHAN models)
        {
            var objvochong = new DC_VOCHONG();
            DC_CANHAN curcanhan = new DC_CANHAN();
            curcanhan = (DC_CANHAN)Session["Dk_ChuCaNhan"];
            objvochong = (DC_VOCHONG)Session["ChuVoChong"];
            //thêm mới cá nhân cho chủ hộ
            if (models.NGUOIID == null || models.NGUOIID == "")
            {
                models.DSGiayToTuyThan = curcanhan.DSGiayToTuyThan;
                models.NGUOIID = Guid.NewGuid().ToString();
                //  models.CANHANID = Guid.NewGuid().ToString();
                if (models.CANHANID == null)
                {
                    models.CANHANID = Guid.NewGuid().ToString();
                }
                if (models.DSGiayToTuyThan != null)
                {
                    foreach (var item in models.DSGiayToTuyThan)
                    {
                        item.CANHANID = models.CANHANID;
                    }
                }
                //1: chủ chồng 
                //2 : chủ vợ
                if (models.DOI_TUONG == "1")
                {
                    models.TRANGTHAI = 1;
                    objvochong.ChongCN = models;
                    objvochong.ChongCN.HOTEN = models.HODEM + " " + models.TEN;
                    objvochong.CHONG = models.CANHANID;
                }
                else if (models.DOI_TUONG == "2")
                {
                    models.TRANGTHAI = 1;
                    objvochong.VoCN = models;
                    objvochong.VoCN.HOTEN = models.HODEM + " " + models.TEN;
                    objvochong.VO = models.CANHANID;
                }
            }
            else
            {
                models.DSGiayToTuyThan = curcanhan.DSGiayToTuyThan;
                //1: chủ chồng 
                //2 : chủ vợ

                if (models.DOI_TUONG == "1")
                {
                    models.TRANGTHAI = 2;
                    Mapper.Map<DC_CANHAN, DC_CANHAN>(models, objvochong.ChongCN);
                    objvochong.ChongCN.HOTEN = models.HODEM + " " + models.TEN;

                }
                else if (models.DOI_TUONG == "2")
                {
                    models.TRANGTHAI = 2;
                    Mapper.Map<DC_CANHAN, DC_CANHAN>(models, objvochong.VoCN);
                }
            }
            Session["Dk_ChuCaNhan"] = models;
            ViewBag.listdantoc = DONDANGKYServices.getdm_dantoc();
            ViewBag.listquoctich = DONDANGKYServices.getdm_quoctich();
            ViewBag.gioitinh = DONDANGKYServices.getdm_gioitinh();
            ViewBag.loaigiaytotuythan = DONDANGKYServices.getdm_loaigiaytotuythan();
            return PartialView("_Dk_VoChong_CaNhan", objvochong);

        }

        public ActionResult LoadcanhanVoChong(string canhanid, string type)
        {
            canhanid = canhanid.Trim();
            var objvochong = new DC_VOCHONG();
            DC_CANHAN curcanhan = new DC_CANHAN();
            //curcanhan = (DangKyChuCaNhan)Session["Dk_ChuCaNhan"];
            objvochong = (DC_VOCHONG)Session["ChuVoChong"];
            //load chủ hộ
            if (type == "1")
            {
                // xem chi tiết

                if (canhanid == objvochong.CHONG)
                {
                    curcanhan = objvochong.ChongCN;
                    curcanhan.DOI_TUONG = "1";
                    if (objvochong.ChongCN != null && objvochong.ChongCN.DSGiayToTuyThan != null && objvochong.ChongCN.DSGiayToTuyThan.Count > 0)
                    {
                        objvochong.ChongCN.DSGiayToTuyThan = DONDANGKYServices.getgiaytotuythan(objvochong.ChongCN.DSGiayToTuyThan);
                    }
                }
            }
            else if (type == "2")
            {
                if (canhanid == objvochong.VO)
                {
                    curcanhan = objvochong.VoCN;
                    curcanhan.DOI_TUONG = "2";
                    if (objvochong.VoCN != null && objvochong.VoCN.DSGiayToTuyThan != null && objvochong.VoCN.DSGiayToTuyThan.Count > 0)
                    {
                        objvochong.VoCN.DSGiayToTuyThan = DONDANGKYServices.getgiaytotuythan(objvochong.VoCN.DSGiayToTuyThan);
                    }
                }
            }

            //load vợ chồng
            Session["Dk_ChuCaNhan"] = curcanhan;
            ViewBag.listdantoc = DONDANGKYServices.getdm_dantoc();
            ViewBag.listquoctich = DONDANGKYServices.getdm_quoctich();
            ViewBag.gioitinh = DONDANGKYServices.getdm_gioitinh();
            ViewBag.loaigiaytotuythan = DONDANGKYServices.getdm_loaigiaytotuythan();
            return PartialView("_Dk_ChuCaNhan_GiayTo", curcanhan);
            // return View();
        }

        public ActionResult ThemDanhSachVoChong(string diachi, string dondangky)
        {
            string nguoiid = "", canhanid = "", hoten = "", cmt = "";
            bool them = false;
            VM_XuLyHoSo_DK GetObject = (VM_XuLyHoSo_DK)Session["lstDsChuDk_" + CurrentUser.UserName];
            var objvochong = new DC_VOCHONG();
            objvochong = (DC_VOCHONG)Session["ChuVoChong"];
            bool tontaihocosan = false;
            for (int i = 0; i < GetObject.CHU_DANGKY.Count; i++)
            {
                if (GetObject.CHU_DANGKY[i].LOAI == 3)
                {
                    if (objvochong.VOCHONGID == GetObject.CHU_DANGKY[i].Chu.VoChong.VOCHONGID)
                    {
                        tontaihocosan = true;
                        break;
                    }
                }
            }

            if (objvochong.VOCHONGID == "" || objvochong.VOCHONGID == null)
            {
                them = true;
                objvochong.VOCHONGID = Guid.NewGuid().ToString();
                objvochong.DIACHI = diachi;

                //objhogiadinh.HOGIADINHID = Guid.NewGuid().ToString();
                DC_DANGKY_NGUOI objdangkynguoi = new DC_DANGKY_NGUOI();
                nguoiid = objdangkynguoi.NGUOIID = Guid.NewGuid().ToString();
                objdangkynguoi.LOAI = 3;
                objdangkynguoi.Chu = new DC_NGUOI();
                objdangkynguoi.Chu.VoChong = new DC_VOCHONG();
                objdangkynguoi.Chu.VoChong = objvochong;
                hoten = objdangkynguoi.Chu_HoTen = objvochong.ChongCN.TEN + "," + objvochong.VoCN.TEN;
                cmt = objdangkynguoi.Chu_CMT = objvochong.ChongCN.SOGIAYTO + "," + objvochong.VoCN.SOGIAYTO;
                objdangkynguoi.Chu_TenLoaiChu = "Chủ vợ chồng";
                objdangkynguoi.Chu.NGUOIID = Guid.NewGuid().ToString();
                objdangkynguoi.Chu.CHITIETID = objvochong.VOCHONGID;
                objdangkynguoi.Chu.LOAIDOITUONGID = "3";
                objdangkynguoi.Chu.TRANGTHAI_NGUOI = 1;
                objdangkynguoi.Chu.VoChong.CMTCHONG = objvochong.ChongCN.SOGIAYTO;
                objdangkynguoi.Chu.VoChong.CMTVO = objvochong.VoCN.SOGIAYTO;
                objdangkynguoi.DONDANGKYID = dondangky;
                GetObject.CHU_DANGKY.Add(objdangkynguoi);
            }
            else if (objvochong.VOCHONGID != "" && objvochong.VOCHONGID != null && tontaihocosan == false)
            {
                them = true;
                //   objhogiadinh.HOGIADINHID = Guid.NewGuid().ToString();
                objvochong.DIACHI = diachi;

                //objhogiadinh.HOGIADINHID = Guid.NewGuid().ToString();
                DC_DANGKY_NGUOI objdangkynguoi = new DC_DANGKY_NGUOI();
                nguoiid = objdangkynguoi.NGUOIID = Guid.NewGuid().ToString();
                objdangkynguoi.LOAI = 3;
                objdangkynguoi.Chu = new DC_NGUOI();
                objdangkynguoi.Chu.VoChong = new DC_VOCHONG();
                objdangkynguoi.Chu.VoChong = objvochong;
                hoten = objdangkynguoi.Chu_HoTen = objvochong.ChongCN.TEN + "," + objvochong.VoCN.TEN;
                cmt = objdangkynguoi.Chu_CMT = objvochong.ChongCN.SOGIAYTO + "," + objvochong.VoCN.SOGIAYTO;
                objdangkynguoi.Chu_TenLoaiChu = "Chủ vợ chồng";
                objdangkynguoi.Chu.NGUOIID = Guid.NewGuid().ToString();
                objdangkynguoi.Chu.CHITIETID = objvochong.VOCHONGID;
                objdangkynguoi.Chu.LOAIDOITUONGID = "3";
                objdangkynguoi.Chu.TRANGTHAI_NGUOI = 1;
                objdangkynguoi.Chu.VoChong.CMTCHONG = objvochong.ChongCN.SOGIAYTO;
                objdangkynguoi.Chu.VoChong.CMTVO = objvochong.VoCN.SOGIAYTO;
                objdangkynguoi.DONDANGKYID = dondangky;
                GetObject.CHU_DANGKY.Add(objdangkynguoi);
            }
            //cập nhật
            else
            {

                for (int i = 0; i < GetObject.CHU_DANGKY.Count; i++)
                {
                    if (GetObject.CHU_DANGKY[i].LOAI == 3)
                    {
                        if (GetObject.CHU_DANGKY[i].Chu.VoChong.VOCHONGID == objvochong.VOCHONGID)
                        {
                            GetObject.CHU_DANGKY[i].Chu.TRANGTHAI_NGUOI = 2;
                            objvochong.DIACHI = diachi;
                            GetObject.CHU_DANGKY[i].Chu.VoChong = objvochong;
                            nguoiid = GetObject.CHU_DANGKY[i].NGUOIID;
                            hoten = objvochong.ChongCN.TEN + " ," + objvochong.VoCN.TEN;
                            cmt = objvochong.ChongCN.SOGIAYTO + " ," + objvochong.VoCN.SOGIAYTO;
                            break;
                        }
                    }
                }

            }
            var result = new { NGUOIID = nguoiid, CANHANID = canhanid, HOTEN = hoten, CMT = cmt, LOAICHU = "Chủ vợ chồng", themmoi = them, LOAICHUID = "3" };
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        // chi tiết 
        public ActionResult ChiTietVoChong(string idnguoi, string loaichu)
        {
            VM_XuLyHoSo_DK GetObject = (VM_XuLyHoSo_DK)Session["lstDsChuDk_" + CurrentUser.UserName];
            var models = new DC_VOCHONG();


            foreach (var item in GetObject.CHU_DANGKY)
            {
                //loại chủ vợ chồng
                if (loaichu == "3")
                {
                    if (item.NGUOIID == idnguoi)
                    {
                        models = item.Chu.VoChong;
                        //  models= DONDANGKYServices.DsHienThi(models);
                        break;
                    }
                }
            }
            ViewBag.listdantoc = DONDANGKYServices.getdm_dantoc();
            ViewBag.listquoctich = DONDANGKYServices.getdm_quoctich();
            ViewBag.gioitinh = DONDANGKYServices.getdm_gioitinh();
            Session["ChuVoChong"] = models;
            ViewBag.loaigiaytotuythan = DONDANGKYServices.getdm_loaigiaytotuythan();
            return PartialView("_Dk_VoChong_CaNhan", models);
        }
        //xóa chủ vợ chồng
        public ActionResult XoacanhanVoChong(string canhanid, string type)
        {
            var models = new DC_VOCHONG();
            //Session["Dk_ChuCaNhan"] = models;
            models = (DC_VOCHONG)Session["ChuVoChong"];
            canhanid = canhanid.Trim();
            if (models.TRANGTHAI == 1)
            {
                if (canhanid == models.CHONG)
                {

                    models.CHONG = null;
                    models.ChongCN = new DC_CANHAN();
                }
                else if (canhanid == models.VO)
                {

                    models.VO = null;
                    models.VoCN = new DC_CANHAN();
                }

            }
            else
            {
                //item.Chu.TRANGTHAI_NGUOI = 2;
                if (canhanid == models.CHONG)
                {
                    //models.Chong.TRANGTHAI = 3;

                    models.CHONG = null;
                    models.ChongCN = new DC_CANHAN();
                }
                else if (canhanid == models.VO)
                {

                    //   models.Vo.TRANGTHAI = 3;
                    models.VO = null;
                    models.VoCN = new DC_CANHAN();
                }


            }
            VM_XuLyHoSo_DK GetObject = (VM_XuLyHoSo_DK)Session["lstDsChuDk_" + CurrentUser.UserName];
            foreach (var item in GetObject.CHU_DANGKY)
            {
                if (item.LOAI == 3)
                {
                    if (item.Chu.VoChong.VOCHONGID == models.VOCHONGID)
                    {
                        if (item.Chu.TRANGTHAI_NGUOI != 1)
                        {
                            item.Chu.TRANGTHAI_NGUOI = 2;

                        }
                        item.Chu.VoChong = models;
                        break;
                    }
                }
            }
            return Json(models, JsonRequestBehavior.AllowGet);
        }

        // tìm kiếm vợ chồng

        public ActionResult SearchVoChong(string socmt)
        {
            // List<DC_NGUOI_CaNhan> listCaNhan1 = new List<DC_NGUOI_CaNhan>();
            //  IQueryable<DC_NGUOI_CaNhan> listCaNhan1;
            var CNN_listFind = new List<DC_NGUOI_SearchVoChong>();
            CNN_listFind = DONDANGKYServices.searchVoChong(socmt);
            return Json(CNN_listFind);
        }
        //Chọn hộ vợ chồng

        public ActionResult ChonVoChong(string VOCHONGID)
        {
            var models = new DC_VOCHONG();
            ViewBag.listdantoc = DONDANGKYServices.getdm_dantoc();
            ViewBag.listquoctich = DONDANGKYServices.getdm_quoctich();
            ViewBag.gioitinh = DONDANGKYServices.getdm_gioitinh();
            DC_NGUOI objnguoi = new DC_NGUOI();
            objnguoi = DONDANGKYServices.Getvochong(VOCHONGID);
            models = objnguoi.VoChong;
            Session["ChuVoChong"] = models;
            ViewBag.loaigiaytotuythan = DONDANGKYServices.getdm_loaigiaytotuythan();
            return PartialView("_Dk_VoChong_CaNhan", models);
        }

        #endregion

        #region chủ tổ chức
        public ActionResult LoadToChuc()
        {
            var objcanhan = new DC_CANHAN();
            Session["Dk_ChuCaNhan"] = objcanhan;
            var models = new DC_TOCHUC();
            //Session["Dk_ChuCaNhan"] = models;
            models.TRANGTHAI = 1;
            Session["ChuToChuc"] = models;
            // models.HOGIADINHID = Guid.NewGuid().ToString();
            ViewBag.listdantoc = DONDANGKYServices.getdm_dantoc();
            ViewBag.listquoctich = DONDANGKYServices.getdm_quoctich();
            ViewBag.gioitinh = DONDANGKYServices.getdm_gioitinh();
            ViewBag.loaigiaytotuythan = DONDANGKYServices.getdm_loaigiaytotuythan();
            return PartialView("_Dk_ToChuc_CaNhan", models);
        }
        public ActionResult LuuThanhVienNguoiDaidien(DC_CANHAN models)
        {
            var objtochuc = new DC_TOCHUC();
            DC_CANHAN curcanhan = new DC_CANHAN();
            curcanhan = (DC_CANHAN)Session["Dk_ChuCaNhan"];
            objtochuc = (DC_TOCHUC)Session["ChuToChuc"];
            //thêm mới cá nhân  người đại diện cho tổ chức
            if (models.NGUOIID == null || models.NGUOIID == "")
            {
                models.DSGiayToTuyThan = curcanhan.DSGiayToTuyThan;
                models.NGUOIID = Guid.NewGuid().ToString();
                //  models.CANHANID = Guid.NewGuid().ToString();
                if (models.CANHANID == null)
                {
                    models.CANHANID = Guid.NewGuid().ToString();
                }
                if (models.DSGiayToTuyThan != null)
                {
                    foreach (var item in models.DSGiayToTuyThan)
                    {
                        if (item != null)
                        {
                            item.CANHANID = models.CANHANID;
                        }
                    }
                }
                // người đại điện

                models.TRANGTHAI = 1;
                objtochuc.NguoiDaiDien = models;
                // Mapper.Map<DC_CANHAN, DC_CANHAN>(models, objtochuc.NguoiDaiDien);
                objtochuc.NguoiDaiDien.HOTEN = models.HODEM + " " + models.TEN;
                objtochuc.NguoiDaiDien.CANHANID = models.CANHANID;
            }
            else
            {
                models.DSGiayToTuyThan = curcanhan.DSGiayToTuyThan;
                //1: chủ chồng 
                //2 : chủ vợ


                models.TRANGTHAI = 2;
                Mapper.Map<DC_CANHAN, DC_CANHAN>(models, objtochuc.NguoiDaiDien);
                objtochuc.NguoiDaiDien.HOTEN = models.HODEM + " " + models.TEN;

            }
            Session["Dk_ChuCaNhan"] = objtochuc.NguoiDaiDien;
            ViewBag.listdantoc = DONDANGKYServices.getdm_dantoc();
            ViewBag.listquoctich = DONDANGKYServices.getdm_quoctich();
            ViewBag.gioitinh = DONDANGKYServices.getdm_gioitinh();
            ViewBag.loaigiaytotuythan = DONDANGKYServices.getdm_loaigiaytotuythan();
            return PartialView("_Dk_ToChuc_CaNhan", objtochuc);

        }

        public ActionResult LoadcanhanNguoiDaiDien(string canhanid)
        {
            canhanid = canhanid.Trim();
            var objtochuc = new DC_TOCHUC();
            DC_CANHAN curcanhan = new DC_CANHAN();
            //curcanhan = (DangKyChuCaNhan)Session["Dk_ChuCaNhan"];
            objtochuc = (DC_TOCHUC)Session["ChuToChuc"];
            //load người đại diện tổ chức
            if (canhanid == objtochuc.NGUOIDAIDIENID)
            {
                curcanhan = objtochuc.NguoiDaiDien;

                if (objtochuc.NguoiDaiDien.DSGiayToTuyThan.Count > 0)
                {
                    objtochuc.NguoiDaiDien.DSGiayToTuyThan = DONDANGKYServices.getgiaytotuythan(objtochuc.NguoiDaiDien.DSGiayToTuyThan);
                }
            }
            Session["Dk_ChuCaNhan"] = curcanhan;
            ViewBag.listdantoc = DONDANGKYServices.getdm_dantoc();
            ViewBag.listquoctich = DONDANGKYServices.getdm_quoctich();
            ViewBag.gioitinh = DONDANGKYServices.getdm_gioitinh();
            ViewBag.loaigiaytotuythan = DONDANGKYServices.getdm_loaigiaytotuythan();
            return PartialView("_Dk_ChuCaNhan_GiayTo", curcanhan);
            // return View();
        }

        public ActionResult ThemDanhSachToChuc(DC_TOCHUC modelstochuc)
        {
            string nguoiid = "", canhanid = "", hoten = "", cmt = "";
            bool them = false;
            VM_XuLyHoSo_DK GetObject = (VM_XuLyHoSo_DK)Session["lstDsChuDk_" + CurrentUser.UserName];
            var objtochuc = new DC_TOCHUC();
            objtochuc = (DC_TOCHUC)Session["ChuToChuc"];
            bool tontaihocosan = false;
            for (int i = 0; i < GetObject.CHU_DANGKY.Count; i++)
            {
                if (GetObject.CHU_DANGKY[i].LOAI == 4)
                {
                    if (objtochuc.TOCHUCID == GetObject.CHU_DANGKY[i].Chu.ToChuc.TOCHUCID)
                    {
                        tontaihocosan = true;
                        break;
                    }
                }
            }

            if (objtochuc.TOCHUCID == "" || objtochuc.TOCHUCID == null)
            {
                them = true;
                DC_CANHAN nguoidaidien = new DC_CANHAN();
                nguoidaidien = objtochuc.NguoiDaiDien;
                objtochuc = modelstochuc;
                objtochuc.NguoiDaiDien = nguoidaidien;
                objtochuc.TOCHUCID = Guid.NewGuid().ToString();


                //objhogiadinh.HOGIADINHID = Guid.NewGuid().ToString();
                DC_DANGKY_NGUOI objdangkynguoi = new DC_DANGKY_NGUOI();
                nguoiid = objdangkynguoi.NGUOIID = Guid.NewGuid().ToString();
                objdangkynguoi.LOAI = 4;
                objdangkynguoi.Chu = new DC_NGUOI();
                objdangkynguoi.Chu.ToChuc = new DC_TOCHUC();
                objdangkynguoi.Chu.ToChuc = objtochuc;
                hoten = objdangkynguoi.Chu_HoTen = objtochuc.TENTOCHUC;
                cmt = objdangkynguoi.Chu_CMT = objtochuc.SOQUYETDINH;
                objdangkynguoi.Chu_TenLoaiChu = "Chủ tổ chức";
                objdangkynguoi.Chu.NGUOIID = Guid.NewGuid().ToString();
                objdangkynguoi.Chu.CHITIETID = objtochuc.TOCHUCID;
                objdangkynguoi.Chu.LOAIDOITUONGID = "4";
                objdangkynguoi.Chu.TRANGTHAI_NGUOI = 1;

                objdangkynguoi.DONDANGKYID = modelstochuc.DONDANGKYID;
                GetObject.CHU_DANGKY.Add(objdangkynguoi);
            }
            else if (objtochuc.TOCHUCID != "" && objtochuc.TOCHUCID != null && tontaihocosan == false)
            {
                them = true;
                //   objhogiadinh.HOGIADINHID = Guid.NewGuid().ToString();
                DC_CANHAN nguoidaidien = new DC_CANHAN();
                nguoidaidien = objtochuc.NguoiDaiDien;
                objtochuc = modelstochuc;
                objtochuc.NguoiDaiDien = nguoidaidien;
                //  objtochuc = modelstochuc;

                //objhogiadinh.HOGIADINHID = Guid.NewGuid().ToString();
                DC_DANGKY_NGUOI objdangkynguoi = new DC_DANGKY_NGUOI();
                nguoiid = objdangkynguoi.NGUOIID = Guid.NewGuid().ToString();
                objdangkynguoi.LOAI = 4;
                objdangkynguoi.Chu = new DC_NGUOI();
                objdangkynguoi.Chu.ToChuc = new DC_TOCHUC();
                objdangkynguoi.Chu.ToChuc = objtochuc;
                hoten = objdangkynguoi.Chu_HoTen = objtochuc.TENTOCHUC;
                cmt = objdangkynguoi.Chu_CMT = objtochuc.SOQUYETDINH;
                objdangkynguoi.Chu_TenLoaiChu = "Chủ tổ chức";
                objdangkynguoi.Chu.NGUOIID = Guid.NewGuid().ToString();
                objdangkynguoi.Chu.CHITIETID = objtochuc.TOCHUCID;
                objdangkynguoi.Chu.LOAIDOITUONGID = "4";
                objdangkynguoi.Chu.TRANGTHAI_NGUOI = 1;
                objdangkynguoi.DONDANGKYID = modelstochuc.DONDANGKYID;
                GetObject.CHU_DANGKY.Add(objdangkynguoi);
            }
            //cập nhật
            else
            {

                for (int i = 0; i < GetObject.CHU_DANGKY.Count; i++)
                {
                    if (GetObject.CHU_DANGKY[i].LOAI == 4)
                    {
                        if (GetObject.CHU_DANGKY[i].Chu.ToChuc.TOCHUCID == objtochuc.TOCHUCID)
                        {
                            GetObject.CHU_DANGKY[i].Chu.TRANGTHAI_NGUOI = 2;
                            objtochuc = modelstochuc;
                            GetObject.CHU_DANGKY[i].Chu.ToChuc = objtochuc;
                            nguoiid = GetObject.CHU_DANGKY[i].NGUOIID;
                            hoten = objtochuc.TENTOCHUC;
                            cmt = objtochuc.SOQUYETDINH;
                            break;
                        }
                    }
                }

            }
            var result = new { NGUOIID = nguoiid, CANHANID = canhanid, HOTEN = hoten, CMT = cmt, LOAICHU = "Chủ tổ chức", themmoi = them, LOAICHUID = "4" };
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        // chi tiết 
        public ActionResult ChiTietToChuc(string idnguoi, string loaichu)
        {
            VM_XuLyHoSo_DK GetObject = (VM_XuLyHoSo_DK)Session["lstDsChuDk_" + CurrentUser.UserName];
            var models = new DC_TOCHUC();


            foreach (var item in GetObject.CHU_DANGKY)
            {
                //loại chủ vợ chồng
                if (loaichu == "4")
                {
                    if (item.NGUOIID == idnguoi)
                    {
                        models = item.Chu.ToChuc;
                        models.CurCaNhan = new DC_CANHAN();
                        models.CurCaNhan = item.Chu.ToChuc.NguoiDaiDien;
                        //  models= DONDANGKYServices.DsHienThi(models);
                        break;
                    }
                }
            }
            ViewBag.listdantoc = DONDANGKYServices.getdm_dantoc();
            ViewBag.listquoctich = DONDANGKYServices.getdm_quoctich();
            ViewBag.gioitinh = DONDANGKYServices.getdm_gioitinh();
            Session["ChuToChuc"] = models;
            ViewBag.loaigiaytotuythan = DONDANGKYServices.getdm_loaigiaytotuythan();
            return PartialView("_Dk_ToChuc_CaNhan", models);
        }
        //xóa chủ vợ chồng
        public ActionResult XoacanhanNguoiDaiDien(string canhanid)
        {
            var models = new DC_TOCHUC();
            //Session["Dk_ChuCaNhan"] = models;
            models = (DC_TOCHUC)Session["ChuToChuc"];
            canhanid = canhanid.Trim();
            if (models.TRANGTHAI == 1)
            {
                if (canhanid == models.NguoiDaiDien.CANHANID)
                {

                    models.NguoiDaiDien.CANHANID = null;
                    models.NguoiDaiDien = new DC_CANHAN();
                }
            }
            else
            {
                //item.Chu.TRANGTHAI_NGUOI = 2;
                if (canhanid == models.NguoiDaiDien.CANHANID)
                {
                    //models.Chong.TRANGTHAI = 3;

                    models.NguoiDaiDien.CANHANID = null;
                    models.NguoiDaiDien = new DC_CANHAN();
                }
            }
            VM_XuLyHoSo_DK GetObject = (VM_XuLyHoSo_DK)Session["lstDsChuDk_" + CurrentUser.UserName];
            foreach (var item in GetObject.CHU_DANGKY)
            {
                if (item.LOAI == 4)
                {
                    if (item.Chu.ToChuc.TOCHUCID == models.TOCHUCID)
                    {
                        if (item.Chu.TRANGTHAI_NGUOI != 1)
                        {
                            item.Chu.TRANGTHAI_NGUOI = 2;

                        }
                        item.Chu.ToChuc = models;
                        break;
                    }
                }
            }
            return Json(models, JsonRequestBehavior.AllowGet);
        }

        // tìm kiếm vợ chồng

        public ActionResult SearchToChuc(string socmt)
        {
            var CNN_listFind = new List<DC_NGUOI_SearchToChuc>();
            CNN_listFind = DONDANGKYServices.searchToChuc(socmt);
            return Json(CNN_listFind);
        }
        //Chọn hộ vợ chồng

        public ActionResult ChonToChuc(string TOCHUCID)
        {
            var models = new DC_TOCHUC();
            ViewBag.listdantoc = DONDANGKYServices.getdm_dantoc();
            ViewBag.listquoctich = DONDANGKYServices.getdm_quoctich();
            ViewBag.gioitinh = DONDANGKYServices.getdm_gioitinh();
            DC_NGUOI objnguoi = new DC_NGUOI();
            objnguoi = DONDANGKYServices.GetToChuc(TOCHUCID);
            models = objnguoi.ToChuc;
            Session["ChuToChuc"] = models;
            ViewBag.loaigiaytotuythan = DONDANGKYServices.getdm_loaigiaytotuythan();
            return PartialView("_Dk_ToChuc_CaNhan", models);
        }

        #endregion

        #region chủ cộng đồng
        public ActionResult LoadCongDong()
        {
            var objcanhan = new DC_CANHAN();
            Session["Dk_ChuCaNhan"] = objcanhan;
            var models = new DC_CONGDONG();
            //Session["Dk_ChuCaNhan"] = models;
            models.TRANGTHAI = 1;
            Session["ChuCongDong"] = models;
            // models.HOGIADINHID = Guid.NewGuid().ToString();
            ViewBag.listdantoc = DONDANGKYServices.getdm_dantoc();
            ViewBag.listquoctich = DONDANGKYServices.getdm_quoctich();
            ViewBag.gioitinh = DONDANGKYServices.getdm_gioitinh();
            ViewBag.loaigiaytotuythan = DONDANGKYServices.getdm_loaigiaytotuythan();
            return PartialView("_Dk_CongDong_CaNhan", models);
        }
        public ActionResult LuuThanhVienNguoiDaidienCongDong(DC_CANHAN models)
        {
            var objtochuc = new DC_CONGDONG();
            DC_CANHAN curcanhan = new DC_CANHAN();
            curcanhan = (DC_CANHAN)Session["Dk_ChuCaNhan"];
            objtochuc = (DC_CONGDONG)Session["ChuCongDOng"];
            //thêm mới cá nhân  người đại diện cho tổ chức
            if (models.NGUOIID == null || models.NGUOIID == "")
            {
                models.DSGiayToTuyThan = curcanhan.DSGiayToTuyThan;
                models.NGUOIID = Guid.NewGuid().ToString();
                //  models.CANHANID = Guid.NewGuid().ToString();
                if (models.CANHANID == null)
                {
                    models.CANHANID = Guid.NewGuid().ToString();
                }
                if (models.DSGiayToTuyThan != null)
                {
                    foreach (var item in models.DSGiayToTuyThan)
                    {
                        if (item != null)
                        {
                            item.CANHANID = models.CANHANID;
                        }
                    }
                }
                // người đại điện

                models.TRANGTHAI = 1;
                objtochuc.NguoiDaiDien = models;
                // Mapper.Map<DC_CANHAN, DC_CANHAN>(models, objtochuc.NguoiDaiDien);
                objtochuc.NguoiDaiDien.HOTEN = models.HODEM + " " + models.TEN;
                objtochuc.NguoiDaiDien.CANHANID = models.CANHANID;
            }
            else
            {
                models.DSGiayToTuyThan = curcanhan.DSGiayToTuyThan;
                //1: chủ chồng 
                //2 : chủ vợ


                models.TRANGTHAI = 2;
                Mapper.Map<DC_CANHAN, DC_CANHAN>(models, objtochuc.NguoiDaiDien);
                objtochuc.NguoiDaiDien.HOTEN = models.HODEM + " " + models.TEN;

            }
            Session["Dk_ChuCaNhan"] = objtochuc.NguoiDaiDien;
            ViewBag.listdantoc = DONDANGKYServices.getdm_dantoc();
            ViewBag.listquoctich = DONDANGKYServices.getdm_quoctich();
            ViewBag.gioitinh = DONDANGKYServices.getdm_gioitinh();
            ViewBag.loaigiaytotuythan = DONDANGKYServices.getdm_loaigiaytotuythan();
            return PartialView("_Dk_CongDong_CaNhan", objtochuc);

        }

        public ActionResult LoadcanhanNguoiDaiDienCongDong(string canhanid)
        {
            canhanid = canhanid.Trim();
            var objtochuc = new DC_CONGDONG();
            DC_CANHAN curcanhan = new DC_CANHAN();
            //curcanhan = (DangKyChuCaNhan)Session["Dk_ChuCaNhan"];
            objtochuc = (DC_CONGDONG)Session["ChuCongDong"];
            //load người đại diện tổ chức
            if (canhanid == objtochuc.NGUOIDAIDIENID)
            {
                curcanhan = objtochuc.NguoiDaiDien;

                if (objtochuc.NguoiDaiDien.DSGiayToTuyThan.Count > 0)
                {
                    objtochuc.NguoiDaiDien.DSGiayToTuyThan = DONDANGKYServices.getgiaytotuythan(objtochuc.NguoiDaiDien.DSGiayToTuyThan);
                }
            }
            Session["Dk_ChuCaNhan"] = curcanhan;
            ViewBag.listdantoc = DONDANGKYServices.getdm_dantoc();
            ViewBag.listquoctich = DONDANGKYServices.getdm_quoctich();
            ViewBag.gioitinh = DONDANGKYServices.getdm_gioitinh();
            ViewBag.loaigiaytotuythan = DONDANGKYServices.getdm_loaigiaytotuythan();
            return PartialView("_Dk_ChuCaNhan_GiayTo", curcanhan);
            // return View();
        }

        public ActionResult ThemDanhSachCongDong(DC_CONGDONG modelstochuc)
        {
            string nguoiid = "", canhanid = "", hoten = "", cmt = "";
            bool them = false;
            VM_XuLyHoSo_DK GetObject = (VM_XuLyHoSo_DK)Session["lstDsChuDk_" + CurrentUser.UserName];
            var objtochuc = new DC_CONGDONG();
            objtochuc = (DC_CONGDONG)Session["ChuCongDong"];
            bool tontaihocosan = false;
            for (int i = 0; i < GetObject.CHU_DANGKY.Count; i++)
            {
                if (GetObject.CHU_DANGKY[i].LOAI == 5)
                {
                    if (objtochuc.CONGDONGID == GetObject.CHU_DANGKY[i].Chu.CongDong.CONGDONGID)
                    {
                        tontaihocosan = true;
                        break;
                    }
                }
            }

            if (objtochuc.CONGDONGID == "" || objtochuc.CONGDONGID == null)
            {
                them = true;
                DC_CANHAN nguoidaidien = new DC_CANHAN();
                nguoidaidien = objtochuc.NguoiDaiDien;
                objtochuc = modelstochuc;
                objtochuc.NguoiDaiDien = nguoidaidien;
                objtochuc.CONGDONGID = Guid.NewGuid().ToString();


                //objhogiadinh.HOGIADINHID = Guid.NewGuid().ToString();
                DC_DANGKY_NGUOI objdangkynguoi = new DC_DANGKY_NGUOI();
                nguoiid = objdangkynguoi.NGUOIID = Guid.NewGuid().ToString();
                objdangkynguoi.LOAI = 5;
                objdangkynguoi.Chu = new DC_NGUOI();
                objdangkynguoi.Chu.CongDong = new DC_CONGDONG();
                objdangkynguoi.Chu.CongDong = objtochuc;
                hoten = objdangkynguoi.Chu_HoTen = objtochuc.TENCONGDONG;
                cmt = objdangkynguoi.Chu_CMT = "";
                objdangkynguoi.Chu_TenLoaiChu = "Chủ cộng đồng";
                objdangkynguoi.Chu.NGUOIID = Guid.NewGuid().ToString();
                objdangkynguoi.Chu.CHITIETID = objtochuc.CONGDONGID;
                objdangkynguoi.Chu.LOAIDOITUONGID = "5";
                objdangkynguoi.Chu.TRANGTHAI_NGUOI = 1;

                objdangkynguoi.DONDANGKYID = modelstochuc.DONDANGKYID;
                GetObject.CHU_DANGKY.Add(objdangkynguoi);
            }
            else if (objtochuc.CONGDONGID != "" && objtochuc.CONGDONGID != null && tontaihocosan == false)
            {
                them = true;
                //   objhogiadinh.HOGIADINHID = Guid.NewGuid().ToString();
                DC_CANHAN nguoidaidien = new DC_CANHAN();
                nguoidaidien = objtochuc.NguoiDaiDien;
                objtochuc = modelstochuc;
                objtochuc.NguoiDaiDien = nguoidaidien;
                //  objtochuc = modelstochuc;

                //objhogiadinh.HOGIADINHID = Guid.NewGuid().ToString();
                DC_DANGKY_NGUOI objdangkynguoi = new DC_DANGKY_NGUOI();
                nguoiid = objdangkynguoi.NGUOIID = Guid.NewGuid().ToString();
                objdangkynguoi.LOAI = 5;
                objdangkynguoi.Chu = new DC_NGUOI();
                objdangkynguoi.Chu.CongDong = new DC_CONGDONG();
                objdangkynguoi.Chu.CongDong = objtochuc;
                hoten = objdangkynguoi.Chu_HoTen = objtochuc.TENCONGDONG;
                cmt = objdangkynguoi.Chu_CMT = "";
                objdangkynguoi.Chu_TenLoaiChu = "Chủ cộng đồng";
                objdangkynguoi.Chu.NGUOIID = Guid.NewGuid().ToString();
                objdangkynguoi.Chu.CHITIETID = objtochuc.CONGDONGID;
                objdangkynguoi.Chu.LOAIDOITUONGID = "5";
                objdangkynguoi.Chu.TRANGTHAI_NGUOI = 1;
                objdangkynguoi.DONDANGKYID = modelstochuc.DONDANGKYID;
                GetObject.CHU_DANGKY.Add(objdangkynguoi);
            }
            //cập nhật
            else
            {

                for (int i = 0; i < GetObject.CHU_DANGKY.Count; i++)
                {
                    if (GetObject.CHU_DANGKY[i].LOAI == 5)
                    {
                        if (GetObject.CHU_DANGKY[i].Chu.CongDong.CONGDONGID == objtochuc.CONGDONGID)
                        {
                            GetObject.CHU_DANGKY[i].Chu.TRANGTHAI_NGUOI = 2;
                            objtochuc = modelstochuc;
                            GetObject.CHU_DANGKY[i].Chu.CongDong = objtochuc;
                            nguoiid = GetObject.CHU_DANGKY[i].NGUOIID;
                            hoten = objtochuc.TENCONGDONG;
                            cmt = "";
                            break;
                        }
                    }
                }

            }
            var result = new { NGUOIID = nguoiid, CANHANID = canhanid, HOTEN = hoten, CMT = cmt, LOAICHU = "Chủ cộng đồng", themmoi = them, LOAICHUID = "5" };
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        // chi tiết 
        public ActionResult ChiTietCongDong(string idnguoi, string loaichu)
        {
            VM_XuLyHoSo_DK GetObject = (VM_XuLyHoSo_DK)Session["lstDsChuDk_" + CurrentUser.UserName];
            var models = new DC_CONGDONG();


            foreach (var item in GetObject.CHU_DANGKY)
            {
                //loại chủ vợ chồng
                if (loaichu == "5")
                {
                    if (item.NGUOIID == idnguoi)
                    {
                        models = item.Chu.CongDong;
                        models.CurCaNhan = new DC_CANHAN();
                        models.CurCaNhan = item.Chu.CongDong.NguoiDaiDien;
                        //  models= DONDANGKYServices.DsHienThi(models);
                        break;
                    }
                }
            }
            ViewBag.listdantoc = DONDANGKYServices.getdm_dantoc();
            ViewBag.listquoctich = DONDANGKYServices.getdm_quoctich();
            ViewBag.gioitinh = DONDANGKYServices.getdm_gioitinh();
            Session["ChuCongDong"] = models;
            ViewBag.loaigiaytotuythan = DONDANGKYServices.getdm_loaigiaytotuythan();
            return PartialView("_Dk_CongDong_CaNhan", models);
        }
        //xóa chủ vợ chồng
        public ActionResult XoacanhanNguoiDaiDienCongDong(string canhanid)
        {
            var models = new DC_TOCHUC();
            //Session["Dk_ChuCaNhan"] = models;
            models = (DC_TOCHUC)Session["ChuCongDong"];
            canhanid = canhanid.Trim();
            if (models.TRANGTHAI == 1)
            {
                if (canhanid == models.NguoiDaiDien.CANHANID)
                {

                    models.NguoiDaiDien.CANHANID = null;
                    models.NguoiDaiDien = new DC_CANHAN();
                }
            }
            else
            {
                //item.Chu.TRANGTHAI_NGUOI = 2;
                if (canhanid == models.NguoiDaiDien.CANHANID)
                {
                    //models.Chong.TRANGTHAI = 3;

                    models.NguoiDaiDien.CANHANID = null;
                    models.NguoiDaiDien = new DC_CANHAN();
                }
            }
            VM_XuLyHoSo_DK GetObject = (VM_XuLyHoSo_DK)Session["lstDsChuDk_" + CurrentUser.UserName];
            foreach (var item in GetObject.CHU_DANGKY)
            {
                if (item.LOAI == 5)
                {
                    if (item.Chu.ToChuc.TOCHUCID == models.TOCHUCID)
                    {
                        if (item.Chu.TRANGTHAI_NGUOI != 1)
                        {
                            item.Chu.TRANGTHAI_NGUOI = 2;

                        }
                        item.Chu.ToChuc = models;
                        break;
                    }
                }
            }
            return Json(models, JsonRequestBehavior.AllowGet);
        }

        // tìm kiếm vợ chồng

        public ActionResult SearchCongDong(string socmt)
        {
            var CNN_listFind = new List<DC_NGUOI_SearchCongDong>();
            CNN_listFind = DONDANGKYServices.searchCongDong(socmt);
            return Json(CNN_listFind);
        }
        //Chọn cộng đồng

        public ActionResult ChonCongDong(string CONGDONGID)
        {
            var models = new DC_CONGDONG();
            ViewBag.listdantoc = DONDANGKYServices.getdm_dantoc();
            ViewBag.listquoctich = DONDANGKYServices.getdm_quoctich();
            ViewBag.gioitinh = DONDANGKYServices.getdm_gioitinh();
            DC_NGUOI objnguoi = new DC_NGUOI();
            objnguoi = DONDANGKYServices.GetCongDong(CONGDONGID);
            models = objnguoi.CongDong;
            Session["ChuCongDong"] = models;
            ViewBag.loaigiaytotuythan = DONDANGKYServices.getdm_loaigiaytotuythan();
            return PartialView("_Dk_CongDong_CaNhan", models);
        }

        #endregion

        #region chủ nhóm người
        public ActionResult LoadNhomNguoi()
        {
            var objcanhan = new DC_CANHAN();
            Session["Dk_ChuCaNhan"] = objcanhan;
            var models = new DC_NHOMNGUOI();
            //Session["Dk_ChuCaNhan"] = models;
            models.NHOMNGUOIID = Guid.NewGuid().ToString();
            models.TRANGTHAI = 1;
            Session["ChuNhomNguoi"] = models;
            //// models.HOGIADINHID = Guid.NewGuid().ToString();
            //ViewBag.listdantoc = DONDANGKYServices.getdm_dantoc();
            //ViewBag.listquoctich = DONDANGKYServices.getdm_quoctich();
            //ViewBag.loaigiaytotuythan = DONDANGKYServices.getdm_loaigiaytotuythan();
            return PartialView("_Dk_Chunhomnguoi", models);
        }

        // thêm cá nhân người đại diện
        public ActionResult ThemMoiDK_CaNhanDaiDiennhomnguoi(DC_CANHAN models)
        {
            DC_CANHAN cur = new DC_CANHAN();
            // Session["Dk_ChuCaNhan"] = models;
            // cur = (DC_CANHAN)Session["Dk_ChuCaNhan"];
            models.DSGiayToTuyThan = cur.DSGiayToTuyThan;
            var them = false;
            string nguoiid = "", canhanid = "", hoten = "", cmt = "";
            //using (MplisEntities db = new MplisEntities())
            //{
            using (MplisEntities dbo = new MplisEntities())
            {
                if (models.CANHANID == null || models.CANHANID == "")
                {

                    them = true;
                    cur = models;
                    cur.CANHANID = Guid.NewGuid().ToString();
                    canhanid = models.CANHANID;
                    nguoiid = models.CANHANID;
                    cmt = models.SOGIAYTO;
                    cur.HOTEN = hoten = models.HODEM + " " + models.TEN;

                    dbo.DC_CANHAN.Add(cur);
                    //cập nhật giấy tờ tùy thân
                    if (cur.DSGiayToTuyThan != null)
                    {
                        foreach (var item in cur.DSGiayToTuyThan)
                        {
                            DC_GIAYTOTUYTHAN obj = new DC_GIAYTOTUYTHAN();
                            obj = item;
                            obj.CANHANID = cur.CANHANID;
                            obj.GIAYTOTUYTHANID = Guid.NewGuid().ToString();
                            dbo.DC_GIAYTOTUYTHAN.Add(obj);
                        }
                    }

                }
                //Cập nhật cá nhân đăng ký
                else
                {
                    var objcanhan = (from item in dbo.DC_CANHAN where item.CANHANID == cur.CANHANID select item).FirstOrDefault();
                    if (objcanhan != null)
                    {
                        Mapper.Map<DC_CANHAN, DC_CANHAN>(models, objcanhan);
                        hoten = objcanhan.HOTEN = objcanhan.HODEM + " " + objcanhan.TEN;
                        cmt = objcanhan.SOGIAYTO;
                        canhanid = nguoiid = objcanhan.CANHANID;
                        // cập nhật giấy tờ tùy thân
                        var lstgiaytotuythan = (from item in dbo.DC_GIAYTOTUYTHAN select item);
                        foreach (var a in lstgiaytotuythan)
                        {
                            dbo.DC_GIAYTOTUYTHAN.Remove(a);
                        }
                        if (cur.DSGiayToTuyThan != null)
                        {
                            foreach (var b in objcanhan.DSGiayToTuyThan)
                            {
                                DC_GIAYTOTUYTHAN obj = new DC_GIAYTOTUYTHAN();
                                obj = b;
                                obj.CANHANID = cur.CANHANID;
                                obj.GIAYTOTUYTHANID = Guid.NewGuid().ToString();
                                dbo.DC_GIAYTOTUYTHAN.Add(obj);
                            }
                        }
                    }
                    else
                    {
                        them = true;
                        cur = models;
                        cur.CANHANID = Guid.NewGuid().ToString();
                        canhanid = models.CANHANID;
                        nguoiid = models.CANHANID;
                        cmt = models.SOGIAYTO;
                        cur.HOTEN = hoten = models.HODEM + " " + models.TEN;

                        dbo.DC_CANHAN.Add(cur);
                        //cập nhật giấy tờ tùy thân
                        if (cur.DSGiayToTuyThan != null)
                        {
                            foreach (var item in cur.DSGiayToTuyThan)
                            {
                                DC_GIAYTOTUYTHAN obj = new DC_GIAYTOTUYTHAN();
                                obj = item;
                                obj.CANHANID = cur.CANHANID;
                                obj.GIAYTOTUYTHANID = Guid.NewGuid().ToString();
                                dbo.DC_GIAYTOTUYTHAN.Add(obj);
                            }
                        }
                    }

                }
                // cập nhật người đại diện
                var objnhomnguoi = new DC_NHOMNGUOI();

                objnhomnguoi = (DC_NHOMNGUOI)Session["ChuNhomNguoi"];
                var checknhomnguoi = (from nhom in dbo.DC_NHOMNGUOI where nhom.NHOMNGUOIID == objnhomnguoi.NHOMNGUOIID select nhom).FirstOrDefault();
                if (checknhomnguoi != null)
                {
                    checknhomnguoi.NGUOIDAIDIEN = models.CANHANID;

                }
                else
                {
                    //checknhomnguoi = new DC_NHOMNGUOI();
                    objnhomnguoi.NGUOIDAIDIEN = models.CANHANID;
                    dbo.DC_NHOMNGUOI.Add(objnhomnguoi);
                }
                //cập nhật danh sách thành viên
                //var objthanhvien = (from itemthanhvien in dbo.DC_NHOMNGUOI_THANHVIEN where itemthanhvien.NHOMNGUOIID == objnhomnguoi.NHOMNGUOIID && itemthanhvien.THANHPHANID == models.CANHANID select itemthanhvien).FirstOrDefault();
                //if (objthanhvien == null)
                //{
                //    DC_NHOMNGUOI_THANHVIEN obj = new DC_NHOMNGUOI_THANHVIEN();
                //    obj.THANHPHANID = models.CANHANID;
                //    obj.LOAIDOITUONG = 1;
                //    obj.NHOMNGUOIID = objnhomnguoi.NHOMNGUOIID;
                //    dbo.DC_NHOMNGUOI_THANHVIEN.Add(obj);

                //}
                dbo.SaveChanges();
            }
            var result = new { NGUOIID = nguoiid, CANHANID = canhanid, HOTEN = hoten, CMT = cmt, LOAICHU = "Cá nhân", themmoi = them, LOAICHUID = "1" };
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        public ActionResult ThemMoiDK_CaNhanThanhViennhomnguoi(DC_CANHAN models)
        {
            DC_CANHAN cur = new DC_CANHAN();
            // Session["Dk_ChuCaNhan"] = models;
            // cur = (DC_CANHAN)Session["Dk_ChuCaNhan"];
            models.DSGiayToTuyThan = cur.DSGiayToTuyThan;
            var them = false;
            string nguoiid = "", canhanid = "", hoten = "", cmt = "";
            //using (MplisEntities db = new MplisEntities())
            //{
            using (MplisEntities dbo = new MplisEntities())
            {
                if (models.CANHANID == null || models.CANHANID == "")
                {

                    them = true;
                    cur = models;
                    cur.CANHANID = Guid.NewGuid().ToString();
                    canhanid = models.CANHANID;
                    nguoiid = models.CANHANID;
                    cmt = models.SOGIAYTO;
                    hoten = models.HODEM + " " + models.TEN;

                    dbo.DC_CANHAN.Add(cur);
                    //cập nhật giấy tờ tùy thân
                    if (cur.DSGiayToTuyThan != null)
                    {
                        foreach (var item in cur.DSGiayToTuyThan)
                        {
                            DC_GIAYTOTUYTHAN obj = new DC_GIAYTOTUYTHAN();
                            obj = item;
                            obj.CANHANID = cur.CANHANID;
                            obj.GIAYTOTUYTHANID = Guid.NewGuid().ToString();
                            dbo.DC_GIAYTOTUYTHAN.Add(obj);
                        }
                    }


                }
                //Cập nhật cá nhân đăng ký
                else
                {
                    var objcanhan = (from item in dbo.DC_CANHAN where item.CANHANID == cur.CANHANID select item).FirstOrDefault();
                    if (objcanhan != null)
                    {
                        Mapper.Map<DC_CANHAN, DC_CANHAN>(models, objcanhan);
                        hoten = objcanhan.HOTEN = objcanhan.HODEM + " " + objcanhan.TEN;
                        cmt = objcanhan.SOGIAYTO;
                        nguoiid = objcanhan.CANHANID;
                        // cập nhật giấy tờ tùy thân
                        var lstgiaytotuythan = (from item in dbo.DC_GIAYTOTUYTHAN select item);
                        foreach (var a in lstgiaytotuythan)
                        {
                            dbo.DC_GIAYTOTUYTHAN.Remove(a);
                        }
                        foreach (var b in objcanhan.DSGiayToTuyThan)
                        {
                            DC_GIAYTOTUYTHAN obj = new DC_GIAYTOTUYTHAN();
                            obj = b;
                            obj.CANHANID = cur.CANHANID;
                            obj.GIAYTOTUYTHANID = Guid.NewGuid().ToString();
                            dbo.DC_GIAYTOTUYTHAN.Add(obj);
                        }
                    }
                    else
                    {
                        them = true;
                        cur = models;
                        cur.CANHANID = Guid.NewGuid().ToString();
                        canhanid = models.CANHANID;
                        nguoiid = models.CANHANID;
                        cmt = models.SOGIAYTO;
                        hoten = models.HODEM + " " + models.TEN;

                        dbo.DC_CANHAN.Add(cur);
                        //cập nhật giấy tờ tùy thân
                        if (cur.DSGiayToTuyThan != null)
                        {
                            foreach (var item in cur.DSGiayToTuyThan)
                            {
                                DC_GIAYTOTUYTHAN obj = new DC_GIAYTOTUYTHAN();
                                obj = item;
                                obj.CANHANID = cur.CANHANID;
                                obj.GIAYTOTUYTHANID = Guid.NewGuid().ToString();
                                dbo.DC_GIAYTOTUYTHAN.Add(obj);
                            }
                        }
                    }

                }
                // cập nhật người đại diện
                var objnhomnguoi = new DC_NHOMNGUOI();

                objnhomnguoi = (DC_NHOMNGUOI)Session["ChuNhomNguoi"];

                //cập nhật danh sách thành viên
                //var objthanhvien = (from itemthanhvien in dbo.DC_NHOMNGUOI_THANHVIEN where itemthanhvien.NHOMNGUOIID == objnhomnguoi.NHOMNGUOIID && itemthanhvien.THANHPHANID == models.CANHANID select itemthanhvien).FirstOrDefault();
                //if (objthanhvien == null)
                //{
                //    DC_NHOMNGUOI_THANHVIEN obj = new DC_NHOMNGUOI_THANHVIEN();
                //    obj.THANHPHANID = models.CANHANID;
                //    obj.LOAIDOITUONG = 1;
                //    obj.NHOMNGUOIID = objnhomnguoi.NHOMNGUOIID;
                //    dbo.DC_NHOMNGUOI_THANHVIEN.Add(obj);

                //}
                dbo.SaveChanges();
            }
            var result = new { NGUOIID = nguoiid, CANHANID = canhanid, HOTEN = hoten, CMT = cmt, LOAICHU = "Cá nhân", themmoi = them, LOAICHUID = "1" };
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        //thêm hộ gia đình vào nhóm
        public ActionResult ThemDanhSachHoGiaDinhNhom(string diachi)
        {
            string nguoiid = "", canhanid = "", hoten = "", cmt = "";
            bool them = false;
            // VM_XuLyHoSo_DK GetObject = (VM_XuLyHoSo_DK)Session["lstDsChuDk_" + CurrentUser.UserName];
            var objhogiadinh = new DC_HOGIADINH();
            objhogiadinh = (DC_HOGIADINH)Session["Dk_ChuHoGiaDinh"];
            objhogiadinh.DIACHI = diachi;
            var objnhomnguoi = new DC_NHOMNGUOI();

            objnhomnguoi = (DC_NHOMNGUOI)Session["ChuNhomNguoi"];
            using (MplisEntities dbo = new MplisEntities())
            {
                if (objhogiadinh.HOGIADINHID == null)
                {
                    objhogiadinh.HOGIADINHID = Guid.NewGuid().ToString();
                }
                var ketqua = DONDANGKYServices.SaveHoGiaDinhThuocNhom(objhogiadinh, dbo, objnhomnguoi, out them);

                canhanid = nguoiid = objhogiadinh.HOGIADINHID;
                hoten = objhogiadinh.ChuHoCN.HOTEN + ", " + objhogiadinh.VoChongCN.HOTEN;
                cmt = objhogiadinh.ChuHoCN.SOGIAYTO + ", " + objhogiadinh.VoChongCN.SOGIAYTO;
            }
            var result = new { NGUOIID = nguoiid, CANHANID = canhanid, HOTEN = hoten, CMT = cmt, LOAICHU = "Hộ gia đình", themmoi = them, LOAICHUID = "2" };
            return Json(result, JsonRequestBehavior.AllowGet);

        }

        public ActionResult ThemDanhSachVoChongNhom(string diachi)
        {
            string nguoiid = "", canhanid = "", hoten = "", cmt = "";
            bool them;
            // VM_XuLyHoSo_DK GetObject = (VM_XuLyHoSo_DK)Session["lstDsChuDk_" + CurrentUser.UserName];
            var objvochong = new DC_VOCHONG();
            objvochong = (DC_VOCHONG)Session["ChuVoChong"];
            objvochong.DIACHI = diachi;
            var objnhomnguoi = new DC_NHOMNGUOI();

            objnhomnguoi = (DC_NHOMNGUOI)Session["ChuNhomNguoi"];
            using (MplisEntities dbo = new MplisEntities())
            {
                if (objvochong.VOCHONGID == null)
                {
                    objvochong.VOCHONGID = Guid.NewGuid().ToString();
                }
                var ketqua = DONDANGKYServices.SaveHoVoChongThuocNhom(objvochong, dbo, objnhomnguoi, out them);
                canhanid = nguoiid = objvochong.VOCHONGID;
                hoten = objvochong.ChongCN.HOTEN + ", " + objvochong.VoCN.HOTEN;
                cmt = objvochong.ChongCN.SOGIAYTO + ", " + objvochong.VoCN.SOGIAYTO;
            }
            var result = new { NGUOIID = nguoiid, CANHANID = canhanid, HOTEN = hoten, CMT = cmt, LOAICHU = "Vợ chồng", themmoi = them, LOAICHUID = "2" };
            return Json(result, JsonRequestBehavior.AllowGet);

        }

        public ActionResult ThemDanhSachToChucNhom(DC_TOCHUC modelstochuc)
        {
            string nguoiid = "", canhanid = "", hoten = "", cmt = "";
            bool them = false;

            var objtochuc = new DC_TOCHUC();
            objtochuc = (DC_TOCHUC)Session["ChuToChuc"];
            objtochuc.DIACHI = modelstochuc.DIACHI;
            objtochuc.TENTOCHUC = modelstochuc.TENTOCHUC;
            objtochuc.SOQUYETDINH = modelstochuc.SOQUYETDINH;
            objtochuc.TENTOCHUCTA = modelstochuc.TENTOCHUCTA;
            objtochuc.TENVIETTAT = modelstochuc.TENVIETTAT;
            objtochuc.NGAYQUYETDINH = modelstochuc.NGAYQUYETDINH;
            objtochuc.MADOANHNGHIEP = modelstochuc.MADOANHNGHIEP;
            objtochuc.MASOTHUE = modelstochuc.MASOTHUE;
            var objnhomnguoi = new DC_NHOMNGUOI();

            objnhomnguoi = (DC_NHOMNGUOI)Session["ChuNhomNguoi"];
            using (MplisEntities dbo = new MplisEntities())
            {
                var ketqua = DONDANGKYServices.SaveHoToChucThuocNhom(objtochuc, dbo, objnhomnguoi, out them);
                canhanid = nguoiid = objtochuc.TOCHUCID;
                hoten = objtochuc.TENTOCHUC;
                cmt = objtochuc.SOQUYETDINH;
            }
            var result = new { NGUOIID = nguoiid, CANHANID = canhanid, HOTEN = hoten, CMT = cmt, LOAICHU = "Chủ tổ chức", themmoi = them, LOAICHUID = "4" };
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        public ActionResult ThemDanhSachCongDongNhom(DC_CONGDONG modelstochuc)
        {
            string nguoiid = "", canhanid = "", hoten = "", cmt = "";
            bool them = false;

            var objtochuc = new DC_CONGDONG();
            objtochuc = (DC_CONGDONG)Session["ChuCongDong"];
            objtochuc.DIACHI = modelstochuc.DIACHI;
            objtochuc.TENCONGDONG = modelstochuc.TENCONGDONG;

            var objnhomnguoi = new DC_NHOMNGUOI();

            objnhomnguoi = (DC_NHOMNGUOI)Session["ChuNhomNguoi"];
            using (MplisEntities dbo = new MplisEntities())
            {
                var ketqua = DONDANGKYServices.SaveCongDongNhom(objtochuc, dbo, objnhomnguoi, out them);
                canhanid = nguoiid = objtochuc.CONGDONGID;
                hoten = objtochuc.TENCONGDONG;
                //    cmt = objtochuc.SOQUYETDINH;
            }
            var result = new { NGUOIID = nguoiid, CANHANID = canhanid, HOTEN = hoten, CMT = cmt, LOAICHU = "Chủ cộng đồng", themmoi = them, LOAICHUID = "5" };
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        public ActionResult XOA_NGUOIKHOINHOM(string idcanhan, string nhomnguoi)
        {
            try
            {
                idcanhan = idcanhan.Trim();
                using (MplisEntities dbo = new MplisEntities())
                {
                    var ketqua = DONDANGKYServices.Xoachukhoinhom(idcanhan, nhomnguoi);
                }
                return Json("true", JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                return Json("false", JsonRequestBehavior.AllowGet);
                throw;
            }

        }
        // cá nhân
        public ActionResult ChiTietChuCaNhanNhom(string canhanid)
        {
            canhanid = canhanid.Trim();
            DC_CANHAN models = new DC_CANHAN();
            //cá nhân
            if (canhanid != "")
            {
                models = DONDANGKYServices.GetCaNhanNhom(canhanid);
            }
            ViewBag.listdantoc = DONDANGKYServices.getdm_dantoc();
            ViewBag.listquoctich = DONDANGKYServices.getdm_quoctich();
            ViewBag.gioitinh = DONDANGKYServices.getdm_gioitinh();
            ViewBag.loaigiaytotuythan = DONDANGKYServices.getdm_loaigiaytotuythan();
            models.DSGiayToTuyThan = DONDANGKYServices.getgiaytotuythan(models.DSGiayToTuyThan);
            Session["Dk_ChuCaNhan"] = models;
            return PartialView("_Dk_ChuCaNhan_GiayTo", models);
        }
        public ActionResult ChiTietChuHoGiaDinhNhom(string hogiadinhid)
        {
            hogiadinhid = hogiadinhid.Trim();
            DC_HOGIADINH models = new DC_HOGIADINH();
            //cá nhân
            if (hogiadinhid != "")
            {
                models = DONDANGKYServices.GetHoGiaDinhNhom(hogiadinhid);
            }
            ViewBag.listdantoc = DONDANGKYServices.getdm_dantoc();
            ViewBag.listquoctich = DONDANGKYServices.getdm_quoctich();
            ViewBag.gioitinh = DONDANGKYServices.getdm_gioitinh();
            models = DONDANGKYServices.getdshienthi(models);
            Session["Dk_ChuHoGiaDinh"] = models;
            ViewBag.loaigiaytotuythan = DONDANGKYServices.getdm_loaigiaytotuythan();
            return PartialView("_Dk_HoGiaDinh_CaNhan", models);
        }

        public ActionResult ChiTietChuVoChongNhom(string vochongid)
        {
            vochongid = vochongid.Trim();
            DC_VOCHONG models = new DC_VOCHONG();
            //cá nhân
            if (vochongid != "")
            {
                models = DONDANGKYServices.GetVoChongNhom(vochongid);
            }
            ViewBag.listdantoc = DONDANGKYServices.getdm_dantoc();
            ViewBag.listquoctich = DONDANGKYServices.getdm_quoctich();
            ViewBag.gioitinh = DONDANGKYServices.getdm_gioitinh();
            Session["ChuVoChong"] = models;
            ViewBag.loaigiaytotuythan = DONDANGKYServices.getdm_loaigiaytotuythan();
            return PartialView("_Dk_VoChong_CaNhan", models);
        }

        public ActionResult ChiTietToChucNhom(string tochucid)
        {
            tochucid = tochucid.Trim();
            DC_TOCHUC models = new DC_TOCHUC();
            //cá nhân
            if (tochucid != "")
            {
                models = DONDANGKYServices.GetToChucNhom(tochucid);
            }
            ViewBag.listdantoc = DONDANGKYServices.getdm_dantoc();
            ViewBag.listquoctich = DONDANGKYServices.getdm_quoctich();
            ViewBag.gioitinh = DONDANGKYServices.getdm_gioitinh();
            Session["ChuToChuc"] = models;
            ViewBag.loaigiaytotuythan = DONDANGKYServices.getdm_loaigiaytotuythan();
            return PartialView("_Dk_ToChuc_CaNhan", models);
        }
        public ActionResult ChiTietCongDongNhom(string congdongid)
        {
            congdongid = congdongid.Trim();
            DC_CONGDONG models = new DC_CONGDONG();
            //cá nhân
            if (congdongid != "")
            {
                models = DONDANGKYServices.GetCongDongNhom(congdongid);
            }
            ViewBag.listdantoc = DONDANGKYServices.getdm_dantoc();
            ViewBag.listquoctich = DONDANGKYServices.getdm_quoctich();
            ViewBag.gioitinh = DONDANGKYServices.getdm_gioitinh();
            Session["ChuCongDong"] = models;
            ViewBag.loaigiaytotuythan = DONDANGKYServices.getdm_loaigiaytotuythan();
            return PartialView("_Dk_CongDong_CaNhan", models);
        }
        #endregion
        #endregion
        #region thông tin tài sản 
        #region Load data
        public ActionResult _DonDangKy_DSTAISAN()
        {
            BoHoSoModel bhs = (BoHoSoModel)Session["BoHoSo_" + CurrentUser.UserName];
            VM_XuLyHoSo_DK GCNVM = new VM_XuLyHoSo_DK();
            GCNVM.initData(bhs);
            return PartialView("_DonDangKy_DSTAISAN", GCNVM);
        }
        public ActionResult _lstThuaTaiSan()
        {
            BoHoSoModel bhs = (BoHoSoModel)Session["BoHoSo_" + CurrentUser.UserName];
            VM_XuLyHoSo_DK GCNVM = new VM_XuLyHoSo_DK();
            GCNVM.initData(bhs);
            return PartialView("_lstThuaTaiSan", GCNVM);
        }
        public ActionResult _DonDangKy_TSNHARIENGLE()
        {
            ViewBag.lstloainharieng = DCTAISANGANLIENVOIDATServices.get_loainharieng();
            ViewBag.lstloaicaphangnharieng = DCTAISANGANLIENVOIDATServices.get_loaicaphang();
            return PartialView("_DonDangKy_TSNHARIENGLE");
        }
        public ActionResult ChiTietNhaRiengLe(string idtaisan, string loaitaisan)
        {
            BoHoSoModel bhs = (BoHoSoModel)Session["BoHoSo_" + CurrentUser.UserName];
            var models = new DangKyTaiSan();
            foreach (var item in bhs.HoSoTN.DonDangKy.DSDangKyTaiSan)
            {
                if (loaitaisan == "1")
                {
                    if (item.TAISANID == idtaisan)
                    {
                        models.CurNhaRiengLe = item.TaiSanGanLienVoiDat.NhaRiengLe;
                        models.mota = item.MOTATOMTAT;
                        break;
                    }
                }
            }
            ViewBag.lstloainharieng = DCTAISANGANLIENVOIDATServices.get_loainharieng();
            ViewBag.lstloaicaphangnharieng = DCTAISANGANLIENVOIDATServices.get_loaicaphang();
            return PartialView("_DonDangKy_TSNHARIENGLE", models);
        }
        public ActionResult LoadRungTrong()
        {
            return PartialView("_DonDangKy_RungTrong");
        }
        public ActionResult ChiTietRungTrong(string idtaisan, string loaitaisan)
        {
            BoHoSoModel bhs = (BoHoSoModel)Session["BoHoSo_" + CurrentUser.UserName];
            var models = new DangKyTaiSan();
            foreach (var item in bhs.HoSoTN.DonDangKy.DSDangKyTaiSan)
            {
                if (loaitaisan == "9")
                {
                    if (item.TAISANID == idtaisan)
                    {
                        models.CurRungTrong = item.TaiSanGanLienVoiDat.RungTrong;
                        models.mota = item.MOTATOMTAT;
                        break;
                    }
                }
            }
            return PartialView("_DonDangKy_RungTrong", models);
        }
        public ActionResult LoadCayLauNam()
        {
            return PartialView("_DonDangKy_CAYLAUNAM");
        }
        public ActionResult ChiTietCayLauNam(string idtaisan, string loaitaisan)
        {
            BoHoSoModel bhs = (BoHoSoModel)Session["BoHoSo_" + CurrentUser.UserName];
            var models = new DangKyTaiSan();
            foreach (var item in bhs.HoSoTN.DonDangKy.DSDangKyTaiSan)
            {
                if (item.TAISANID == idtaisan)
                {
                    models.CurCayLauNam = item.TaiSanGanLienVoiDat.CayLauNam;
                    models.mota = item.MOTATOMTAT;
                    break;
                }
            }
            return PartialView("_DonDangKy_CAYLAUNAM", models);
        }
        public ActionResult LoadCongTrinhXayDung()
        {
            return PartialView("_DonDangKy_CONGTRINHXAYDUNG");
        }
        public ActionResult ChiTietCongTrinhXayDung(string idtaisan, string loaitaisan)
        {
            BoHoSoModel bhs = (BoHoSoModel)Session["BoHoSo_" + CurrentUser.UserName];
            var models = new DangKyTaiSan();
            models.tenxats = bhs.HoSoTN.TenKVHC;
            foreach (var item in bhs.HoSoTN.DonDangKy.DSDangKyTaiSan)
            {
                if (loaitaisan == "6")
                {
                    if (item.TAISANID == idtaisan)
                    {
                        models.CurCongTrinhXayDung = item.TaiSanGanLienVoiDat.CongTrinhXayDung;
                        models.mota = item.MOTATOMTAT;
                        break;
                    }
                }
            }
            return PartialView("_DonDangKy_CONGTRINHXAYDUNG", models);
        }
        public ActionResult LoadCongTrinhNgam()
        {

            return PartialView("_DonDangKy_CongTrinhNgam");
        }
        public ActionResult ChiTietCongTrinhNgam(string idtaisan, string loaitaisan)
        {
            BoHoSoModel bhs = (BoHoSoModel)Session["BoHoSo_" + CurrentUser.UserName];
            var models = new DangKyTaiSan();
            models.tenxats = bhs.HoSoTN.TenKVHC;
            foreach (var item in bhs.HoSoTN.DonDangKy.DSDangKyTaiSan)
            {
                if (loaitaisan == "7")
                {
                    if (item.TAISANID == idtaisan)
                    {
                        models.CurCongTrinhNgam = item.TaiSanGanLienVoiDat.CongTrinhNgam;
                        models.mota = item.MOTATOMTAT;
                        break;
                    }
                }
            }
            return PartialView("_DonDangKy_CongTrinhNgam", models);
        }
        public ActionResult LoadHangMucCongTrinh()
        {
            BoHoSoModel bhs = (BoHoSoModel)Session["BoHoSo_" + CurrentUser.UserName];
            ViewBag.listcongtrinhxaydung = DCTAISANGANLIENVOIDATServices.getdc_congtrinhxaydung(bhs);
            return PartialView("_DonDangKy_HangMucCongTrinh");
        }
        public ActionResult ChiTietHangMucCongTrinh(string idtaisan, string loaitaisan)
        {
            BoHoSoModel bhs = (BoHoSoModel)Session["BoHoSo_" + CurrentUser.UserName];
            var models = new DangKyTaiSan();
            models.tenxats = bhs.HoSoTN.TenKVHC;
            foreach (var item in bhs.HoSoTN.DonDangKy.DSDangKyTaiSan)
            {
                if (loaitaisan == "8")
                {
                    if (idtaisan == item.TAISANID)
                    {
                        models.CurHangMucCongTrinh = item.TaiSanGanLienVoiDat.HangMucCongTrinh;
                        models.mota = item.MOTATOMTAT;
                        break;
                    }
                }
            }
            ViewBag.listcongtrinhxaydung = DCTAISANGANLIENVOIDATServices.getdc_congtrinhxaydung(bhs);
            return PartialView("_DonDangKy_HangMucCongTrinh", models);
        }
        #endregion
        #region xử lý thông tin tài sản
        public ActionResult ThemMoiTaiSanDK(DangKyTaiSan models, string dSSHTaiSan, string dShmch, int LoaiTaiSan)
        {
            BoHoSoModel bhs = (BoHoSoModel)Session["BoHoSo_" + CurrentUser.UserName];
            DC_DIACHI diachi = (DC_DIACHI)Session["diachitaisan"];
            DCTAISANGANLIENVOIDATServices.ThemMoiTaiSan(bhs, dSSHTaiSan, models, LoaiTaiSan, dShmch, diachi);
            Session["BoHoSo_" + CurrentUser.UserName] = bhs;
            VM_XuLyHoSo_DK GCNVM = new VM_XuLyHoSo_DK();
            GCNVM.initData(bhs);
            return PartialView("_lstTaiSanDK", GCNVM);
        }
        public ActionResult XoaTaiSanDK(string taisanid, string dondangky_id)
        {
            try
            {
                BoHoSoModel bhs = (BoHoSoModel)Session["BoHoSo_" + CurrentUser.UserName];
                foreach (var item in bhs.HoSoTN.DonDangKy.DSDangKyTaiSan)
                {
                    if (item.TAISANID == taisanid && item.DONDANGKYID == dondangky_id)
                    {
                        item.trangthaitaisan = 3;
                    }
                }
                Session["BoHoSo_" + CurrentUser.UserName] = bhs;
                VM_XuLyHoSo_DK GCNVM = new VM_XuLyHoSo_DK();
                GCNVM.initData(bhs);
                return PartialView("_lstTaiSanDK", GCNVM);
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        public JsonResult Save_formDonDangKy_DSTAISAN()
        {
            bool save = false;

            List<DC_DANGKY_TAISAN> DSDangKyTaiSan = new List<DC_DANGKY_TAISAN>();
            BoHoSoModel bhs = (BoHoSoModel)Session["BoHoSo_" + CurrentUser.UserName];
            DSDangKyTaiSan = bhs.HoSoTN.DonDangKy.DSDangKyTaiSan;
            save = DCTAISANGANLIENVOIDATServices.SaveDangKyTaiSan(DSDangKyTaiSan);
            if (save)
            {
                for (var i = 0; i <= DSDangKyTaiSan.Count - 1; i++)
                {
                    if (DSDangKyTaiSan[i].trangthaitaisan == 3)
                    {
                        DSDangKyTaiSan.RemoveAt(i);
                    }
                    else
                    {
                        DSDangKyTaiSan[i].trangthaitaisan = 0;
                    }
                }
                bhs.HoSoTN.DonDangKy.DSDangKyTaiSan = DSDangKyTaiSan;
                Session["BoHoSo_" + CurrentUser.UserName] = bhs;
                return Json("true", JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json("false", JsonRequestBehavior.AllowGet);
            }
        }
        #endregion
        #region combo căn hộ
        #region popup_khuchungcu
        public ActionResult _DonDangKy_KhuChungCu(string id)
        {
            ViewBag.ID = id;
            return PartialView("_DonDangKy_KhuChungCu");
        }
        public ActionResult _ChiTietKhuChungCu(string t)
        {
            BoHoSoModel bhs = (BoHoSoModel)Session["BoHoSo_" + CurrentUser.UserName];
            var models = new DangKyTaiSan();
            foreach (var item in bhs.HoSoTN.DonDangKy.DSDangKyTaiSan)
            {
                if (item.TaiSanGanLienVoiDat.KhuChungCu != null)
                {
                    if (item.TaiSanGanLienVoiDat.KhuChungCu.KHUCHUNGCUID == t)
                    {
                        models.CurKhuChungCu = item.TaiSanGanLienVoiDat.KhuChungCu;
                    }
                }

            }

            models.tenxats = bhs.HoSoTN.TenKVHC;
            return PartialView("_ChiTietKhuChungCu", models);
        }
        public ActionResult _ChiTietNhaChungCu(string t)
        {
            ViewBag.IDNCC = t;
            return PartialView("_ChiTietNhaChungCu");
        }
        public ActionResult _ChiTietHangMucNCH(string t)
        {
            ViewBag.IDNCC = t;
            return PartialView("_ChiTietHangMucNCH");
        }
        public ActionResult lstNhaChungCu(string t)
        {
            BoHoSoModel bhs = (BoHoSoModel)Session["BoHoSo_" + CurrentUser.UserName];
            DangKyTaiSan obj = new DangKyTaiSan();
            if (t != "")
            {
                foreach (var item in bhs.HoSoTN.DonDangKy.DSDangKyTaiSan)
                {
                    if (item.TaiSanGanLienVoiDat.NhaChungCu != null && item.TaiSanGanLienVoiDat.NhaChungCu.KHUCHUNGCUID == t)
                    {
                        obj.lstNhaChungCu.Add(item.TaiSanGanLienVoiDat.NhaChungCu);
                    }
                }
            }
            else
            {
                foreach (var item in bhs.HoSoTN.DonDangKy.DSDangKyTaiSan)
                {
                    if (item.TaiSanGanLienVoiDat.NhaChungCu != null)
                    {
                        obj.lstNhaChungCu.Add(item.TaiSanGanLienVoiDat.NhaChungCu);
                    }
                }
            }
            return PartialView(obj);
        }
        public PartialViewResult _lstHangMucNCH(string t)
        {
            BoHoSoModel bhs = (BoHoSoModel)Session["BoHoSo_" + CurrentUser.UserName];
            DangKyTaiSan obj = new DangKyTaiSan();
            if (t != "")
            {
                foreach (var item in bhs.HoSoTN.DonDangKy.DSDangKyTaiSan)
                {
                    if (item.TaiSanGanLienVoiDat.NhaChungCu != null)
                    {
                        if (item.TaiSanGanLienVoiDat.NhaChungCu.KHUCHUNGCUID == t)
                            obj.lstNhaChungCu.Add(item.TaiSanGanLienVoiDat.NhaChungCu);
                    }
                }
                foreach (var item in bhs.HoSoTN.DonDangKy.DSDangKyTaiSan)
                {
                    foreach (var a in obj.lstNhaChungCu)
                    {
                        if (item.TaiSanGanLienVoiDat.HangMucNgoaiCanHo != null && item.trangthaitaisan != 3 && a.NHACHUNGCUID == item.TaiSanGanLienVoiDat.HangMucNgoaiCanHo.NHACHUNGCUID)
                        {
                            obj.lstHangMucNgoaiCanHo.Add(item.TaiSanGanLienVoiDat.HangMucNgoaiCanHo);
                        }
                    }
                }
            }
            else
            {
                foreach (var item in bhs.HoSoTN.DonDangKy.DSDangKyTaiSan)
                {
                    if (item.TaiSanGanLienVoiDat.HangMucNgoaiCanHo != null && item.trangthaitaisan != 3)
                        obj.lstHangMucNgoaiCanHo.Add(item.TaiSanGanLienVoiDat.HangMucNgoaiCanHo);
                }
            }
            return PartialView(obj);
        }
        public ActionResult LoadNhaChungCu(string a)
        {
            BoHoSoModel bhs = (BoHoSoModel)Session["BoHoSo_" + CurrentUser.UserName];
            ViewBag.listkhuchungcu = DCTAISANGANLIENVOIDATServices.getdc_khuchungcu(bhs);
            var models = new DangKyTaiSan();
            if (a != "")
            {
                models.CurNhaChungCu.KHUCHUNGCUID = a;
            }
            models.tenxats = bhs.HoSoTN.TenKVHC;

            return PartialView("_DonDangKy_NhaChungCu", models);
        }
        public ActionResult ChiTietNhaChungCu(string idtaisan, string loaitaisan)
        {
            BoHoSoModel bhs = (BoHoSoModel)Session["BoHoSo_" + CurrentUser.UserName];
            var models = new DangKyTaiSan();
            foreach (var item in bhs.HoSoTN.DonDangKy.DSDangKyTaiSan)
            {
                if (loaitaisan == "3")
                {
                    if (idtaisan == item.TAISANID)
                    {
                        models.CurNhaChungCu = item.TaiSanGanLienVoiDat.NhaChungCu;
                    }
                }
            }
            models.tenxats = bhs.HoSoTN.TenKVHC;
            ViewBag.listkhuchungcu = DCTAISANGANLIENVOIDATServices.getdc_khuchungcu(bhs);
            return PartialView("_DonDangKy_NhaChungCu", models);
        }
        public ActionResult LoadHangMucNgoaiCanHo(string a)
        {
            BoHoSoModel bhs = (BoHoSoModel)Session["BoHoSo_" + CurrentUser.UserName];
            if (a != null && a != "")
            {
                ViewBag.listnhachungcu = DCTAISANGANLIENVOIDATServices.getdc_nhachungcu(bhs, a);
            }
            else
            {
                ViewBag.listnhachungcu = DCTAISANGANLIENVOIDATServices.getdc_nhachungcu(bhs, a);
            }
            ViewBag.listkhuchungcu = DCTAISANGANLIENVOIDATServices.getdc_khuchungcu(bhs);

            return PartialView("_DonDangKy_HangMucNgoaiCanHo");
        }
        public ActionResult ChiTietHangMucNgoaiCanHo(string idtaisan, string loaitaisan)
        {
            BoHoSoModel bhs = (BoHoSoModel)Session["BoHoSo_" + CurrentUser.UserName];
            var models = new DangKyTaiSan();
            string t4 = "";
            foreach (var item in bhs.HoSoTN.DonDangKy.DSDangKyTaiSan)
            {
                if (loaitaisan == "5")
                {
                    if (idtaisan == item.TAISANID)
                    {
                        models.CurHangMucNgoaiCanHo = item.TaiSanGanLienVoiDat.HangMucNgoaiCanHo;
                    }
                }
            }
            models.CurNhaChungCu.NHACHUNGCUID = models.CurCanHo.NHACHUNGCUID;
            ViewBag.listkhuchungcu = DCTAISANGANLIENVOIDATServices.getdc_khuchungcu(bhs);
            ViewBag.listnhachungcu = DCTAISANGANLIENVOIDATServices.getdc_nhachungcu(bhs, t4);
            return PartialView("_DonDangKy_HangMucNgoaiCanho", models);
        }
        #endregion
        #region popup_nhachungcu
        public ActionResult _Popup_NhaChungCu(string a)
        {
            ViewBag.Loadncc = a;
            return PartialView("_Popup_NhaChungCu");
        }
        public ActionResult _DonDangKy_ncc_ch(string t)
        {
            BoHoSoModel bhs = (BoHoSoModel)Session["BoHoSo_" + CurrentUser.UserName];
            ViewBag.listkhuchungcu = DCTAISANGANLIENVOIDATServices.getdc_khuchungcu(bhs);
            var models = new DangKyTaiSan();
            if (t != "")
            {
                foreach (var item in bhs.HoSoTN.DonDangKy.DSDangKyTaiSan)
                {
                    if (item.TaiSanGanLienVoiDat.NhaChungCu != null)
                    {
                        if (t == item.TaiSanGanLienVoiDat.NhaChungCu.NHACHUNGCUID)
                        {
                            models.CurNhaChungCu = item.TaiSanGanLienVoiDat.NhaChungCu;
                        }
                    }

                }
            }
            models.tenxats = bhs.HoSoTN.TenKVHC;
            return PartialView("_DonDangKy_ncc_ch", models);
        }
        public ActionResult LoadNhaChungCuCH()
        {
            BoHoSoModel bhs = (BoHoSoModel)Session["BoHoSo_" + CurrentUser.UserName];
            ViewBag.listkhuchungcu = DCTAISANGANLIENVOIDATServices.getdc_khuchungcu(bhs);
            return PartialView("_DonDangKy_ncc_ch");
        }
        #endregion
        #region căn hộ
        public ActionResult _lstThuaTSCH()
        {
            BoHoSoModel bhs = (BoHoSoModel)Session["BoHoSo_" + CurrentUser.UserName];
            VM_XuLyHoSo_DK GCNVM = new VM_XuLyHoSo_DK();
            GCNVM.initData(bhs);
            return PartialView("_lstThuaTSCH", GCNVM);
        }
        public PartialViewResult _lstcheckhangmucNCH()
        {
            BoHoSoModel bhs = (BoHoSoModel)Session["BoHoSo_" + CurrentUser.UserName];
            VM_XuLyHoSo_DK GCNVM = new VM_XuLyHoSo_DK();
            GCNVM.initData(bhs);
            return PartialView(GCNVM);
        }
        public ActionResult LoadCanHo()
        {
            string t4 = "";
            BoHoSoModel bhs = (BoHoSoModel)Session["BoHoSo_" + CurrentUser.UserName];
            ViewBag.listkhuchungcu = DCTAISANGANLIENVOIDATServices.getdc_khuchungcu(bhs);
            ViewBag.listnhachungcu = DCTAISANGANLIENVOIDATServices.getdc_nhachungcu(bhs, t4);
            ViewBag.lsttinhtrangdk = DCTAISANGANLIENVOIDATServices.get_tinhtrangcanho();
            return PartialView("_DonDangKy_CanHo");
        }
        public ActionResult ChiTietCanHo(string idtaisan, string loaitaisan)
        {
            BoHoSoModel bhs = (BoHoSoModel)Session["BoHoSo_" + CurrentUser.UserName];
            var models = new DangKyTaiSan();
            string t4 = "";
            foreach (var item in bhs.HoSoTN.DonDangKy.DSDangKyTaiSan)
            {
                if (loaitaisan == "4")
                {
                    if (idtaisan == item.TAISANID)
                    {
                        models.CurCanHo = item.TaiSanGanLienVoiDat.CanHo;
                    }
                }
            }
            models.CurNhaChungCu.NHACHUNGCUID = models.CurCanHo.NHACHUNGCUID;
            foreach (var item in bhs.HoSoTN.DonDangKy.DSDangKyTaiSan)
            {
                if (item.TaiSanGanLienVoiDat.NhaChungCu != null)
                {
                    if (models.CurNhaChungCu.NHACHUNGCUID == item.TaiSanGanLienVoiDat.NhaChungCu.NHACHUNGCUID)
                    {
                        models.CurNhaChungCu.KHUCHUNGCUID = item.TaiSanGanLienVoiDat.NhaChungCu.KHUCHUNGCUID;
                    }
                }
            }
            ViewBag.listkhuchungcu = DCTAISANGANLIENVOIDATServices.getdc_khuchungcu(bhs);
            ViewBag.listnhachungcu = DCTAISANGANLIENVOIDATServices.getdc_nhachungcu(bhs, t4);
            ViewBag.lsttinhtrangdk = DCTAISANGANLIENVOIDATServices.get_tinhtrangcanho();
            return PartialView("_DonDangKy_CanHo", models);
        }
        #endregion
        #region xử lý thông tin
        #region Nhà chung cư
        public ActionResult ThemMoiNhaChungCu(DangKyTaiSan models)
        {
            BoHoSoModel bhs = (BoHoSoModel)Session["BoHoSo_" + CurrentUser.UserName];
            DC_DIACHI diachi = new DC_DIACHI();
            DCTAISANGANLIENVOIDATServices.ThemMoiTaiSan(bhs, "", models, 3, "", diachi);
            Session["BoHoSo_" + CurrentUser.UserName] = bhs;
            foreach (var item in bhs.HoSoTN.DonDangKy.DSDangKyTaiSan)
            {
                if (item.TaiSanGanLienVoiDat.NhaChungCu != null)
                {
                    if (item.TaiSanGanLienVoiDat.NhaChungCu.KHUCHUNGCUID == models.CurNhaChungCu.KHUCHUNGCUID)
                        models.lstNhaChungCu.Add(item.TaiSanGanLienVoiDat.NhaChungCu);
                }
            }
            return PartialView("lstNhaChungCu", models);
        }
        #endregion
        #region hạng mục ngoài căn hộ
        public ActionResult ThemMoiHangMucNgoaiCanHo(DangKyTaiSan models)
        {
            BoHoSoModel bhs = (BoHoSoModel)Session["BoHoSo_" + CurrentUser.UserName];
            DC_DIACHI diachi = new DC_DIACHI();
            DCTAISANGANLIENVOIDATServices.ThemMoiTaiSan(bhs, "", models, 5, "", diachi);
            Session["BoHoSo_" + CurrentUser.UserName] = bhs;
            VM_XuLyHoSo_DK GCNVM = new VM_XuLyHoSo_DK();
            GCNVM.initData(bhs);
            return PartialView("_lstHangMucNCH");
        }
        public ActionResult XOA_HANGMUCNGOAICANHO(string taisanid, string dondangky_id)
        {
            try
            {
                BoHoSoModel bhs = (BoHoSoModel)Session["BoHoSo_" + CurrentUser.UserName];

                foreach (var item in bhs.HoSoTN.DonDangKy.DSDangKyTaiSan)
                {
                    if (item.TAISANID == taisanid)
                    {
                        item.trangthaitaisan = 3;
                    }
                }

                Session["BoHoSo_" + CurrentUser.UserName] = bhs;
                return PartialView("_lstHangMucNCH");
            }
            catch (Exception ex)
            {

                throw;
            }

        }
        #endregion
        #region khu chung cư         
        public ActionResult ThemMoiKhuChungCu(DangKyTaiSan models)
        {
            BoHoSoModel bhs = (BoHoSoModel)Session["BoHoSo_" + CurrentUser.UserName];
            DC_DIACHI diachi = new DC_DIACHI();
            DCTAISANGANLIENVOIDATServices.ThemMoiTaiSan(bhs, "", models, 2, "", diachi);
            Session["BoHoSo_" + CurrentUser.UserName] = bhs;
            VM_XuLyHoSo_DK GCNVM = new VM_XuLyHoSo_DK();
            GCNVM.initData(bhs);
            var result = new { TAISANID = models.CurKhuChungCu.uId, loaitaisan = "Khu chung cư", dientich = models.CurKhuChungCu.DIENTICHKHU, LOAITAISAN = "2", gjson = GCNVM.JSONTSThua };
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        #endregion
        #endregion
        #endregion
        #region popup_diachi
        public ActionResult _DiaChiTaiSan(string id)
        {
            BoHoSoModel bhs = (BoHoSoModel)Session["BoHoSo_" + CurrentUser.UserName];
            DC_DIACHI diachi = new DC_DIACHI();
            if (id == null || id == "")
            {
                ViewBag.huyendiachi = new List<HC_HUYEN>();
                ViewBag.xadiachi = new List<HC_DMKVHC>();
            }
            else
            {
                var taisan = (from a in bhs.HoSoTN.DonDangKy.DSDangKyTaiSan where a.TaiSanGanLienVoiDat.TAISANID == id select a).FirstOrDefault();
                diachi = taisan.TaiSanGanLienVoiDat.diachitaisan;
                if (diachi.TENHUYEN != null && diachi.TENXA != null)
                {
                    ViewBag.xadiachi = DCTAISANGANLIENVOIDATServices.get_xabyhuyen(diachi.TENHUYEN, diachi.TENTINH);
                    ViewBag.huyendiachi = DCTAISANGANLIENVOIDATServices.get_huyenbytinh(diachi.TENTINH);

                }
                else
                {
                    ViewBag.huyendiachi = new List<HC_HUYEN>();
                    ViewBag.xadiachi = new List<HC_DMKVHC>();
                }
            }
            ViewBag.tinhdiachi = DCTAISANGANLIENVOIDATServices.get_tinh();
            return PartialView("Popup_DiaChiTaiSan", diachi);
        }
        public ActionResult ChonHuyen(DC_DIACHI diachi)
        {
            ViewBag.tinhdiachi = DCTAISANGANLIENVOIDATServices.get_tinh();
            ViewBag.huyendiachi = Session["chonhuyen"] = DCTAISANGANLIENVOIDATServices.get_huyenbytinh(diachi.TENTINH);
            ViewBag.xadiachi = new List<HC_DMKVHC>();

            return PartialView("_ChiTietDiaChi", diachi);
        }
        public ActionResult ChonXa(DC_DIACHI diachi)
        {
            ViewBag.tinhdiachi = DCTAISANGANLIENVOIDATServices.get_tinh();
            ViewBag.huyendiachi = Session["chonhuyen"];
            ViewBag.xadiachi = DCTAISANGANLIENVOIDATServices.get_xabyhuyen(diachi.TENHUYEN, diachi.TENTINH);
            return PartialView("_ChiTietDiaChi", diachi);
        }
        public ActionResult ThemDiaChi(DC_DIACHI diachi)
        {
            diachi.DIACHIID = Guid.NewGuid().ToString();
            diachi.DIACHIDAYDU = diachi.DIACHICHITIET + "," + diachi.TENDUONGPHO + "," + diachi.TENTODANPHO + "," + diachi.TENXA + "," + diachi.TENHUYEN + "," + diachi.TENTINH;
            Session["diachitaisan"] = diachi;
            return Json(diachi.DIACHIDAYDU, JsonRequestBehavior.AllowGet);
        }
        public ActionResult LoadDiaChi()
        {
            ViewBag.tinhdiachi = DCTAISANGANLIENVOIDATServices.get_tinh();
            ViewBag.huyendiachi = new List<HC_HUYEN>();
            ViewBag.xadiachi = new List<HC_DMKVHC>();
            return PartialView("_ChiTietDiaChi");
        }
        #endregion
        #endregion
        #endregion
    }
    public class objgcn
    {
        public string idgcn { get; set; }
    }
}
