using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppCore.Models;
using AutoMapper;

namespace MPLIS.Libraries.Data.XuLyHoSo.Models
{
    public class DanhSachTaiSanVM
    {
        public string GiayChungNhanID { get; set; }
        public List<TaiSanVM> DSTaiSanVM { get; set; }
        public DanhSachTaiSanVM ()
        {
            DSTaiSanVM = new List<TaiSanVM>();
        }
        public void initData(BoHoSoModel bhs)
        {
            GiayChungNhanID = bhs.CurDC_GIAYCHUNGNHAN.GIAYCHUNGNHANID;
            foreach (var dangKyTaiSan in bhs.HoSoTN.DonDangKy.DSDangKyTaiSan)
            {
                DSTaiSanVM.Add(Mapper.Map<DC_DANGKY_TAISAN, TaiSanVM>(dangKyTaiSan));
            }
        }
    }
    public class TaiSanVM
    {
        public string TaiSanGanLienVoiDatID { get; set; }
        public string LoaiTaiSan { get; set; }
        public string TenTaiSan { get; set; }
        public decimal DienTich { get; set; }
    }
}
