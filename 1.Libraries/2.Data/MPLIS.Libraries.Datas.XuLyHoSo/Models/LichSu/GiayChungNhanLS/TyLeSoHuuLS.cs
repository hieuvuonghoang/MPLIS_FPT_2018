﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppCore.Models;

namespace MPLIS.Libraries.Data.XuLyHoSo.Models
{
    public class TyLeSoHuuLS
    {
        public string HOTEN { get; set; }
        public string TENLOAICHU { get; set; }
        public string SOGIAYTO { get; set; }
        public int ISNGUOIDAIDIEN { get; set; }
        #region "Properties"
        public string GCNTILESHID { get; set; }
        public Nullable<decimal> TILESOHUU { get; set; }
        public string GIAYCHUNGNHANID { get; set; }
        public string NGUOIID { get; set; }
        public string THANHVIENID { get; set; }
        public string LOAIDTMIENGIAMID { get; set; }
        #endregion
    }
}