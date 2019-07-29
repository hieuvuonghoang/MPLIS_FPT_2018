using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppCore.Models
{
    public partial class DC_DANGKY_TAISAN
    {
        public DC_TAISANGANLIENVOIDAT TaiSanGanLienVoiDat { get; set; }
        //trạng thái thêm/sửa/xóa đối tượng : 
        // mặc định là 0 : không thay đổi
        // mặc định là 1 : thêm
        // mặc định là 2 : sửa
        // mặc định là 3 : xóa
        public string LoaiTaiSan { get; set; }
        public string TenTaiSan { get; set; }
        public decimal? DienTich { get; set; }
        public int trangthaitaisan { get; set; }
    }
}
