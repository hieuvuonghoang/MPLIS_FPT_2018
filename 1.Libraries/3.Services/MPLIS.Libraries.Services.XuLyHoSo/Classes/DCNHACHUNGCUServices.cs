using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AppCore.Models;

namespace MPLIS.Libraries.Services.XuLyHoSo.Classes
{
    public static class DCNHACHUNGCUServices
    {
        public static DC_NHACHUNGCU GetNhaChungCu(string nhaChungCuID, MplisEntities db)
        {
            DC_NHACHUNGCU nhaChungCu = null;
            var ret = db.DC_NHACHUNGCU.Where(it => it.NHACHUNGCUID == nhaChungCuID)
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
                }).FirstOrDefault();
            if (ret != null)
            {
                nhaChungCu = ret.nCC;
                if (ret.cHs.Count() > 0)
                {
                    ret.nCC.DSCanHo = new List<DC_CANHO>();
                    foreach (var tempCH in ret.cHs)
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
                        ret.nCC.DSCanHo.Add(tempCH.cH);
                    }
                }
                if (ret.hMNCHs.Count() > 0)
                {
                    ret.nCC.DSHangMucNgoaiCanHo = new List<DC_HANGMUCNGOAICANHO>();
                    foreach (var tempHMNCH in ret.hMNCHs)
                        ret.nCC.DSHangMucNgoaiCanHo.Add(tempHMNCH);
                }
            }
            return nhaChungCu;
        }
    }
}