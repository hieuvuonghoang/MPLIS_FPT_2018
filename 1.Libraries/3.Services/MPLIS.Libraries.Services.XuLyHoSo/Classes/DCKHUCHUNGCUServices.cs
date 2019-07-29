using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AppCore.Models;

namespace MPLIS.Libraries.Services.XuLyHoSo.Classes
{
    public static class DCKHUCHUNGCUServices
    {
        public static DC_KHUCHUNGCU GetKhuChungCu(string khuChungCuID, MplisEntities db)
        {
            DC_KHUCHUNGCU khuChungCu = null;
            var ret = db.DC_KHUCHUNGCU.Where(it => it.KHUCHUNGCUID == khuChungCuID)
                .Select(kCC => new
                {
                    kCC,
                    nhaChungCus = db.DC_NHACHUNGCU.Where(it => it.KHUCHUNGCUID == kCC.KHUCHUNGCUID)
                    .Select(nCC => new
                    {
                        nCC,
                        cHs = db.DC_CANHO.Where(it => it.NHACHUNGCUID == nCC.NHACHUNGCUID)
                        .Select(cH => new
                        {
                            cH,
                            cH_HMNCHs = db.DC_CANHO_HANGMUCNCH.Where(it => it.CANHOID == cH.CANHOID)
                            .Select(cH_HMNCH => new
                            {
                                cH_HMNCH,
                                hMNCH = db.DC_HANGMUCNGOAICANHO.Where(it => it.HANGMUCSOHUUCHUNGID == cH_HMNCH.HANGMUCSOHUUCHUNGID).FirstOrDefault()
                            }).ToList()
                        }).ToList(),
                        hMNCHs = db.DC_HANGMUCNGOAICANHO.Where(it => it.NHACHUNGCUID == nCC.NHACHUNGCUID).ToList()
                    }).ToList()
                }).FirstOrDefault();
            if (ret != null)
            {
                khuChungCu = ret.kCC;
                if (ret.nhaChungCus.Count() > 0)
                {
                    ret.kCC.DSNhaChungCu = new List<DC_NHACHUNGCU>();
                    foreach (var it in ret.nhaChungCus)
                    {
                        if (it.cHs.Count() > 0)
                        {
                            it.nCC.DSCanHo = new List<DC_CANHO>();
                            foreach (var tempCH in it.cHs)
                            {
                                if (tempCH.cH_HMNCHs.Count() > 0)
                                {
                                    tempCH.cH.DSCanHoHangMucNCH = new List<DC_CANHO_HANGMUCNCH>();
                                    foreach (var tempCHHMNCH in tempCH.cH_HMNCHs)
                                    {
                                        if (tempCHHMNCH.hMNCH != null)
                                            tempCHHMNCH.cH_HMNCH.HangMucNgoaiCanHo = tempCHHMNCH.hMNCH;
                                        tempCH.cH.DSCanHoHangMucNCH.Add(tempCHHMNCH.cH_HMNCH);
                                    }
                                }
                                it.nCC.DSCanHo.Add(tempCH.cH);
                            }
                        }
                        if (it.hMNCHs.Count() > 0)
                        {
                            it.nCC.DSHangMucNgoaiCanHo = new List<DC_HANGMUCNGOAICANHO>();
                            foreach (var tempHMNCH in it.hMNCHs)
                                it.nCC.DSHangMucNgoaiCanHo.Add(tempHMNCH);
                        }
                        ret.kCC.DSNhaChungCu.Add(it.nCC);
                    }
                }
            }
            return khuChungCu;
        }
    }
}