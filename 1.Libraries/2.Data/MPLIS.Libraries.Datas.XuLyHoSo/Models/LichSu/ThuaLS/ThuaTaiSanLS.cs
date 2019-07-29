using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppCore.Models;

namespace MPLIS.Libraries.Data.XuLyHoSo.Models
{
    public class ThuaTaiSanLS
    {
        public string THUADATID { get; set; }
        public string THUATAISANID { get; set; }

        #region Properties
        public string TAISANGANLIENVOIDATID { get; set; }
        public string TAISANID { get; set; }
        public string LOAITAISAN { get; set; }
        public string TENTAISAN { get; set; }
        public string uId { get; set; }
        public Nullable<System.DateTime> THOIDIEMKHOITAO { get; set; }
        public Nullable<System.DateTime> THOIDIEMCAPNHAT { get; set; }
        public string NGUOICAPNHATID { get; set; }
        public string TRANGTHAI { get; set; }
        public string TAISANGOCID { get; set; }
        public Nullable<decimal> SOLANCAPQUYEN { get; set; }
        #endregion
    }
}
