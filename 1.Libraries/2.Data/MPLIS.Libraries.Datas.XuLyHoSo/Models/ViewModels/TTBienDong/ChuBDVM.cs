using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPLIS.Libraries.Data.XuLyHoSo.Models
{
    public class ChuBDVM
    {
        //private properties
        public string BDCHUID { get; set; }
        public string NGUOIID { get; set; }
        public string BIENDONGID { get; set; }
        public string VAITROCHU { get; set; }

        //properties get from other object
        public string VaiTro { get; set; }
        public string Chu_TenLoaiChu { get; set; }
        public string Chu_HoTen { get; set; }
        public string Chu_CMT { get; set; }
        public string Chu_DiaChi { get; set; }
    }
}
