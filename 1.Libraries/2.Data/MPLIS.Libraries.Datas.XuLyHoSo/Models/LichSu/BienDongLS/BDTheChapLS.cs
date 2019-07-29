using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPLIS.Libraries.Data.XuLyHoSo.Models
{
    public class BDTheChapLS
    {
        public List<string> DSQuyenSoHuuTaiSanID { get; set; }
        public List<string> DSQuyenSuDungDatID { get; set; }

        public BDTheChapLS()
        {
            DSQuyenSoHuuTaiSanID = new List<string>();
            DSQuyenSuDungDatID = new List<string>();
        }

        #region "Properties"
        public string BDTHECHAPID { get; set; }
        public Nullable<System.DateTime> NGAYNHANHS { get; set; }
        public Nullable<System.DateTime> NGAYTHECHAP { get; set; }
        public string QUYENSO { get; set; }
        public Nullable<decimal> SOTHUTU { get; set; }
        public Nullable<decimal> SODANGKY { get; set; }
        public Nullable<System.DateTime> NGAYBATDAU { get; set; }
        public Nullable<System.DateTime> NGAYKETTHUC { get; set; }
        public string BIENDONGID { get; set; }
        #endregion
    }
}
