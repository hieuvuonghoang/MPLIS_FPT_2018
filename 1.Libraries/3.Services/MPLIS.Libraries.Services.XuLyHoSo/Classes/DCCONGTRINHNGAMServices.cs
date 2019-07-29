using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AppCore.Models;

namespace MPLIS.Libraries.Services.XuLyHoSo.Classes
{
    public static class DCCONGTRINHNGAMServices
    {
        public static DC_CONGTRINHNGAM GetCongTrinhNgam(string congTrinhNgamID, MplisEntities db)
        {
            DC_CONGTRINHNGAM congTrinhNgam = null;
            var ret = db.DC_CONGTRINHNGAM.Where(it => it.CONGTRINHNGAMID == congTrinhNgamID).FirstOrDefault();
            if (ret != null)
                congTrinhNgam = ret;
            return congTrinhNgam;
        }
    }
}