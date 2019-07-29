using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AppCore.Models;

namespace MPLIS.Libraries.Services.XuLyHoSo.Classes
{
    public static class DCCONGTRINHXAYDUNGServices
    {
        public static DC_CONGTRINHXAYDUNG GetCongTringXayDung(string congTrinhXayDungID, MplisEntities db)
        {
            DC_CONGTRINHXAYDUNG congTrinhXayDung = null;
            var ret = db.DC_CONGTRINHXAYDUNG.Where(it => it.CONGTRINHXAYDUNGID == congTrinhXayDungID)
                .Select(cTXD => new
                {
                    cTXD,
                    hMCTs = db.DC_HANGMUCCONGTRINH.Where(it => it.CONGTRINHXAYDUNGID == cTXD.CONGTRINHXAYDUNGID).ToList()
                }).FirstOrDefault();
            if (ret != null)
            {
                congTrinhXayDung = ret.cTXD;
                if (ret.hMCTs.Count() > 0)
                {
                    ret.cTXD.DSHangMucCongTrinh = new List<DC_HANGMUCCONGTRINH>();
                    foreach (var it in ret.hMCTs)
                        ret.cTXD.DSHangMucCongTrinh.Add(it);
                }
            }
            return congTrinhXayDung;
        }
    }
}