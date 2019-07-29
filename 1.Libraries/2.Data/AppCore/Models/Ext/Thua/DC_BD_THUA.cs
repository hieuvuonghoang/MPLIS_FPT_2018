using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppCore.Models
{
    public partial class DC_BD_THUA
    {
        public DC_THUADAT Thua { get; set; }
        public string LoaiThua { get; set; }
        public string XaPhuong { get; set; }
        public decimal? SHToBanDo { get; set; }
        public decimal? STTThua { get; set; }
        public decimal? DienTich { get; set; }
        public string DiaChi { get; set; }
    }
}
