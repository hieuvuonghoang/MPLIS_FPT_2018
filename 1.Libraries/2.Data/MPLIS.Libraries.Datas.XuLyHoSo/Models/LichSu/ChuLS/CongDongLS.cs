using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPLIS.Libraries.Data.XuLyHoSo.Models
{
    public class CongDongLS
    {
        public CaNhanLS NguoiDaiDien { get; set; }
        public CaNhanLS CurCaNhan { get; set; }
        public int TRANGTHAI { get; set; }
        public string DONDANGKYID { get; set; }
        public string HoTenNguoiDaiDien { get; set; }
        public string DOITUONGSUDUNGID { get; set; }

        #region "Properties"
        public string CONGDONGID { get; set; }
        public string TENCONGDONG { get; set; }
        public string NGUOIDAIDIENID { get; set; }
        public string DIACHI { get; set; }
        public string uId { get; set; }
        public Nullable<System.DateTime> THOIDIEMKHOITAO { get; set; }
        public Nullable<System.DateTime> THOIDIEMCAPNHAT { get; set; }
        public string NGUOICAPNHATID { get; set; }
        public string CMTNGUOIDAIDIEN { get; set; }
        #endregion
    }
}
