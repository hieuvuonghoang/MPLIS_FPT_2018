using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppCore.Models;

namespace MPLIS.Libraries.Services.QuanTriQuyTrinh
{
    public static class HCDMKVHCServices
    {
        public static List<HC_DMKVHC> GetKVHC(byte capToChuc, string kVHCID)
        {
            List<HC_DMKVHC> dSKVHC = new List<HC_DMKVHC>();
            using (MplisEntities db = new MplisEntities())
            {
                if (capToChuc == 2)
                {
                    //Người dùng thuộc Huyện, lấy tất cả các Xã thuộc Huyện
                    var ret = db.HC_DMKVHC.Where(it => it.KVHCID == kVHCID)
                        .Select(huyen => new
                        {
                            huyen,
                            //StartsWith: LIKE "abc%"
                            dSXaPhuong = db.HC_DMKVHC.Where(it => it.MAKVHC.Length == 10 && it.MAKVHC.StartsWith(huyen.MAKVHC)).ToList()
                        }).FirstOrDefault();
                    if(ret != null && ret.dSXaPhuong != null)
                    {
                        dSKVHC = ret.dSXaPhuong;
                    }
                }
                else if (capToChuc == 1)
                {
                    //Người dùng thuộc Tỉnh, lấy tất cả các Huyện thuộc Tỉnh
                    var ret = db.HC_DMKVHC.Where(it => it.KVHCID == kVHCID)
                        .Select(tinh => new
                        {
                            tinh,
                            dSQuanHuyen = db.HC_DMKVHC.Where(it => it.MAKVHC.Length == 5 && it.MAKVHC.StartsWith(tinh.MAKVHC)).ToList()
                        }).FirstOrDefault();
                    if (ret != null && ret.dSQuanHuyen != null)
                    {
                        dSKVHC = ret.dSQuanHuyen;
                    }
                }
            }
            return dSKVHC;
        }
    }
}
