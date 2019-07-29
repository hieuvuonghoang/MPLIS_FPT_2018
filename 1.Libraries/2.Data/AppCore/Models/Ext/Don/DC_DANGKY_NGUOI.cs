using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppCore.Models
{
    public partial class DC_DANGKY_NGUOI
    {
        public DC_NGUOI Chu { get; set; }
        public int TRANGTHAI { get; set; }
        public string Chu_TenLoaiChu { get; set; }
        public string Chu_HoTen { get; set; }
        public string Chu_CMT { get; set; }
        public string Chu_DiaChi { get; set; }
        public void InitData()
        {
            switch (Chu.LOAIDOITUONGID)
            {
                case "1":
                    Chu_TenLoaiChu = "Cá nhân";
                    Chu_HoTen = Chu.CaNhan.HODEM + " " + Chu.CaNhan.TEN;
                    Chu_CMT = Chu.CaNhan.SOGIAYTO;
                    break;
                case "2":
                    Chu_TenLoaiChu = "Hộ gia đình";
                    Chu_HoTen = "";
                    Chu_CMT = "";
                    foreach (var tempThanhVien in Chu.HoGiaDinh.DSThanhVien)
                    {
                        Chu_HoTen += tempThanhVien.ThanhVien.HODEM + " " + tempThanhVien.ThanhVien.TEN + ", ";
                        Chu_CMT += tempThanhVien.ThanhVien.SOGIAYTO + ", ";
                    }
                    if(Chu_HoTen != "")
                    {
                        Chu_HoTen = Chu_HoTen.Substring(0, Chu_HoTen.Length - 2);
                    }
                    if (Chu_CMT != "")
                    {
                        Chu_CMT = Chu_CMT.Substring(0, Chu_CMT.Length - 2);
                    }
                    break;
                case "3":
                    Chu_TenLoaiChu = "Vợ chồng";
                    Chu_HoTen = Chu.VoChong.ChongCN.HODEM + " " + Chu.VoChong.ChongCN.TEN + ", " + Chu.VoChong.VoCN.HODEM + " " + Chu.VoChong.VoCN.TEN;
                    Chu_CMT = Chu.VoChong.CMTCHONG + ", " + Chu.VoChong.CMTVO;
                    break;
                case "4":
                    Chu_TenLoaiChu = "Tổ chức";
                    Chu_HoTen = Chu.ToChuc.TENTOCHUC;
                    Chu_CMT = Chu.ToChuc.NguoiDaiDien.SOGIAYTO;
                    break;
                case "5":
                    Chu_TenLoaiChu = "Cộng đồng";
                    Chu_HoTen = Chu.CongDong.TENCONGDONG;
                    Chu_CMT = Chu.CongDong.NguoiDaiDien.SOGIAYTO;
                    break;
                case "6":
                    Chu_TenLoaiChu = "Nhóm người";
                    //Chu_HoTen = Chu.NhomNguoi.NguoiDaiDien.HOTEN;
                    //Chu_CMT = Chu.NhomNguoi.NguoiDaiDien.SOGIAYTO;
                    break;
                default:
                    break;
            }
        }
        public void ThemMoiChu(string loaiChuID)
        {
            Chu = new DC_NGUOI();
            Chu.NGUOIID = Guid.NewGuid().ToString();
            Chu.TRANGTHAI = 1;
            NGUOIID = Chu.NGUOIID;
            switch (loaiChuID)
            {
                case "1":
                    Chu.LOAIDOITUONGID = "1";
                    Chu.CaNhan = new DC_CANHAN();
                    Chu.CaNhan.TRANGTHAI = 1;
                    Chu.CaNhan.CANHANID = Guid.NewGuid().ToString();
                    Chu.CaNhan.FLAGSEARCH = true;
                    Chu.CHITIETID = Chu.CaNhan.CANHANID;
                    LOAI = 1;
                    break;
                case "2":
                    Chu.LOAIDOITUONGID = "2";
                    Chu.HoGiaDinh = new DC_HOGIADINH();
                    Chu.HoGiaDinh.TRANGTHAI = 1;
                    Chu.HoGiaDinh.HOGIADINHID = Guid.NewGuid().ToString();
                    Chu.CHITIETID = Chu.HoGiaDinh.HOGIADINHID;
                    LOAI = 2;
                    break;
                case "3":
                    Chu.LOAIDOITUONGID = "3";
                    Chu.VoChong = new DC_VOCHONG();
                    Chu.VoChong.TRANGTHAI = 1;
                    Chu.VoChong.VOCHONGID = Guid.NewGuid().ToString();
                    Chu.CHITIETID = Chu.VoChong.VOCHONGID;
                    LOAI = 3;
                    break;
                case "4":
                    Chu.LOAIDOITUONGID = "4";
                    Chu.ToChuc = new DC_TOCHUC();
                    Chu.ToChuc.TRANGTHAI = 1;
                    Chu.ToChuc.TOCHUCID = Guid.NewGuid().ToString();
                    Chu.CHITIETID = Chu.ToChuc.TOCHUCID;
                    LOAI = 4;
                    break;
                case "5":
                    Chu.LOAIDOITUONGID = "5";
                    Chu.CongDong = new DC_CONGDONG();
                    Chu.CongDong.TRANGTHAI = 1;
                    Chu.CongDong.CONGDONGID = Guid.NewGuid().ToString();
                    Chu.CHITIETID = Chu.CongDong.CONGDONGID;
                    LOAI = 5;
                    break;
                case "6":
                    Chu.LOAIDOITUONGID = "6";
                    Chu.NhomNguoi = new DC_NHOMNGUOI();
                    Chu.NhomNguoi.DSThanhVien = new List<DC_NHOMNGUOI_THANHVIEN>();
                    Chu.NhomNguoi.TRANGTHAI = 1;
                    Chu.NhomNguoi.NHOMNGUOIID = Guid.NewGuid().ToString();
                    Chu.CHITIETID = Chu.NhomNguoi.NHOMNGUOIID;
                    LOAI = 6;
                    break;
                default:
                    break;
            }
        }
    }
}
