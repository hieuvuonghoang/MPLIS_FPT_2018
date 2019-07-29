using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AppCore.Models;

namespace MPLIS.Libraries.Services.XuLyHoSo.Classes
{
    public static class DCHANGMUCNGOAICANHOServices
    {
        public static DC_HANGMUCNGOAICANHO GetHangMucNgoaiCanHo(string hangMucSoHuuChungID, MplisEntities db)
        {
            DC_HANGMUCNGOAICANHO hangMucNgoaiCanHo = null;
            var ret = db.DC_HANGMUCNGOAICANHO.Where(it => it.HANGMUCSOHUUCHUNGID == hangMucSoHuuChungID).FirstOrDefault();
            if (ret != null)
                hangMucNgoaiCanHo = ret;
            return hangMucNgoaiCanHo;
        }
        public static List<DC_HANGMUCNGOAICANHO> GetDSHangMucNgoaiCanHo(string nhaChungCuID, MplisEntities db)
        {
            var ret = db.DC_HANGMUCNGOAICANHO.Where(it => it.NHACHUNGCUID == nhaChungCuID).ToList();
            return ret;
        }
    }
}