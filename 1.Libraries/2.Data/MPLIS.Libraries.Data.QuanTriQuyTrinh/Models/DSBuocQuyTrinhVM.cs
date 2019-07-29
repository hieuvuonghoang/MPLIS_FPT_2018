using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppCore.Models;

namespace MPLIS.Libraries.Data.QuanTriQuyTrinh.Models
{
    public class DSBuocQuyTrinhVM
    {
        public DSBuocQuyTrinhVM()
        {
            DSBuocQuyTrinh = new List<QT_BUOCQUYTRINH>();
        }
        public List<QT_BUOCQUYTRINH> DSBuocQuyTrinh { get; set; }
    }
}
