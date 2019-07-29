using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using AppCore.Models;

namespace MPLIS.Libraries.Data.XuLyHoSo.Models
{
    public class DSTaiSanVM
    {
        public DSTaiSanVM()
        {
            DSTaiSan = new List<TaiSanGanLienVoiDatVM>();
        }
        public List<TaiSanGanLienVoiDatVM> DSTaiSan { get; set; }
        public QUYENTRENGCN ISQuyen { get; set; }
        public void InitData(BoHoSoModel bhs)
        {
            if(bhs.HoSoTN.DonDangKy.DSDangKyTaiSan != null)
            {
                foreach (var temp in bhs.HoSoTN.DonDangKy.DSDangKyTaiSan)
                {
                    if(temp.TaiSanGanLienVoiDat != null)
                    {
                        temp.TaiSanGanLienVoiDat.InitData();
                        DSTaiSan.Add(Mapper.Map<DC_TAISANGANLIENVOIDAT, TaiSanGanLienVoiDatVM>(temp.TaiSanGanLienVoiDat));
                    }
                }
            }
        }
    }
}
