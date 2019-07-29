using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPLIS.Libraries.Data.XuLyHoSo.Models
{
    public class NhaChungCuLS
    {
        #region "Properties"
        public string NHACHUNGCUID { get; set; }
        public string KHUCHUNGCUID { get; set; }
        public string TENCHUNGCU { get; set; }
        public Nullable<decimal> DIENTICHXAYDUNG { get; set; }
        public Nullable<decimal> DIENTICHSAN { get; set; }
        public Nullable<decimal> TONGSOCAN { get; set; }
        public Nullable<decimal> SOTANG { get; set; }
        public Nullable<decimal> SOTANGHAM { get; set; }
        public Nullable<decimal> NAMXAYDUNG { get; set; }
        public Nullable<decimal> NAMHOANTHANH { get; set; }
        public string THOIHANSOHUU { get; set; }
        public string CAPHANG { get; set; }
        public string uId { get; set; }
        public Nullable<System.DateTime> THOIDIEMKHOITAO { get; set; }
        public string NGUOICAPNHATID { get; set; }
        public Nullable<System.DateTime> THOIDIEMCAPNHAT { get; set; }
        public string MAXA { get; set; }
        #endregion
    }
}
