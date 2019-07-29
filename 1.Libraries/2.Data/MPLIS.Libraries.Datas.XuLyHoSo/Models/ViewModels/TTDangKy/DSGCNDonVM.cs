using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPLIS.Libraries.Data.XuLyHoSo.Models
{
    public class DSGCNDonVM
    {
        public List<GCNDonVM> DSDangKyGCN { get; set; }

        public DSGCNDonVM()
        {
            DSDangKyGCN = new List<GCNDonVM>();
        }
    }
}
