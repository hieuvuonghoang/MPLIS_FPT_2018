using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppCore.Models;

namespace MPLIS.Libraries.Services.QuanTriQuyTrinh
{
    public static class QTNHOMQUYTRINHServices
    {
        public static List<QT_NHOMQUYTRINH> GetDSNhomQuyTrinh()
        {
            List<QT_NHOMQUYTRINH> dSNhomQuyTrinh = new List<QT_NHOMQUYTRINH>();
            using(MplisEntities db = new MplisEntities())
            {
                var ret = db.QT_NHOMQUYTRINH.OrderBy(it => it.THUTUSAPXEP).ToList();
                if(ret != null)
                {
                    dSNhomQuyTrinh = ret;
                }
            }
            return dSNhomQuyTrinh;
        }
    }
}
