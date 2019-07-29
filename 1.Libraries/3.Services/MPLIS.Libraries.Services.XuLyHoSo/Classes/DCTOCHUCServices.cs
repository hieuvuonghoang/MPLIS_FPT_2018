using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using AppCore.Models;
using MPLIS.Libraries.Data.XuLyHoSo.Models;
using System.Data.Entity;

namespace MPLIS.Libraries.Services.XuLyHoSo.Classes
{
    public static class DCTOCHUCServices
    {
        public static DC_TOCHUC GetToChuc(string toChucID, MplisEntities db)
        {
            DC_TOCHUC objToChuc = null;
            var retToChuc = db.DC_TOCHUC.Where(it => it.TOCHUCID == toChucID)
                .Select(toChuc => new
                {
                    toChuc,
                    nguoiDaiDien = db.DC_CANHAN.Where(it => it.CANHANID.Equals(toChuc.NGUOIDAIDIENID))
                    .Select(caNhan => new
                    {
                        caNhan,
                        giayTos = db.DC_GIAYTOTUYTHAN.Where(it => it.CANHANID.Equals(caNhan.CANHANID))
                        .Select(giayTo => new
                        {
                            giayTo,
                            tenGiayTo = db.DM_LOAIGIAYTOTUYTHAN.Where(it => it.LOAIGIAYTOTUYTHANID.Equals(giayTo.LOAIGIAYTOTUYTHANID))
                            .Select(it => it.TENLOAIGIAYTOTUYTHAN).FirstOrDefault()
                        }).ToList()
                    }).FirstOrDefault()
                }).FirstOrDefault();
            if (retToChuc != null)
            {
                objToChuc = retToChuc.toChuc;
                objToChuc.TRANGTHAI = 2;
                if (retToChuc.nguoiDaiDien != null)
                {
                    retToChuc.nguoiDaiDien.caNhan.DSGiayToTuyThan = new List<DC_GIAYTOTUYTHAN>();
                    foreach (var tempGiayTo in retToChuc.nguoiDaiDien.giayTos)
                    {
                        tempGiayTo.giayTo.TenGiayToTuyThan = tempGiayTo.tenGiayTo;
                        retToChuc.nguoiDaiDien.caNhan.DSGiayToTuyThan.Add(tempGiayTo.giayTo);
                    }
                    objToChuc.NguoiDaiDien = retToChuc.nguoiDaiDien.caNhan;
                    objToChuc.NguoiDaiDien.TRANGTHAI = 2;
                    objToChuc.NguoiDaiDien.setHoTen();
                    objToChuc.NguoiDaiDien.HOTEN = objToChuc.NguoiDaiDien.HOTEN;
                    objToChuc.CMTNGUOIDAIDIEN = objToChuc.NguoiDaiDien.SOGIAYTO;
                    objToChuc.HoTenNguoiDaiDien = objToChuc.NguoiDaiDien.HOTEN;
                }
            }
            return objToChuc;
        }
        public static List<DC_TOCHUC> TimKiemToChucByCMTNguoiDaiDien(string cMTNguoiDaiDien)
        {
            List<DC_TOCHUC> dSToChuc = new List<DC_TOCHUC>();
            using (MplisEntities db = new MplisEntities())
            {
                var retToChuc = db.DC_TOCHUC.Where(it => it.CMTNGUOIDAIDIEN == cMTNguoiDaiDien).ToList();
                if (retToChuc != null)
                {
                    dSToChuc = retToChuc;
                }
            }
            return dSToChuc;
        }
        public static List<DC_TOCHUC> TimKiemToChucTheoMaDN(string maSoThue, string maDoanhNghiep)
        {
            List<DC_TOCHUC> dSToChuc = new List<DC_TOCHUC>();
            using (MplisEntities db = new MplisEntities())
            {
                if (maDoanhNghiep != "")
                {
                    if (maSoThue != "")
                    {
                        dSToChuc = db.DC_TOCHUC.Where(it => it.MASOTHUE == maSoThue && it.MADOANHNGHIEP == maDoanhNghiep).ToList();
                    }
                    else
                    {
                        dSToChuc = db.DC_TOCHUC.Where(it => it.MADOANHNGHIEP == maDoanhNghiep).ToList();
                    }
                }
                else
                {
                    if (maSoThue != "")
                    {
                        dSToChuc = db.DC_TOCHUC.Where(it => it.MASOTHUE == maSoThue).ToList();
                    }
                }
            }
            return dSToChuc;
        }
        public static bool CheckToChucTheoMaDN(string maDoanhNghiep)
        {
            using (MplisEntities db = new MplisEntities())
            {
                var retToChuc = db.DC_TOCHUC.Where(it => it.MADOANHNGHIEP == maDoanhNghiep).FirstOrDefault();
                if (retToChuc != null)
                    return false;
            }
            return true;
        }
        public static void SaveToChuc(DC_TOCHUC toChuc, MplisEntities db)
        {
            if (toChuc.TRANGTHAI == 1)
            {
                db.Entry(toChuc).State = EntityState.Added;
                toChuc.TRANGTHAI = 2;
            }
            else if (toChuc.TRANGTHAI == 2)
            {
                db.Entry(toChuc).State = EntityState.Modified;
            }
            if (toChuc.NguoiDaiDien != null)
            {
                DCCANHANServices.SaveCaNhan(toChuc.NguoiDaiDien, db);
            }
        }
    }
}