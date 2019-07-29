using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppCore.Models
{
    public partial class DC_NHOMNGUOI
    {
        //public DC_NHOMNGUOI()
        //{
        //    DSThanhVien = new List<DC_NHOMNGUOI_THANHVIEN>();
        //}
        public List<DC_NHOMNGUOI_THANHVIEN> DSThanhVien { get; set; }
        public DC_NHOMNGUOI_THANHVIEN CurNhomNguoiThanhVien { get; set; }
        public int TRANGTHAI { get; set; }
        public string HoTenNguoiDaiDien { get; set; }
        public void NhomNguoiSetThongTin()
        {
            NGUOIDAIDIEN = null;
            CMTNGUOIDAIDIEN = null;
            HoTenNguoiDaiDien = null;
            foreach (var temp in DSThanhVien)
            {
                temp.InitData();
                if(temp.ISNGUOIDAIDIEN == 1)
                {
                    NGUOIDAIDIEN = temp.THANHPHANID;
                    CMTNGUOIDAIDIEN = temp.SOGIAYTO;
                    HoTenNguoiDaiDien = temp.HOTEN;
                }
            }
        }
    }
}
