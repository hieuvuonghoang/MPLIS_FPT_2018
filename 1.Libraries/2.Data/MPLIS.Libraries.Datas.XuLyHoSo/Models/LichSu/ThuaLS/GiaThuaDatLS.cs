using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPLIS.Libraries.Data.XuLyHoSo.Models
{
    public class GiaThuaDatLS
    {
        #region "Properties"
        public string LOAIGIADATID { get; set; }
        public string THUADATID { get; set; }
        public string GIATHUADATID { get; set; }
        public Nullable<decimal> GIADAT { get; set; }
        public Nullable<System.DateTime> THOIDIEMXACDINH { get; set; }
        public string CANCUPHAPLY { get; set; }
        public string NGUOICAPNHATID { get; set; }
        public Nullable<System.DateTime> THOIDIEMCAPNHAT { get; set; }
        public Nullable<System.DateTime> THOIDIEMKHOITAO { get; set; }
        public string uId { get; set; }
        public string TENFILE { get; set; }
        #endregion
    }
}
