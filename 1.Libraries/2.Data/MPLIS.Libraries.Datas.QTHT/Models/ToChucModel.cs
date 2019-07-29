using System;
using System.Collections.Generic;
using System.Linq;
using AppCore.Models;

namespace MPLIS.Libraries.Data.QTHT.Models
{
    public class ToChucModel
    {
        public List<HC_TINH> GetListTT()
        {
            using (var context = new MplisEntities())
            {
                var list = context.HC_TINH.ToList();
                return list;
            }
        }
        public List<HC_TINH> GetListTTC2(string maTinh)
        {
            using (var context = new MplisEntities())
            {
                var list = context.HC_TINH.Where(m => m.TINHID == maTinh).ToList();
                return list;
            }
        }

        public List<HC_HUYEN> GetListQH()
        {
            using (var context = new MplisEntities())
            {
                var list = context.HC_HUYEN.Where(m => m.HUYENID == "").ToList();
                return list;
            }
        }

        public List<HC_HUYEN> GetListQHC2(string maTinh)
        {
            using (var context = new MplisEntities())
            {
                var list = context.HC_HUYEN.Where(m => m.TINHID == maTinh).ToList();
                return list;
            }
        }

        public List<HC_HUYEN> GeDSHuyenTheoMaHuyen(string maHuyen)
        {
            using (var context = new MplisEntities())
            {
                var list = context.HC_HUYEN.Where(m => m.HUYENID == maHuyen).ToList();
                return list;
            }
        }

        public List<HC_DMKVHC> GetListDSXaHuyen()
        {
            using (var context = new MplisEntities())
            {
                var list = context.HC_DMKVHC.Where(x => x.KVHCID == "").ToList();
                return list;
            }
        }
        public List<HC_DMKVHC> GetDSXaTheoHuyen(string MaHuyen)
        {
            using (var context = new MplisEntities())
            {
                //var list = context.HC_XA.Where(x => x.XAID == "").ToList();
                var dsXaid2017 =
                                 from h in context.HC_HUYEN
                                 from x in context.HC_DMKVHC
                                 where (h.HUYENID == x.HUYENID) && (h.HUYENID == MaHuyen)
                                 select x.KVHCID;

                var list = context.HC_DMKVHC.Where(x => dsXaid2017.Contains(x.KVHCID)).ToList();

                return list;
            }
        }


        public IList<HT_TOCHUC> DsToChuc { get; set; }
        public HT_TOCHUC ItemToChuc { get; set; }
        public string ToChucCha { get; set; }
        public string IdToChucCha { get; set; }
        public string IdPopupToChuc { get; set; }
        public string Tencncha { get; set; }
        public string TenTochuc { get; set; }

        //Thong tin to chuc
        public string Tochucid { get; set; }
        public string Khoachaid { get; set; }
        public string Tentochuc { get; set; }
        public string Mota { get; set; }
        public int Thutusapxep { get; set; }
        public string Uid { get; set; }
        public string maCapToChuc { get; set; }
        public string maTinh { get; set; }
        public string maHuyen { get; set; }
        public IList<HT_TOCHUC> DanhSachToChucPopup { get; set; }

        public DateTime Thoidiemkhoitao { get; set; }
        public string Nguoicapnhat { get; set; }
        public DateTime Thoidiemcapnhat { get; set; }

        //Gán tổ chức cho người dùng
        public HT_NGUOIDUNG NguoiDungItem { get; set; }
        public IList<HT_NGUOIDUNG> LstNguoiDung { get; set; }
        public IList<HT_NGUOIDUNG> LstNguoiDungT { get; set; }
        public HT_TOCHUC_NGUOIDUNG ToChucNguoiDung { get; set; }
        public IList<HT_TOCHUC_NGUOIDUNG> LstToChucNguoiDung { get; set; }

        //Gán tổ chức cho chức năng
        public HT_NHOMCHUCNANG NhomChucNangItem { get; set; }
        public IList<HT_NHOMCHUCNANG> LstNhomChucNang { get; set; }
        public IList<HT_NHOMCHUCNANG> LstNhomChucNangT { get; set; }
        public HT_TOCHUC_NHOMCHUCNANG ToChucNhomChucNang { get; set; }
        public IList<HT_TOCHUC_NHOMCHUCNANG> LstToChucNhomCn { get; set; }

        //Gán tổ chức cho xã
        public HC_DMKVHC XaItem { get; set; }
        public IList<HC_DMKVHC> LstDsXa { get; set; }
        public IList<HC_DMKVHC> LstDsxaT { get; set; }
        public List<HC_TINH> Tinh { get; set; }
        public List<HC_HUYEN> Huyen { get; set; }



        public IList<HC_HUYEN> DSTenHuyen { get; set; }
        public List<HC_DMKVHC> Xa { get; set; }
        public List<HT_XA_TOCHUC> XaToChuc { get; set; }

        internal HT_XA_TOCHUC xa_ToChuc { get; set; }

        public IList<HT_XA_TOCHUC> LstXaToChuc { get; set; }

        //Xoá
        public IList<HT_TOCHUC> Listcaycon { get; set; }
    }
    public class DanhSachTinhHuyenXa
    {
        public string TenTinh { get; set; }
        public string TenHuyen { get; set; }
        public string TenXa { get; set; }

    }


}