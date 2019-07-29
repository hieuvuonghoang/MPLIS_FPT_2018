using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppCore.Models;

namespace MPLIS.Libraries.Data.QuanTriQuyTrinh.Models
{
    public class DSQuyTrinhVM
    {
        public DSQuyTrinhVM()
        {
            DSQuyTrinh = new List<QT_QUYTRINH>();
        }
        public List<QT_QUYTRINH> DSQuyTrinh { get; set; }
    }
}
