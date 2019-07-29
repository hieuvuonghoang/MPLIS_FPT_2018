using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppCore.Models;
using AutoMapper;

namespace MPLIS.Libraries.Data.XuLyHoSo.Models
{
    public class DangKyGiayChungNhanVM
    {
        public GiayChungNhanLS GiayChungNhan { get; set; }
        public string SoPhatHanh { get; set; }
        public string MaVach { get; set; }
        public string TrangThai { get; set; }
        #region "Properties"
        public string DONDANGKYID { get; set; }
        public string GIAYCHUNGNHANID { get; set; }
        public Nullable<System.DateTime> THOIDIEMKHOITAO { get; set; }
        public Nullable<System.DateTime> THOIDIEMCAPNHAT { get; set; }
        public string NGUOICAPNHATID { get; set; }
        public string uId { get; set; }
        public string DANGKYGCNID { get; set; }
        #endregion
    }
    public class DSDangKyGiayChungNhanVM
    {
        public DSDangKyGiayChungNhanVM()
        {
            DSDangKyGiayChungNhan = new List<DangKyGiayChungNhanVM>();
        }
        public List<DangKyGiayChungNhanVM> DSDangKyGiayChungNhan { get; set; }
        public void InitData(BoHoSoModel bhs)
        {
            foreach (var temp in bhs.HoSoTN.DonDangKy.DSDangKyGCN)
                DSDangKyGiayChungNhan.Add(Mapper.Map<DC_DANGKY_GCN, DangKyGiayChungNhanVM>(temp));
        }
    }
}
