using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPLIS.Libraries.Data.XuLyHoSo.Models
{
    public class QuyenSHTSVM
    {
        public string QUYENSOHUUTAISANID { get; set; }
        public string NGUOIID { get; set; }
        public string TAISANGANLIENVOIDATID { get; set; }
        public string GIAYCHUNGNHANID { get; set; }
        public string uId { get; set; }
        public Nullable<System.DateTime> THOIDIEMKHOITAO { get; set; }
        public Nullable<System.DateTime> THOIDIEMCAPNHAT { get; set; }
        public string NGUOICAPNHATID { get; set; }
        public string DONDANGKYID { get; set; }
        public string TRANGTHAIPL { get; set; }
        public Nullable<System.DateTime> NGAYDANGKYTC { get; set; }
        public string BDTHECHAPID { get; set; }
        public string QUYENSHTSGOCID { get; set; }
        public string LoaiTaiSan { get; set; }
        public string TenTaiSan { get; set; }
        public decimal DienTich { get; set; }
        public bool EnableCheck { get; set; } 
    }
}
