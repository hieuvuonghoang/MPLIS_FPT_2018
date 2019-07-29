using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPLIS.Libraries.Data.XuLyHoSo.Models
{
    public class NhaRiengLeLS
    {
        #region "Properties"
        public string NHARIENGLEID { get; set; }
        public string XAID { get; set; }
        public Nullable<decimal> DIENTICHXAYDUNG { get; set; }
        public Nullable<decimal> DIENTICHSAN { get; set; }
        public string SOTANG { get; set; }
        public Nullable<decimal> SOTANGHAM { get; set; }
        public string KETCAU { get; set; }
        public string CAPHANG { get; set; }
        public string DIACHI { get; set; }
        public string uId { get; set; }
        public Nullable<System.DateTime> THOIDIEMKHOITAO { get; set; }
        public string NGUOICAPNHATID { get; set; }
        public Nullable<System.DateTime> THOIDIEMCAPNHAT { get; set; }
        #endregion
    }
}
