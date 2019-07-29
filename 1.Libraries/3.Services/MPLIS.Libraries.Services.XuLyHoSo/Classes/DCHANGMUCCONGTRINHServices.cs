using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AppCore.Models;

namespace MPLIS.Libraries.Services.XuLyHoSo.Classes
{
    public static class DCHANGMUCCONGTRINHServices
    {
        public static DC_HANGMUCCONGTRINH GetHangMucCongTrinh(string hangMucCongTrinhID, MplisEntities db)
        {
            DC_HANGMUCCONGTRINH hangMucCongTrinh = null;
            var ret = db.DC_HANGMUCCONGTRINH.Where(it => it.HANGMUCCONGTRINHID == hangMucCongTrinhID).FirstOrDefault();
            if (ret != null)
                hangMucCongTrinh = ret;
            return hangMucCongTrinh;
        }
    }
}