﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppCore.Models;

namespace MPLIS.Libraries.Data.XuLyHoSo.Models
{
    public class DangKyNguoiVM
    {
        public DangKyNguoiVM()
        {
            DSDoiTuongSuDung = new List<DM_DOITUONGSUDUNG>();
        }
        public NguoiLS Chu { get; set; }
        public string Chu_TenLoaiChu { get; set; }
        public string Chu_HoTen { get; set; }
        public string Chu_CMT { get; set; }
        public string Chu_DiaChi { get; set; }
        public List<DM_DOITUONGSUDUNG> DSDoiTuongSuDung { get; set; }

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
