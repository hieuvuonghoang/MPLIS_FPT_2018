using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPLIS.Libraries.Data.XuLyHoSo.Models
{
    public class DangKyChuCaNhan
    {
        public List<GiayToTuyThanLS> DSGiayToTuyThan { get; set; }

        public DangKyChuCaNhan()
        {
            DSGiayToTuyThan = new List<Models.GiayToTuyThanLS>();
            //GTTT_listFind = new List<DC_NGUOI_CreateGIAYTOTUYTHAN>();
            //curGiaytotuythan = new DC_NGUOI_CreateGIAYTOTUYTHAN();
            CO_DB = "0";
        }
        //public DC_NGUOI_CreateGIAYTOTUYTHAN curGiaytotuythan { get; set; }
        #region "Properties"
        //public List<DC_NGUOI_CreateGIAYTOTUYTHAN> GTTT_listFind { get; set; }
        public string DONDANGKYID { get; set; }
        public string CANHANID { get; set; }
        public string NGUOIID { get; set; }
        public string HOTEN { get; set; }
        public string HODEM { get; set; }
        public string TEN { get; set; }
        public Nullable<System.DateTime> NGAYSINH { get; set; }
        public Nullable<decimal> NAMSINH { get; set; }
        public Nullable<decimal> GIOITINH { get; set; }
        public bool CONSONG { get; set; }
        public string SOGIAYTO { get; set; }
        public Nullable<System.DateTime> NGAYCAP { get; set; }
        public string NOICAP { get; set; }
        public string QUOCTICHID { get; set; }
        public string QUOCTICHKHACIDS { get; set; }
        public string DANTOCID { get; set; }
        public string DIACHI { get; set; }
        public string UID { get; set; }
        public Nullable<System.DateTime> THOIDIEMKHOITAO { get; set; }
        public Nullable<System.DateTime> THOIDIEMCAPNHAT { get; set; }
        public string NGUOICAPNHATID { get; set; }
        public string GIAYTOTUYTHANID { get; set; }
        public string SODIENTHOAI { get; set; }
        public string EMAIL { get; set; }
        public bool CONHUCAUGHINONVTC { get; set; }

        public decimal LOAI { get; set; }
        public decimal DENGHIDANGKY { get; set; }
        public string MOTATOMTAT { get; set; }
        public bool LAGIAYTOINGCN { get; set; }
        //Đối tượng 1: chủ hộ
        // 2: vợ chồng
        //3 :con thành viên
        public string DOI_TUONG { get; set; }
        //Đối tượng 1: cá nhân
        // 2: hộ gia đình
        //3 : vợ chồng
        // 4: tổ chức
        //5 : cộng đồng dân cư
        public string TYPE_CHU { get; set; }

        //1 thêm mới cá nhân
        //2 sửa cá nhân
        //3 xóa cá nhân
        public string CO_DB { get; set; }
        #endregion
    }
    #region lớp chủ hộ gia đình
    // thành viên chủ hộ
    public class DangKyHoGiaDinhThanhVien
    {
        #region "Properties"
        //khởi tạo cá nhân thành viên

        public DangKyHoGiaDinhThanhVien()
        {
            ObjThanhVien = new Models.DangKyChuCaNhan();
        }
        public DangKyChuCaNhan ObjThanhVien { get; set; }
        public string HOGIADINHID { get; set; }
        public string CANHANID { get; set; }
        public string uId { get; set; }
        public Nullable<System.DateTime> THOIDIEMKHOITAO { get; set; }
        public Nullable<System.DateTime> THOIDIEMCAPNHAT { get; set; }
        public string NGUOICAPNHATID { get; set; }
        public string QUANHEVOICHUHO { get; set; }
        #endregion
    }
    public class DSHienThiHoGiaDinh
    {
        public string CANHANID { get; set; }
        public string HOTEN { get; set; }
        public string SOGIAYTO { get; set; }
        public string QUANHE { get; set; }
    }
    public class DangKyChuHoGiaDinh
    {
        //Danh sách id của các thành viên thuộc gia đình
        public List<DangKyHoGiaDinhThanhVien> DSThanhVien { get; set; }

        public DangKyChuHoGiaDinh()
        {
            DSThanhVien = new List<DangKyHoGiaDinhThanhVien>();
            ObjChuHo = new Models.DangKyChuCaNhan();
            ObjVoChong = new Models.DangKyChuCaNhan();
            CurCaNhan = new Models.DangKyChuCaNhan();
            //DSHienThi = new List<Models.DSHienThiHoGiaDinh>();
        }

        #region "Properties"
        //public List<DSHienThiHoGiaDinh> DSHienThi { get; set; }
        public DangKyChuCaNhan CurCaNhan { get; set; }
        public DangKyChuCaNhan ObjChuHo { get; set; }

        public DangKyChuCaNhan ObjVoChong { get; set; }
        public string NGUOIID { get; set; }
        public string HOGIADINHID { get; set; }
        public string CHUHO { get; set; }
        public string CMTCHUHO { get; set; }
        public string CMTVOCHONG { get; set; }
        public string VOCHONG { get; set; }
        public string DIACHI { get; set; }
        public string DIACHIID { get; set; }
        public string uId { get; set; }
        public Nullable<System.DateTime> THOIDIEMKHOITAO { get; set; }
        public Nullable<System.DateTime> THOIDIEMCAPNHAT { get; set; }
        public string NGUOICAPNHATID { get; set; }
        
    #endregion
}
    #endregion

    #region lớp chủ vợ chồng
    public class DangKyChuVoChong
    {
        public DangKyChuVoChong()
        {
            ObjChong = new Models.DangKyChuCaNhan();
            ObjVo = new Models.DangKyChuCaNhan();
        }
        public DangKyChuCaNhan ObjChong { get; set; }
        public DangKyChuCaNhan ObjVo { get; set; }
        public string VOCHONGID { get; set; }
        public string CHONG { get; set; }
        public string VO { get; set; }
        public string uId { get; set; }
        public Nullable<System.DateTime> THOIDIEMKHOITAO { get; set; }
        public Nullable<System.DateTime> THOIDIEMCAPNHAT { get; set; }
        public string NGUOICAPNHATID { get; set; }
        public string DIACHI { get; set; }
    }
    #endregion
    #region lớp chủ Tổ chức
    public class DangKyToChuc
    {
        public string TOCHUCID { get; set; }
        public string TENTOCHUC { get; set; }
        public string TENVIETTAT { get; set; }
        public string TENTOCHUCTA { get; set; }
        public string NGUOIDAIDIENID { get; set; }
        public string SOQUYETDINH { get; set; }
        public Nullable<System.DateTime> NGAYQUYETDINH { get; set; }
        public string LOAIQUYETDINHTHANHLAP { get; set; }
        public string MADOANHNGHIEP { get; set; }
        public string MASOTHUE { get; set; }
        public string LOAITOCHUC { get; set; }
        public string DIACHI { get; set; }
        public string uId { get; set; }
        public Nullable<System.DateTime> THOIDIEMKHOITAO { get; set; }
        public Nullable<System.DateTime> THOIDIEMCAPNHAT { get; set; }
        public string NGUOICAPNHATID { get; set; }
        public DangKyToChuc()
        {
            ObjNguoiDaiDienToChuc = new Models.DangKyChuCaNhan();
            
        }
        public DangKyChuCaNhan ObjNguoiDaiDienToChuc { get; set; }

    }
    #endregion
    #region lớp chủ cộng đồng
    public class DangKyChuCongDong
    {
        public DangKyChuCongDong()
        {
            ObjNguoiDaiDienCongDong = new Models.DangKyChuCaNhan();

        }
        public DangKyChuCaNhan ObjNguoiDaiDienCongDong { get; set; }
        public string CONGDONGID { get; set; }
        public string TENCONGDONG { get; set; }
        public string NGUOIDAIDIENID { get; set; }
        public string DIACHI { get; set; }
        public string uId { get; set; }
        public Nullable<System.DateTime> THOIDIEMKHOITAO { get; set; }
        public Nullable<System.DateTime> THOIDIEMCAPNHAT { get; set; }
        public string NGUOICAPNHATID { get; set; }
    }
    #endregion



}
