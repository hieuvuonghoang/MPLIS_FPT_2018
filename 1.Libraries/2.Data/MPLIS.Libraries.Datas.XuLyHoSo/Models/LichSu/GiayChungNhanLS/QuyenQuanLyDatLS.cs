using System;
using AppCore.Models;

namespace MPLIS.Libraries.Data.XuLyHoSo.Models
{
    public class QuyenQuanLyDatLS
    {
        public string XaPhuong { get; set; }
        public decimal SHToBanDo { get; set; }
        public decimal STTThua { get; set; }
        public decimal DienTich { get; set; }
        public string DiaChi { get; set; }
        public int TRANGTHAI { get; set; }
        public string Str_MucDichSDDat { get; set; }
        #region "Properties"
        public string QUYENQUANLYDATID { get; set; }
        public string NGUOIID { get; set; }
        public string THUADATID { get; set; }
        public string MUCDICHSUDUNGID { get; set; }
        public string uId { get; set; }
        public Nullable<System.DateTime> THOIDIEMKHOITAO { get; set; }
        public Nullable<System.DateTime> THOIDIEMCAPNHAT { get; set; }
        public string NGUOICAPNHATID { get; set; }
        public string DONDANGKYID { get; set; }
        public string GIAYCHUNGNHANID { get; set; }
        public string BDTHECHAPID { get; set; }
        public string QUYENQLDATGOCID { get; set; }
        public Nullable<System.DateTime> NGAYDANGKYTC { get; set; }
        public string TRANGTHAIPL { get; set; }
        public Nullable<decimal> TILESOHUU { get; set; }
        #endregion
    }
}
