using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPLIS.Libraries.Data.XuLyHoSo.Models
{
    public class XacNhanDonDangKyLS
    {
        public List<YKienXacNhanLS> DSYKienXacNhan { get; set; }

        public XacNhanDonDangKyLS()
        {
            DSYKienXacNhan = new List<Models.YKienXacNhanLS>();
        }

        #region "Properties"
        public string XACNHANDONDANGKYID { get; set; }
        public string DONDANGKYID { get; set; }
        public Nullable<decimal> CAPXACNHAN { get; set; }
        public string DONVIHANHCHINHID { get; set; }
        public string TENCOQUANXACNHAN { get; set; }
        public string CANBOYKIENID { get; set; }
        public string CANBOKIEMTRAID { get; set; }
        public string CANBOPHEDUYETID { get; set; }
        public string uId { get; set; }
        public Nullable<System.DateTime> THOIDIEMKHOITAO { get; set; }
        public Nullable<System.DateTime> THOIDIEMCAPNHAT { get; set; }
        public string NGUOICAPNHATID { get; set; }
        #endregion
    }
}
