using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MPLIS.Libraries.Data.QTHT.Models
{
    public class DVHCViewModel
    {
        public string HUYENID { get; set; }
        public string TENHUYEN { get; set; }
        public string XAID { get; set; }
        public string TENXA { get; set; }
        public string MAXA { get; set; }
    }

    public class HuyenNguoiDung
    {
        public string HUYENID { get; set; }
        public string TENHUYEN { get; set; }
    }
}