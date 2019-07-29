using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppCore.Models;

namespace MPLIS.Libraries.Data.QuanTriQuyTrinh.Models
{
    public class DSCongViecTheoBuocVM
    {
        public DSCongViecTheoBuocVM()
        {
            DSCongViecTheoBuoc = new List<QT_CONGVIECTHEOBUOC>();
        }
        public List<QT_CONGVIECTHEOBUOC> DSCongViecTheoBuoc { get; set; }
    }
}
