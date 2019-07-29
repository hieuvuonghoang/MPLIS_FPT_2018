using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppCore.Models
{
    public partial class DC_QUYENSOHUUTAISAN
    {
        public DC_TAISANGANLIENVOIDAT TaiSanGanLienVoiDat { get; set; }
        public DC_NGUOI Chu { get; set; }
        public string LoaiTaiSan { get; set; }
        public string TenTaiSan { get; set; }
        public decimal DienTich { get; set; }
        public void UpdateData()
        {
            LoaiTaiSan = TaiSanGanLienVoiDat.LOAITAISAN;
            TenTaiSan = TaiSanGanLienVoiDat.TENTAISAN;
            DienTich = TaiSanGanLienVoiDat.DienTich;
        }
    }
}
