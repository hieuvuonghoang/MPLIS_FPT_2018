using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppCore.Models;

namespace MPLIS.Libraries.Data.XuLyHoSo.Models
{
    public class CaNhanLS
    {
        public List<GiayToTuyThanLS> DSGiayToTuyThan { get; set; }
        public CaNhanLS()
        {
            DSGiayToTuyThan = new List<GiayToTuyThanLS>();
        }
        public bool _CONSONG
        {
            get
            {
                return CONSONG ?? true;
            }
            set
            {
                CONSONG = value;
            }
        }
        public int TRANGTHAI { get; set; }
        public bool FLAGSEARCH { get; set; }
        #region "Properties"
        public string CANHANID { get; set; }
        public string HOTEN { get; set; }
        public string HODEM { get; set; }
        public string TEN { get; set; }
        public Nullable<System.DateTime> NGAYSINH { get; set; }
        public Nullable<decimal> NAMSINH { get; set; }
        public Nullable<decimal> GIOITINH { get; set; }
        public Nullable<bool> CONSONG { get; set; }
        public string SOGIAYTO { get; set; }
        public Nullable<System.DateTime> NGAYCAP { get; set; }
        public string NOICAP { get; set; }
        public string QUOCTICHID { get; set; }
        public string QUOCTICHKHACIDS { get; set; }
        public string DANTOCID { get; set; }
        public string DIACHI { get; set; }
        public string UID { get; set; }
        public Nullable<System.DateTime> THOIDIEMKHOITAO { get; set; }
        public Nullable<System.DateTime> THOIDIEMCAPNHAT { get; set; }
        public string NGUOICAPNHATID { get; set; }
        public string GIAYTOTUYTHANID { get; set; }
        public string SODIENTHOAI { get; set; }
        public string EMAIL { get; set; }
        public string MASOTHUE { get; set; }
        #endregion
    }
}
