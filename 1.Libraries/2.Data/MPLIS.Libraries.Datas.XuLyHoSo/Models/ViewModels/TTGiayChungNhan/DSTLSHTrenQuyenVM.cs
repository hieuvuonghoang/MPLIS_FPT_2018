using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPLIS.Libraries.Data.XuLyHoSo.Models
{
    public class DSTLSHTrenQuyenVM
    {
        public DSTLSHTrenQuyenVM()
        {
            DSTLSHTrenQuyen = new List<TyLeSoHuuTrenQuyenVM>();
        }
        public List<TyLeSoHuuTrenQuyenVM> DSTLSHTrenQuyen { get; set; }
        public ISQuyen ISQUYEN { get; set; }
    }
}
