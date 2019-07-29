using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AppCore.Models;
using MPLIS.Libraries.Data.XuLyHoSo.Models;
using AutoMapper;
using System.Data.Entity;
using Newtonsoft.Json;
using System.Data.Common;

namespace MPLIS.Libraries.Services.XuLyHoSo.Classes
{
    public static class DCDANGKYNGUOIServices
    {
        public static bool XoaChuTrongDangKy(string dangKyNguoiID, List<DC_DANGKY_NGUOI> dSDangKyChu, out string mes)
        {
            DC_DANGKY_NGUOI dangKyChu = null;
            foreach (var tempDangKyChu in dSDangKyChu)
            {
                if (tempDangKyChu.DANGKYNGUOIID == dangKyNguoiID)
                {
                    dangKyChu = tempDangKyChu;
                    break;
                }
            }
            if (dangKyChu != null)
            {
                try
                {
                    using (MplisEntities db = new MplisEntities())
                    {
                        db.Entry(dangKyChu).State = EntityState.Deleted;
                        db.SaveChanges();
                    }
                }
                catch (Exception ex)
                {
                    var err = ex;
                    mes = ex.Message;
                    return false;
                }
                dSDangKyChu.Remove(dangKyChu);
                mes = "Xóa chủ trong đăng ký thành công!";
                return true;
            }
            mes = "Dữ liệu không đúng?";
            return false;
        }
        public static bool SaveDangKyNguoi(DC_DANGKY_NGUOI dangKyNguoi, List<DC_DANGKY_NGUOI> dSDangKyNguoi, out string mes)
        {
            string str = "";
            try
            {
                //CSDL:
                using (MplisEntities db = new MplisEntities())
                {
                    switch (dangKyNguoi.Chu.LOAIDOITUONGID)
                    {
                        case "1":
                            dangKyNguoi.Chu.CaNhan.setHoTen();
                            if (dangKyNguoi.TRANGTHAI == 1)
                                str = "Thêm mới Cá nhân: " + dangKyNguoi.Chu.CaNhan.HOTEN + " vào đăng ký thành công!";
                            else if (dangKyNguoi.TRANGTHAI == 2)
                                str = "Cập nhật Cá nhân: " + dangKyNguoi.Chu.CaNhan.HOTEN + " trong đăng ký thành công!";
                            DCCANHANServices.SaveCaNhan(dangKyNguoi.Chu.CaNhan, db);
                            break;
                        case "2":
                            if (dangKyNguoi.TRANGTHAI == 1)
                                str = "Thêm mới Hộ Gia Đình: " + " vào đăng ký thành công!";
                            else if (dangKyNguoi.TRANGTHAI == 2)
                                str = "Cập nhật Hộ Gia Đình: " + " trong đăng ký thành công!";
                            DCHOGIADINHServices.SaveHoGiaDinh(dangKyNguoi.Chu.HoGiaDinh, db);
                            break;
                        case "3":
                            if (dangKyNguoi.TRANGTHAI == 1)
                                str = "Thêm mới Vợ Chồng: " + " vào đăng ký thành công!";
                            else if (dangKyNguoi.TRANGTHAI == 2)
                                str = "Cập nhật Vợ Chồng: " + " trong đăng ký thành công!";
                            DCVOCHONGServices.SaveVoChong(dangKyNguoi.Chu.VoChong, db);
                            break;
                        case "4":
                            if (dangKyNguoi.TRANGTHAI == 1)
                                str = "Thêm mới Tổ Chức: " + " vào đăng ký thành công!";
                            else if (dangKyNguoi.TRANGTHAI == 2)
                                str = "Cập nhật Tổ Chức: " + " trong đăng ký thành công!";
                            DCTOCHUCServices.SaveToChuc(dangKyNguoi.Chu.ToChuc, db);
                            break;
                        case "5":
                            if (dangKyNguoi.TRANGTHAI == 1)
                                str = "Thêm mới Cộng Đồng: " + " vào đăng ký thành công!";
                            else if (dangKyNguoi.TRANGTHAI == 2)
                                str = "Cập nhật Cộng Đồng: " + " trong đăng ký thành công!";
                            DCCONGDONGServices.SaveCongDong(dangKyNguoi.Chu.CongDong, db);
                            break;
                        case "6":
                            if (dangKyNguoi.TRANGTHAI == 1)
                                str = "Thêm mới Nhóm Người: " + " vào đăng ký thành công!";
                            else if (dangKyNguoi.TRANGTHAI == 2)
                                str = "Cập nhật Nhóm Người: " + " trong đăng ký thành công!";
                            DCNHOMNGUOIServices.SaveNhomNguoi(dangKyNguoi.Chu.NhomNguoi, db);
                            break;
                    }
                    DCNGUOIServices.SaveNguoi(dangKyNguoi.Chu, db);
                    if (dangKyNguoi.TRANGTHAI == 1)
                    {
                        db.Entry(Mapper.Map<DC_DANGKY_NGUOI, DC_DANGKY_NGUOI>(dangKyNguoi)).State = EntityState.Added;
                        dangKyNguoi.TRANGTHAI = 2;
                    }
                    else if (dangKyNguoi.TRANGTHAI == 2)
                    {
                        db.Entry(Mapper.Map<DC_DANGKY_NGUOI, DC_DANGKY_NGUOI>(dangKyNguoi)).State = EntityState.Modified;
                    }
                    db.SaveChanges();
                }
                //Session:
                dangKyNguoi.InitData();
                if (dangKyNguoi.TRANGTHAI == 2)
                {
                    DC_DANGKY_NGUOI dangKyNguoiTemp = null;
                    foreach (var temp in dSDangKyNguoi)
                    {
                        if (temp.DANGKYNGUOIID == dangKyNguoi.DANGKYNGUOIID)
                        {
                            dangKyNguoiTemp = temp;
                            break;
                        }
                    }
                    if (dangKyNguoiTemp != null)
                        dSDangKyNguoi.Remove(dangKyNguoiTemp);
                }
                dSDangKyNguoi.Add(dangKyNguoi);
                mes = str;
                return true;
            }
            catch (Exception ex)
            {
                var err = ex;
                mes = ex.Message;
                return false;
            }
        }
        public static bool XoaNguoiTrongDangKyByNguoiID(string nguoiID, BoHoSoModel bhs)
        {
            DC_DANGKY_NGUOI dangKyNguoi = null;
            foreach (var tempDangKyNguoi in bhs.HoSoTN.DonDangKy.DSDangKyChu)
            {
                if (tempDangKyNguoi.NGUOIID == nguoiID)
                {
                    dangKyNguoi = tempDangKyNguoi;
                    break;
                }
            }
            if (dangKyNguoi != null && DBDeleteDangKyNguoi(dangKyNguoi))
            {
                bhs.HoSoTN.DonDangKy.DSDangKyChu.Remove(dangKyNguoi);
                return true;
            }
            return false;
        }
        public static bool XemThongTinChiTiet(string dangKyNguoiID, BoHoSoModel bhs, DangKyNguoiVM dangKyNguoiVM)
        {
            DC_DANGKY_NGUOI dangKyNguoi = null;
            foreach (var tempDangKyNguoi in bhs.HoSoTN.DonDangKy.DSDangKyChu)
            {
                if (tempDangKyNguoi.DANGKYNGUOIID == dangKyNguoiID)
                {
                    dangKyNguoi = tempDangKyNguoi;
                    break;
                }
            }
            if (dangKyNguoi != null)
            {
                bhs.HoSoTN.DonDangKy.CurDangKyNguoi = Mapper.Map<DC_DANGKY_NGUOI, DC_DANGKY_NGUOI>(dangKyNguoi);
                Mapper.Map<DC_DANGKY_NGUOI, DangKyNguoiVM>(dangKyNguoi, dangKyNguoiVM);
                dangKyNguoiVM.DSDoiTuongSuDung = DONDANGKYServices.GetDM_DOITUONGSUDUNG(dangKyNguoi.LOAI ?? 0M);
                return true;
            }
            return false;
        }
        public static bool DBInsertOrUpdateDangKyNguoi(DC_DANGKY_NGUOI dangKyNguoi)
        {
            try
            {
                using (MplisEntities db = new MplisEntities())
                {
                    if (dangKyNguoi.DANGKYNGUOIID == null || dangKyNguoi.NGUOICAPNHATID == "")
                    {
                        dangKyNguoi.DANGKYNGUOIID = Guid.NewGuid().ToString();
                        db.Entry(Mapper.Map<DC_DANGKY_NGUOI, DC_DANGKY_NGUOI>(dangKyNguoi)).State = EntityState.Added;
                    }
                    else
                    {
                        db.Entry(Mapper.Map<DC_DANGKY_NGUOI, DC_DANGKY_NGUOI>(dangKyNguoi)).State = EntityState.Modified;
                    }
                    db.SaveChanges();
                }
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }
        public static bool DBDeleteDangKyNguoi(DC_DANGKY_NGUOI dangKyNguoi)
        {
            try
            {
                using (MplisEntities db = new MplisEntities())
                {
                    db.Entry(Mapper.Map<DC_DANGKY_NGUOI, DC_DANGKY_NGUOI>(dangKyNguoi)).State = EntityState.Deleted;
                    db.SaveChanges();
                }
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }
    }
}