using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AppCore.Models;

namespace MPLIS.Libraries.Services.XuLyHoSo.Classes
{
    public static class DMLOAIDTMIENGIAMServices
    {
        public static List<DM_LOAIDTMIENGIAM> GetDMLOAIDTMIENGIAM()
        {
            List<DM_LOAIDTMIENGIAM> dSLoaiDTMienGiam = null;
            using (MplisEntities db = new MplisEntities())
            {
                var ret = db.DM_LOAIDTMIENGIAM.OrderBy(it => it.LOAIDTMIENGIAMID).ToList();
                if (ret != null)
                    dSLoaiDTMienGiam = ret;
            }
            return dSLoaiDTMienGiam;
        }
    }
}