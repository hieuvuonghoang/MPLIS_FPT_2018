using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppCore.Models
{
    public partial class DC_MUCDICHSUDUNGDAT
    {
        public DM_MUCDICHSUDUNG DMMucDichSuDung { get; set; }
        public List<DC_NGUONGOCSUDUNG> NGSDDats { get; set; }
        public List<DC_QUYENSUDUNGDAT> DSQuyenSDD { get; set; }
        public List<DC_VITRITHUADAT> DSViTriMDSD { get; set; }
        public decimal SOHIEUTOBANDO { get; set; }
        public decimal SOTHUTUTHUA { get; set; }
        public string TenXaPhuong { get; set; }
        public string MDSD{ get; set; }
        public string TenMDSD { get; set; }
        public List<string> NguonID { get; set; }
        public bool _LAMUCDICHCHINH { get; set; }
        public bool _SUDUNGCHUNG { get; set; }
  
    }
}
