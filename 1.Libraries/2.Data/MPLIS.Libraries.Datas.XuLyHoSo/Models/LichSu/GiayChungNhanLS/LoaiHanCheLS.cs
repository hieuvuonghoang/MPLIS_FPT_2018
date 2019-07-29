using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppCore.Models;

namespace MPLIS.Libraries.Data.XuLyHoSo.Models
{
    public class LoaiHanCheLS
    {
        #region "Properties"
        public string LOAIHANCHEID { get; set; }
        public string TENLOAIHANCHE { get; set; }
        public string uId { get; set; }
        public Nullable<System.DateTime> THOIDIEMKHOITAO { get; set; }
        public string NGUOICAPNHATID { get; set; }
        public Nullable<System.DateTime> THOIDIEMCAPNHAT { get; set; }
        #endregion
    }
}
