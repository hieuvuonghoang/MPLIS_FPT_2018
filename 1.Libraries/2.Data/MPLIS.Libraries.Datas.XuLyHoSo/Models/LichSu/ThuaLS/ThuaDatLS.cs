using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppCore.Models;

namespace MPLIS.Libraries.Data.XuLyHoSo.Models
{
    public class ThuaDatLS
    {
        public List<Thua_ThuaLS> QHThua { get; set; }
        public List<MucDichSuDungDatLS> DSMucDichSuDungDat { get; set; }
        public List<GiaThuaDatLS> DSGiaDat { get; set; }
        public ThuaDatLS()
        {
            QHThua = new List<Models.Thua_ThuaLS>();
            DSMucDichSuDungDat = new List<MucDichSuDungDatLS>();
            DSGiaDat = new List<Models.GiaThuaDatLS>();
        }
        public string TenXaPhuong { get; set; }
        public string DSMucDichSuDungDatToString { get; set; }
        public string MDSD { get; set; }
        public string MUCDICHSUDUNGDATID { get; set; }

        #region "Properties"
        public string THUADATID { get; set; }
        public Nullable<decimal> SOHIEUTOBANDO { get; set; }
        public Nullable<decimal> SOTHUTUTHUA { get; set; }
        public string SOHIEUTOBANDOCU { get; set; }
        public string SOTHUTUTHUACU { get; set; }
        public Nullable<decimal> DIENTICH { get; set; }
        public Nullable<decimal> DIENTICHPHAPLY { get; set; }
        public string TAILIEUDODACID { get; set; }
        public Nullable<decimal> LADOITUONGCHIEMDAT { get; set; }
        public string uId { get; set; }
        public Nullable<System.DateTime> THOIDIEMKHOITAO { get; set; }
        public string NGUOICAPNHATID { get; set; }
        public Nullable<System.DateTime> THOIDIEMCAPNHAT { get; set; }
        public string DIACHITHUADAT { get; set; }
        public string XAID { get; set; }
        public string DANGTRANHCHAP { get; set; }
        public string GEOMETRY { get; set; }
        public string TRANGTHAI { get; set; }
        public string THUAGOCID { get; set; }
        public string LOAITHUADAT { get; set; }
        public string HSKTFILEPATH { get; set; }
        public string GTQUYENSDD { get; set; }
        public string DOANDUONGID { get; set; }
        public string KHUVUCID { get; set; }
        #endregion
    }
}
