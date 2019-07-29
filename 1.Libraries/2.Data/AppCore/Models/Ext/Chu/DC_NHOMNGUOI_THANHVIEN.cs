using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppCore.Models
{
    public partial class DC_NHOMNGUOI_THANHVIEN
    {
        public DC_NHOMNGUOI_THANHVIEN()
        {

        }
        public DC_CANHAN ThanhVien { get; set; }
        public DC_CANHAN ThanhVienCaNhan { get; set; }
        public DC_VOCHONG ThanhVienVoChong { get; set; }
        public DC_HOGIADINH ThanhVienHoGiaDinh { get; set; }
        public DC_CONGDONG ThanhVienCongDong { get; set; }
        public DC_TOCHUC ThanhVienToChuc { get; set; }
        public DC_NHOMNGUOI_THANHVIEN(string loaiChuID)
        {
            LOAIDOITUONG = loaiChuID;
            TRANGTHAI = 1;
            NHOMNGUOITHANHVIENID = Guid.NewGuid().ToString();
            switch (loaiChuID)
            {
                case "1":
                    ThanhVienCaNhan = new DC_CANHAN();
                    ThanhVienCaNhan.CANHANID = Guid.NewGuid().ToString();
                    ThanhVienCaNhan.TRANGTHAI = 1;
                    THANHPHANID = ThanhVienCaNhan.CANHANID;
                    break;
                case "2":
                    ThanhVienHoGiaDinh = new DC_HOGIADINH();
                    ThanhVienHoGiaDinh.HOGIADINHID = Guid.NewGuid().ToString();
                    ThanhVienHoGiaDinh.TRANGTHAI = 1;
                    THANHPHANID = ThanhVienHoGiaDinh.HOGIADINHID;
                    break;
                case "3":
                    ThanhVienVoChong = new DC_VOCHONG();
                    ThanhVienVoChong.VOCHONGID = Guid.NewGuid().ToString();
                    ThanhVienVoChong.TRANGTHAI = 1;
                    THANHPHANID = ThanhVienVoChong.VOCHONGID;
                    break;
                case "4":
                    ThanhVienToChuc = new DC_TOCHUC();
                    ThanhVienToChuc.TOCHUCID = Guid.NewGuid().ToString();
                    ThanhVienToChuc.TRANGTHAI = 1;
                    THANHPHANID = ThanhVienToChuc.TOCHUCID;
                    break;
                case "5":
                    ThanhVienCongDong = new DC_CONGDONG();
                    ThanhVienCongDong.CONGDONGID = Guid.NewGuid().ToString();
                    ThanhVienCongDong.TRANGTHAI = 1;
                    THANHPHANID = ThanhVienCongDong.CONGDONGID;
                    break;
                default:
                    break;
            }
        }
        public void InitData()
        {
            if (ISNGUOIDAIDIEN == 1)
            {
                TenVaiTro = "Đại Diện";
            }
            else
            {
                TenVaiTro = "Thành Viên";
            }
            switch (LOAIDOITUONG)
            {
                case "1":
                    ThanhVienCaNhan.setHoTen();
                    HOTEN = ThanhVienCaNhan.HOTEN;
                    SOGIAYTO = ThanhVienCaNhan.SOGIAYTO;
                    TENLOAICHU = "Cá Nhân";
                    break;
                case "2":
                    ThanhVienHoGiaDinh.ChuHoCN.setHoTen();
                    HOTEN = ThanhVienHoGiaDinh.ChuHoCN.HOTEN;
                    SOGIAYTO = ThanhVienHoGiaDinh.ChuHoCN.SOGIAYTO;
                    TENLOAICHU = "Hộ Gia Đình";
                    break;
                case "3":
                    ThanhVienVoChong.ChongCN.setHoTen();
                    ThanhVienVoChong.VoCN.setHoTen();
                    HOTEN = ThanhVienVoChong.ChongCN.HOTEN + ", " + ThanhVienVoChong.VoCN.HOTEN;
                    SOGIAYTO = ThanhVienVoChong.ChongCN.SOGIAYTO + ", " + ThanhVienVoChong.VoCN.SOGIAYTO;
                    TENLOAICHU = "Vợ Chồng";
                    break;
                case "4":
                    HOTEN = ThanhVienToChuc.TENTOCHUC;
                    SOGIAYTO = ThanhVienToChuc.NguoiDaiDien.SOGIAYTO;
                    TENLOAICHU = "Tổ Chức";
                    break;
                case "5":
                    HOTEN = ThanhVienCongDong.TENCONGDONG;
                    SOGIAYTO = ThanhVienCongDong.NguoiDaiDien.SOGIAYTO;
                    TENLOAICHU = "Cộng Động";
                    break;
            }
        }
        public int TRANGTHAI { get; set; }
        public string TenVaiTro { get; set; }
        public string NHOMNGUOIVAITROID { get; set; }
        public string TENLOAICHU { get; set; }
        public int ISNGUOIDAIDIEN { get; set; }
        public string HOTEN { get; set; }
        public string SOGIAYTO { get; set; }
        public decimal TLSH { get; set; }
    }
}
