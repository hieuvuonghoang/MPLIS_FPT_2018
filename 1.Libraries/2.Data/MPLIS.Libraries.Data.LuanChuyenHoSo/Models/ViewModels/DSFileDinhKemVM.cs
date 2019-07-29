using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppCore.Models;

namespace MPLIS.Libraries.Data.LuanChuyenHoSo.Models
{
    public class DSFileDinhKemVM
    {
        public DSFileDinhKemVM()
        {
            DSFileDinhKem = new List<QT_FILEDINHKEMHOSO>();
        }
        public List<QT_FILEDINHKEMHOSO> DSFileDinhKem { get; set; }
    }
}
