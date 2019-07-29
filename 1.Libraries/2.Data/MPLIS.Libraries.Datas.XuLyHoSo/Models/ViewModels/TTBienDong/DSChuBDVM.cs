using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppCore.Models;

namespace MPLIS.Libraries.Data.XuLyHoSo.Models
{
    public class DSChuBDVM
    {
        public List<ChuBDVM> DSChu { get; set; }

        public DSChuBDVM()
        {
            DSChu = new List<ChuBDVM>();
        }
    }
}
