using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPLIS.Libraries.Data.XuLyHoSo.Models
{
    public class TyLeSoHuuTrenQuyenVM
    {
        public TyLeSoHuuTrenQuyenVM(string soPhatHanh, string maVach, string quyenID, decimal tiLeSoHuu)
        {
            SOPHATHANH = soPhatHanh;
            MAVACH = maVach;
            QUYENID = quyenID;
            TILESOHUU = tiLeSoHuu;
        }
        #region "Properties"
        public string SOPHATHANH { get; set; }
        public string MAVACH { get; set; }
        public string QUYENID { get; set; }
        public decimal TILESOHUU { get; set; }
        #endregion
    }
}
