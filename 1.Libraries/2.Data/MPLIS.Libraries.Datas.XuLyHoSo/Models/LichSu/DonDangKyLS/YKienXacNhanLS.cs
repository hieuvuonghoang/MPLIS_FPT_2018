using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPLIS.Libraries.Data.XuLyHoSo.Models
{
    public class YKienXacNhanLS
    {
        #region "Properties"
        public string YKIENXACNHANID { get; set; }
        public string XACNHANDONDANGKYID { get; set; }
        public string LOAIYKIEN { get; set; }
        public string NOIDUNGYKIEN { get; set; }
        public string uId { get; set; }
        public Nullable<System.DateTime> THOIDIEMKHOITAO { get; set; }
        public Nullable<System.DateTime> THOIDIEMCAPNHAT { get; set; }
        public string NGUOICAPNHATID { get; set; }
        #endregion
    }
}
