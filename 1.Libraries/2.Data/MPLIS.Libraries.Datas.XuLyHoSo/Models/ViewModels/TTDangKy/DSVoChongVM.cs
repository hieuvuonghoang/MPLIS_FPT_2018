using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppCore.Models;

namespace MPLIS.Libraries.Data.XuLyHoSo.Models
{
    public class DSVoChongVM
    {
        public DSVoChongVM()
        {
            DSVoChong = new List<DC_VOCHONG>();
        }
        public List<DC_VOCHONG> DSVoChong { get; set; }
    }
}
