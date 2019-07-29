using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppCore.Models;

namespace MPLIS.Libraries.Services.QuanTriQuyTrinh
{
    public static class HTNGUOIDUNGServices
    {
        public static List<HT_NGUOIDUNG> GetNguoiDungByDVHCID(string donViHanhChinhID)
        {
            List<HT_NGUOIDUNG> dSNguoiDung = new List<HT_NGUOIDUNG>();
            using(MplisEntities db = new MplisEntities())
            {
                var retNguoiDung = db.HT_NGUOIDUNG.Where(it => it.DONVIHANHCHINHID == donViHanhChinhID).ToList();
                if(retNguoiDung != null)
                {
                    dSNguoiDung = retNguoiDung;
                }
            }
            return dSNguoiDung;
        }
    }
}
