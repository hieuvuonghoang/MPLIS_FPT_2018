using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPLIS.Libraries.Data.XuLyHoSo.Models
{
    public class NhomNguoiThanhVienLS
    {
        public CaNhanLS ThanhVienCaNhan { get; set; }
        public HoGiaDinhLS ThanhVienHoGiaDinh { get; set; }
        public VoChongLS ThanhVienVoChong { get; set; }
        public ToChucLS ThanhVienToChuc { get; set; }
        public CongDongLS ThanhVienCongDong { get; set; }
        public decimal TLSH { get; set; }
        public int TRANGTHAI { get; set; }
        public string TenVaiTro { get; set; }
        public int ISNGUOIDAIDIEN { get; set; }
        public string SOGIAYTO { get; set; }
        public string HOTEN { get; set; }
        public string TENLOAICHU { get; set; }
        public string NHOMNGUOIID { get; set; }
        public string LOAIDOITUONG { get; set; }
        public string uId { get; set; }
        public Nullable<System.DateTime> THOIDIEMKHOITAO { get; set; }
        public Nullable<System.DateTime> THOIDIEMCAPNHAT { get; set; }
        public string NGUOICAPNHATID { get; set; }
        public string NHOMNGUOITHANHVIENID { get; set; }
        public string THANHPHANID { get; set; }
    }
}
