using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppCore.Models;

namespace MPLIS.Libraries.Data.XuLyHoSo.Models
{
    public class FormChiTietChuVM
    {
        public DangKy_NguoiLS DangKyNguoi { get; set; }
        public List<DM_DOITUONGSUDUNG> DSDoiTuongSuDung { get; set; }
        public bool IsFormChuCaNhan { get; set; }
        public bool IsFormChuHoGiaDinh { get; set; }
        public bool IsFormChuVoChong { get; set; }
        public bool IsFormChuToChuc { get; set; }
        public bool IsFormChuCongDong { get; set; }
        public bool IsFormChuNhomNguoi { get; set;}
        public string FormID { get; set; }
        public string UrlSaveForm { get; set; }
        public NguoiLS Chu { get; set; }
        public bool IsNguoiLS { get; set; }
        public bool IsThanhVienHoGiaDinh { get; set; }
        public HoGiaDinhThanhVienLS HoGiaDinhThanhVien { get; set; }
        public void InitForm(DangKy_NguoiLS dangKyNguoi)
        {
            DangKyNguoi = dangKyNguoi;
            switch(dangKyNguoi.Chu.LOAIDOITUONGID)
            {
                case "1":
                    FormID = "FormChuCaNhanID";
                    UrlSaveForm = "/XLHSDangKyDemo/_Save_FormCaNhan";
                    //DSDoiTuongSuDung = 
                    break;
                case "2":
                    FormID = "FormChuHoGiaDinhID";
                    break;
                case "3":
                    FormID = "FormChuVoChongID";
                    break;
                case "4":
                    FormID = "FormChuToChucID";
                    break;
                case "5":
                    FormID = "FormChuCongDongID";
                    break;
                case "6":
                    FormID = "FormChuNhomNguoiID";
                    break;
                default:
                    break;
            }
        }
        public void InitData(NguoiLS chu)
        {
            Chu = chu;
            switch(Chu.LOAIDOITUONGID)
            {
                case "1":
                    FormID = "FormChuCaNhanID";
                    UrlSaveForm = "/XLHSDangKyDemo/_Save_FormCaNhan";
                    IsNguoiLS = true;
                    break;
                case "2":
                    FormID = "FormChuHoGiaDinhID";
                    UrlSaveForm = "/XLHSDangKyDemo/_Save_FormHoGiaDinh";
                    IsNguoiLS = true;
                    break;
                case "3":
                    FormID = "FormChuVoChongID";
                    UrlSaveForm = "/XLHSDangKyDemo/_Save_FormVoChong";
                    IsNguoiLS = true;
                    break;
                case "4":
                    FormID = "FormChuToChucID";
                    UrlSaveForm = "/XLHSDangKyDemo/_Save_FormToChuc";
                    IsNguoiLS = true;
                    break;
                case "5":
                    FormID = "FormChuCongDongID";
                    UrlSaveForm = "/XLHSDangKyDemo/_Save_FormCongDong";
                    IsNguoiLS = true;
                    break;
                case "6":
                    FormID = "FormChuNhomNguoiID";
                    UrlSaveForm = "/XLHSDangKyDemo/_Save_FormNhomNguoi";
                    IsNguoiLS = true;
                    break;
                default:
                    break;
            }
        }
        public void InitDataHGDThanhVien(CaNhanLS thanhVien)
        {
            Chu = new NguoiLS();
            Chu.TRANGTHAI = thanhVien.TRANGTHAI;
            Chu.LOAIDOITUONGID = "1";
            Chu.CaNhan = thanhVien;
            FormID = "FormHoGiaDinhThanhVienID";
            UrlSaveForm = "/XLHSDangKyDemo/_HoGiaDinh_SaveFormThanhVien";
            IsThanhVienHoGiaDinh = true;
        }
        public void InitDataHGDThanhVien(HoGiaDinhThanhVienLS hoGiaDinhThanhVien)
        {
            Chu = new NguoiLS();
            Chu.TRANGTHAI = hoGiaDinhThanhVien.TRANGTHAI;
            Chu.LOAIDOITUONGID = "1";
            Chu.CaNhan = hoGiaDinhThanhVien.ThanhVien;
            FormID = "FormHoGiaDinhThanhVienID";
            UrlSaveForm = "/XLHSDangKyDemo/_HoGiaDinh_SaveFormThanhVien";
            IsThanhVienHoGiaDinh = true;
            HoGiaDinhThanhVien = hoGiaDinhThanhVien;
        }
        public void InitForm(DC_DANGKY_NGUOI dangKyChu)
        {
            switch(dangKyChu.Chu.LOAIDOITUONGID)
            {
                case "1":
                    break;
                case "2":
                    break;
                case "3":
                    break;
                case "4":
                    break;
                case "5":
                    break;
                case "6":
                    break;
                default:
                    break;
            }
        }
    }
}
