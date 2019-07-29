using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPLIS.Libraries.Data.SSO.Models
{
    public class SSOHtToChuc
    {
        public string TOCHUCID { get; set; }
        public string KHOACHAID { get; set; }
        public string TENTOCHUC { get; set; }
        public string MOTA { get; set; }
        public string THUTUSAPXEP { get; set; }
        public string uId { get; set; }
        public Nullable<System.DateTime> THOIDIEMKHOITAO { get; set; }
        public string NGUOICAPNHATID { get; set; }
        public Nullable<System.DateTime> THOIDIEMCAPNHAT { get; set; }
        public string DONVIHANHCHINHID { get; set; }
        public Nullable<byte> CAPTOCHUC { get; set; }
        public string MATOCHUC { get; set; }
    }
}
