using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppCore.Models;

namespace MPLIS.Libraries.Data.XuLyHoSo.Models
{
    public class HanCheLS
    {
        public LoaiHanCheLS LoaiHanChe { get; set; }
        public string TenLoaiHanChe { get; set; }
        public bool _ConHieuLuc
        {
            get
            {
                return CONHIEULUC == "Y" ? true : false;
            }
            set
            {
                if (value)
                    CONHIEULUC = "Y";
                else
                    CONHIEULUC = "N";
            }
        }
        public bool _HanCheMotPhan
        {
            get
            {
                return HANCHEMOTPHAN == "Y" ? true : false;
            }
            set
            {
                if (value)
                    HANCHEMOTPHAN = "Y";
                else
                    HANCHEMOTPHAN = "N";
            }
        }
        public int TRANGTHAI { get; set; }
        #region "Properties"
        public string HANCHEID { get; set; }
        public string LOAIHANCHEID { get; set; }
        public Nullable<decimal> DIENTICH { get; set; }
        public string NOIDUNGHANCHE { get; set; }
        public string HANCHEMOTPHAN { get; set; }
        public string SOVANBAN { get; set; }
        public Nullable<System.DateTime> NGAYBANHANH { get; set; }
        public string COQUANBANHANH { get; set; }
        public string uId { get; set; }
        public Nullable<System.DateTime> THOIDIEMKHOITAO { get; set; }
        public Nullable<System.DateTime> THOIDIEMCAPNHAT { get; set; }
        public string NGUOICAPNHATID { get; set; }
        public string DUONGDANFILEVANBAN { get; set; }
        public string GIAYCHUNGNHANID { get; set; }
        public string THUADATID { get; set; }
        public Nullable<decimal> LOAIHANCHE { get; set; }
        public string SODORANHGIOIHANCHE { get; set; }
        public string CONHIEULUC { get; set; }
        public Nullable<System.DateTime> NGAYHETHIEULUC { get; set; }
        #endregion
    }
}
