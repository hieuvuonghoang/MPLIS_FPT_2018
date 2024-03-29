﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPLIS.Libraries.Data.XuLyHoSo.Models
{
    public class CanHoLS
    {
        #region "Properties"
        public string CANHOID { get; set; }
        public string NHACHUNGCUID { get; set; }
        public string SOHIEUCANHO { get; set; }
        public Nullable<decimal> TANGSO { get; set; }
        public Nullable<decimal> DIENTICHSAN { get; set; }
        public string uId { get; set; }
        public Nullable<System.DateTime> THOIDIEMKHOITAO { get; set; }
        public string NGUOICAPNHATID { get; set; }
        public Nullable<System.DateTime> THOIDIEMCAPNHAT { get; set; }
        public string HINHTHUCSOHUU { get; set; }
        public string THOIHANSOHUU { get; set; }
        public string TINHTRANGDANGKY { get; set; }
        #endregion
    }
}
