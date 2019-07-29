using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPLIS.Libraries.Data.XuLyHoSo.Models.XuLyHoSo.DangKy
{
    public class DC_NGUOI_SearchHoGiaDinh
    {
        public string HOGIADINHID { get; set; }
        public string CMTCHUHO { get; set; }
        public string HOTEN_CHUHO { get; set; }
        public string CMTVOCHONG { get; set; }
        public string HOTEN_VOCHONG { get; set; }
    }

    public class DC_NGUOI_SearchNguoi
    {
        public string CANHANID { get; set; }
        public string HOTEN { get; set; }
        public string SOGIAYTO { get; set; }
        public string DIACHI { get; set; }
        public string NGUOIID { get; set; }
    }

    public class DC_NGUOI_CaNhan
    {
        public string CANHANID { get; set; }
        public string NGUOIID { get; set; }
        public string HOTEN { get; set; }
        public string HODEM { get; set; }
        public string TEN { get; set; }
        public Nullable<System.DateTime> NGAYSINH { get; set; }
        public Nullable<decimal> NAMSINH { get; set; }
        public Nullable<decimal> GIOITINH { get; set; }
        public Nullable<bool> CONSONG { get; set; }
        public string SOGIAYTO { get; set; }
        public Nullable<System.DateTime> NGAYCAP { get; set; }
        public string NOICAP { get; set; }
        public string QUOCTICHID { get; set; }
        public string QUOCTICHKHACIDS { get; set; }
        public string DANTOCID { get; set; }
        public string DIACHI { get; set; }
        public string DIACHIID { get; set; }
        public string UID { get; set; }
        public Nullable<System.DateTime> THOIDIEMKHOITAO { get; set; }
        public Nullable<System.DateTime> THOIDIEMCAPNHAT { get; set; }
        public string NGUOICAPNHATID { get; set; }
        public string GIAYTOTUYTHANID { get; set; }
        public string TenGiayToTuyThanCaNhan { get; set; }
        public string SODIENTHOAI { get; set; }
        public string EMAIL { get; set; }
    }

    public class DC_NGUOI_SearchToChuc
    {
        public string TOCHUCID { get; set; }
        public string TENTOCHUC { get; set; }
        public string SOQUYETDINH { get; set; }
        public string MASOTHUE { get; set; }
        public string NGUOIDAIDIEN { get; set; }
    }

    public class DC_NGUOI_SearchCongDong
    {
        public string CONGDONGID { get; set; }
        public string TENCONGDONG { get; set; }
        public string DIACHICONGDONG { get; set; }
        public string NGUOIDAIDIEN { get; set; }
    }

    public class DC_NGUOI_SearchVoChong
    {
        public string VOCHONGID { get; set; }
        public string CMTCHUHO { get; set; }
        public string HOTEN_CHUHO { get; set; }
        public string CMTVOCHONG { get; set; }
        public string HOTEN_VOCHONG { get; set; }
    }
}
