using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppCore.Models
{
    public partial class DC_GIAYTOTUYTHAN
    {
        public string TenGiayToTuyThan { get; set; }
        //public bool LAGIAYTOINGCN { get; set; }
        public bool _LAGIAYTOINGCN
        {
            get
            {
                return LAGIAYTOINGCN ?? false;
            }
            set
            {
                LAGIAYTOINGCN = value;
            }
        }

        public int TRANGTHAI { get; set; }
    }
}
