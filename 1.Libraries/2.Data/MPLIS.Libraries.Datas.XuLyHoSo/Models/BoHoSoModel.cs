using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppCore.Models;

namespace MPLIS.Libraries.Data.XuLyHoSo.Models
{   
    public class BoHoSoModel
    {
        //public string HOSOTIEPNHANID { get; set; }
        //public LOAIDOITUONG LoaiDoiTuong { get; set; }

        //public DC_BIENDONG BienDong { get; set; }
        //public DC_GIAYCHUNGNHAN GiayChungNhan { get; set; }
        //public List<list_DSLienQuanBD> dsChiTietTheChap { get; set; }
        public List<list_Droplist> ls_droplist_ttriengGCN { get; set; }
        public List<DC_LOAIBIENDONG> DS_LoaiBienDong { get; set; }
        public List<list_DSLienQuanBD> list_DoiTuong_xoa { get; set; }
        public List<list_Droplist> list_Droplist_TTGCNDangKy { get; set; }
        public string _LuuQD = "", _LuuCHU = "", _XoaCHU = "", _LuuGCN = "", _XoaGCN = "";
        public QT_HOSOTIEPNHAN HoSoTN { get; set; }

        //Thông tin sử dụng trong tab giấy chứng nhận
        public List<list_Droplist> list_Droplist_XLHSChon_GCN = new List<list_Droplist>();
        public List<list_Droplist> list_Droplist_Nguoi_QuyenSDDat = new List<list_Droplist>();
        public List<list_Droplist> list_Droplist_TTXL = new List<list_Droplist>();
        public List<list_DSLienQuanBD> list_GCNQUYEN_xoa = new List<list_DSLienQuanBD>();
        public List<list_DSLienQuanBD> list_DSQuyenSDDAT { get; set; }
        public List<list_DSLienQuanBD> list_DSQuyenSHTAISAN { get; set; }
        private bool isInitGCN = false;
        public DC_GIAYCHUNGNHAN CurDC_GIAYCHUNGNHAN { get; set; }
        public BoHoSoModel()
        {
            ls_droplist_ttriengGCN = new List<list_Droplist>();
            DS_LoaiBienDong = new List<DC_LOAIBIENDONG>();
            list_DoiTuong_xoa = new List<list_DSLienQuanBD>();
            list_Droplist_TTGCNDangKy = new List<list_Droplist>();
        }
        public void initCurGCN(string iD, TaiGCN loaiGCN)
        {
            if(loaiGCN == TaiGCN.DANGKY)
            {
                if (HoSoTN.DonDangKy != null && HoSoTN.DonDangKy.DSDangKyGCN != null)
                {
                    foreach(var temp in HoSoTN.DonDangKy.DSDangKyGCN)
                    {
                        if(temp.DANGKYGCNID == iD)
                        {
                            temp.GiayChungNhan.EnableEdit = false;
                            CurDC_GIAYCHUNGNHAN = temp.GiayChungNhan;
                            break;
                        }
                    }
                }
            } else if(loaiGCN == TaiGCN.BIENDONG)
            {
                if (HoSoTN.BienDong != null && HoSoTN.BienDong.DSGcn != null)
                {
                    foreach (var temp in HoSoTN.BienDong.DSGcn)
                    {
                        if (temp.BDGCNID == iD)
                        {
                            if(temp.LAGCNVAO == "Y")
                            {
                                bool found = false;
                                foreach(var tempA in HoSoTN.DonDangKy.DSDangKyGCN)
                                {
                                    if (tempA.GIAYCHUNGNHANID != temp.GiayChungNhan.GIAYCHUNGNHANID)
                                        continue;
                                    else
                                    {
                                        found = true;
                                        break;
                                    }
                                }
                                if(found)
                                {
                                    temp.GiayChungNhan.EnableEdit = false;
                                } else
                                {
                                    temp.GiayChungNhan.EnableEdit = true;
                                }
                            } else
                            {
                                temp.GiayChungNhan.EnableEdit = true;
                            }
                            if((temp.GiayChungNhan.EnableEdit == true) && (temp.GiayChungNhan.TRANGTHAI == 0))
                            {
                                temp.GiayChungNhan.TRANGTHAI = 2;
                            }
                            CurDC_GIAYCHUNGNHAN = temp.GiayChungNhan;
                            break;
                        }
                    }
                }
            }

            list_Droplist_Nguoi_QuyenSDDat = new List<list_Droplist>();
            if (HoSoTN.DonDangKy != null && HoSoTN.DonDangKy.DSDangKyChu != null && HoSoTN.DonDangKy.DSDangKyChu.Count > 0)
            {
                foreach (var objnguoi in HoSoTN.DonDangKy.DSDangKyChu)
                {
                    list_Droplist_Nguoi_QuyenSDDat.Add(new list_Droplist(objnguoi.NGUOIID, "Kiểu chủ: " + objnguoi.Chu_TenLoaiChu + " - Họ tên: " + objnguoi.Chu_HoTen));
                }
            }

            list_Droplist_TTXL = new List<list_Droplist>();
            list_Droplist_TTXL.Add(new list_Droplist("Y", "Đã phê duyệt, có tính pháp lý"));
            list_Droplist_TTXL.Add(new list_Droplist("N", "Không được phê duyệt, không có tính pháp lý"));
            list_Droplist_TTXL.Add(new list_Droplist("S", "Đang xử lý, không có tính pháp lý"));
        }

