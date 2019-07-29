using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPLIS.Libraries.Data.XuLyHoSo.Models
{
    public class FileDinhKemHoSoLS
    {
        #region "Properties"
        public string FILEDINHKEMHOSOID { get; set; }
        public string HOSOTIEPNHANID { get; set; }
        public string TRANGTHAIHOSOID { get; set; }
        public string LOAIGIAYTOKEMTHEOHOSOID { get; set; }
        public string SODOQUYTRINHID { get; set; }
        public string BUOCQUYTRINHID { get; set; }
        public string TENFILE { get; set; }
        public Nullable<System.DateTime> NGAYTAOFILE { get; set; }
        public string NGUOITAOFILEID { get; set; }
        public Nullable<byte> LOAI { get; set; }
        public Nullable<decimal> SOLUONG { get; set; }
        public string GHICHU { get; set; }
        public string DUONGDANFILE { get; set; }
        public string UID { get; set; }
        public Nullable<System.DateTime> THOIDIEMKHOITAO { get; set; }
        public string NGUOICAPNHATID { get; set; }
        public Nullable<System.DateTime> THOIDIEMCAPNHAT { get; set; }
        public Nullable<decimal> LOAIBAOCAO { get; set; }
        #endregion
    }
}
