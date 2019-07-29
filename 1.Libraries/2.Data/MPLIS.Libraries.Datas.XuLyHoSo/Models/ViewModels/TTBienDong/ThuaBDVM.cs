using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPLIS.Libraries.Data.XuLyHoSo.Models
{
    public class ThuaBDVM
    {
        //origin properties
        public string BDTHUAID { get; set; }
        public string THUADATID { get; set; }
        public string LOAITHUABD { get; set; }
        public string LADULIEULS { get; set; }
        public string BIENDONGID { get; set; }

        //properties get from other objects
        public string LoaiThua { get; set; }
        public string XaPhuong { get; set; }
        public decimal SHToBanDo { get; set; }
        public decimal STTThua { get; set; }
        public decimal DienTich { get; set; }
        public string DiaChi { get; set; }
    }
}
