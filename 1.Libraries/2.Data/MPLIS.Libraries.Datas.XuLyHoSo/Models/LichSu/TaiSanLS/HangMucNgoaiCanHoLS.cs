using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPLIS.Libraries.Data.XuLyHoSo.Models
{
    public class HangMucNgoaiCanHoLS
    {
        #region "Properties"
        public string HANGMUCSOHUUCHUNGID { get; set; }
        public string NHACHUNGCUID { get; set; }
        public string TENHANGMUC { get; set; }
        public Nullable<decimal> DIENTICH { get; set; }
        public string uId { get; set; }
        public Nullable<System.DateTime> THOIDIEMKHOITAO { get; set; }
        public string NGUOICAPNHATID { get; set; }
        public Nullable<System.DateTime> THOIDIEMCAPNHAT { get; set; }
        #endregion
    }
}
