using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPLIS.Libraries.Data.XuLyHoSo.Models
{
    public class GiayToTuyThanLS
    {
        public string TenLoaiGiayTo { get; set; }
        public string GIAYTOTUYTHANID { get; set; }
        public string LOAIGIAYTOTUYTHANID { get; set; }
        public string CANHANID { get; set; }
        public string SOGIAYTO { get; set; }
        public Nullable<System.DateTime> NGAYCAP { get; set; }
        public string NOICAP { get; set; }
        public string uId { get; set; }
        public Nullable<System.DateTime> THOIDIEMKHOITAO { get; set; }
        public Nullable<System.DateTime> THOIDIEMCAPNHAT { get; set; }
        public string NGUOICAPNHATID { get; set; }
        public Nullable<bool> LAGIAYTOINGCN { get; set; }
    }
}
