using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppCore.Models;
using AutoMapper;

namespace MPLIS.Libraries.Data.XuLyHoSo.Models
{
    public class DSThuaDatVM
    {
        public DSThuaDatVM()
        {
            DSThuaTheoThuaID = new List<ThuaDatLS>();
            DSThuaTheoMDSDID = new List<MucDichSuDungDatLS>();
        }
        public QUYENTRENGCN ISQuyen { get; set; }
        public List<ThuaDatLS> DSThuaTheoThuaID { get; set; }
        public List<MucDichSuDungDatLS> DSThuaTheoMDSDID { get; set; }
        public void InitData(BoHoSoModel bhs)
        {
            if (bhs.HoSoTN.DonDangKy.DSDangKyThua != null)
            {
                foreach (var temp in bhs.HoSoTN.DonDangKy.DSDangKyThua)
                {
                    DSThuaTheoThuaID.Add(Mapper.Map<DC_THUADAT, ThuaDatLS>(temp.Thua));
                    if (temp.Thua.DSMucDichSuDungDat != null)
                    {
                        foreach (var tempB in temp.Thua.DSMucDichSuDungDat)
                        {
                            DSThuaTheoMDSDID.Add(Mapper.Map<DC_MUCDICHSUDUNGDAT, MucDichSuDungDatLS>(tempB));
                        }
                    }
                }
            }
        }
    }
}
