using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AppCore.Models;

namespace MPLIS.Libraries.Services.XuLyHoSo.Classes
{
    public static class DCCAYLAUNAMServices
    {
        public static DC_CAYLAUNAM GetCayLauNam(string cayLauNamID, MplisEntities db)
        {
            DC_CAYLAUNAM cayLauNam = null;
            var ret = db.DC_CAYLAUNAM.Where(it => it.CAYLAUNAMID == cayLauNamID).FirstOrDefault();
            if (ret != null)
                cayLauNam = ret;
            return cayLauNam;
        }
    }
}