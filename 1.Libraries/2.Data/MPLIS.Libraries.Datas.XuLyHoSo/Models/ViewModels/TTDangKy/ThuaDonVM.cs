using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPLIS.Libraries.Data.XuLyHoSo.Models
{
    public class ThuaDonVM
    {
        //private properties
        public string DONDANGKYID { get; set; }
        public string MUCDICHSUDUNGDATID { get; set; }
        public string MOTATOMTAT { get; set; }
        public string uId { get; set; }
        public Nullable<System.DateTime> THOIDIEMKHOITAO { get; set; }
        public Nullable<System.DateTime> THOIDIEMCAPNHAT { get; set; }
        public string NGUOICAPNHATID { get; set; }
        public Nullable<decimal> HINHTHUCSUDUNG { get; set; }
        public string THOIHANSUDUNG { get; set; }
        public string QUYENHANCHE { get; set; }
        public string THOIDIEMSUDUNGDAT { get; set; }
        public Nullable<decimal> DUDIEUKIENCAPGIAY { get; set; }
        public string LYDOKHONGDUDIEUKIEN { get; set; }
        public string THUADATID { get; set; }
        public string DANGKYTHUAID { get; set; }

        //properties get from other object
        public string XaPhuong { get; set; }
        public decimal SHToBanDo { get; set; }
        public decimal STTThua { get; set; }
        public decimal DienTich { get; set; }
        public string DiaChi { get; set; }
    }
}
