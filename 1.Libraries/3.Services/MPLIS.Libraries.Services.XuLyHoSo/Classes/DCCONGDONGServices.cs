using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using System.Data.Entity;
using MPLIS.Libraries.Data.XuLyHoSo.Models;
using AppCore.Models;

namespace MPLIS.Libraries.Services.XuLyHoSo.Classes
{
    public static class DCCONGDONGServices
    {
        public static DC_CONGDONG GetCongDong(string congDongID, MplisEntities db)
        {
            DC_CONGDONG objCongDong = null;
            var retCongDong = db.DC_CONGDONG.Where(it => it.CONGDONGID == congDongID)
                                .Select(congDong => new
                                {
                                    congDong,
                                    nguoiDaiDien = db.DC_CANHAN.Where(it => it.CANHANID.Equals(congDong.NGUOIDAIDIENID))
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
            if (retCongDong != null)
            {
                objCongDong = retCongDong.congDong;
                objCongDong.TRANGTHAI = 2;
                if (retCongDong.nguoiDaiDien != null)
                {
                    retCongDong.nguoiDaiDien.caNhan.DSGiayToTuyThan = new List<DC_GIAYTOTUYTHAN>();
                    foreach (var tempGiayTo in retCongDong.nguoiDaiDien.giayTos)
                    {
                        tempGiayTo.giayTo.TenGiayToTuyThan = tempGiayTo.tenGiayTo;
                        retCongDong.nguoiDaiDien.caNhan.DSGiayToTuyThan.Add(tempGiayTo.giayTo);
                    }
                    objCongDong.NguoiDaiDien = retCongDong.nguoiDaiDien.caNhan;
                    objCongDong.NguoiDaiDien.TRANGTHAI = 2;
                    objCongDong.NguoiDaiDien.setHoTen();
                    objCongDong.NguoiDaiDien.HOTEN = objCongDong.NguoiDaiDien.HOTEN;
                    objCongDong.CMTNGUOIDAIDIEN = objCongDong.NguoiDaiDien.SOGIAYTO;
                    objCongDong.HoTenNguoiDaiDien = objCongDong.NguoiDaiDien.HOTEN;
                }
            }
            return objCongDong;
        }
        public static void SaveCongDong(DC_CONGDONG congDong, MplisEntities db)
        {
            if (congDong.TRANGTHAI == 1)
            {
                db.Entry(congDong).State = EntityState.Added;
                congDong.TRANGTHAI = 2;
            }
            else if (congDong.TRANGTHAI == 2)
            {
                db.Entry(congDong).State = EntityState.Modified;
            }
            if (congDong.NguoiDaiDien != null)
            {
                DCCANHANServices.SaveCaNhan(congDong.NguoiDaiDien, db);
            }
        }
    }
}