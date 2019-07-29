using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AppCore.Models;
using AutoMapper;
using MPLIS.Libraries.Data.XuLyHoSo.Models;
using System.Data.Entity;
using System.Data.Common;

namespace MPLIS.Libraries.Services.XuLyHoSo.Classes
{
    public static class DCHOGIADINHServices
    {
        public static DC_HOGIADINH GetHoGiaDinh(string hoGiaDinhID, MplisEntities db)
        {
            DC_HOGIADINH objHoGiaDinh = null;
            var retHoGiaDinh = db.DC_HOGIADINH.Where(it => it.HOGIADINHID == hoGiaDinhID)
                .Select(hoGiaDinh => new
                {
                    hoGiaDinh,
                    thanhViens = db.DC_HOGIADINH_THANHVIEN.Where(it => it.HOGIADINHID.Equals(hoGiaDinh.HOGIADINHID))
                    .Select(thanhVien => new
                    {
                        thanhVien,
                        caNhan = db.DC_CANHAN.Where(it => it.CANHANID.Equals(thanhVien.CANHANID))
                        .Select(cN => new
                        {
                            cN,
                            giayTos = db.DC_GIAYTOTUYTHAN.Where(it => it.CANHANID.Equals(cN.CANHANID))
                            .Select(giayTo => new
                            {
                                giayTo,
                                tenGiayTo = db.DM_LOAIGIAYTOTUYTHAN.Where(it => it.LOAIGIAYTOTUYTHANID.Equals(giayTo.LOAIGIAYTOTUYTHANID))
                                .Select(it => it.TENLOAIGIAYTOTUYTHAN)
                                .FirstOrDefault()
                            }).ToList()
                        }).FirstOrDefault(),
                        tenQuanHe = db.DM_QHVOICHUHO.Where(it => it.QHVOICHUHOID.Equals(thanhVien.QHVOICHUHOID))
                        .Select(it => it.TENQUANHE)
                        .FirstOrDefault()
                    }).ToList()
                }).FirstOrDefault();
            if (retHoGiaDinh != null)
            {
                objHoGiaDinh = retHoGiaDinh.hoGiaDinh;
                objHoGiaDinh.TRANGTHAI = 2;
                retHoGiaDinh.hoGiaDinh.DSThanhVien = new List<DC_HOGIADINH_THANHVIEN>();
                foreach (var tempThanhVien in retHoGiaDinh.thanhViens)
                {
                    tempThanhVien.thanhVien.TRANGTHAI = 2;
                    tempThanhVien.thanhVien.ThanhVien = tempThanhVien.caNhan.cN;
                    tempThanhVien.thanhVien.ThanhVien.TRANGTHAI = 2;
                    tempThanhVien.thanhVien.TenQuanHe = tempThanhVien.tenQuanHe;
                    tempThanhVien.thanhVien.ThanhVien.DSGiayToTuyThan = new List<DC_GIAYTOTUYTHAN>();
                    foreach(var tempGiayTo in tempThanhVien.caNhan.giayTos)
                    {
                        tempGiayTo.giayTo.TenGiayToTuyThan = tempGiayTo.tenGiayTo;
                        tempThanhVien.thanhVien.ThanhVien.DSGiayToTuyThan.Add(tempGiayTo.giayTo);
                    }
                    if(tempThanhVien.thanhVien.QHVOICHUHOID == "DBE8EB8DA18049ED8E253B2685769746")
                    {
                        objHoGiaDinh.CMTCHUHO = tempThanhVien.thanhVien.ThanhVien.SOGIAYTO;
                        objHoGiaDinh.CHUHO_HOTEN = tempThanhVien.thanhVien.ThanhVien.HOTEN;
                        objHoGiaDinh.ChuHoCN = tempThanhVien.thanhVien.ThanhVien;
                    }
                    if (tempThanhVien.thanhVien.QHVOICHUHOID == "CD487A3FFF9B45B3BAC998F80F68622C" || tempThanhVien.thanhVien.QHVOICHUHOID == "87D621F7C7004637BD871BAB0D97068D")
                    {
                        objHoGiaDinh.CMTVOCHONG = tempThanhVien.thanhVien.ThanhVien.SOGIAYTO;
                        objHoGiaDinh.VOCHONG_HOTEN = tempThanhVien.thanhVien.ThanhVien.HOTEN;
                        objHoGiaDinh.VoChongCN = tempThanhVien.thanhVien.ThanhVien;
                    }
                    retHoGiaDinh.hoGiaDinh.DSThanhVien.Add(tempThanhVien.thanhVien);
                }
                objHoGiaDinh.DSThanhVien = retHoGiaDinh.hoGiaDinh.DSThanhVien;
            }
            return objHoGiaDinh;
        }
        public static void SaveHoGiaDinh(DC_HOGIADINH hoGiaDinh, MplisEntities db)
        {
            //Xóa tất thành viên liên quan tới hộ gia đình
            if (db.Database.Connection.State == System.Data.ConnectionState.Closed
                    || db.Database.Connection.State == System.Data.ConnectionState.Broken)
                db.Database.Connection.Open();
            DbCommand cmd = db.Database.Connection.CreateCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "BEGIN DELETE DC_HOGIADINH_THANHVIEN WHERE HOGIADINHID IN ('" + hoGiaDinh.HOGIADINHID + "'); END; ";
            cmd.ExecuteNonQuery();
            if (hoGiaDinh.TRANGTHAI == 1)
            {
                db.Entry(Mapper.Map<DC_HOGIADINH, DC_HOGIADINH>(hoGiaDinh)).State = EntityState.Added;
                hoGiaDinh.TRANGTHAI = 2;
            }
            else if (hoGiaDinh.TRANGTHAI == 2)
            {
                db.Entry(Mapper.Map<DC_HOGIADINH, DC_HOGIADINH>(hoGiaDinh)).State = EntityState.Modified;
            }
            foreach (var temp in hoGiaDinh.DSThanhVien)
            {
                DCCANHANServices.SaveCaNhan(temp.ThanhVien, db);
                DCHOGIADINHTHANHVIENServies.SaveHoGiaDinhThanhVien(temp, db);
            }
        }
    }
}