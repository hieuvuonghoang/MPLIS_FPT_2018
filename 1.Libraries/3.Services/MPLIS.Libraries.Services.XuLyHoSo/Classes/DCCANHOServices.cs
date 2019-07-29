using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AppCore.Models;

namespace MPLIS.Libraries.Services.XuLyHoSo.Classes
{
    public static class DCCANHOServices
    {
        public static DC_CANHO GetCanHo(string canHoID, MplisEntities db)
        {
            DC_CANHO canHo = null;
            var ret = db.DC_CANHO.Where(it => it.CANHOID == canHoID)
                .Select(cH => new
                {
                    cH,
                    cH_HMNCHs = db.DC_CANHO_HANGMUCNCH.Where(it => it.CANHOID == cH.CANHOID)
                    .Select(cH_HMNCH => new
                    {
                        cH_HMNCH,
                        hMNCH = db.DC_HANGMUCNGOAICANHO.Where(it => it.HANGMUCSOHUUCHUNGID == cH_HMNCH.HANGMUCSOHUUCHUNGID).FirstOrDefault()
                    }).ToList()
                }).FirstOrDefault();
            if (ret != null)
            {
                canHo = ret.cH;
                if (ret.cH_HMNCHs.Count() > 0)
                {
                    ret.cH.DSCanHoHangMucNCH = new List<DC_CANHO_HANGMUCNCH>();
                    foreach (var it in ret.cH_HMNCHs)
                    {
                        if (it.hMNCH != null)
                            it.cH_HMNCH.HangMucNgoaiCanHo = it.hMNCH;
                        ret.cH.DSCanHoHangMucNCH.Add(it.cH_HMNCH);
                    }
                }
            }
            return canHo;
        }
        public static List<DC_CANHO> GetDSCanHo(string nhaChungCuID, MplisEntities db)
        {
            List<DC_CANHO> DSCanHo = new List<DC_CANHO>();
            var ret = db.DC_CANHO.Where(it => it.NHACHUNGCUID == nhaChungCuID)
                .Select(cH => new
                {
                    cH,
                    cH_HMNCHs = db.DC_CANHO_HANGMUCNCH.Where(it => it.CANHOID == cH.CANHOID)
                    .Select(cH_HMNCH => new
                    {
                        cH_HMNCH,
                        hMNCH = DCHANGMUCNGOAICANHOServices.GetHangMucNgoaiCanHo(cH_HMNCH.HANGMUCSOHUUCHUNGID, db)
                    }).ToList()
                }).ToList();
            foreach (var tempCH in ret)
            {
                if (tempCH.cH_HMNCHs.Count() > 0)
                {
                    tempCH.cH.DSCanHoHangMucNCH = new List<DC_CANHO_HANGMUCNCH>();
                    foreach (var it in tempCH.cH_HMNCHs)
                    {
                        if (it.hMNCH != null)
                            it.cH_HMNCH.HangMucNgoaiCanHo = it.hMNCH;
                        tempCH.cH.DSCanHoHangMucNCH.Add(it.cH_HMNCH);
                    }
                }
            }
            return DSCanHo;
        }
    }
}