using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppCore.Models
{
    public partial class DC_QUYENSUDUNGDAT
    {
        public DC_THUADAT Thua { get; set; }
        public DC_NGUOI Chu { get; set; }
        public DC_MUCDICHSUDUNGDAT MdsdDat { get; set; }
        public string XaPhuong { get; set; }
        public decimal SHToBanDo { get; set; }
        public decimal STTThua { get; set; }
        public decimal DienTich { get; set; }
        public string DiaChi { get; set; }
        public string Str_MucDichSDDat { get; set; }
        public void UpdateData()
        {
            XaPhuong = Thua.TenXaPhuong;
            SHToBanDo = Thua.SOHIEUTOBANDO ?? 0M;
            STTThua = Thua.SOTHUTUTHUA ?? 0M;
            DiaChi = Thua.DIACHITHUADAT;
            DienTich = Thua.DIENTICH ?? 0M;
            Str_MucDichSDDat = MdsdDat.MDSD;
        }
    }
}