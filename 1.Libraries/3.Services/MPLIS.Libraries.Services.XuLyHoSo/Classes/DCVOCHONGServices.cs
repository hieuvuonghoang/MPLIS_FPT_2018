using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AppCore.Models;
using AutoMapper;
using MPLIS.Libraries.Data.XuLyHoSo.Models;
using System.Data.Entity;

namespace MPLIS.Libraries.Services.XuLyHoSo.Classes
{
    public static class DCVOCHONGServices
    {
        public static DC_VOCHONG GetVoChong(string voChongID, MplisEntities db)
        {
            DC_VOCHONG objVoChong = null;
            var retVoChong = db.DC_VOCHONG.Where(it => it.VOCHONGID == voChongID)
                .Select(voChong => new
                {
                    voChong,
                    chongCN = db.DC_CANHAN.Where(it => it.CANHANID.Equals(voChong.CHONG))
                    .Select(chong => new
                    {
                        chong,
                        giayTos = db.DC_GIAYTOTUYTHAN.Where(it => it.CANHANID.Equals(chong.CANHANID))
                        .Select(giayTo => new
                        {
                            giayTo,
                            tenGiayTo = db.DM_LOAIGIAYTOTUYTHAN.Where(it => it.LOAIGIAYTOTUYTHANID.Equals(giayTo.LOAIGIAYTOTUYTHANID))
                            .Select(it => it.TENLOAIGIAYTOTUYTHAN)
                            .FirstOrDefault()
                        }).ToList()
                    }).FirstOrDefault(),
                    voCN = db.DC_CANHAN.Where(it => it.CANHANID.Equals(voChong.VO))
                    .Select(vo => new
                    {
                        vo,
                        giayTos = db.DC_GIAYTOTUYTHAN.Where(it => it.CANHANID.Equals(vo.CANHANID))
                        .Select(giayTo => new
                        {
                            giayTo,
                            tenGiayTo = db.DM_LOAIGIAYTOTUYTHAN.Where(it => it.LOAIGIAYTOTUYTHANID.Equals(giayTo.LOAIGIAYTOTUYTHANID))
                            .Select(it => it.TENLOAIGIAYTOTUYTHAN)
                            .FirstOrDefault()
                        }).ToList()
                    }).FirstOrDefault()
                }).FirstOrDefault();
            if (retVoChong != null)
            {
                objVoChong = retVoChong.voChong;
                objVoChong.TRANGTHAI = 2;
                objVoChong.ChongCN = retVoChong.chongCN.chong;
                objVoChong.ChongCN.TRANGTHAI = 2;
                objVoChong.ChongCN.HOTEN = objVoChong.ChongCN.HODEM + " " + objVoChong.ChongCN.TEN;
                objVoChong.ChongCN.DSGiayToTuyThan = new List<DC_GIAYTOTUYTHAN>();
                foreach (var tempGiayTo in retVoChong.chongCN.giayTos)
                {
                    tempGiayTo.giayTo.TenGiayToTuyThan = tempGiayTo.tenGiayTo;
                    objVoChong.ChongCN.DSGiayToTuyThan.Add(tempGiayTo.giayTo);
                }
                objVoChong.VoCN = retVoChong.voCN.vo;
                objVoChong.VoCN.TRANGTHAI = 2;
                objVoChong.VoCN.HOTEN = objVoChong.VoCN.HODEM + " " + objVoChong.VoCN.TEN;
                objVoChong.VoCN.DSGiayToTuyThan = new List<DC_GIAYTOTUYTHAN>();
                foreach (var tempGiayTo in retVoChong.voCN.giayTos)
                {
                    tempGiayTo.giayTo.TenGiayToTuyThan = tempGiayTo.tenGiayTo;
                    objVoChong.VoCN.DSGiayToTuyThan.Add(tempGiayTo.giayTo);
                }
                objVoChong.CMTCHONG = objVoChong.ChongCN.SOGIAYTO;
                objVoChong.CMTVO = objVoChong.VoCN.SOGIAYTO;
            }
            return objVoChong;
        }
        public static List<DC_VOCHONG> TimKiemVoChongByCMTChong(string cMTChong)
        {
            List<DC_VOCHONG> dSVoChong = new List<DC_VOCHONG>();
            using(MplisEntities db = new MplisEntities())
            {
                var retVoChong = db.DC_VOCHONG.Where(it => it.CMTCHONG == cMTChong)
                    .Select(voChong => new
                    {
                        voChong,
                        chongCN = db.DC_CANHAN.Where(it => it.CANHANID == voChong.CHONG).FirstOrDefault(),
                        voCN = db.DC_CANHAN.Where(it => it.CANHANID == voChong.VO).FirstOrDefault()
                    }).ToList();
                if(retVoChong != null)
                {
                    foreach(var tempVoChong in retVoChong)
                    {
                        if(tempVoChong.chongCN != null)
                        {
                            tempVoChong.chongCN.setHoTen();
                            tempVoChong.voChong.ChongCN = tempVoChong.chongCN;
                        }
                        if(tempVoChong.voCN != null)
                        {
                            tempVoChong.voCN.setHoTen();
                            tempVoChong.voChong.VoCN = tempVoChong.voCN;
                        }
                        dSVoChong.Add(tempVoChong.voChong);
                    }
                }
            }
            return dSVoChong;
        }
        public static void SaveVoChong(DC_VOCHONG voChong, MplisEntities db)
        {
            if(voChong.TRANGTHAI == 1)
            {
                db.Entry(voChong).State = EntityState.Added;
                voChong.TRANGTHAI = 2;
            } else if(voChong.TRANGTHAI == 2)
            {
                db.Entry(voChong).State = EntityState.Modified;
            }
            if(voChong.ChongCN != null)
            {
                DCCANHANServices.SaveCaNhan(voChong.ChongCN, db);
            }
            if(voChong.VoCN != null)
            {
                DCCANHANServices.SaveCaNhan(voChong.VoCN, db);
            }
        }
    }
}