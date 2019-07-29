using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppCore.Models;

namespace MPLIS.Libraries.Data.XuLyHoSo.Models
{
    public class DSToChucVM
    {
        public DSToChucVM()
        {
            DSToChuc = new List<DC_TOCHUC>();
        }
        public List<DC_TOCHUC> DSToChuc { get; set; }
    }
}
