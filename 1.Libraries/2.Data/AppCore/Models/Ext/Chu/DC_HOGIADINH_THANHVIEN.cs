using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppCore.Models
{
    public partial class DC_HOGIADINH_THANHVIEN
    {
        public DC_CANHAN ThanhVien { get; set; }
        public void InitData(string tenQuanHe)
        {
            ThanhVien.setHoTen();
            HOTEN = ThanhVien.HOTEN;
            SOGIAYTO = ThanhVien.SOGIAYTO;
            TenQuanHe = tenQuanHe;
        }
        public string TenQuanHe { get; set; }
        public int TRANGTHAI { get; set; }
        public string HOTEN { get; set; }
        public string SOGIAYTO { get; set; }
    }
}
