using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPLIS.Libraries.Data.XuLyHoSo.Models
{
    public class MucDichSuDungDatLS
    {
        public List<NguonGocSuDungDatLS> NGSDDats { get; set; }
        public string TenMDSD { get; set; }
        public string MDSD { get; set; }
        public decimal SOHIEUTOBANDO { get; set; }
        public decimal SOTHUTUTHUA { get; set; }
        public string TenXaPhuong { get; set; }

        #region "Properties"
        public string MUCDICHSUDUNGDATID { get; set; }
        public string THUADATID { get; set; }
        public Nullable<decimal> SOTHUTUMDSD { get; set; }
        public string MUCDICHSUDUNGID { get; set; }
        public string MUCDICHSUDUNGQHID { get; set; }
        public Nullable<decimal> DIENTICH { get; set; }
        public Nullable<decimal> SUDUNGCHUNG { get; set; }
        public string THOIHANSUDUNG { get; set; }
        public string uId { get; set; }
        public Nullable<System.DateTime> THOIDIEMKHOITAO { get; set; }
        public string NGUOICAPNHATID { get; set; }
        public Nullable<System.DateTime> THOIDIEMCAPNHAT { get; set; }
        public Nullable<bool> LAMUCDICHCHINH { get; set; }
        public string MDSDGOCID { get; set; }
        public string DACAPQUYEN { get; set; }
        public string LOAITHOIHANSUDUNG { get; set; }
        public Nullable<System.DateTime> TUNGAY { get; set; }
        public Nullable<System.DateTime> DENNGAY { get; set; }
        public Nullable<decimal> DIENTICHPHAINOPTIEN { get; set; }
        public Nullable<decimal> DIENTICHKHONGPHAINOPTIEN { get; set; }
        public Nullable<decimal> SOLANCAPQUYEN { get; set; }
        public string NGUONGOCSDTH { get; set; }
        public string HINHTHUCSUDUNGID { get; set; }
        #endregion
    }
}
