using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppCore.Models;
using AutoMapper;

namespace MPLIS.Libraries.Data.XuLyHoSo.Models
{
    public class DSChuDonVM
    {
        public DSChuDonVM()
        {
            DSDangKyChu = new List<ChuDonVM>();
        }
        public List<ChuDonVM> DSDangKyChu { get; set; }
        public string NGUOIID { get; set; }
        public void InitData(BoHoSoModel bhs)
        {
            foreach(var tempDangKyChu in bhs.HoSoTN.DonDangKy.DSDangKyChu)
            {
                DSDangKyChu.Add(Mapper.Map<DC_DANGKY_NGUOI, ChuDonVM>(tempDangKyChu));
            }
        }
    }
}