        public void initGCN(string GiayChungNhanID, TaiGCN loaiGCN)
        {
            if (loaiGCN == TaiGCN.DANGKY)
            {
                if (HoSoTN.DonDangKy != null && HoSoTN.DonDangKy.DSDangKyGCN != null)
                    foreach (var it in HoSoTN.DonDangKy.DSDangKyGCN)
                    {
                        if (it.GIAYCHUNGNHANID.Equals(GiayChungNhanID))
                        {
                            CurDC_GIAYCHUNGNHAN = it.GiayChungNhan;
                            break;
                        }
                    }
            }
            else
            {
                if (HoSoTN.BienDong != null && HoSoTN.BienDong.DSGcn != null)
                    foreach (var it in HoSoTN.BienDong.DSGcn)
                    {
                        if (it.GIAYCHUNGNHANID.Equals(GiayChungNhanID))
                        {
                            CurDC_GIAYCHUNGNHAN = it.GiayChungNhan;
                            var result = HoSoTN.DonDangKy.DSDangKyGCN.Where(dKGCN => dKGCN.GIAYCHUNGNHANID.Equals(it.GIAYCHUNGNHANID)).FirstOrDefault();
                            if(result != null)
                            {
                                CurDC_GIAYCHUNGNHAN.ThuocDangKy = true;
                            } else
                            {
                                CurDC_GIAYCHUNGNHAN.ThuocDangKy = false;
                            }
                            break;
                        }
                    }
            }

            if (isInitGCN || HoSoTN == null) return;
            list_Droplist_TTXL = new List<list_Droplist>();
            list_Droplist_TTXL.Add(new list_Droplist("Y", "Đã phê duyệt, có tính pháp lý"));
            list_Droplist_TTXL.Add(new list_Droplist("N", "Không được phê duyệt, không có tính pháp lý"));
            list_Droplist_TTXL.Add(new list_Droplist("S", "Đang xử lý, không có tính pháp lý"));

            list_Droplist_XLHSChon_GCN = new List<list_Droplist>();
            if (HoSoTN.DonDangKy != null && HoSoTN.DonDangKy.DSDangKyGCN != null && HoSoTN.DonDangKy.DSDangKyGCN.Count > 0)
            {
                foreach (var it in HoSoTN.DonDangKy.DSDangKyGCN)
                {
                    list_Droplist_XLHSChon_GCN.Add(new list_Droplist(it.GIAYCHUNGNHANID, "Số phát hành: " + it.SoPhatHanh + " - Mã vạch: " + it.MaVach));
                }
            }

            list_Droplist_Nguoi_QuyenSDDat = new List<list_Droplist>();
            if (HoSoTN.DonDangKy != null && HoSoTN.DonDangKy.DSDangKyChu != null && HoSoTN.DonDangKy.DSDangKyChu.Count > 0)
            {
                foreach (var objnguoi in HoSoTN.DonDangKy.DSDangKyChu)
                {
                    list_Droplist_Nguoi_QuyenSDDat.Add(new list_Droplist(objnguoi.NGUOIID, "Kiểu chủ: " + objnguoi.Chu_TenLoaiChu + " - Họ tên: " + objnguoi.Chu_HoTen));
                }
            }

            list_DSQuyenSDDAT = new List<list_DSLienQuanBD>();
            if (HoSoTN.DonDangKy != null && HoSoTN.DonDangKy.DSDangKyThua != null && HoSoTN.DonDangKy.DSDangKyThua.Count > 0)
            {
                foreach (var ob in HoSoTN.DonDangKy.DSDangKyThua)
                {
                    if (ob.Thua != null && ob.Thua.DSMucDichSuDungDat != null)
                        foreach (var ob1 in ob.Thua.DSMucDichSuDungDat)
                        {
                            list_DSQuyenSDDAT.Add(new list_DSLienQuanBD("SDDAT", ob1.MUCDICHSUDUNGDATID, "", "", false,
                                 ob1.THUADATID, ob1.DMMucDichSuDung.MAMUCDICHSUDUNG,
                                 ob1.MDSD, ob1.DIENTICH == null ? "" : ob1.DIENTICH.ToString(),
                                 ob1.SUDUNGCHUNG == null ? "" : ob1.SUDUNGCHUNG.ToString(),
                                 ob.SHToBanDo.ToString(), ob.STTThua.ToString(), ob.TenXaPhuong));
                        }
                }
            }

            list_DSQuyenSHTAISAN = new List<list_DSLienQuanBD>();
            if (HoSoTN.DonDangKy != null && HoSoTN.DonDangKy.DSDangKyTaiSan != null && HoSoTN.DonDangKy.DSDangKyTaiSan.Count > 0)
            {
                foreach (var ob in HoSoTN.DonDangKy.DSDangKyTaiSan)
                {
                    if (ob.TaiSanGanLienVoiDat != null)
                    {
                        decimal dienTich = 0.0m;
                        switch (ob.TaiSanGanLienVoiDat.LOAITAISAN)
                        {
                            case "1"://DC_NHARIENGLE
                                if (ob.TaiSanGanLienVoiDat.NhaRiengLe != null)
                                    dienTich = (decimal)ob.TaiSanGanLienVoiDat.NhaRiengLe.DIENTICHSAN;
                                break;
                            case "2"://DC_NHACHUNGCU
                            case "3":
                                if (ob.TaiSanGanLienVoiDat.NhaChungCu != null)
                                    dienTich = (decimal)ob.TaiSanGanLienVoiDat.NhaChungCu.DIENTICHSAN;
                                break;
                            case "4"://DC_CANHO
                                if (ob.TaiSanGanLienVoiDat.CanHo != null)
                                        dienTich = (decimal)ob.TaiSanGanLienVoiDat.CanHo.DIENTICHSAN;
                                break;
                            case "5"://DC_HANGMUCNGOAICANHO
                                if (ob.TaiSanGanLienVoiDat.HangMucNgoaiCanHo != null)
                                    dienTich = (decimal)ob.TaiSanGanLienVoiDat.HangMucNgoaiCanHo.DIENTICH;
                                break;
                            case "6"://DC_CONGTRINHXAYDUNG
                                if (ob.TaiSanGanLienVoiDat.CongTrinhXayDung != null)
                                    dienTich = (decimal)ob.TaiSanGanLienVoiDat.CongTrinhXayDung.DIENTICHSAN;
                                break;
                            case "7"://DC_CONGTRINHNGAM
                                if (ob.TaiSanGanLienVoiDat.CongTrinhNgam != null)
                                    dienTich = (decimal)ob.TaiSanGanLienVoiDat.CongTrinhNgam.DIENTICHCONGTRINH;
                                break;
                            case "8"://DC_HANGMUCCONGTRINH
                                if (ob.TaiSanGanLienVoiDat.HangMucCongTrinh != null)
                                    dienTich = (decimal)ob.TaiSanGanLienVoiDat.HangMucCongTrinh.DIENTICHSAN;
                                break;
                            case "9"://DC_RUNGTRONG
                                if (ob.TaiSanGanLienVoiDat.RungTrong != null)
                                    dienTich = (decimal)ob.TaiSanGanLienVoiDat.RungTrong.DIENTICH;
                                break;
                            case "10"://DC_CAYLAUNAM
                                if (ob.TaiSanGanLienVoiDat.CayLauNam != null)
                                    dienTich = (decimal)ob.TaiSanGanLienVoiDat.CayLauNam.DIENTICH;
                                break;
                            default:
                                break;
                        }
                        list_DSQuyenSHTAISAN.Add(new list_DSLienQuanBD("SHTAISAN", ob.TaiSanGanLienVoiDat.TAISANGANLIENVOIDATID, "", "", true,
                             ob.TAISANID, ob.LoaiTaiSan, ob.TenTaiSan, dienTich.ToString(),
                             "",
                             "", "", ""));
                    }
                }
            }
            isInitGCN = true;
        }

