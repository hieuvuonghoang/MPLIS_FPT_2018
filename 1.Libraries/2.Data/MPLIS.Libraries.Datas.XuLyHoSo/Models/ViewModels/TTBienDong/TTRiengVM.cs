using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPLIS.Libraries.Data.XuLyHoSo.Models
{
    public class TTRiengVM
    {
        public TTRiengVM()
        {
            dSChuBDVM = new DSChuBDVM();
        }
        public DSChuBDVM dSChuBDVM { get; set; }
        public TheChapVM theChapVM { get; set; }
        public TheChapGiaiChapGCNVM theChapGiaiChapGCNVM { get; set; }
    }
}
