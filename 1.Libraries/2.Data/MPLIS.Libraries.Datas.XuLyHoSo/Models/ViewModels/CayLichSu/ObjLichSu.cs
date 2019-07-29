using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPLIS.Libraries.Data.XuLyHoSo.Models
{
    public class ObjLichSu
    {
        public string name { get; set; }
        public string GCN { get; set; }
        public string SOTO { get; set; }
        public string SOTHUA { get; set; }
        public string CHU { get; set; }
        public string LAGCN { get; set; }
        public string className { get; set; }
        public List<ObjLichSu> children { get; set; }
    }
}
