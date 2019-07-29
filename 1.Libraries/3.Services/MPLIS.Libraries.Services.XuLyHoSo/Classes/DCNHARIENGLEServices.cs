using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AppCore.Models;

namespace MPLIS.Libraries.Services.XuLyHoSo.Classes
{
    public static class DCNHARIENGLEServices
    {
        public static DC_NHARIENGLE GetNhaRiengLe(string nhaRiengLeID, MplisEntities db)
        {
            DC_NHARIENGLE nhaRiengLe = null;
            var ret = db.DC_NHARIENGLE.Where(it => it.NHARIENGLEID == nhaRiengLeID)
                .Select(nRL => new
                {
                    nRL,
                    loaiNhan = db.DM_LOAINHA.Where(it => it.LOAINHAID == nRL.LOAINHAID).FirstOrDefault(),
                    loaiCapHang = db.DM_LOAICAPHANG.Where(it => it.LOAICAPHANGID == nRL.LOAICAPHANGID).FirstOrDefault()
                }).FirstOrDefault();
            if (ret != null)
            {
                nhaRiengLe = ret.nRL;
                if (ret.loaiNhan != null)
                    ret.nRL.LoaiNha = ret.loaiNhan;
                if (ret.loaiCapHang != null)
                    ret.nRL.LoaiCapHang = ret.loaiCapHang;
            }
            return nhaRiengLe;
        }
    }
}