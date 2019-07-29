using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppCore.Models;
using MPLIS.Libraries.Data.XuLyHoSo.Models;

namespace MPLIS.Libraries.Data.XuLyHoSo.Models
{
    public class DSCongDongVM
    {
        public DSCongDongVM()
        {
            DSCongDong = new List<DC_CONGDONG>();
        }
        public List<DC_CONGDONG> DSCongDong { get; set; }
    }
}
