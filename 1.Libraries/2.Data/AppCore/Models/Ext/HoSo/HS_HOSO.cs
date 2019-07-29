using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppCore.Models
{
    public partial class HS_HOSO
    {
        public List<HS_THANHPHANHOSO> DSFileDinhKem { get; set; }
        public List<HS_TC_GCN> DSGCN { get; set; }
        public List<HS_TC_CHU> DSChu { get; set; }
        public List<HS_LIENKETTHUADAT> DSThua { get; set; }
        public HS_THANHPHANHOSO file { get; set; }
    }
}
