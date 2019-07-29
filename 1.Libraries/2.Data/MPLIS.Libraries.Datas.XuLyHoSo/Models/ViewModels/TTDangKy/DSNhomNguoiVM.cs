using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppCore.Models;

namespace MPLIS.Libraries.Data.XuLyHoSo.Models
{
    public class DSNhomNguoiVM
    {
        public DSNhomNguoiVM()
        {
            DSNhomNguoi = new List<DC_NHOMNGUOI>();
        }
        public List<DC_NHOMNGUOI> DSNhomNguoi { get; set; }
    }
}
