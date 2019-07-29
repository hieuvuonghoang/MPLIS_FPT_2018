using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppCore.Models
{
   public partial class DC_NHARIENGLE
    {
        public DM_LOAINHA LoaiNha { get; set; }
        public DM_LOAICAPHANG LoaiCapHang { get; set; }
        public bool _CO_HSXN_NHADUYNHAT { get; set; }
    }
}
