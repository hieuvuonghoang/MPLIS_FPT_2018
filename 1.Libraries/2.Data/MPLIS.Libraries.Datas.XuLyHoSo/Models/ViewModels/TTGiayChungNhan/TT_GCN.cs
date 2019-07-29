using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppCore.Models;

namespace MPLIS.Libraries.Data.XuLyHoSo.Models
{
    public class TT_GCN
    {
        public DC_GIAYCHUNGNHAN giaychungnhan { get; set; }
        public List<DC_NGUOI> list_chu { get; set; }
        public List<DC_CONGTRINHXAYDUNG> list_congtrinh { get; set; }
        //public List<DC_HANGMUCCONGTRINH> list_hangmuccongtrinh { get; set; }
        public List<DC_CAYLAUNAM> list_caylaunam{ get; set; }

    }
}
