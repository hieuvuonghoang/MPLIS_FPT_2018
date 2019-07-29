using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPLIS.Libraries.Data.XuLyHoSo.Models
{
    public class RungTrongLS
    {
        #region "Properties"
        public string RUNGTRONGID { get; set; }
        public string TENRUNG { get; set; }
        public string LOAICAYRUNG { get; set; }
        public Nullable<decimal> DIENTICH { get; set; }
        public string DIACHIID { get; set; }
        public string uId { get; set; }
        public Nullable<System.DateTime> THOIDIEMKHOITAO { get; set; }
        public string NGUOICAPNHATID { get; set; }
        public Nullable<System.DateTime> THOIDIEMCAPNHAT { get; set; }
        public string THOIHANSOHUU { get; set; }
        public string HINHTHUCSOHUU { get; set; }
        #endregion
    }
}
