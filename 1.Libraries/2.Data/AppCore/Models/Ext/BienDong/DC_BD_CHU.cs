using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppCore.Models
{
    public partial class DC_BD_CHU
    {
        public DC_NGUOI Chu { get; set; }
        public string VaiTro { get; set; }
        public string Chu_TenLoaiChu { get; set; }
        public string Chu_HoTen { get; set; }
        public string Chu_CMT { get; set; }
        public string Chu_DiaChi { get; set; }
    }
}
