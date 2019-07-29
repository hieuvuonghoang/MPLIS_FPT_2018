using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppCore.Models;

namespace MPLIS.Libraries.Data.XuLyHoSo.Models
{
    public class NhomNguoiLS
    {
        public NhomNguoiLS()
        {
            DSThanhVien = new List<NhomNguoiThanhVienLS>();
        }
        public List<NhomNguoiThanhVienLS> DSThanhVien { get; set; }
        public NhomNguoiThanhVienLS CurNhomNguoiThanhVien { get; set; }
        public int TRANGTHAI { get; set; }
        public string HoTenNguoiDaiDien { get; set; }
        #region "Properties"
        public string NHOMNGUOIID { get; set; }
        public string NGUOIDAIDIEN { get; set; }
        public string uId { get; set; }
        public Nullable<System.DateTime> THOIDIEMKHOITAO { get; set; }
        public Nullable<System.DateTime> THOIDIEMCAPNHAT { get; set; }
        public string NGUOICAPNHATID { get; set; }
        public string CMTNGUOIDAIDIEN { get; set; }
        #endregion
    }
}
