using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPLIS.Libraries.Data.XuLyHoSo.Models
{
    public class GCNDonVM
    {
        //private properties
        public string DONDANGKYID { get; set; }
        public string GIAYCHUNGNHANID { get; set; }
        public Nullable<System.DateTime> THOIDIEMKHOITAO { get; set; }
        public Nullable<System.DateTime> THOIDIEMCAPNHAT { get; set; }
        public string NGUOICAPNHATID { get; set; }
        public string uId { get; set; }
        public string DANGKYGCNID { get; set; }

        //properties get from other objects
        public string SoPhatHanh { get; set; }
        public string MaVach { get; set; }
        public string TrangThai { get; set; }
    }
}
