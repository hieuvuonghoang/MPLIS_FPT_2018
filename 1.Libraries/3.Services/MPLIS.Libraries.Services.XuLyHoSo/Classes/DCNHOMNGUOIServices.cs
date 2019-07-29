using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using System.Data.Entity;
using MPLIS.Libraries.Data.XuLyHoSo.Models;
using AppCore.Models;
using System.Data.Common;

namespace MPLIS.Libraries.Services.XuLyHoSo.Classes
{
    public static class DCNHOMNGUOIServices
    {
        public static DC_NHOMNGUOI GetNhomNguoi(string nhomNguoiID, MplisEntities db)
        {
            DC_NHOMNGUOI objNhomNguoi = null;
            var retNhomNguoi = db.DC_NHOMNGUOI.Where(it => it.NHOMNGUOIID == nhomNguoiID)
                .Select(nhomNguoi => new
                {
                    nhomNguoi,
                    thanhViens = db.DC_NHOMNGUOI_THANHVIEN.Where(it => it.NHOMNGUOIID == nhomNguoi.NHOMNGUOIID).ToList()
                }).FirstOrDefault();
            if (retNhomNguoi != null)
            {
                objNhomNguoi = retNhomNguoi.nhomNguoi;
                objNhomNguoi.TRANGTHAI = 2;
                retNhomNguoi.nhomNguoi.DSThanhVien = new List<DC_NHOMNGUOI_THANHVIEN>();
                foreach (var tempThanhVien in retNhomNguoi.thanhViens)
                {
                    switch(tempThanhVien.LOAIDOITUONG)
                    {
                        case "1":
                            tempThanhVien.ThanhVienCaNhan = DCCANHANServices.GetCaNhan(tempThanhVien.THANHPHANID, db);
                            break;
                        case "2":
                            tempThanhVien.ThanhVienHoGiaDinh = DCHOGIADINHServices.GetHoGiaDinh(tempThanhVien.THANHPHANID, db);
                            break;
                        case "3":
                            tempThanhVien.ThanhVienVoChong = DCVOCHONGServices.GetVoChong(tempThanhVien.THANHPHANID, db);
                            break;
                        case "4":
                            tempThanhVien.ThanhVienToChuc = DCTOCHUCServices.GetToChuc(tempThanhVien.THANHPHANID, db);
                            break;
                        case "5":
                            tempThanhVien.ThanhVienCongDong = DCCONGDONGServices.GetCongDong(tempThanhVien.THANHPHANID, db);
                            break;
                    }
                    if (tempThanhVien.THANHPHANID == objNhomNguoi.NGUOIDAIDIEN)
                    {
                        tempThanhVien.ISNGUOIDAIDIEN = 1;
                        tempThanhVien.InitData();
                        objNhomNguoi.CMTNGUOIDAIDIEN = tempThanhVien.SOGIAYTO;
                        objNhomNguoi.HoTenNguoiDaiDien = tempThanhVien.HOTEN;
                    }
                    tempThanhVien.InitData();
                    retNhomNguoi.nhomNguoi.DSThanhVien.Add(tempThanhVien);
                }
            }
            return objNhomNguoi;
        }
        public static void SaveNhomNguoi(DC_NHOMNGUOI nhomNguoi, MplisEntities db)
        {
            //Xóa tất thành viên liên quan tới nhóm người
            if (db.Database.Connection.State == System.Data.ConnectionState.Closed
                    || db.Database.Connection.State == System.Data.ConnectionState.Broken)
                db.Database.Connection.Open();
            DbCommand cmd = db.Database.Connection.CreateCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "BEGIN DELETE DC_NHOMNGUOI_THANHVIEN WHERE NHOMNGUOIID IN ('" + nhomNguoi.NHOMNGUOIID + "'); END; ";
            cmd.ExecuteNonQuery();
            if (nhomNguoi.TRANGTHAI == 1)
            {
                db.Entry(Mapper.Map<DC_NHOMNGUOI, DC_NHOMNGUOI>(nhomNguoi)).State = EntityState.Added;
                nhomNguoi.TRANGTHAI = 2;
            }
            else if (nhomNguoi.TRANGTHAI == 2)
            {
                db.Entry(Mapper.Map<DC_NHOMNGUOI, DC_NHOMNGUOI>(nhomNguoi)).State = EntityState.Modified;
            }
            foreach (var temp in nhomNguoi.DSThanhVien)
            {
                switch (temp.LOAIDOITUONG)
                {
                    case "1":
                        DCCANHANServices.SaveCaNhan(temp.ThanhVienCaNhan, db);
                        break;
                    case "2":
                        DCHOGIADINHServices.SaveHoGiaDinh(temp.ThanhVienHoGiaDinh, db);
                        break;
                    case "3":
                        DCVOCHONGServices.SaveVoChong(temp.ThanhVienVoChong, db);
                        break;
                    case "4":
                        DCTOCHUCServices.SaveToChuc(temp.ThanhVienToChuc, db);
                        break;
                    case "5":
                        DCCONGDONGServices.SaveCongDong(temp.ThanhVienCongDong, db);
                        break;
                }
                DCNHOMNGUOITHANHVIENServices.SaveNhomNguoiThanhVien(temp, db);
            }
        }
    }
}