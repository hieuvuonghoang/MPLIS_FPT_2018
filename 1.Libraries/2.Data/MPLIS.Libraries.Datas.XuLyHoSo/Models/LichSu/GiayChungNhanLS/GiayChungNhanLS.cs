using System;
using System.Collections.Generic;

namespace MPLIS.Libraries.Data.XuLyHoSo.Models
{
    public class GiayChungNhanLS
    {
        public List<QuyenSuDungDatLS> DSQuyenSDDat { get; set; }
        public List<QuyenQuanLyDatLS> DSQuyenQLDat { get; set; }
        public List<QuyenSoHuuTaiSanLS> DSQuyenSHTS { get; set; }
        public List<HanCheLS> DSHanChe { get; set; }
        public List<string> DSQuyenSoHuuTaiSanID { get; set; }
        public List<string> DSQuyenSuDungDatID { get; set; }
        public List<GCN_GCNLS> QHGcn_Gcn { get; set; }
        public List<TyLeSoHuuLS> DSTyLeSoHuu { get; set; }
        public int TRANGTHAI { get; set; }
        public bool EnableEdit { get; set; }
        public bool ChinhSua { get; set; }
        public bool _NONVTC
        {
            get
            {
                return NONVTC == "Y" ? true : false;
            }
            set
            {
                NONVTC = value ? "Y" : "N";
            }
        }
        #region "Properties"
        public string GIAYCHUNGNHANID { get; set; }
        public string SOPHATHANH { get; set; }
        public string MAVACH { get; set; }
        public string BANQUET { get; set; }
        public string NGUOIID { get; set; }
        public string uId { get; set; }
        public Nullable<System.DateTime> THOIDIEMKHOITAO { get; set; }
        public Nullable<System.DateTime> THOIDIEMCAPNHAT { get; set; }
        public string NGUOICAPNHATID { get; set; }
        public string DONDANGKYID { get; set; }
        public string SOVAOSO { get; set; }
        public Nullable<System.DateTime> NGAYCAP { get; set; }
        public string TRANGTHAIXULY { get; set; }
        public string TRANGTHAIPL { get; set; }
        public string MAXA { get; set; }
        public string HSKTFILEPATH { get; set; }
        public string GHICHU { get; set; }
        public string SOHUUCHUNGID { get; set; }
        public string TOCHUCID { get; set; }
        public string NONVTC { get; set; }
        #endregion
    }
}
