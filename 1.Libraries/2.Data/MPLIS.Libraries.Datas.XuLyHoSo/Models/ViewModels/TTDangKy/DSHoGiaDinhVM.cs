using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppCore.Models;

namespace MPLIS.Libraries.Data.XuLyHoSo.Models
{
    public class DSHoGiaDinhVM
    {
        public DSHoGiaDinhVM()
        {
            DSHoGiaDinh = new List<DC_HOGIADINH>();
        }
        public List<DC_HOGIADINH> DSHoGiaDinh { get; set; }
    }
}
