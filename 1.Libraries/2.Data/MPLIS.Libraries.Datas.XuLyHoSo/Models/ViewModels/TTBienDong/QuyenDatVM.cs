using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPLIS.Libraries.Data.XuLyHoSo.Models
{
    public class QuyenDatVM
    {
        public bool EnableCheck { get; set; }
        public string TRANGTHAIPL { get; set; }
        public Nullable<System.DateTime> NGAYDANGKYTC { get; set; }
        public string XaPhuong { get; set; }
        public decimal SHToBanDo { get; set; }
        public decimal STTThua { get; set; }
        public decimal DienTich { get; set; }
        public string DiaChi { get; set; }
        public string MDSD { get; set; }
    }
    public class QuyenSDDatVM : QuyenDatVM
    {
        public string QUYENSUDUNGDATID { get; set; }
    }
    public class QuyenQLDatVM : QuyenDatVM
    {
        public string QUYENQUANLYDATID { get; set; }
    }
}
