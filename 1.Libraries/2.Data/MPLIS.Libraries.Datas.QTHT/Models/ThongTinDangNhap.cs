using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppCore.Models;

namespace MPLIS.Libraries.Data.QTHT.Models
{
    public class ThongTinDangNhap
    {
        public Boolean kiemTraDangNhap { get; set; }
        public string khoaLienKet { get; set; }
        public string sessionNguoiDung { get; set; }
        public string nguoiDungId { get; set; }
        public string hoVaTenNguoiDung { get; set; }
        public string tenDangNhap { get; set; }
        public string loaiNguoiDung { get; set; }
        public string emaiNguoiDung { get; set; }
        public string capNguoiDung { get; set; }
        public string donViHanhChinhId { get; set; }
        public string diaChiNguoiDung { get; set; }
        public string moTaNguoiDung { get; set; }
        public List<DanhSachXaNguoiDung> xaNguoiDungs { get; set; }
        public string sessionTinhId { get; set; }
        public string sessionHuyenId { get; set; }
        public string sessionXaId { get; set; }
        public string sessionMaTinh { get; set; }
        public string sessionMaHuyen { get; set; }
        public string sessionMaXa { get; set; }

    }
    public class DanhSachXaNguoiDung
    {
        public string idXa { get; set; }
        public string maXa { get; set; }
        public string tenXa { get; set; }

    }
}