        public void initListTTRiengGCN()
        {
            ls_droplist_ttriengGCN = new List<list_Droplist>();
            foreach(var objGCN in HoSoTN.BienDong.DSGcn)
            {
                if(objGCN.LAGCNVAO.Equals("N"))
                {
                    ls_droplist_ttriengGCN.Add(new list_Droplist(objGCN.GIAYCHUNGNHANID, "Số phát hành: " + objGCN.SoPhatHanh + " - Mã vạch: " + objGCN.MaVach));
                }
            }
        }

        public DC_GIAYCHUNGNHAN getGCNInHoSo(string GCNID)
        {
            if (HoSoTN == null || GCNID == null || GCNID.Trim().Equals("")) return null;

            DC_GIAYCHUNGNHAN ret = null;

            if (HoSoTN.BienDong != null)
            {
                foreach (var it in HoSoTN.BienDong.DSGcn)
                {
                    if (it.GIAYCHUNGNHANID.Equals(GCNID)) ret = it.GiayChungNhan;
                    break;
                }
            }
            else if (HoSoTN.DonDangKy != null)
            {
                foreach (var it in HoSoTN.DonDangKy.DSDangKyGCN)
                {
                    if (it.GIAYCHUNGNHANID.Equals(GCNID)) ret = it.GiayChungNhan;
                    break;
                }
            }

            return ret;
        }

        public DC_THUADAT getThuaDatInHoSo(string ThuaDatID)
        {
            if (HoSoTN == null || ThuaDatID == null || ThuaDatID.Trim().Equals("")) return null;

            DC_THUADAT ret = null;

            if (HoSoTN.BienDong != null)
            {
                foreach (var it in HoSoTN.BienDong.DSThua)
                {
                    if (it.THUADATID.Equals(ThuaDatID)) ret = it.Thua;
                    break;
                }
            }
            else if (HoSoTN.DonDangKy != null)
            {
                foreach (var it in HoSoTN.DonDangKy.DSDangKyThua)
                {
                    if (it.THUADATID.Equals(ThuaDatID)) ret = it.Thua;
                    break;
                }
            }

            return ret;
        }
    }

    public enum TaiGCN
    {
        DANGKY = 0,
        BIENDONG = 1,
        KHAC = 2
    }

    public enum ISQuyen
    {
        QSDDAT = 0,
        QSHTS = 1,
        QQLDAT = 2
    }

    public enum LOAIDOITUONG
    {
        HOSOTIEPNHAN,
        THONGTINDANGKY,
        BIENDONG,
        GIAYCHUNGNHAN,
        TTNGHIAVUTAICHINH,
        INANBAOCAO
    }
}
