using AppCore.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppCore.Models
{
   
    public partial class DC_BIENDONG
    {
        public DC_QUYETDINH CurDC_QUYETDINH { get; set; }
        public bool isCOTHUAXL { get; set; }
        public bool isCOTTRIENG { get; set; }
        public List<DC_BD_CHU> DSChu { get; set; }
        public List<DC_BD_GCN> DSGcn { get; set; }
        public List<DC_BD_THUA> DSThua { get; set; }
        public DC_BD_THECHAP TheChapObj { get; set; }

        public bool isInitData = false;

    }
}
