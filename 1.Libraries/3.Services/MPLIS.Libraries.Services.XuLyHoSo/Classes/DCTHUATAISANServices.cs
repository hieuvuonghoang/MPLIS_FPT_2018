using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AppCore.Models;

namespace MPLIS.Libraries.Services.XuLyHoSo.Classes
{
    public static class DCTHUATAISANServices
    {
        public static List<DC_THUATAISAN> GetDSThuaTaiSan(string taiSanGanLienVoiDatID, MplisEntities db)
        {
            var ret = db.DC_THUATAISAN.Where(it => it.TAISANGANLIENVOIDATID == taiSanGanLienVoiDatID).ToList();
            return ret;
        }
    }
}