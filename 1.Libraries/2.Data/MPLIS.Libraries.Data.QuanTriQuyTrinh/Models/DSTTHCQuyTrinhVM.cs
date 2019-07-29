using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppCore.Models;

namespace MPLIS.Libraries.Data.QuanTriQuyTrinh.Models
{
    public class DSTTHCQuyTrinhVM
    {
        public DSTTHCQuyTrinhVM()
        {
            DSTTHCQuyTrinh = new List<QT_TTHC_QUYTRINH>();
        }
        public List<QT_TTHC_QUYTRINH> DSTTHCQuyTrinh { get; set; }
    }
}
