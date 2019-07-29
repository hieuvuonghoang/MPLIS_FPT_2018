using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPLIS.Libraries.Data.SSO.Models
{
    public class SSOHtNguoiDung
    {
        public string NGUOIDUNGID { get; set; }
        public string TENDANGNHAP { get; set; }
        public string MATKHAU { get; set; }
        public string HOTENNGUOIDUNG { get; set; }
        public string GIOITINH { get; set; }
        public string SODIENTHOAI { get; set; }
        public string SODIENTHOAI2 { get; set; }
        public string EMAIL { get; set; }
        public string DIACHI { get; set; }
        public Nullable<bool> READONLY { get; set; }
        public byte[] ANHBIEUTUONG { get; set; }
        public string PHAITHAYDOIMATKHAU { get; set; }
        public Nullable<System.DateTime> THOIDIEMMATKHAUCOHIEULUC { get; set; }
        public Nullable<System.DateTime> THOIDIEMMATKHAUHETHIEULUC { get; set; }
        public string CHOPHEPSUDUNG { get; set; }
        public string MOTA { get; set; }
        public string uId { get; set; }
        public Nullable<System.DateTime> THOIDIEMKHOITAO { get; set; }
        public string NGUOICAPNHATID { get; set; }
        public Nullable<System.DateTime> THOIDIEMCAPNHAT { get; set; }
        public string CAPNGUOIDUNG { get; set; }
        public string DONVIHANHCHINHID { get; set; }
        public Nullable<decimal> LOAINGUOIDUNG { get; set; }
    }
}
