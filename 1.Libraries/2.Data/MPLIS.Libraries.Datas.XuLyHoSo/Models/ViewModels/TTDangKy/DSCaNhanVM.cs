using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppCore.Models;

namespace MPLIS.Libraries.Data.XuLyHoSo.Models
{
    public class DSCaNhanVM
    {
        public DSCaNhanVM()
        {
            DSCaNhan = new List<DC_CANHAN>();
        }
        public List<DC_CANHAN> DSCaNhan { get; set; }
    }
}
