using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppCore.Models
{
    public partial class DC_DANGKY_THUA
    {
        public DC_THUADAT Thua { get; set; }
        public string XaPhuong { get; set; }
        public string TenXaPhuong { get; set; }
        public decimal SHToBanDo { get; set; }
        public decimal STTThua { get; set; }
        public decimal DienTich { get; set; }
        public string DiaChi { get; set; }
        public string mdsd_id { get; set; }
        public string mdsd{ get; set; }
        //0,1,2
        //Thêm , sửa , xóa
        public string TRANGTHAITHUA { get; set; }
    }
}
