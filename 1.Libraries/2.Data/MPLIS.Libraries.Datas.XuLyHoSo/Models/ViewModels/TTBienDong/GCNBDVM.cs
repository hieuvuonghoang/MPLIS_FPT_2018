using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPLIS.Libraries.Data.XuLyHoSo.Models
{
    public class GCNBDVM
    {
        //original properties
        public string BDGCNID { get; set; }
        public string GIAYCHUNGNHANID { get; set; }
        public string BIENDONGID { get; set; }
        public string LAGCNVAO { get; set; }

        //properties get from other objects
        public string SoPhatHanh { get; set; }
        public string MaVach { get; set; }
        public string TrangThai { get; set; }
    }
}
