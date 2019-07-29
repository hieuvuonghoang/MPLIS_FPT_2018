using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPLIS.Libraries.Data.XuLyHoSo.Models
{
    public class HoGiaDinhThanhVienLS
    {
        public CaNhanLS ThanhVien { get; set; }
        public string TenQuanHe { get; set; }
        public int TRANGTHAI { get; set; }
        #region "Properties"
        public string HOGIADINHID { get; set; }
        public string CANHANID { get; set; }
        public string uId { get; set; }
        public Nullable<System.DateTime> THOIDIEMKHOITAO { get; set; }
        public Nullable<System.DateTime> THOIDIEMCAPNHAT { get; set; }
        public string NGUOICAPNHATID { get; set; }
        public string HOGIADINHTVID { get; set; }
        public string QHVOICHUHOID { get; set; }
        #endregion
    }
}
