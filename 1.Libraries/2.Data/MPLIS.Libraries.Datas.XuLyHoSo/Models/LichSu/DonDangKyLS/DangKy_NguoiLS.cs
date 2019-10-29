﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPLIS.Libraries.Data.XuLyHoSo.Models
{
    public class DangKy_NguoiLS
    {
        public NguoiLS Chu { get; set; }
        public int TRANGTHAI { get; set; }
        public string FORMID { get; set; }
        #region "Properties"
        public string DONDANGKYID { get; set; }
        public string NGUOIID { get; set; }
        public string MOTATOMTAT { get; set; }
        public string uId { get; set; }
        public Nullable<System.DateTime> THOIDIEMKHOITAO { get; set; }
        public Nullable<System.DateTime> THOIDIEMCAPNHAT { get; set; }
        public string NGUOICAPNHATID { get; set; }
        public Nullable<decimal> LOAI { get; set; }
        public Nullable<decimal> DENGHIDANGKY { get; set; }
        public Nullable<bool> CONHUCAUGHINONVTC { get; set; }
        public string DENGHIKHAC { get; set; }
        public string DANGKYNGUOIID { get; set; }
        #endregion
    }
}