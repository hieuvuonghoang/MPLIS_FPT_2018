using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AppCore.Models;
using System.Data.Entity;

namespace MPLIS.Libraries.Services.XuLyHoSo.Classes
{
    public class DMLOAITAISANGANLIENVOIDATServices
    {
        public static DM_LOAITAISANGANLIENVOIDAT getLoaiTaiSanGanLienVoiDat(string maLoaiTaiSan)
        {
            DM_LOAITAISANGANLIENVOIDAT ret = null;
            using(MplisEntities db = new MplisEntities())
            {
                var result = db.DM_LOAITAISANGANLIENVOIDAT.Where(it => it.MALOAITAISANGANLIENVOIDAT.Equals(maLoaiTaiSan)).FirstOrDefault();
                if (result != null)
                    ret = result;
            }
            return ret;
        }
    }
}