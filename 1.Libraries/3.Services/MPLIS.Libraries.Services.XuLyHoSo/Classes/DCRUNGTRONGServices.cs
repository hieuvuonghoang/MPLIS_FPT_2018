using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AppCore.Models;

namespace MPLIS.Libraries.Services.XuLyHoSo.Classes
{
    public static class DCRUNGTRONGServices
    {
        public static DC_RUNGTRONG GetRungTrong(string rungTrongID, MplisEntities db)
        {
            DC_RUNGTRONG rungTrong = null;
            var ret = db.DC_RUNGTRONG.Where(it => it.RUNGTRONGID == rungTrongID).FirstOrDefault();
            if (ret != null)
                rungTrong = ret;
            return rungTrong;
        }
    }
}