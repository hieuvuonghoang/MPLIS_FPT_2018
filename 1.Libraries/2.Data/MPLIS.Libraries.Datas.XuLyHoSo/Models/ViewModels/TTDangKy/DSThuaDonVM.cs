using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppCore.Models;
using AutoMapper;

namespace MPLIS.Libraries.Data.XuLyHoSo.Models
{
    public class DSThuaDonVM
    {
        public List<ThuaDonVM> DSDangKyThua { get; set; }

        public DSThuaDonVM()
        {
            DSDangKyThua = new List<ThuaDonVM>();
        }

        public void initData(BoHoSoModel bhs)
        {
            ThuaDonVM ch;

            foreach (var it in bhs.HoSoTN.DonDangKy.DSDangKyThua)
            {
                if (it.Thua != null && it.Thua.LOAITHUADAT != null && !it.Thua.LOAITHUADAT.Equals("X"))
                {
                    ch = Mapper.Map<DC_DANGKY_THUA, ThuaDonVM>(it);
                    DSDangKyThua.Add(ch);
                }
            }
        }
    }
}
