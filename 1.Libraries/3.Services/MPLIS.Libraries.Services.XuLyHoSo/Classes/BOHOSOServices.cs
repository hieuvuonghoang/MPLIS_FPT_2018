using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using AppCore.Models;
using MPLIS.Libraries.Data.XuLyHoSo.Models;
using Newtonsoft.Json;
using System.Data.Common;

namespace MPLIS.Libraries.Services.XuLyHoSo.Classes
{
    public static class BOHOSOServices
    {
        #region "Khởi tạo dữ liệu cho bộ hồ sơ - phục vụ xử lý nghiệp vụ"
        public static void initDataInBHS(BoHoSoModel bhs)
        {
            DCBIENDONGServices.updateTTBienDong(bhs.HoSoTN);
            DCDONDANGKYServices.updateTTDonDangKy(bhs.HoSoTN.DonDangKy);
            if(bhs.HoSoTN.BienDong != null)
            {
                if (bhs.HoSoTN.BienDong.COTHUAXULY == "Y")
                    bhs.HoSoTN.BienDong.isCOTHUAXL = true;
                else bhs.HoSoTN.BienDong.isCOTHUAXL = false;
                if (bhs.HoSoTN.BienDong.MABIENDONG == "TC")
                {
                    bhs.HoSoTN.BienDong.isCOTTRIENG = true;
                    DCBDTHECHAPServices.updateTheChapByBienDongID(bhs.HoSoTN.BienDong.TheChapObj);
                }
                else
                {
                    bhs.HoSoTN.BienDong.isCOTTRIENG = false;
                }
                LoadLoaiBienDong(bhs);
            }
            //if (bhs.HoSoTN.BienDong.QUYETDINHID == null)
            //    bhs.HoSoTN.BienDong.QUYETDINHID = "00000000-0000-0000-0000-000000000000";
            
        }

        private static void LoadLoaiBienDong(BoHoSoModel bhs)
        {
            using(MplisEntities db = new MplisEntities())
            {
                var objLoaiBD = (from it in db.DC_LOAIBIENDONG
                                       select it).OrderBy(c => c.TENLOAIBIENDONG).ToList();
                bhs.DS_LoaiBienDong = objLoaiBD;
                var objgcntttrieng = (from item in bhs.HoSoTN.BienDong.DSGcn.Where(c => c.LAGCNVAO == "N")
                                      select item);
                if (objgcntttrieng != null)
                {
                    foreach (var _add in objgcntttrieng)
                        bhs.list_Droplist_TTGCNDangKy.Add(new list_Droplist(_add.GIAYCHUNGNHANID, "Số phát hành: " + _add.SoPhatHanh + " - Mã vạch: " + _add.MaVach));
                }
                bhs.ls_droplist_ttriengGCN = bhs.list_Droplist_TTGCNDangKy;
            }
        }
        #endregion

        #region "Convert dữ liệu từ bộ hồ sơ sang chuẩn lịch sử chuẩn bị cho lưu lịch sử"
        public static HoSoTiepNhanLS ConvertHoSoTiepNhanToLS(QT_HOSOTIEPNHAN HoSoTiepNhan)
        {
            HoSoTiepNhanLS HoSoLS;

            //Lấy dữ liệu hồ sơ và file đính kèm hồ sơ
            HoSoLS = Mapper.Map<QT_HOSOTIEPNHAN, HoSoTiepNhanLS>(HoSoTiepNhan);
            FileDinhKemHoSoLS pFile;
            if (HoSoTiepNhan.DSFileDinhKem != null)
            {
                HoSoLS.DSFileDinhKem.Clear();
                foreach (var it in HoSoTiepNhan.DSFileDinhKem)
                {
                    pFile = Mapper.Map<QT_FILEDINHKEMHOSO, FileDinhKemHoSoLS>(it);
                    HoSoLS.DSFileDinhKem.Add(pFile);
                }
            }

            //Lấy dữ liệu đơn đăng ký
            HoSoLS.DonDangKy = ConvertDonDangKyToLS(HoSoTiepNhan.DonDangKy, ref HoSoLS);

            //Lấy dữ liệu biến động
            HoSoLS.BienDong = ConvertBienDongToLS(HoSoTiepNhan.BienDong, ref HoSoLS);

            return HoSoLS;
        }

        #region "Convert thông tin biến động và thông tin riêng biến động"
        private static BienDongLS ConvertBienDongToLS(DC_BIENDONG BienDong, ref HoSoTiepNhanLS HoSoLS)
        {
            if (BienDong == null) return null;
            BienDongLS ret;
            ret = Mapper.Map<DC_BIENDONG, BienDongLS>(BienDong);

            //Giấy chứng nhận trong biến động
            BDGiayChungNhanLS bdGCN;
            GiayChungNhanLS gcnLS;
            if (BienDong.DSGcn != null)
            {
                ret.DSGcn.Clear();
                foreach (var it in BienDong.DSGcn)
                {
                    bdGCN = Mapper.Map<DC_BD_GCN, BDGiayChungNhanLS>(it);
                    if (!HoSoLS.DSGiayChungNhan.Contains(it.GIAYCHUNGNHANID))
                    {
                        gcnLS = ConvertGCNtoLS(it.GiayChungNhan, ref HoSoLS);
                        HoSoLS.DSGiayChungNhan.Add(it.GIAYCHUNGNHANID, gcnLS);
                    }
                    ret.DSGcn.Add(bdGCN);
                }
            }

            //Chủ trong biến động
            BDChuLS dkChu;
            NguoiLS nLS;
            if (BienDong.DSChu != null)
            {
                ret.DSChu.Clear();
                foreach (var it in BienDong.DSChu)
                {
                    dkChu = Mapper.Map<DC_BD_CHU, BDChuLS>(it);
                    if (!HoSoLS.DSChu.Contains(it.NGUOIID))
                    {
                        nLS = ConvertChuToLS(it.Chu, ref HoSoLS);
                        HoSoLS.DSChu.Add(nLS.NGUOIID, nLS);
                    }
                    ret.DSChu.Add(dkChu);
                }
            }

            //Thửa đất trong biến động
            BDThuaLS dkThua;
            ThuaDatLS tdLS;
            if (BienDong.DSThua != null)
            {
                ret.DSThua.Clear();
                foreach (var it in BienDong.DSThua)
                {
                    dkThua = Mapper.Map<DC_BD_THUA, BDThuaLS>(it);
                    if (!HoSoLS.DSThua.Contains(it.THUADATID))
                    {
                        tdLS = ConvertThuaDatToLS(it.Thua, ref HoSoLS);
                        HoSoLS.DSThua.Add(tdLS.THUADATID, tdLS);
                    }
                    ret.DSThua.Add(dkThua);
                }
            }

            //Thông tin riêng biến động thế chấp
            ret.TheChapObj = ConvertBDTheChapToLS(BienDong.TheChapObj, ref HoSoLS);

            return ret;
        }

        private static BDTheChapLS ConvertBDTheChapToLS(DC_BD_THECHAP bdTheChap, ref HoSoTiepNhanLS HoSoLS)
        {
            if (bdTheChap == null) return null;
            BDTheChapLS ret;
            ret = Mapper.Map<DC_BD_THECHAP, BDTheChapLS>(bdTheChap);

            //Quyền sở hữu tài sản bị thế chấp
            QuyenSoHuuTaiSanLS qshtsLS;
            foreach (var it in bdTheChap.DSQuyenSoHuuTaiSan)
            {
                if (!HoSoLS.DSQuyenSoHuuTaiSan.Contains(it.QUYENSOHUUTAISANID))
                {
                    qshtsLS = Mapper.Map<DC_QUYENSOHUUTAISAN, QuyenSoHuuTaiSanLS>(it);
                    HoSoLS.DSQuyenSoHuuTaiSan.Add(qshtsLS.QUYENSOHUUTAISANID, qshtsLS);
                }
                ret.DSQuyenSoHuuTaiSanID.Add(it.QUYENSOHUUTAISANID);
            }

            //Quyền sử dụng đất bị thế chấp
            QuyenSuDungDatLS qsddLS;
            foreach (var it in bdTheChap.DSQuyenSuDungDat)
            {
                if (!HoSoLS.DSQuyenSuDungDat.Contains(it.QUYENSUDUNGDATID))
                {
                    qsddLS = Mapper.Map<DC_QUYENSUDUNGDAT, QuyenSuDungDatLS>(it);
                    HoSoLS.DSQuyenSuDungDat.Add(qsddLS.QUYENSUDUNGDATID, qsddLS);
                }
                ret.DSQuyenSuDungDatID.Add(it.QUYENSUDUNGDATID);
            }

            return ret;
        }
        #endregion

        //chuyển đổi dữ liệu đơn đăng ký sang các đối tượng lịch sử
        private static DonDangKyLS ConvertDonDangKyToLS(DC_DONDANGKY DonDangKy, ref HoSoTiepNhanLS HoSoLS)
        {
            if (DonDangKy == null) return null;
            DonDangKyLS DonLS;
            DonLS = Mapper.Map<DC_DONDANGKY, DonDangKyLS>(DonDangKy);

            //Giấy chứng nhận đăng ký
            DangKy_GCNLS dkGCN;
            GiayChungNhanLS gcnLS;
            if (DonDangKy.DSDangKyGCN != null)
            {
                DonLS.DSDangKyGCN.Clear();
                foreach (var it in DonDangKy.DSDangKyGCN)
                {
                    dkGCN = Mapper.Map<DC_DANGKY_GCN, DangKy_GCNLS>(it);
                    if (!HoSoLS.DSGiayChungNhan.Contains(it.GIAYCHUNGNHANID))
                    {
                        gcnLS = ConvertGCNtoLS(it.GiayChungNhan, ref HoSoLS);
                        HoSoLS.DSGiayChungNhan.Add(it.GIAYCHUNGNHANID, gcnLS);
                    }
                    DonLS.DSDangKyGCN.Add(dkGCN);
                }
            }

            //Chủ đăng ký
            DangKy_NguoiLS dkChu;
            NguoiLS nLS;
            if (DonDangKy.DSDangKyChu != null)
            {
                DonLS.DSDangKyChu.Clear();
                foreach (var it in DonDangKy.DSDangKyChu)
                {
                    dkChu = Mapper.Map<DC_DANGKY_NGUOI, DangKy_NguoiLS>(it);
                    if (!HoSoLS.DSChu.Contains(it.NGUOIID))
                    {
                        nLS = ConvertChuToLS(it.Chu, ref HoSoLS);
                        HoSoLS.DSChu.Add(nLS.NGUOIID, nLS);
                    }
                    DonLS.DSDangKyChu.Add(dkChu);
                }
            }

            //Thửa đất đăng ký
            DangKy_ThuaLS dkThua;
            ThuaDatLS tdLS;
            if (DonDangKy.DSDangKyThua != null)
            {
                DonLS.DSDangKyThua.Clear();
                foreach (var it in DonDangKy.DSDangKyThua)
                {
                    dkThua = Mapper.Map<DC_DANGKY_THUA, DangKy_ThuaLS>(it);
                    if (!HoSoLS.DSThua.Contains(it.THUADATID))
                    {
                        tdLS = ConvertThuaDatToLS(it.Thua, ref HoSoLS);
                        HoSoLS.DSThua.Add(tdLS.THUADATID, tdLS);
                    }
                    DonLS.DSDangKyThua.Add(dkThua);
                }
            }

            //Tài sản đăng ký
            DangKy_TaiSanLS dkTaiSan;
            TaiSanLS tsLS;
            if (DonDangKy.DSDangKyTaiSan != null)
            {
                DonLS.DSDangKyTaiSan.Clear();
                foreach (var it in DonDangKy.DSDangKyTaiSan)
                {
                    dkTaiSan = Mapper.Map<DC_DANGKY_TAISAN, DangKy_TaiSanLS>(it);
                    if (!HoSoLS.DSTaiSan.Contains(it.TAISANID))
                    {
                        tsLS = ConvertTaiSanToLS(it.TaiSanGanLienVoiDat);
                        HoSoLS.DSTaiSan.Add(tsLS.TAISANGANLIENVOIDATID, tsLS);
                    }
                    DonLS.DSDangKyTaiSan.Add(dkTaiSan);
                }
            }

            //Ý kiến xác nhận
            XacNhanDonDangKyLS xnDK;
            YKienXacNhanLS ykxnLS;
            if (DonDangKy.DSXacNhan != null)
            {
                DonLS.DSXacNhan.Clear();
                foreach (var it in DonDangKy.DSXacNhan)
                {
                    xnDK = Mapper.Map<DC_XACNHANDONDANGKY, XacNhanDonDangKyLS>(it);
                    xnDK.DSYKienXacNhan.Clear();
                    foreach (var yk in it.DSYKienXacNhan)
                    {
                        ykxnLS = Mapper.Map<DC_YKIENXACNHAN, YKienXacNhanLS>(yk);
                        xnDK.DSYKienXacNhan.Add(ykxnLS);
                    }
                    DonLS.DSXacNhan.Add(xnDK);
                }
            }

            return DonLS;
        }

        //chuyển đổi dữ liệu giấy chứng nhận sang các đối tượng lịch sử
        private static GiayChungNhanLS ConvertGCNtoLS(DC_GIAYCHUNGNHAN gcn, ref HoSoTiepNhanLS HoSoLS)
        {
            if (gcn == null) return null;
            GiayChungNhanLS gcnLS;
            ThuaDatLS tdLS;
            NguoiLS nLS;
            TaiSanLS tsLS;
            MucDichSuDungDatLS mdsddLS;

            gcnLS = Mapper.Map<DC_GIAYCHUNGNHAN, GiayChungNhanLS>(gcn);

            #region "Lấy dữ liệu các bảng quan hệ của giấy chứng nhận - Đưa các đối tượng dùng chung vào các hashtable"
            GCN_GCNLS qhGCN;
            if (gcn.QHGcn_Gcn != null)
            {
                gcnLS.QHGcn_Gcn.Clear();
                foreach (var it in gcn.QHGcn_Gcn)
                {
                    qhGCN = Mapper.Map<DC_BD_GCN_GCN, GCN_GCNLS>(it);
                    gcnLS.QHGcn_Gcn.Add(qhGCN);
                }
            }

            QuyenSuDungDatLS qSDDat;
            if (gcn.DSQuyenSDDat != null)
                foreach (var it in gcn.DSQuyenSDDat)
                {
                    qSDDat = Mapper.Map<DC_QUYENSUDUNGDAT, QuyenSuDungDatLS>(it);
                    if (!HoSoLS.DSQuyenSuDungDat.Contains(qSDDat.QUYENSUDUNGDATID)) HoSoLS.DSQuyenSuDungDat.Add(qSDDat.QUYENSUDUNGDATID, qSDDat);
                    //lưu trữ chủ
                    if (!HoSoLS.DSChu.Contains(it.NGUOIID))
                    {
                        nLS = ConvertChuToLS(it.Chu, ref HoSoLS);
                        HoSoLS.DSChu.Add(it.NGUOIID, nLS);
                    }

                    //lưu trữ thửa
                    if (!HoSoLS.DSThua.Contains(it.THUADATID))
                    {
                        tdLS = ConvertThuaDatToLS(it.Thua, ref HoSoLS);
                        HoSoLS.DSThua.Add(tdLS.THUADATID, tdLS);
                    }

                    //lưu trữ mdsddat
                    if (!HoSoLS.DSMDSDDat.Contains(it.MUCDICHSUDUNGDATID))
                    {
                        mdsddLS = Mapper.Map<DC_MUCDICHSUDUNGDAT, MucDichSuDungDatLS>(it.MdsdDat);
                        HoSoLS.DSMDSDDat.Add(it.MUCDICHSUDUNGDATID, mdsddLS);
                    }
                    gcnLS.DSQuyenSuDungDatID.Add(qSDDat.QUYENSUDUNGDATID);
                }

            QuyenSoHuuTaiSanLS qSHTaiSan;
            if (gcn.DSQuyenSHTS != null)
                foreach (var it in gcn.DSQuyenSHTS)
                {
                    qSHTaiSan = Mapper.Map<DC_QUYENSOHUUTAISAN, QuyenSoHuuTaiSanLS>(it);
                    if (!HoSoLS.DSQuyenSoHuuTaiSan.Contains(qSHTaiSan.QUYENSOHUUTAISANID)) HoSoLS.DSQuyenSoHuuTaiSan.Add(qSHTaiSan.QUYENSOHUUTAISANID, qSHTaiSan);
                    if (!HoSoLS.DSChu.Contains(it.NGUOIID))
                    {
                        nLS = ConvertChuToLS(it.Chu, ref HoSoLS);
                        HoSoLS.DSChu.Add(it.NGUOIID, nLS);
                    }
                    if (!HoSoLS.DSTaiSan.Contains(it.TAISANGANLIENVOIDATID))
                    {
                        tsLS = ConvertTaiSanToLS(it.TaiSanGanLienVoiDat);
                        HoSoLS.DSTaiSan.Add(tsLS.TAISANGANLIENVOIDATID, tsLS);
                    }
                    gcnLS.DSQuyenSoHuuTaiSanID.Add(qSHTaiSan.QUYENSOHUUTAISANID);
                }
            #endregion

            return gcnLS;
        }

        #region "Convert thông tin chủ sang lịch sử"
        private static NguoiLS ConvertChuToLS(DC_NGUOI chu, ref HoSoTiepNhanLS HoSoLS)
        {
            if (chu == null) return null;
            NguoiLS chuLS;

            chuLS = Mapper.Map<DC_NGUOI, NguoiLS>(chu);
            switch (chuLS.LOAIDOITUONGID)
            {
                case "1"://DC_CANHAN
                    chuLS.CaNhan = ConvertCaNhanToLS(chu.CaNhan, ref HoSoLS);
                    break;
                case "2"://DC_HOGIADINH
                    chuLS.HoGiaDinh = Mapper.Map<DC_HOGIADINH, HoGiaDinhLS>(chu.HoGiaDinh);
                    HoGiaDinhThanhVienLS it;
                    if (chu.HoGiaDinh.DSThanhVien != null)
                    {
                        chuLS.HoGiaDinh.DSThanhVien.Clear();
                        foreach (var qh in chu.HoGiaDinh.DSThanhVien)
                        {
                            it = Mapper.Map<DC_HOGIADINH_THANHVIEN, HoGiaDinhThanhVienLS>(qh);
                            ConvertCaNhanToLS(qh.ThanhVien, ref HoSoLS);
                            chuLS.HoGiaDinh.DSThanhVien.Add(it);
                        }
                    }
                    break;
                case "3"://DC_VOCHONG
                    chuLS.VoChong = Mapper.Map<DC_VOCHONG, VoChongLS>(chu.VoChong);
                    ConvertCaNhanToLS(chu.VoChong.ChongCN, ref HoSoLS);
                    ConvertCaNhanToLS(chu.VoChong.VoCN, ref HoSoLS);
                    break;
                case "4"://DC_CONGDONG
                    chuLS.CongDong = Mapper.Map<DC_CONGDONG, CongDongLS>(chu.CongDong);
                    ConvertCaNhanToLS(chu.CongDong.NguoiDaiDien, ref HoSoLS);
                    break;
                case "5"://DC_TOCHUC
                    chuLS.ToChuc = Mapper.Map<DC_TOCHUC, ToChucLS>(chu.ToChuc);
                    ConvertCaNhanToLS(chu.ToChuc.NguoiDaiDien, ref HoSoLS);
                    break;
                case "6"://DC_NHOMNGUOI
                    chuLS.NhomNguoi = Mapper.Map<DC_NHOMNGUOI, NhomNguoiLS>(chu.NhomNguoi);
                    NhomNguoiThanhVienLS ntv;
                    if (chu.NhomNguoi.DSThanhVien != null)
                    {
                        chuLS.NhomNguoi.DSThanhVien.Clear();
                        foreach (var qh in chu.NhomNguoi.DSThanhVien)
                        {
                            ntv = Mapper.Map<DC_NHOMNGUOI_THANHVIEN, NhomNguoiThanhVienLS>(qh);
                            ConvertCaNhanToLS(qh.ThanhVien, ref HoSoLS);
                            chuLS.NhomNguoi.DSThanhVien.Add(ntv);
                        }
                    }
                    break;
                default:
                    break;
            }

            return chuLS;
        }

        private static CaNhanLS ConvertCaNhanToLS(DC_CANHAN cn, ref HoSoTiepNhanLS HoSoLS)
        {
            if (cn == null) return null;
            CaNhanLS cnLS;
            GiayToTuyThanLS gttt;

            cnLS = Mapper.Map<DC_CANHAN, CaNhanLS>(cn);
            if (cn.DSGiayToTuyThan != null)
            {
                cnLS.DSGiayToTuyThan.Clear();
                foreach (var gt in cn.DSGiayToTuyThan)
                {
                    gttt = Mapper.Map<DC_GIAYTOTUYTHAN, GiayToTuyThanLS>(gt);
                    cnLS.DSGiayToTuyThan.Add(gttt);
                }
            }

            if (!HoSoLS.DSCaNhan.Contains(cnLS.CANHANID))
            {
                HoSoLS.DSCaNhan.Add(cnLS.CANHANID, cnLS);
            }

            return cnLS;
        }
        #endregion

        #region "Convert thông tin tài sản sang lịch sử"
        private static TaiSanLS ConvertTaiSanToLS(DC_TAISANGANLIENVOIDAT ts)
        {
            if (ts == null) return null;
            TaiSanLS ret;
            ret = Mapper.Map<DC_TAISANGANLIENVOIDAT, TaiSanLS>(ts);

            switch (ret.LOAITAISAN)
            {
                case "1"://DC_NHARIENGLE
                    ret.NhaRiengLe = Mapper.Map<DC_NHARIENGLE, NhaRiengLeLS>(ts.NhaRiengLe);
                    break;
                case "2"://DC_NHACHUNGCU
                case "3":
                    ret.NhaChungCu = Mapper.Map<DC_NHACHUNGCU, NhaChungCuLS>(ts.NhaChungCu);
                    break;
                case "4"://DC_CANHO
                    ret.CanHo = Mapper.Map<DC_CANHO, CanHoLS>(ts.CanHo);
                    break;
                case "5"://DC_HANGMUCNGOAICANHO
                    ret.HangMucNgoaiCanHo = Mapper.Map<DC_HANGMUCNGOAICANHO, HangMucNgoaiCanHoLS>(ts.HangMucNgoaiCanHo);
                    break;
                case "6"://DC_CONGTRINHXAYDUNG
                    ret.CongTrinhXayDung = Mapper.Map<DC_CONGTRINHXAYDUNG, CongTrinhXayDungLS>(ts.CongTrinhXayDung);
                    break;
                case "7"://DC_CONGTRINHNGAM
                    ret.CongTrinhNgam = Mapper.Map<DC_CONGTRINHNGAM, CongTrinhNgamLS>(ts.CongTrinhNgam);
                    break;
                case "8"://DC_HANGMUCCONGTRINH
                    ret.HangMucCongTrinh = Mapper.Map<DC_HANGMUCCONGTRINH, HangMucCongTrinhLS>(ts.HangMucCongTrinh);
                    break;
                case "9"://DC_RUNGTRONG
                    ret.RungTrong = Mapper.Map<DC_RUNGTRONG, RungTrongLS>(ts.RungTrong);
                    break;
                case "10"://DC_CAYLAUNAM
                    ret.CayLauNam = Mapper.Map<DC_CAYLAUNAM, CayLauNamLS>(ts.CayLauNam);
                    break;
                default:
                    break;
            }

            return ret;
        }
        #endregion

        #region "Convert thửa đất sang lịch sử"
        private static ThuaDatLS ConvertThuaDatToLS(DC_THUADAT td, ref HoSoTiepNhanLS HoSoLS)
        {
            if (td == null) return null;
            ThuaDatLS tdLS;
            GiaThuaDatLS gtdLS;
            Thua_ThuaLS ttLS;
            MucDichSuDungDatLS mdsddLS;

            tdLS = Mapper.Map<DC_THUADAT, ThuaDatLS>(td);
            if (td.DSGiaDat != null)
            {
                tdLS.DSGiaDat.Clear();
                foreach (var it in td.DSGiaDat)
                {
                    gtdLS = Mapper.Map<GD_GIATHUADAT, GiaThuaDatLS>(it);
                    tdLS.DSGiaDat.Add(gtdLS);
                }
            }

            if (td.QHThua != null)
            {
                tdLS.QHThua.Clear();
                foreach (var it in td.QHThua)
                {
                    ttLS = Mapper.Map<DC_BD_THUA_THUA, Thua_ThuaLS>(it);
                    tdLS.QHThua.Add(ttLS);
                }
            }

            if (td.DSMucDichSuDungDat != null)
            {
                tdLS.DSMucDichSuDungDat.Clear();
                foreach (var it in td.DSMucDichSuDungDat)
                {
                    mdsddLS = Mapper.Map<DC_MUCDICHSUDUNGDAT, MucDichSuDungDatLS>(it);
                    tdLS.DSMucDichSuDungDat.Add(mdsddLS);
                    if (!HoSoLS.DSMDSDDat.Contains(mdsddLS.MUCDICHSUDUNGDATID)) HoSoLS.DSMDSDDat.Add(mdsddLS.MUCDICHSUDUNGDATID, mdsddLS);
                }
            }

            return tdLS;
        }
        #endregion

        #endregion

        #region "Convert dữ liệu từ bộ hồ sơ lịch sử sang dữ liệu thường"
        public static QT_HOSOTIEPNHAN ConvertHoSoLSToHoSoTiepNhan(HoSoTiepNhanLS HoSoLS)
        {
            QT_HOSOTIEPNHAN HoSoTiepNhan;

            //Lấy dữ liệu hồ sơ và file đính kèm hồ sơ
            HoSoTiepNhan = Mapper.Map<HoSoTiepNhanLS, QT_HOSOTIEPNHAN>(HoSoLS);

            QT_FILEDINHKEMHOSO pFile;
            if (HoSoLS.DSFileDinhKem != null)
            {
                HoSoTiepNhan.DSFileDinhKem = new List<QT_FILEDINHKEMHOSO>();
                foreach (var it in HoSoLS.DSFileDinhKem)
                {
                    pFile = Mapper.Map<FileDinhKemHoSoLS, QT_FILEDINHKEMHOSO>(it);
                    HoSoTiepNhan.DSFileDinhKem.Add(pFile);
                }
            }

            //Lấy dữ liệu đơn đăng ký
            HoSoTiepNhan.DonDangKy = ConvertDonDangKyLSToDonDangKy(HoSoLS.DonDangKy, ref HoSoLS);

            //Lấy dữ liệu biến động
            HoSoTiepNhan.BienDong = ConvertBienDongLSToBienDong(HoSoLS.BienDong, ref HoSoLS);

            return HoSoTiepNhan;
        }

        #region "Convert thông tin biến động và thông tin riêng biến động"
        private static DC_BIENDONG ConvertBienDongLSToBienDong(BienDongLS BienDong, ref HoSoTiepNhanLS HoSoLS)
        {
            if (BienDong == null) return null;
            DC_BIENDONG ret;
            ret = Mapper.Map<BienDongLS, DC_BIENDONG>(BienDong);

            //Giấy chứng nhận trong biến động
            DC_BD_GCN bdGCN;
            DC_GIAYCHUNGNHAN gcn;
            GiayChungNhanLS gcnLS;
            if (BienDong.DSGcn != null)
            {
                ret.DSGcn = new List<DC_BD_GCN>();
                foreach (var it in BienDong.DSGcn)
                {
                    bdGCN = Mapper.Map<BDGiayChungNhanLS, DC_BD_GCN>(it);
                    if (HoSoLS.DSGiayChungNhan.Contains(it.GIAYCHUNGNHANID))
                    {
                        gcnLS = (GiayChungNhanLS)HoSoLS.DSGiayChungNhan[it.GIAYCHUNGNHANID];
                        gcn = ConvertGCNLStoGCN(gcnLS, ref HoSoLS);
                        bdGCN.GiayChungNhan = gcn;
                    }
                    ret.DSGcn.Add(bdGCN);
                }
            }

            //Chủ trong biến động
            DC_BD_CHU dkChu;
            NguoiLS nLS;
            if (BienDong.DSChu != null)
            {
                ret.DSChu = new List<DC_BD_CHU>();
                foreach (var it in BienDong.DSChu)
                {
                    dkChu = Mapper.Map<BDChuLS, DC_BD_CHU>(it);
                    if (HoSoLS.DSChu.Contains(it.NGUOIID))
                    {
                        nLS = (NguoiLS)HoSoLS.DSChu[it.NGUOIID];
                        dkChu.Chu = ConvertNguoiLSToNguoi(nLS, ref HoSoLS);
                    }
                    ret.DSChu.Add(dkChu);
                }
            }

            //Thửa đất trong biến động
            DC_BD_THUA dkThua;
            ThuaDatLS tdLS;
            if (BienDong.DSThua != null)
            {
                ret.DSThua = new List<DC_BD_THUA>();
                foreach (var it in BienDong.DSThua)
                {
                    dkThua = Mapper.Map<BDThuaLS, DC_BD_THUA>(it);
                    if (HoSoLS.DSThua.Contains(it.THUADATID))
                    {
                        tdLS = (ThuaDatLS)HoSoLS.DSThua[it.THUADATID];
                        dkThua.Thua = ConvertThuaDatLSToThuaDat(tdLS, HoSoLS);
                    }
                    ret.DSThua.Add(dkThua);
                }
            }

            //Thông tin riêng biến động thế chấp
            ret.TheChapObj = ConvertBDTheChapLSToBDTheChap(BienDong.TheChapObj, ref HoSoLS);

            return ret;
        }

        private static DC_BD_THECHAP ConvertBDTheChapLSToBDTheChap(BDTheChapLS bdTheChapLS, ref HoSoTiepNhanLS HoSoLS)
        {
            if (bdTheChapLS == null) return null;
            DC_BD_THECHAP ret;

            ret = Mapper.Map<BDTheChapLS, DC_BD_THECHAP>(bdTheChapLS);

            //Quyền sở hữu tài sản bị thế chấp
            QuyenSoHuuTaiSanLS qshtsLS;
            DC_QUYENSOHUUTAISAN qshts;
            foreach (var it in bdTheChapLS.DSQuyenSoHuuTaiSanID)
            {
                if (HoSoLS.DSQuyenSoHuuTaiSan.Contains(it))
                {
                    qshtsLS = (QuyenSoHuuTaiSanLS)HoSoLS.DSQuyenSoHuuTaiSan[it];
                    qshts = Mapper.Map<QuyenSoHuuTaiSanLS, DC_QUYENSOHUUTAISAN>(qshtsLS);
                    ret.DSQuyenSoHuuTaiSan.Add(qshts);
                }
            }

            //Quyền sử dụng đất bị thế chấp
            QuyenSuDungDatLS qsddLS;
            DC_QUYENSUDUNGDAT qsdd;
            foreach (var it in bdTheChapLS.DSQuyenSuDungDatID)
            {
                if (HoSoLS.DSQuyenSuDungDat.Contains(it))
                {
                    qsddLS = (QuyenSuDungDatLS)HoSoLS.DSQuyenSuDungDat[it];
                    qsdd = Mapper.Map<QuyenSuDungDatLS, DC_QUYENSUDUNGDAT>(qsddLS);
                    ret.DSQuyenSuDungDat.Add(qsdd);
                }
            }

            return ret;
        }
        #endregion

        //chuyển đổi dữ liệu đơn đăng ký lịch sử sang đơn đăng ký
        private static DC_DONDANGKY ConvertDonDangKyLSToDonDangKy(DonDangKyLS DonDangKyLS, ref HoSoTiepNhanLS HoSoLS)
        {
            if (DonDangKyLS == null) return null;
            DC_DONDANGKY Don;
            Don = Mapper.Map<DonDangKyLS, DC_DONDANGKY>(DonDangKyLS);

            //Giấy chứng nhận đăng ký
            DC_DANGKY_GCN dkGCN;
            GiayChungNhanLS gcnLS;
            Don.DSDangKyGCN.Clear();
            if (DonDangKyLS.DSDangKyGCN != null)
                foreach (var it in DonDangKyLS.DSDangKyGCN)
                {
                    dkGCN = Mapper.Map<DangKy_GCNLS, DC_DANGKY_GCN>(it);
                    if (HoSoLS.DSGiayChungNhan.Contains(it.GIAYCHUNGNHANID))
                    {
                        gcnLS = (GiayChungNhanLS)HoSoLS.DSGiayChungNhan[it.GIAYCHUNGNHANID];
                        dkGCN.GiayChungNhan = ConvertGCNLStoGCN(gcnLS, ref HoSoLS);
                    }
                    Don.DSDangKyGCN.Add(dkGCN);
                }

            //Chủ đăng ký
            DC_DANGKY_NGUOI dkChu;
            NguoiLS nLS;
            Don.DSDangKyChu.Clear();
            if (DonDangKyLS.DSDangKyChu != null)
                foreach (var it in DonDangKyLS.DSDangKyChu)
                {
                    dkChu = Mapper.Map<DangKy_NguoiLS, DC_DANGKY_NGUOI>(it);
                    if (HoSoLS.DSChu.Contains(it.NGUOIID))
                    {
                        nLS = (NguoiLS)HoSoLS.DSChu[it.NGUOIID];
                        dkChu.Chu = ConvertNguoiLSToNguoi(nLS, ref HoSoLS);
                    }
                    Don.DSDangKyChu.Add(dkChu);
                }

            //Thửa đất đăng ký
            DC_DANGKY_THUA dkThua;
            ThuaDatLS tdLS;
            Don.DSDangKyThua.Clear();
            if (DonDangKyLS.DSDangKyThua != null)
                foreach (var it in DonDangKyLS.DSDangKyThua)
                {
                    dkThua = Mapper.Map<DangKy_ThuaLS, DC_DANGKY_THUA>(it);
                    if (HoSoLS.DSThua.Contains(it.THUADATID))
                    {
                        tdLS = (ThuaDatLS)HoSoLS.DSThua[it.THUADATID];
                        dkThua.Thua = ConvertThuaDatLSToThuaDat(tdLS, HoSoLS);
                    }
                    Don.DSDangKyThua.Add(dkThua);
                }

            //Tài sản đăng ký
            DC_DANGKY_TAISAN dkTaiSan;
            TaiSanLS tsLS;
            Don.DSDangKyTaiSan.Clear();
            if (DonDangKyLS.DSDangKyTaiSan != null)
                foreach (var it in DonDangKyLS.DSDangKyTaiSan)
                {
                    dkTaiSan = Mapper.Map<DangKy_TaiSanLS, DC_DANGKY_TAISAN>(it);
                    if (HoSoLS.DSTaiSan.Contains(it.TAISANID))
                    {
                        tsLS = (TaiSanLS)HoSoLS.DSTaiSan[it.TAISANID];
                        dkTaiSan.TaiSanGanLienVoiDat = ConvertTaiSanLSToTaiSan(tsLS);
                    }
                    Don.DSDangKyTaiSan.Add(dkTaiSan);
                }

            //Ý kiến xác nhận
            DC_XACNHANDONDANGKY xnDK;
            DC_YKIENXACNHAN ykxn;
            Don.DSXacNhan.Clear();
            if (DonDangKyLS.DSXacNhan != null)
                foreach (var it in DonDangKyLS.DSXacNhan)
                {
                    xnDK = Mapper.Map<XacNhanDonDangKyLS, DC_XACNHANDONDANGKY>(it);
                    xnDK.DSYKienXacNhan.Clear();
                    foreach (var yk in it.DSYKienXacNhan)
                    {
                        ykxn = Mapper.Map<YKienXacNhanLS, DC_YKIENXACNHAN>(yk);
                        xnDK.DSYKienXacNhan.Add(ykxn);
                    }
                    Don.DSXacNhan.Add(xnDK);
                }

            return Don;
        }

        //chuyển đổi dữ liệu giấy chứng nhận sang các đối tượng lịch sử
        private static DC_GIAYCHUNGNHAN ConvertGCNLStoGCN(GiayChungNhanLS gcnLS, ref HoSoTiepNhanLS HoSoLS)
        {
            if (gcnLS == null) return null;
            DC_GIAYCHUNGNHAN gcn;
            ThuaDatLS tdLS;
            NguoiLS nLS;
            DC_NGUOI nguoi;
            TaiSanLS tsLS;
            MucDichSuDungDatLS mdsddLS;

            gcn = Mapper.Map<GiayChungNhanLS, DC_GIAYCHUNGNHAN>(gcnLS);

            #region "Lấy các đối tượng dùng chung từ các hashtable - Đưa vào các bảng quan hệ của giấy chứng nhận"
            DC_BD_GCN_GCN qhGCN;
            if (gcnLS.QHGcn_Gcn != null)
            {
                gcn.QHGcn_Gcn.Clear();
                foreach (var it in gcnLS.QHGcn_Gcn)
                {
                    qhGCN = Mapper.Map<GCN_GCNLS, DC_BD_GCN_GCN>(it);
                    gcn.QHGcn_Gcn.Add(qhGCN);
                }
            }

            DC_QUYENSUDUNGDAT qSDDat;
            QuyenSuDungDatLS qsdDatLS;
            if (gcnLS.DSQuyenSuDungDatID != null)
            {
                gcn.DSQuyenSDDat = new List<DC_QUYENSUDUNGDAT>();
                foreach (var it in gcnLS.DSQuyenSuDungDatID)
                {
                    if (HoSoLS.DSQuyenSuDungDat.Contains(it))
                    {
                        qsdDatLS = (QuyenSuDungDatLS)HoSoLS.DSQuyenSuDungDat[it];
                        qSDDat = Mapper.Map<QuyenSuDungDatLS, DC_QUYENSUDUNGDAT>(qsdDatLS);

                        //lưu trữ chủ
                        if (HoSoLS.DSChu.Contains(qSDDat.NGUOIID))
                        {
                            nLS = (NguoiLS)HoSoLS.DSChu[qSDDat.NGUOIID];
                            nguoi = ConvertNguoiLSToNguoi(nLS, ref HoSoLS);
                            qSDDat.Chu = nguoi;
                        }

                        //lưu trữ thửa
                        if (HoSoLS.DSThua.Contains(qSDDat.THUADATID))
                        {
                            tdLS = (ThuaDatLS)HoSoLS.DSThua[qSDDat.THUADATID];
                            qSDDat.Thua = ConvertThuaDatLSToThuaDat(tdLS, HoSoLS);
                        }

                        //lưu trữ mdsddat
                        if (HoSoLS.DSMDSDDat.Contains(qSDDat.MUCDICHSUDUNGDATID))
                        {
                            mdsddLS = (MucDichSuDungDatLS)HoSoLS.DSMDSDDat[qSDDat.MUCDICHSUDUNGDATID];
                            qSDDat.MdsdDat = Mapper.Map<MucDichSuDungDatLS, DC_MUCDICHSUDUNGDAT>(mdsddLS);
                        }
                        gcn.DSQuyenSDDat.Add(qSDDat);
                    }
                }
            }

            DC_QUYENSOHUUTAISAN qSHTaiSan;
            QuyenSoHuuTaiSanLS qSHTaiSanLS;
            if (gcnLS.DSQuyenSoHuuTaiSanID != null)
            {
                gcn.DSQuyenSHTS = new List<DC_QUYENSOHUUTAISAN>();
                foreach (var it in gcnLS.DSQuyenSoHuuTaiSanID)
                {
                    if (HoSoLS.DSQuyenSoHuuTaiSan.Contains(it))
                    {
                        qSHTaiSanLS = (QuyenSoHuuTaiSanLS)HoSoLS.DSQuyenSoHuuTaiSan[it];
                        qSHTaiSan = Mapper.Map<QuyenSoHuuTaiSanLS, DC_QUYENSOHUUTAISAN>(qSHTaiSanLS);

                        if (HoSoLS.DSChu.Contains(qSHTaiSan.NGUOIID))
                        {
                            nLS = (NguoiLS)HoSoLS.DSChu[qSHTaiSanLS.NGUOIID];
                            qSHTaiSan.Chu = ConvertNguoiLSToNguoi(nLS, ref HoSoLS);
                        }

                        if (HoSoLS.DSTaiSan.Contains(qSHTaiSan.TAISANGANLIENVOIDATID))
                        {
                            tsLS = (TaiSanLS)HoSoLS.DSTaiSan[qSHTaiSan.TAISANGANLIENVOIDATID];
                            qSHTaiSan.TaiSanGanLienVoiDat = ConvertTaiSanLSToTaiSan(tsLS);
                        }
                        gcn.DSQuyenSHTS.Add(qSHTaiSan);
                    }
                }
            }
            #endregion

            return gcn;
        }

        #region "Convert thông tin chủ lịch sử sang chủ"
        private static DC_NGUOI ConvertNguoiLSToNguoi(NguoiLS chuLS, ref HoSoTiepNhanLS HoSoLS)
        {
            if (chuLS == null) return null;
            DC_NGUOI chu;

            chu = Mapper.Map<NguoiLS, DC_NGUOI>(chuLS);
            switch (chuLS.LOAIDOITUONGID)
            {
                case "1"://DC_CANHAN
                    chu.CaNhan = ConvertCaNhanLSToCaNhan(chuLS.CaNhan);
                    break;
                case "2"://DC_HOGIADINH
                    chu.HoGiaDinh = Mapper.Map<HoGiaDinhLS, DC_HOGIADINH>(chuLS.HoGiaDinh);
                    DC_HOGIADINH_THANHVIEN it;
                    if (chuLS.HoGiaDinh.DSThanhVien != null)
                    {
                        chu.HoGiaDinh.DSThanhVien.Clear();
                        foreach (var qh in chuLS.HoGiaDinh.DSThanhVien)
                        {
                            it = Mapper.Map<HoGiaDinhThanhVienLS, DC_HOGIADINH_THANHVIEN>(qh);
                            it.ThanhVien = ConvertCaNhanLSToCaNhan(qh.CANHANID, ref HoSoLS);
                            chu.HoGiaDinh.DSThanhVien.Add(it);
                        }
                    }
                    break;
                case "3"://DC_VOCHONG
                    chu.VoChong = Mapper.Map<VoChongLS, DC_VOCHONG>(chuLS.VoChong);
                    chu.VoChong.ChongCN = ConvertCaNhanLSToCaNhan(chuLS.VoChong.CHONG, ref HoSoLS);
                    chu.VoChong.VoCN = ConvertCaNhanLSToCaNhan(chuLS.VoChong.VO, ref HoSoLS);
                    break;
                case "4"://DC_CONGDONG
                    chu.CongDong = Mapper.Map<CongDongLS, DC_CONGDONG>(chuLS.CongDong);
                    chu.CongDong.NguoiDaiDien = ConvertCaNhanLSToCaNhan(chuLS.CongDong.NGUOIDAIDIENID, ref HoSoLS);
                    break;
                case "5"://DC_TOCHUC
                    chu.ToChuc = Mapper.Map<ToChucLS, DC_TOCHUC>(chuLS.ToChuc);
                    chu.ToChuc.NguoiDaiDien = ConvertCaNhanLSToCaNhan(chuLS.ToChuc.NGUOIDAIDIENID, ref HoSoLS);
                    break;
                case "6"://DC_NHOMNGUOI
                    chu.NhomNguoi = Mapper.Map<NhomNguoiLS, DC_NHOMNGUOI>(chuLS.NhomNguoi);
                    DC_NHOMNGUOI_THANHVIEN ntv;
                    if (chu.NhomNguoi.DSThanhVien != null)
                    {
                        chu.NhomNguoi.DSThanhVien.Clear();
                        foreach (var qh in chuLS.NhomNguoi.DSThanhVien)
                        {
                            ntv = Mapper.Map<NhomNguoiThanhVienLS, DC_NHOMNGUOI_THANHVIEN>(qh);
                            ntv.ThanhVien = ConvertCaNhanLSToCaNhan(qh.THANHPHANID, ref HoSoLS);
                            chu.NhomNguoi.DSThanhVien.Add(ntv);
                        }
                    }
                    break;
                default:
                    break;
            }

            return chu;
        }

        private static DC_CANHAN ConvertCaNhanLSToCaNhan(CaNhanLS cnLS)
        {
            DC_CANHAN cn = null;
            DC_GIAYTOTUYTHAN gttt;

            cn = Mapper.Map<CaNhanLS, DC_CANHAN>(cnLS);
            if (cnLS.DSGiayToTuyThan != null)
            {
                cn.DSGiayToTuyThan.Clear();
                foreach (var gt in cnLS.DSGiayToTuyThan)
                {
                    gttt = Mapper.Map<GiayToTuyThanLS, DC_GIAYTOTUYTHAN>(gt);
                    cn.DSGiayToTuyThan.Add(gttt);
                }
            }

            return cn;
        }

        private static DC_CANHAN ConvertCaNhanLSToCaNhan(string cnID, ref HoSoTiepNhanLS HoSoLS)
        {
            CaNhanLS cnLS;
            DC_CANHAN cn = null;
            DC_GIAYTOTUYTHAN gttt;

            if (HoSoLS.DSCaNhan.Contains(cnID))
            {
                cnLS = (CaNhanLS)HoSoLS.DSCaNhan[cnID];
                cn = Mapper.Map<CaNhanLS, DC_CANHAN>(cnLS);
                cn.DSGiayToTuyThan.Clear();
                if (cnLS.DSGiayToTuyThan != null)
                    foreach (var gt in cnLS.DSGiayToTuyThan)
                    {
                        gttt = Mapper.Map<GiayToTuyThanLS, DC_GIAYTOTUYTHAN>(gt);
                        cn.DSGiayToTuyThan.Add(gttt);
                    }
            }

            return cn;
        }
        #endregion

        #region "Convert thông tin tài sản sang lịch sử"
        private static DC_TAISANGANLIENVOIDAT ConvertTaiSanLSToTaiSan(TaiSanLS tsLS)
        {
            if (tsLS == null) return null;
            DC_TAISANGANLIENVOIDAT ret;
            ret = Mapper.Map<TaiSanLS, DC_TAISANGANLIENVOIDAT>(tsLS);

            switch (ret.LOAITAISAN)
            {
                case "1"://DC_NHARIENGLE
                    ret.NhaRiengLe = Mapper.Map<NhaRiengLeLS, DC_NHARIENGLE>(tsLS.NhaRiengLe);
                    break;
                case "2"://DC_NHACHUNGCU
                case "3":
                    ret.NhaChungCu = Mapper.Map<NhaChungCuLS, DC_NHACHUNGCU>(tsLS.NhaChungCu);
                    break;
                case "4"://DC_CANHO
                    ret.CanHo = Mapper.Map<CanHoLS, DC_CANHO>(tsLS.CanHo);
                    break;
                case "5"://DC_HANGMUCNGOAICANHO
                    ret.HangMucNgoaiCanHo = Mapper.Map<HangMucNgoaiCanHoLS, DC_HANGMUCNGOAICANHO>(tsLS.HangMucNgoaiCanHo);
                    break;
                case "6"://DC_CONGTRINHXAYDUNG
                    ret.CongTrinhXayDung = Mapper.Map<CongTrinhXayDungLS, DC_CONGTRINHXAYDUNG>(tsLS.CongTrinhXayDung);
                    break;
                case "7"://DC_CONGTRINHNGAM
                    ret.CongTrinhNgam = Mapper.Map<CongTrinhNgamLS, DC_CONGTRINHNGAM>(tsLS.CongTrinhNgam);
                    break;
                case "8"://DC_HANGMUCCONGTRINH
                    ret.HangMucCongTrinh = Mapper.Map<HangMucCongTrinhLS, DC_HANGMUCCONGTRINH>(tsLS.HangMucCongTrinh);
                    break;
                case "9"://DC_RUNGTRONG
                    ret.RungTrong = Mapper.Map<RungTrongLS, DC_RUNGTRONG>(tsLS.RungTrong);
                    break;
                case "10"://DC_CAYLAUNAM
                    ret.CayLauNam = Mapper.Map<CayLauNamLS, DC_CAYLAUNAM>(tsLS.CayLauNam);
                    break;
                default:
                    break;
            }

            return ret;
        }
        #endregion

        #region "Convert thửa đất lịch sử sang thửa đất"
        private static DC_THUADAT ConvertThuaDatLSToThuaDat(ThuaDatLS tdLS, HoSoTiepNhanLS HoSoLS)
        {
            if (tdLS == null) return null;
            DC_THUADAT td;
            GD_GIATHUADAT gtd;
            DC_BD_THUA_THUA tt;
            DC_MUCDICHSUDUNGDAT mdsdd;
            MucDichSuDungDatLS mdLS;

            td = Mapper.Map<ThuaDatLS, DC_THUADAT>(tdLS);
            if (tdLS.DSGiaDat != null)
            {
                td.DSGiaDat.Clear();
                foreach (var it in tdLS.DSGiaDat)
                {
                    gtd = Mapper.Map<GiaThuaDatLS, GD_GIATHUADAT>(it);
                    td.DSGiaDat.Add(gtd);
                }
            }

            if (tdLS.QHThua != null)
            {
                td.QHThua.Clear();
                foreach (var it in tdLS.QHThua)
                {
                    tt = Mapper.Map<Thua_ThuaLS, DC_BD_THUA_THUA>(it);
                    td.QHThua.Add(tt);
                }
            }

            if (tdLS.DSMucDichSuDungDat != null)
            {
                td.DSMucDichSuDungDat.Clear();
                foreach (var it in tdLS.DSMucDichSuDungDat)
                {
                    mdsdd = Mapper.Map<MucDichSuDungDatLS, DC_MUCDICHSUDUNGDAT>(it);
                    td.DSMucDichSuDungDat.Add(mdsdd);
                }
            }

            if (HoSoLS.DSMDSDDat != null)
            {
                td.DSMucDichSuDungDat.Clear();
                foreach (DictionaryEntry it in HoSoLS.DSMDSDDat)
                {
                    mdLS = (MucDichSuDungDatLS)it.Value;
                    if(mdLS.THUADATID.Equals(td.THUADATID))
                    {
                        mdsdd = Mapper.Map<MucDichSuDungDatLS, DC_MUCDICHSUDUNGDAT>(mdLS);
                        td.DSMucDichSuDungDat.Add(mdsdd);
                    }
                }
            }

            return td;
        }
        #endregion
        #endregion

        #region "Lưu lịch sử"
        //hàm gọi lưu lịch sử
        public static void LuuLichSu(QT_HOSOTIEPNHAN HoSoTiepNhan)
        {
            CapNhatTrangThaiDuLieu(HoSoTiepNhan);

            HoSoTiepNhanLS HoSoLS;
            HoSoLS = ConvertHoSoTiepNhanToLS(HoSoTiepNhan);

            LuuThongTinTraCuu(HoSoLS);

            LuuCayLichSu(HoSoLS);

            //cập nhật các dữ liệu liên quan với thửa đất đầu vào
            CapNhatDuLieuLienQuanThuaDat(HoSoLS);

            //Xóa dữ liệu cũ
            XoaDuLieuCu(HoSoTiepNhan);
        }

        #region "Chuyển trạng thái đối tượng trước khi lưu lịch sử"
        private static void CapNhatTrangThaiDuLieu(QT_HOSOTIEPNHAN HoSoTiepNhan)
        {
            string gcnIDs = "", thuaIDs = "", tsIDs = "";
            Hashtable TDs = new Hashtable();

            #region "Update record status before processing"
            HoSoTiepNhan.TRANGTHAI = "N";
            foreach (var it in HoSoTiepNhan.BienDong.DSGcn)
            {
                //cập nhật thông tin GCN trước khi lưu
                if (it.LAGCNVAO.Equals("Y"))
                {
                    //đã mất tính pháp lý
                    it.GiayChungNhan.TRANGTHAIXULY = "N";
                    foreach (var q in it.GiayChungNhan.DSQuyenSDDat)
                    {
                        q.Thua.TRANGTHAI = "N";
                    }
                    foreach (var q in it.GiayChungNhan.DSQuyenSHTS)
                    {
                        q.TaiSanGanLienVoiDat.TRANGTHAI = "N";
                    }
                }
                else
                {
                    //đã phê duyệt, có tính pháp lý
                    gcnIDs += "'" + it.GIAYCHUNGNHANID + "',";
                    it.GiayChungNhan.TRANGTHAIXULY = "Y";
                    foreach (var q in it.GiayChungNhan.DSQuyenSDDat)
                    {
                        if (!TDs.Contains(q.THUADATID))
                        {
                            TDs.Add(q.THUADATID, q.THUADATID);
                            thuaIDs += "'" + q.THUADATID + "',";
                        }
                        q.Thua.TRANGTHAI = "Y";
                    }
                    foreach (var q in it.GiayChungNhan.DSQuyenSHTS)
                    {
                        tsIDs += "'" + q.TAISANGANLIENVOIDATID + "',";
                        q.TaiSanGanLienVoiDat.TRANGTHAI = "Y";
                    }
                }
            }
            #endregion

            #region "Update data status in database"
            List<string> queries = new List<string>();
            if (gcnIDs.Length > 0)
            {
                gcnIDs = gcnIDs.Substring(0, gcnIDs.Length - 1);
                queries.Add("update DC_GIAYCHUNGNHAN set TRANGTHAIXULY = 'Y' where GIAYCHUNGNHANID in (" + gcnIDs + ");");
            }
            if (thuaIDs.Length > 0)
            {
                thuaIDs = thuaIDs.Substring(0, thuaIDs.Length - 1);
                queries.Add("update DC_THUADAT set TRANGTHAI = 'Y' where THUADATID in (" + thuaIDs + ");");
            }
            if (tsIDs.Length > 0)
            {
                tsIDs = tsIDs.Substring(0, tsIDs.Length - 1);
                queries.Add("update DC_TAISANGANLIENVOIDAT set TRANGTHAI = 'Y' where TAISANGANLIENVOIDATID in (" + tsIDs + ");");
            }

            if (queries.Count > 0)
            {
                string sqlBatch = "";
                for (int i = 0; i < queries.Count; i++)
                {
                    sqlBatch += queries[i];
                }

                using (MplisEntities db = new MplisEntities())
                {
                    try
                    {
                        if (db.Database.Connection.State == System.Data.ConnectionState.Closed
                            || db.Database.Connection.State == System.Data.ConnectionState.Broken)
                            db.Database.Connection.Open();
                        DbCommand cmd = db.Database.Connection.CreateCommand();
                        cmd.CommandType = System.Data.CommandType.Text;
                        sqlBatch = "BEGIN " + sqlBatch + " END; ";
                        cmd.CommandText = sqlBatch;
                        cmd.ExecuteNonQuery();
                        //db.Database.ExecuteSqlCommand(sqlBatch);
                    }
                    catch (Exception ex)
                    {

                    }
                }
            }
            #endregion
        }
        #endregion

        #region "Xóa dữ liệu cũ sau khi kết thúc lưu lịch sử - chỉ dữ liệu thuộc tính"
        private static void XoaDuLieuCu(QT_HOSOTIEPNHAN HoSoTiepNhan)
        {
            List<string> queries = new List<string>();

            XoaDuLieuDangKy(HoSoTiepNhan, ref queries);

            XoaDuLieuBienDong(HoSoTiepNhan, ref queries);

            //Tạm thời không xóa dữ liệu của hồ sơ cũ
            //Sẽ bổ sung thêm sau - dính đến dữ liệu trong quá trình xử lý hồ sơ - trong bảng QT_XULYHOSO
            //XoaDuLieuHoSo(HoSoTiepNhan, ref queries);

            //Chạy lệnh xóa
            string sqlBatch = "";
            for (int i = 0; i < queries.Count; i++)
            {
                sqlBatch += queries[i];
            }

            if (sqlBatch.Length > 0)
                using (MplisEntities db = new MplisEntities())
                {
                    try
                    {
                        if (db.Database.Connection.State == System.Data.ConnectionState.Closed
                            || db.Database.Connection.State == System.Data.ConnectionState.Broken)
                            db.Database.Connection.Open();
                        DbCommand cmd = db.Database.Connection.CreateCommand();
                        sqlBatch = "BEGIN " + sqlBatch + " END; ";
                        cmd.CommandText = sqlBatch;
                        cmd.ExecuteNonQuery();
                        //db.Database.ExecuteSqlCommand(sqlBatch);
                    }
                    catch (Exception ex)
                    {

                    }
                }
        }

        #region "Xóa dữ liệu biến động"
        private static void XoaDuLieuBienDong(QT_HOSOTIEPNHAN HoSoTiepNhan, ref List<string> queries)
        {
            XoaDuLieuKhacTrongBienDong(HoSoTiepNhan, ref queries);

            XoaDuLieuGCNBienDong(HoSoTiepNhan, ref queries);
        }

        private static void XoaDuLieuGCNBienDong(QT_HOSOTIEPNHAN HoSoTiepNhan, ref List<string> queries)
        {
            string delGCN = "", delThua = "", delTaiSan = "", delQuyenSHTS = "", delQuyenSDD = "", delMDSDD = "";
            Hashtable dsThuaDel = new Hashtable();

            foreach (var it in HoSoTiepNhan.BienDong.DSGcn)
            {
                if (it.LAGCNVAO.Equals("Y"))
                {
                    delGCN += "'" + it.GIAYCHUNGNHANID + "',";
                    foreach (var q in it.GiayChungNhan.DSQuyenSDDat)
                    {
                        if (!dsThuaDel.Contains(q.THUADATID))
                        {
                            dsThuaDel.Add(q.THUADATID, q.THUADATID);
                            delThua += "'" + q.THUADATID + "',";
                        }
                        delQuyenSDD += "'" + q.QUYENSUDUNGDATID + "',";
                        delMDSDD += "'" + q.MUCDICHSUDUNGDATID + "',";
                    }

                    foreach (var q in it.GiayChungNhan.DSQuyenSHTS)
                    {
                        delQuyenSHTS += "'" + q.QUYENSOHUUTAISANID + "',";
                        delTaiSan += "'" + q.TAISANGANLIENVOIDATID + "',";
                        switch (q.TaiSanGanLienVoiDat.LOAITAISAN)
                        {
                            case "1"://DC_NHARIENGLE
                                queries.Add("delete from DC_NHARIENGLE where NHARIENGLEID = '" + q.TaiSanGanLienVoiDat.TAISANID + "';");
                                break;
                            case "2"://DC_NHACHUNGCU
                            case "3":
                                queries.Add("delete from DC_NHACHUNGCU where NHACHUNGCUID = '" + q.TaiSanGanLienVoiDat.TAISANID + "';");
                                break;
                            case "4"://DC_CANHO
                                queries.Add("delete from DC_CANHO where CANHOID = '" + q.TaiSanGanLienVoiDat.TAISANID + "';");
                                break;
                            case "5"://DC_HANGMUCNGOAICANHO
                                queries.Add("delete from DC_HANGMUCNGOAICANHO where HANGMUCSOHUUCHUNGID = '" + q.TaiSanGanLienVoiDat.TAISANID + "';");
                                break;
                            case "6"://DC_CONGTRINHXAYDUNG
                                queries.Add("delete from DC_CONGTRINHXAYDUNG where CONGTRINHXAYDUNGID = '" + q.TaiSanGanLienVoiDat.TAISANID + "';");
                                break;
                            case "7"://DC_CONGTRINHNGAM
                                queries.Add("delete from DC_CONGTRINHNGAM where CONGTRINHNGAMID = '" + q.TaiSanGanLienVoiDat.TAISANID + "';");
                                break;
                            case "8"://DC_HANGMUCCONGTRINH
                                queries.Add("delete from DC_HANGMUCCONGTRINH where HANGMUCCONGTRINHID = '" + q.TaiSanGanLienVoiDat.TAISANID + "';");
                                break;
                            case "9"://DC_RUNGTRONG
                                queries.Add("delete from DC_RUNGTRONG where RUNGTRONGID = '" + q.TaiSanGanLienVoiDat.TAISANID + "';");
                                break;
                            case "10"://DC_CAYLAUNAM
                                queries.Add("delete from DC_CAYLAUNAM where CAYLAUNAMID = '" + q.TaiSanGanLienVoiDat.TAISANID + "';");
                                break;
                            default:
                                break;
                        }
                    }
                }
            }

            if (delThua.Length > 0) delThua = delThua.Substring(0, delThua.Length - 1);

            //Tạo chuỗi query và đưa vào danh sách thực thi
            //Xóa trong các bảng DC_NGUONGOCSUDUNG, DC_MUCDICHSUDUNGDAT, DC_THUATAISAN, DC_THUADAT, DC_MUCDICHSUDUNGDAT, 
            //DC_TAISANGANLIENVOIDAT, DC_QUYENSUDUNGDAT, DC_QUYENSOHUUTAISAN
            if (delQuyenSDD.Length > 0)
            {
                delQuyenSDD = delQuyenSDD.Substring(0, delQuyenSDD.Length - 1);
                queries.Add("delete from DC_QUYENSUDUNGDAT where QUYENSUDUNGDATID in (" + delQuyenSDD + ");");
            }

            if (delQuyenSHTS.Length > 0)
            {
                delQuyenSHTS = delQuyenSHTS.Substring(0, delQuyenSHTS.Length - 1);
                queries.Add("delete from DC_QUYENSOHUUTAISAN where QUYENSOHUUTAISANID in (" + delQuyenSHTS + ");");
            }

            if (delTaiSan.Length > 0)
            {
                delTaiSan = delTaiSan.Substring(0, delTaiSan.Length - 1);
                queries.Add("delete from DC_THUATAISAN where TAISANGANLIENVOIDATID in (" + delTaiSan + ");");
                queries.Add("delete from DC_TAISANGANLIENVOIDAT where TAISANGANLIENVOIDATID in (" + delTaiSan + ");");
            }

            if (delMDSDD.Length > 0)
            {
                delMDSDD = delMDSDD.Substring(0, delMDSDD.Length - 1);
                queries.Add("delete from DC_NGUONGOCSUDUNG where MUCDICHSUDUNGDATID in (" + delMDSDD + ");");
                if (delThua.Length > 0)
                {
                    queries.Add("delete from DC_BD_THUA_THUA where THUACHAID in (" + delThua + ");");
                    queries.Add("delete from DC_BD_THUA_THUA where THUADATID in (" + delThua + ");");
                    queries.Add("delete from DC_MUCDICHSUDUNGDAT where MUCDICHSUDUNGDATID in (" + delMDSDD + ");");
                    queries.Add("delete from DC_MUCDICHSUDUNGDAT where THUADATID in (" + delThua + ");");
                    queries.Add("delete from DC_THUADAT where THUADATID in (" + delThua + ");");
                }
                else
                {
                    queries.Add("delete from DC_MUCDICHSUDUNGDAT where MUCDICHSUDUNGDATID in (" + delMDSDD + ");");
                }
            }

            //Xóa trong các bảng DC_BD_GCN_GCN, DC_BD_GCN, DC_GIAYCHUNGNHAN
            queries.Add("delete from DC_BD_GCN where BIENDONGID = '" + HoSoTiepNhan.BienDong.BIENDONGID + "';");
            if (delGCN.Length > 0)
            {
                delGCN = delGCN.Substring(0, delGCN.Length - 1);
                queries.Add("delete from DC_BD_GCN_GCN where GCNCHAID in (" + delGCN + ");");
                queries.Add("delete from DC_BD_GCN_GCN where GIAYCHUNGNHANID in (" + delGCN + ");");
                queries.Add("delete from DC_GIAYCHUNGNHAN where GIAYCHUNGNHANID in (" + delGCN + ");");
            }
        }

        private static void XoaDuLieuKhacTrongBienDong(QT_HOSOTIEPNHAN HoSoTiepNhan, ref List<string> queries)
        {
            //Thửa xử lý
            string delThua = "";
            if (HoSoTiepNhan.BienDong.COTHUAXULY != null && HoSoTiepNhan.BienDong.COTHUAXULY.Equals("Y"))
                foreach (var it in HoSoTiepNhan.BienDong.DSThua)
                {
                    if (it.LOAITHUABD != null && it.LOAITHUABD.Equals("X"))
                    {
                        delThua += "'" + it.THUADATID + "',";
                    }
                }

            queries.Add("delete from DC_BD_THUA where BIENDONGID = '" + HoSoTiepNhan.BienDong.BIENDONGID + "';");
            if (delThua.Length > 0)
            {
                delThua = delThua.Substring(0, delThua.Length - 1);
                queries.Add("delete from DC_BD_THUA_THUA where THUACHAID in (" + delThua + ");");
                queries.Add("delete from DC_BD_THUA_THUA where THUADATID in (" + delThua + ");");
                queries.Add("delete from DC_THUADAT where THUADATID in (" + delThua + ");");
            }

            //Chủ trong biến động
            queries.Add("delete from DC_BD_CHU where BIENDONGID = '" + HoSoTiepNhan.BienDong.BIENDONGID + "';");

            //Quyết định trong biến động
            if (HoSoTiepNhan.BienDong.QUYETDINHID != null && HoSoTiepNhan.BienDong.QUYETDINHID.Length > 0)
                queries.Add("delete from DC_QUYETDINH where QUYETDINHID = '" + HoSoTiepNhan.BienDong.QUYETDINHID + "';");
        }
        #endregion

        private static void XoaDuLieuDangKy(QT_HOSOTIEPNHAN HoSoTiepNhan, ref List<string> queries)
        {
            queries.Add("delete from DC_DANGKY_GCN where DONDANGKYID = '" + HoSoTiepNhan.DonDangKy.DONDANGKYID + "';");
            queries.Add("delete from DC_DANGKY_TAISAN where DONDANGKYID = '" + HoSoTiepNhan.DonDangKy.DONDANGKYID + "';");
            queries.Add("delete from DC_DANGKY_NGUOI where DONDANGKYID = '" + HoSoTiepNhan.DonDangKy.DONDANGKYID + "';");
            queries.Add("delete from DC_DANGKY_THUA where DONDANGKYID = '" + HoSoTiepNhan.DonDangKy.DONDANGKYID + "';");
            string delXNDDK = "";
            if (HoSoTiepNhan.DonDangKy.DSXacNhan != null)
                foreach (var it in HoSoTiepNhan.DonDangKy.DSXacNhan)
                {
                    delXNDDK += "'" + it.XACNHANDONDANGKYID + "',";
                }

            if (delXNDDK.Length > 0)
            {
                delXNDDK = delXNDDK.Substring(0, delXNDDK.Length - 1);
                queries.Add("delete from DC_YKIENXACNHAN where XACNHANDONDANGKYID in (" + delXNDDK + ");");
                queries.Add("delete from DC_XACNHANDONDANGKY where DONDANGKYID = '" + HoSoTiepNhan.DonDangKy.DONDANGKYID + "';");
            }

            queries.Add("delete from DC_DONDANGKY where HOSOTIEPNHANID = '" + HoSoTiepNhan.HOSOTIEPNHANID + "';");
        }

        private static void XoaDuLieuHoSo(QT_HOSOTIEPNHAN HoSoTiepNhan, ref List<string> queries)
        {
            queries.Add("delete from QT_FILEDINHKEMHOSO where HOSOTIEPNHANID = '" + HoSoTiepNhan.HOSOTIEPNHANID + "';");
            queries.Add("delete from QT_HOSOTIEPNHAN where HOSOTIEPNHANID = '" + HoSoTiepNhan.HOSOTIEPNHANID + "';");
        }

        #endregion

        #region "Lưu thông tin phục vụ tra cứu trên dữ liệu lịch sử sau này"
        private static void LuuThongTinTraCuu(HoSoTiepNhanLS HoSoLS)
        {
            using (MplisEntities db = new MplisEntities())
            {
                db.Configuration.ProxyCreationEnabled = false;
                db.Configuration.LazyLoadingEnabled = false;
                //Lưu thông tin bộ hồ sơ
                LS_BOHOSO bhs = new LS_BOHOSO();
                bhs.BOHOSOID = Guid.NewGuid().ToString();
                bhs.BIENDONGID = HoSoLS.BienDong.BIENDONGID;
                bhs.MAKVHC = HoSoLS.MaKVHC;
                bhs.NGAYPD = DateTime.Now;
                bhs.DATA = JsonConvert.SerializeObject(HoSoLS);
                db.LS_BOHOSO.Add(bhs);
                db.SaveChanges();

                //Lưu thông tin tra cứu GCN
                GiayChungNhanLS gcn;
                foreach (var cn in HoSoLS.BienDong.DSGcn)
                {
                    if (!cn.LAGCNVAO.Equals("Y"))
                    {
                        gcn = (GiayChungNhanLS)HoSoLS.DSGiayChungNhan[cn.GIAYCHUNGNHANID];
                        LS_TC_GCN tcgcn = new LS_TC_GCN();
                        tcgcn.TCGCNID = Guid.NewGuid().ToString();
                        tcgcn.BOHOSOID = bhs.BOHOSOID;
                        tcgcn.GCNID = gcn.GIAYCHUNGNHANID;
                        tcgcn.MAKVHC = HoSoLS.MaKVHC;
                        tcgcn.MAVACH = gcn.MAVACH;
                        tcgcn.SOVAOSO = gcn.SOVAOSO;
                        tcgcn.SOPHATHANH = gcn.SOPHATHANH;
                        db.LS_TC_GCN.Add(tcgcn);
                    }
                }
                db.SaveChanges();

                //Lưu thông tin tra cứu hồ sơ
                LS_TC_HOSO hs = new LS_TC_HOSO();
                hs.TCHOSOID = Guid.NewGuid().ToString();
                hs.BOHOSOID = bhs.BOHOSOID;
                hs.HOSOID = HoSoLS.HOSOTIEPNHANID;
                hs.MAKVHC = HoSoLS.MaKVHC;
                hs.NGAYNHANHOSO = HoSoLS.NGAYTIEPNHANHOSO;
                hs.NGAYTRAKETQUA = HoSoLS.NGAYTRAKETQUA;
                hs.DIACHI = HoSoLS.DIACHINGUOINOPHS;
                hs.NGUOINOPHOSO = HoSoLS.NGUOINOPHOSO;
                hs.SOBIENNHAN = HoSoLS.SOBIENNHAN;
                db.LS_TC_HOSO.Add(hs);
                db.SaveChanges();

                //Lưu thông tin tra cứu theo chủ
                //Chủ tổ chức, cộng đồng
                NguoiLS nls;
                LS_TC_CHU tcChu;
                foreach (DictionaryEntry chu in HoSoLS.DSChu)
                {
                    nls = (NguoiLS)chu.Value;
                    switch (nls.LOAIDOITUONGID)
                    {
                        case "4"://DC_CONGDONG
                            if (nls.CongDong != null)
                            {
                                tcChu = new LS_TC_CHU();
                                tcChu.TCCHUID = Guid.NewGuid().ToString();
                                tcChu.BOHOSOID = bhs.BOHOSOID;
                                tcChu.CHUID = nls.NGUOIID;
                                tcChu.MAKVHC = HoSoLS.MaKVHC;
                                tcChu.TENCHU = nls.CongDong.TENCONGDONG;
                                tcChu.DIACHI = nls.CongDong.DIACHI;
                                db.LS_TC_CHU.Add(tcChu);
                            }
                            break;
                        case "5"://DC_TOCHUC
                            if (nls.ToChuc != null)
                            {
                                tcChu = new LS_TC_CHU();
                                tcChu.TCCHUID = Guid.NewGuid().ToString();
                                tcChu.BOHOSOID = bhs.BOHOSOID;
                                tcChu.CHUID = nls.NGUOIID;
                                tcChu.MAKVHC = HoSoLS.MaKVHC;
                                tcChu.TENCHU = nls.ToChuc.TENTOCHUC;
                                tcChu.DIACHI = nls.ToChuc.DIACHI;
                                tcChu.SOGIAYTOXM = nls.ToChuc.MADOANHNGHIEP;
                                db.LS_TC_CHU.Add(tcChu);
                            }
                            break;
                        default:
                            tcChu = new LS_TC_CHU();
                            tcChu.TCCHUID = Guid.NewGuid().ToString();
                            tcChu.BOHOSOID = bhs.BOHOSOID;
                            tcChu.CHUID = nls.NGUOIID;
                            tcChu.MAKVHC = HoSoLS.MaKVHC;
                            db.LS_TC_CHU.Add(tcChu);
                            break;
                    }
                    db.SaveChanges();
                }

                //Chủ cá nhân
                CaNhanLS cnLS;
                foreach (DictionaryEntry cn in HoSoLS.DSCaNhan)
                {
                    cnLS = (CaNhanLS)cn.Value;
                    tcChu = new LS_TC_CHU();
                    tcChu.TCCHUID = Guid.NewGuid().ToString();
                    tcChu.BOHOSOID = bhs.BOHOSOID;
                    tcChu.MAKVHC = HoSoLS.MaKVHC;
                    tcChu.TENCHU = cnLS.HOTEN;
                    tcChu.DIACHI = cnLS.DIACHI;
                    tcChu.SOGIAYTOXM = cnLS.SOGIAYTO;
                    db.LS_TC_CHU.Add(tcChu);
                }
                db.SaveChanges();

                //Lưu thông tin tra cứu theo thửa
                LS_TC_THUA tcThua;
                ThuaDatLS tLS;
                foreach (var thua in HoSoLS.BienDong.DSThua)
                {
                    if (thua.LOAITHUABD.Equals("R"))
                    {
                        tLS = (ThuaDatLS)HoSoLS.DSThua[thua.THUADATID];
                        tcThua = new LS_TC_THUA();
                        tcThua.TCTHUAID = Guid.NewGuid().ToString();
                        tcThua.BOHOSOID = bhs.BOHOSOID;
                        tcThua.THUAID = tLS.THUADATID;
                        tcThua.XAID = HoSoLS.DONVIHANHCHINHID;
                        tcThua.MAKVHC = bhs.MAKVHC;
                        tcThua.SHTOBD = tLS.SOHIEUTOBANDO == null ? "" : tLS.SOHIEUTOBANDO.ToString();
                        tcThua.STTTHUA = tLS.SOTHUTUTHUA == null ? "" : tLS.SOTHUTUTHUA.ToString();
                        db.LS_TC_THUA.Add(tcThua);
                        db.SaveChanges();
                    }
                }
            }
        }
        #endregion

        #region "Lưu dữ liệu cây lịch sử"
        private static void LuuCayLichSu(HoSoTiepNhanLS HoSoLS)
        {
            LuuLSGiayChungNhan(HoSoLS);

            LuuLSThuaDat(HoSoLS);
        }
        #endregion

        #region "Lưu lịch sử giấy chứng nhận"
        private static void LuuLSGiayChungNhan(HoSoTiepNhanLS HoSoLS)
        {
            GiayChungNhanLS gcn;
            string sql = "", param = "";
            Hashtable oldData = new Hashtable();
            List<string> oldGCNIDs = new List<string>();
            List<LS_BD_GCN> lsOldData;
            bool DaLuu = false;
            LS_BD_GCN lsGCN;

            using (MplisEntities db = new MplisEntities())
            {
                db.Configuration.ProxyCreationEnabled = false;
                db.Configuration.LazyLoadingEnabled = false;
                //Lấy các cây lịch sử cũ, chuẩn bị cho cây lịch sử mới
                foreach (var gcnQH in HoSoLS.BienDong.DSGcn)
                {
                    if (gcnQH.LAGCNVAO.Equals("Y"))
                    {
                        var _NhanhGCN = (from ls in db.LS_BD_GCN
                                         where ls.GCNHIENTAIID == gcnQH.GIAYCHUNGNHANID
                                         orderby ls.NGAYPD
                                         select ls).ToList();
                        if (_NhanhGCN != null && _NhanhGCN.Count > 0)
                        {
                            oldData.Add(gcnQH.GIAYCHUNGNHANID, _NhanhGCN);
                            oldGCNIDs.Add(gcnQH.GIAYCHUNGNHANID);
                        }
                        else
                        {
                            lsOldData = new List<LS_BD_GCN>();
                            lsGCN = new LS_BD_GCN();
                            lsGCN.LSBDGCNID = Guid.NewGuid().ToString();
                            lsGCN.GCNHIENTAIID = gcnQH.GIAYCHUNGNHANID;
                            lsGCN.GCNID = gcnQH.GIAYCHUNGNHANID;
                            lsGCN.NGAYPD = DateTime.Now;
                            lsGCN.BIENDONGID = HoSoLS.BienDong.BIENDONGID;
                            lsGCN.MAKVHC = HoSoLS.MaKVHC;
                            lsOldData.Add(lsGCN);
                            oldData.Add(lsGCN.GCNID, lsOldData);
                        }
                    }
                }

                //Xóa các dữ liệu cũ
                foreach (var gcnID in oldGCNIDs)
                {
                    param += "'" + gcnID + "',";
                }

                if (param.Length > 0)
                {
                    param = "(" + param.Substring(0, param.Length - 1) + ")";
                    sql = "delete from LS_BD_GCN where GCNHienTaiID in {0}";
                    db.Database.ExecuteSqlCommand(sql, param);
                }

                //chèn vào các dữ liệu mới
                foreach (var gcnQH in HoSoLS.BienDong.DSGcn)
                {
                    if (!gcnQH.LAGCNVAO.Equals("Y"))
                    {
                        gcn = (GiayChungNhanLS)HoSoLS.DSGiayChungNhan[gcnQH.GIAYCHUNGNHANID];
                        DaLuu = false;
                        foreach (var it in gcn.QHGcn_Gcn)
                        {
                            if (oldData.Contains(it.GCNCHAID))
                            {
                                //clone từ cây cũ
                                lsOldData = (List<LS_BD_GCN>)oldData[it.GCNCHAID];
                                foreach (var dt in lsOldData)
                                {
                                    lsGCN = Mapper.Map<LS_BD_GCN>(dt);
                                    lsGCN.LSBDGCNID = Guid.NewGuid().ToString();
                                    lsGCN.GCNHIENTAIID = gcn.GIAYCHUNGNHANID;
                                    db.LS_BD_GCN.Add(lsGCN);
                                }
                            }
                            //chèn bản ghi mới móc vào đầu chuỗi
                            lsGCN = new LS_BD_GCN();
                            lsGCN.LSBDGCNID = Guid.NewGuid().ToString();
                            lsGCN.GCNHIENTAIID = gcn.GIAYCHUNGNHANID;
                            lsGCN.GCNID = gcn.GIAYCHUNGNHANID;
                            lsGCN.GCNCHAID = it.GCNCHAID;
                            lsGCN.NGAYPD = DateTime.Now;
                            lsGCN.BIENDONGID = HoSoLS.BienDong.BIENDONGID;
                            lsGCN.MAKVHC = HoSoLS.MaKVHC;
                            db.LS_BD_GCN.Add(lsGCN);
                            DaLuu = true;
                        }

                        //Xử lý với trường hợp là bản ghi đầu tiên của chuỗi
                        if (!DaLuu)
                        {
                            lsGCN = new LS_BD_GCN();
                            lsGCN.LSBDGCNID = Guid.NewGuid().ToString();
                            lsGCN.GCNHIENTAIID = gcn.GIAYCHUNGNHANID;
                            lsGCN.GCNID = gcn.GIAYCHUNGNHANID;
                            lsGCN.NGAYPD = DateTime.Now;
                            lsGCN.BIENDONGID = HoSoLS.BienDong.BIENDONGID;
                            lsGCN.MAKVHC = HoSoLS.MaKVHC;
                            db.LS_BD_GCN.Add(lsGCN);
                        }
                    }
                }

                db.SaveChanges();
            }
        }
        #endregion

        #region "Lưu lịch sử thửa đất"
        private static void LuuLSThuaDat(HoSoTiepNhanLS HoSoLS)
        {
            ThuaDatLS td;
            string sql = "", param = "";
            Hashtable oldData = new Hashtable();
            List<string> oldThuaIDs = new List<string>();
            List<LS_BD_THUA> lsOldData, lsNewData;
            bool DaLuu = false;
            LS_BD_THUA lsThua;

            using (MplisEntities db = new MplisEntities())
            {
                db.Configuration.ProxyCreationEnabled = false;
                db.Configuration.LazyLoadingEnabled = false;
                //Lấy các cây lịch sử cũ, chuẩn bị cho cây lịch sử mới
                foreach (var thuaQH in HoSoLS.BienDong.DSThua)
                {
                    if (thuaQH.LOAITHUABD.Equals("V")) //thửa nằm trong danh sách thửa vào
                    {
                        var _NhanhThua = (from ls in db.LS_BD_THUA
                                          where ls.THUAHIENTAIID == thuaQH.THUADATID
                                          orderby ls.NGAYPD
                                          select ls).ToList();
                        if (_NhanhThua != null && _NhanhThua.Count > 0)
                        {
                            oldData.Add(thuaQH.THUADATID, _NhanhThua);
                            oldThuaIDs.Add(thuaQH.THUADATID);
                        }
                        else
                        {
                            lsOldData = new List<LS_BD_THUA>();
                            lsThua = new LS_BD_THUA();
                            lsThua.LICHSUTHUAID = Guid.NewGuid().ToString();
                            lsThua.THUAHIENTAIID = thuaQH.THUADATID;
                            lsThua.THUAID = thuaQH.THUADATID;
                            lsThua.NGAYPD = DateTime.Now;
                            lsThua.BIENDONGID = HoSoLS.BienDong.BIENDONGID;
                            lsThua.MAKVHC = HoSoLS.MaKVHC;
                            lsOldData.Add(lsThua);
                            oldData.Add(lsThua.THUAID, lsOldData);
                        }

                    }
                }

                //Xóa các dữ liệu cũ
                foreach (var thuaID in oldThuaIDs)
                {
                    param += "'" + thuaID + "',";
                }

                if (param.Length > 0)
                {
                    param = "(" + param.Substring(0, param.Length - 1) + ")";
                    sql = "delete from LS_BD_THUA where THUAHIENTAIID in {0}";
                    db.Database.ExecuteSqlCommand(sql, param);
                }

                //chèn vào các dữ liệu mới
                if (HoSoLS.BienDong.COTHUAXULY != null && HoSoLS.BienDong.COTHUAXULY.Equals("Y"))
                {
                    foreach (var thuaQH in HoSoLS.BienDong.DSThua.Where(t => t.LOAITHUABD.Equals("X")))
                    {
                        td = (ThuaDatLS)HoSoLS.DSThua[thuaQH.THUADATID];
                        foreach (var it in td.QHThua)
                        {
                            if (oldData.Contains(it.THUACHAID))
                            {
                                //clone từ cây cũ
                                lsNewData = new List<LS_BD_THUA>();
                                lsOldData = (List<LS_BD_THUA>)oldData[it.THUACHAID];
                                foreach (var dt in lsOldData)
                                {
                                    lsThua = Mapper.Map<LS_BD_THUA>(dt);
                                    lsThua.LICHSUTHUAID = Guid.NewGuid().ToString();
                                    lsThua.THUAHIENTAIID = td.THUADATID;
                                    lsNewData.Add(lsThua);
                                }
                                oldData.Add(td.THUADATID, lsNewData);
                            }
                            //chèn bản ghi mới móc vào đầu chuỗi
                            lsThua = new LS_BD_THUA();
                            lsThua.LICHSUTHUAID = Guid.NewGuid().ToString();
                            lsThua.THUAHIENTAIID = td.THUADATID;
                            lsThua.THUAID = td.THUADATID;
                            lsThua.THUACHAID = it.THUACHAID;
                            lsThua.NGAYPD = DateTime.Now.AddMinutes(-15); //giảm đi 15 phút để order theo thời gian tự thành một chuỗi
                            lsThua.BIENDONGID = HoSoLS.BienDong.BIENDONGID;
                            lsThua.MAKVHC = HoSoLS.MaKVHC;
                        }
                    }
                }

                //xử lý với thửa hiện tại
                foreach (var thuaQH in HoSoLS.BienDong.DSThua.Where(t => t.LOAITHUABD.Equals("R")))
                {
                    td = (ThuaDatLS)HoSoLS.DSThua[thuaQH.THUADATID];
                    DaLuu = false;
                    foreach (var it in td.QHThua)
                    {
                        if (oldData.Contains(it.THUACHAID))
                        {
                            //clone từ cây cũ
                            lsOldData = (List<LS_BD_THUA>)oldData[it.THUACHAID];
                            foreach (var dt in lsOldData)
                            {
                                lsThua = Mapper.Map<LS_BD_THUA>(dt);
                                lsThua.LICHSUTHUAID = Guid.NewGuid().ToString();
                                lsThua.THUAHIENTAIID = td.THUADATID;
                                db.LS_BD_THUA.Add(lsThua);
                            }
                        }
                        //chèn bản ghi mới móc vào đầu chuỗi
                        lsThua = new LS_BD_THUA();
                        lsThua.LICHSUTHUAID = Guid.NewGuid().ToString();
                        lsThua.THUAHIENTAIID = td.THUADATID;
                        lsThua.THUAID = td.THUADATID;
                        lsThua.THUACHAID = it.THUACHAID;
                        lsThua.NGAYPD = DateTime.Now;
                        lsThua.BIENDONGID = HoSoLS.BienDong.BIENDONGID;
                        lsThua.MAKVHC = HoSoLS.MaKVHC;
                        db.LS_BD_THUA.Add(lsThua);
                        DaLuu = true;
                    }
                    //Xử lý với trường hợp là bản ghi đầu tiên của chuỗi
                    if (!DaLuu)
                    {
                        lsThua = new LS_BD_THUA();
                        lsThua.LICHSUTHUAID = Guid.NewGuid().ToString();
                        lsThua.THUAHIENTAIID = td.THUADATID;
                        lsThua.THUAID = td.THUADATID;
                        lsThua.NGAYPD = DateTime.Now;
                        lsThua.BIENDONGID = HoSoLS.BienDong.BIENDONGID;
                        lsThua.MAKVHC = HoSoLS.MaKVHC;
                        db.LS_BD_THUA.Add(lsThua);
                    }
                }
                db.SaveChanges();
            }
        }
        #endregion

        #region "Cập nhật dữ liệu các đối tượng ngoài bộ hồ sơ nhưng có liên quan tới các thửa đầu vào trong bộ hồ sơ"
        //Chỉ xử lý với thửa đầu vào
        private static void CapNhatDuLieuLienQuanThuaDat(HoSoTiepNhanLS HoSoLS)
        {
            Hashtable thuaIDS = new Hashtable();
            List<string> tIDs = new List<string>();

            //lấy danh sách thửa vào
            foreach (var it in HoSoLS.BienDong.DSThua.Where(ir => ir.LOAITHUABD.Equals("V")))
            {
                if (!thuaIDS.Contains(it.THUADATID))
                {
                    thuaIDS.Add(it.THUADATID, it.THUADATID);
                    tIDs.Add(it.THUADATID);
                }
            }

            if (thuaIDS.Count > 0)
            {
                #region "Xử lý với quyền sử dụng đất"
                //lấy danh sách các MDSD liên quan mà không có trong bộ hồ sơ xử lý - Chỉ lấy của thửa vào
                QuyenSuDungDatLS qsdd;
                string qsddIDs = "";
                foreach (DictionaryEntry it in HoSoLS.DSQuyenSuDungDat)
                {
                    qsdd = (QuyenSuDungDatLS)it.Value;
                    if (thuaIDS.Contains(qsdd.THUADATID))
                        qsddIDs += qsdd.QUYENSUDUNGDATID + ",";
                }

                string[] IDs;
                List<DC_QUYENSUDUNGDAT> dsQSDD;
                DC_QUYENSUDUNGDAT data;
                ThuaDatLS thuaRa, thuaGocLS;
                bool daGan, daganMDSDD;

                using (MplisEntities db = new MplisEntities())
                {
                    //Xử lý với MDSD đất
                    dsQSDD = new List<DC_QUYENSUDUNGDAT>();
                    if (qsddIDs.Length > 0)
                    {
                        qsddIDs = qsddIDs.Substring(0, qsddIDs.Length - 1);
                        IDs = qsddIDs.Split(',');
                        var data1 = (from it in db.DC_QUYENSUDUNGDAT.Where(ab => tIDs.Contains(ab.THUADATID))
                                     where !IDs.Contains(it.QUYENSUDUNGDATID)
                                     select new
                                     {
                                         it,
                                         mdsd = db.DC_MUCDICHSUDUNGDAT.Where(i => i.MUCDICHSUDUNGDATID.Equals(it.MUCDICHSUDUNGDATID)).FirstOrDefault()
                                     }).ToList();
                        foreach (var dt in data1)
                        {
                            data = dt.it;
                            data.MdsdDat = dt.mdsd;
                            dsQSDD.Add(data);
                        }
                    }
                    else
                    {
                        var data2 = (from it in db.DC_QUYENSUDUNGDAT.Where(ab => tIDs.Contains(ab.THUADATID))
                                     select new
                                     {
                                         it,
                                         mdsd = db.DC_MUCDICHSUDUNGDAT.Where(i => i.MUCDICHSUDUNGDATID.Equals(it.MUCDICHSUDUNGDATID)).FirstOrDefault()
                                     }).ToList();
                        foreach (var dt in data2)
                        {
                            data = dt.it;
                            data.MdsdDat = dt.mdsd;
                            dsQSDD.Add(data);
                        }
                    }

                    if (dsQSDD != null && dsQSDD.Count > 0)
                    {
                        foreach (var q in dsQSDD)
                        {
                            thuaGocLS = (ThuaDatLS)HoSoLS.DSThua[q.THUADATID];
                            daGan = false;
                            //Tìm thửa ra đối ứng
                            foreach (var it in HoSoLS.BienDong.DSThua)
                            {
                                thuaRa = (ThuaDatLS)HoSoLS.DSThua[it.THUADATID];
                                if (it.LOAITHUABD.Equals("R"))  //thửa ra
                                {
                                    if (q.THUADATID.Equals(thuaRa.THUAGOCID)) //Tìm thửa đối ứng theo thửa gốc id
                                    {
                                        q.THUADATID = thuaRa.THUADATID;
                                        daganMDSDD = false;
                                        //tìm mdsd đối ứng trong mỗi thửa ra
                                        foreach (var md in thuaRa.DSMucDichSuDungDat)
                                        {
                                            if (md.MDSDGOCID != null && md.MDSDGOCID.Equals(q.MdsdDat.MUCDICHSUDUNGDATID))
                                            {
                                                q.MUCDICHSUDUNGDATID = md.MUCDICHSUDUNGDATID;
                                                daganMDSDD = true;
                                                break;
                                            }
                                        }
                                        if (!daganMDSDD) //nếu không tìm đc MDSD đối ứng trên thửa mới thì chỉ gán lại thửa đất id cho MDSD
                                        {
                                            q.MdsdDat.THUADATID = thuaRa.THUADATID;
                                        }
                                        daGan = true;
                                        break;
                                    }
                                    else //tìm thửa đối ứng theo tra điều kiện map theo bộ ba mã xã, số tờ bản đồ, số thứ tự thửa
                                    {
                                        if (thuaRa.XAID.Equals(thuaGocLS.XAID)
                                            && thuaRa.SOHIEUTOBANDO.Equals(thuaGocLS.SOHIEUTOBANDO)
                                            && thuaRa.SOTHUTUTHUA.Equals(thuaGocLS.SOTHUTUTHUA))
                                        {
                                            q.THUADATID = thuaRa.THUADATID;
                                            q.MdsdDat.THUADATID = thuaRa.THUADATID;
                                            daGan = true;
                                            break;
                                        }
                                    }
                                }
                            }
                            if (!daGan) //xử lý cho trường hợp không tìm được 
                            {
                                //Tìm thửa cha của thửa đầu vào để gán
                                foreach (var it in HoSoLS.BienDong.DSThua)
                                {
                                    if (it.LOAITHUABD.Equals("R"))  //thửa ra
                                    {
                                        thuaRa = (ThuaDatLS)HoSoLS.DSThua[it.THUADATID];
                                        foreach (var qh in thuaRa.QHThua)
                                        {
                                            if (qh.THUACHAID.Equals(q.THUADATID))
                                            {
                                                q.THUADATID = thuaRa.THUADATID;
                                                q.MdsdDat.THUADATID = thuaRa.THUADATID;
                                                daGan = true;
                                                break;
                                            }
                                        }
                                    }
                                }
                                if (!daGan)
                                {
                                    //Lấy một thửa đầu ra bất kỳ để gán
                                    foreach (var it in HoSoLS.BienDong.DSThua)
                                    {
                                        if (it.LOAITHUABD.Equals("R"))  //thửa ra
                                        {
                                            thuaRa = (ThuaDatLS)HoSoLS.DSThua[it.THUADATID];
                                            q.THUADATID = thuaRa.THUADATID;
                                            q.MdsdDat.THUADATID = thuaRa.THUADATID;
                                            daGan = true;
                                            break;
                                        }
                                    }
                                }
                            }
                        }
                        db.SaveChanges();
                    }
                }
                #endregion

                #region "Cập nhật quan hệ giữa thửa đất đầu ra với tài sản"
                QuyenSoHuuTaiSanLS qshts;
                List<DC_THUATAISAN> dsThuaTS;
                string tsIDs = "";

                foreach (DictionaryEntry it in HoSoLS.DSQuyenSoHuuTaiSan)
                {
                    qshts = (QuyenSoHuuTaiSanLS)it.Value;
                    tsIDs += qshts.TAISANGANLIENVOIDATID + ",";
                }

                using (MplisEntities db = new MplisEntities())
                {
                    if (tsIDs.Length > 0)
                    {
                        tsIDs = tsIDs.Substring(0, tsIDs.Length - 1);
                        IDs = tsIDs.Split(',');
                        dsThuaTS = (from it in db.DC_THUATAISAN.Where(ab => tIDs.Contains(ab.THUADATID))
                                    where !IDs.Contains(it.TAISANGANLIENVOIDATID)
                                    select it).ToList();
                    }
                    else
                    {
                        dsThuaTS = (from it in db.DC_THUATAISAN.Where(ab => tIDs.Contains(ab.THUADATID))
                                    select it).ToList();
                    }

                    foreach (var q in dsThuaTS)
                    {
                        thuaGocLS = (ThuaDatLS)HoSoLS.DSThua[q.THUADATID];
                        daGan = false;
                        foreach (var it in HoSoLS.BienDong.DSThua)
                        {
                            if (it.LOAITHUABD.Equals("R"))  //thửa ra
                            {
                                thuaRa = (ThuaDatLS)HoSoLS.DSThua[it.THUADATID];
                                if (q.THUADATID.Equals(thuaRa.THUAGOCID))
                                {
                                    q.THUADATID = thuaRa.THUADATID;
                                    daGan = true;
                                    break;
                                }
                                else
                                {
                                    if (thuaRa.XAID.Equals(thuaGocLS.XAID)
                                        && thuaRa.SOHIEUTOBANDO.Equals(thuaGocLS.SOHIEUTOBANDO)
                                        && thuaRa.SOTHUTUTHUA.Equals(thuaGocLS.SOTHUTUTHUA))
                                    {
                                        q.THUADATID = thuaRa.THUADATID;
                                        daGan = true;
                                        break;
                                    }
                                }
                            }
                        }
                        if (!daGan)
                        {
                            //Tìm thửa con của thửa đầu vào để gán
                            foreach (var it in HoSoLS.BienDong.DSThua)
                            {
                                if (it.LOAITHUABD.Equals("R"))  //thửa ra
                                {
                                    thuaRa = (ThuaDatLS)HoSoLS.DSThua[it.THUADATID];
                                    foreach (var qh in thuaRa.QHThua)
                                    {
                                        if (qh.THUACHAID.Equals(q.THUADATID))
                                        {
                                            q.THUADATID = thuaRa.THUADATID;
                                            daGan = true;
                                            break;
                                        }
                                    }
                                }
                            }
                            if (!daGan)
                            {
                                //Lấy một thửa đầu ra bất kỳ để gán
                                foreach (var it in HoSoLS.BienDong.DSThua)
                                {
                                    if (it.LOAITHUABD.Equals("R"))  //thửa ra
                                    {
                                        thuaRa = (ThuaDatLS)HoSoLS.DSThua[it.THUADATID];
                                        q.THUADATID = thuaRa.THUADATID;
                                        daGan = true;
                                        break;
                                    }
                                }
                            }
                        }
                    }

                    db.SaveChanges();
                }
                #endregion
            }
        }
        #endregion

        #endregion

        #region "Khôi phục bộ dữ liệu hồ sơ nghiệp vụ từ dữ liệu lịch sử đã lưu"
        public static void RestoreHashData(HoSoTiepNhanLS HoSoLS)
        {
            Hashtable Datas = new Hashtable();
            CaNhanLS cnLS;
            foreach (DictionaryEntry it in HoSoLS.DSCaNhan)
            {
                cnLS = JsonConvert.DeserializeObject<CaNhanLS>(it.Value.ToString());
                Datas.Add(it.Key, cnLS);
            }
            HoSoLS.DSCaNhan = Datas;

            NguoiLS nLS;
            Datas = new Hashtable();
            foreach (DictionaryEntry it in HoSoLS.DSChu)
            {
                nLS = JsonConvert.DeserializeObject<NguoiLS>(it.Value.ToString());
                Datas.Add(it.Key, nLS);
            }
            HoSoLS.DSChu = Datas;

            GiayChungNhanLS gcnLS;
            Datas = new Hashtable();
            foreach (DictionaryEntry it in HoSoLS.DSGiayChungNhan)
            {
                gcnLS = JsonConvert.DeserializeObject<GiayChungNhanLS>(it.Value.ToString());
                Datas.Add(it.Key, gcnLS);
            }
            HoSoLS.DSGiayChungNhan = Datas;

            MucDichSuDungDatLS mdsddLS;
            Datas = new Hashtable();
            foreach (DictionaryEntry it in HoSoLS.DSMDSDDat)
            {
                mdsddLS = JsonConvert.DeserializeObject<MucDichSuDungDatLS>(it.Value.ToString());
                Datas.Add(it.Key, mdsddLS);
            }
            HoSoLS.DSMDSDDat = Datas;

            QuyenSoHuuTaiSanLS qshtsLS;
            Datas = new Hashtable();
            foreach (DictionaryEntry it in HoSoLS.DSQuyenSoHuuTaiSan)
            {
                qshtsLS = JsonConvert.DeserializeObject<QuyenSoHuuTaiSanLS>(it.Value.ToString());
                Datas.Add(it.Key, qshtsLS);
            }
            HoSoLS.DSQuyenSoHuuTaiSan = Datas;

            QuyenSuDungDatLS qsddLS;
            Datas = new Hashtable();
            foreach (DictionaryEntry it in HoSoLS.DSQuyenSuDungDat)
            {
                qsddLS = JsonConvert.DeserializeObject<QuyenSuDungDatLS>(it.Value.ToString());
                Datas.Add(it.Key, qsddLS);
            }
            HoSoLS.DSQuyenSuDungDat = Datas;

            TaiSanLS tsLS;
            Datas = new Hashtable();
            foreach (DictionaryEntry it in HoSoLS.DSTaiSan)
            {
                tsLS = JsonConvert.DeserializeObject<TaiSanLS>(it.Value.ToString());
                Datas.Add(it.Key, tsLS);
            }
            HoSoLS.DSTaiSan = Datas;

            ThuaDatLS tdLS;
            Datas = new Hashtable();
            foreach (DictionaryEntry it in HoSoLS.DSThua)
            {
                tdLS = JsonConvert.DeserializeObject<ThuaDatLS>(it.Value.ToString());
                Datas.Add(it.Key, tdLS);
            }
            HoSoLS.DSThua = Datas;
        }

        //hàm gọi khôi phục dữ liệu
        public static void RestoreBussinessData(LS_BOHOSO BoHoSo)
        {
            HoSoTiepNhanLS HoSoLS = JsonConvert.DeserializeObject<HoSoTiepNhanLS>(BoHoSo.DATA);

            RestoreHashData(HoSoLS);

            List<string> queries = new List<string>();

            UpdateCurrentStatus(HoSoLS, ref queries);

            //DeleteCurrentData(HoSoLS);

            QT_HOSOTIEPNHAN HoSo = BOHOSOServices.ConvertHoSoLSToHoSoTiepNhan(HoSoLS);

            RestoreObjects(HoSo);

            //Cập nhật dữ liệu các đối tượng ngoài bộ hồ sơ nhưng có liên quan tới các thửa đầu vào trong bộ hồ sơ
            CapNhatDuLieuLienQuanThuaDat_KPDL(HoSoLS);

            RestoreOldHistoryData(BoHoSo);
        }

        #region "Cập nhật trạng thái dữ liệu trở về trạng thái xử lý của bộ hồ sơ"
        /* Chỉ cập nhật dữ liệu đầu vào và ra của biến động
        * Dữ liệu xử lý giữ nguyên
        */
        private static void UpdateCurrentStatus(HoSoTiepNhanLS HoSoLS, ref List<string> queries)
        {
            //Cập nhật trạng thái hồ sơ
            HoSoLS.TRANGTHAI = "S";
            //Cập nhật trạng thái giấy chứng nhận
            GiayChungNhanLS gcnLS;
            QuyenSuDungDatLS qsddLS;
            QuyenSoHuuTaiSanLS qshtsLS;
            ThuaDatLS tLS;
            TaiSanLS tsLS;
            Hashtable thuaID = new Hashtable(), taiSanID = new Hashtable(), gcnIDs = new Hashtable();

            #region "Đổi trạng thái các đối tượng đầu ra của biến động trong bộ hồ sơ"
            foreach (var it in HoSoLS.BienDong.DSGcn)
            {
                //cập nhật thông tin GCN trước khi lưu
                if (it.LAGCNVAO.Equals("Y")) //GCN vào
                {
                    //khôi phục tính pháp lý
                    if (HoSoLS.DSGiayChungNhan.Contains(it.GIAYCHUNGNHANID))
                    {
                        gcnLS = (GiayChungNhanLS)HoSoLS.DSGiayChungNhan[it.GIAYCHUNGNHANID];
                        gcnLS.TRANGTHAIXULY = "Y";
                        foreach (var id in gcnLS.DSQuyenSuDungDatID)    //đổi trạng thái thửa đất
                        {
                            if (HoSoLS.DSQuyenSuDungDat.Contains(id))
                            {
                                qsddLS = (QuyenSuDungDatLS)HoSoLS.DSQuyenSuDungDat[id];
                                if (HoSoLS.DSThua.Contains(qsddLS.THUADATID))
                                {
                                    tLS = (ThuaDatLS)HoSoLS.DSThua[qsddLS.THUADATID];
                                    tLS.TRANGTHAI = "Y";
                                }
                            }
                        }

                        foreach (var id in gcnLS.DSQuyenSoHuuTaiSanID)  //Đổi trạng thái tài sản
                        {
                            if (HoSoLS.DSQuyenSoHuuTaiSan.Contains(id))
                            {
                                qshtsLS = (QuyenSoHuuTaiSanLS)HoSoLS.DSQuyenSoHuuTaiSan[id];
                                if (HoSoLS.DSTaiSan.Contains(qshtsLS.TAISANGANLIENVOIDATID))
                                {
                                    tsLS = (TaiSanLS)HoSoLS.DSTaiSan[qshtsLS.TAISANGANLIENVOIDATID];
                                    tsLS.TRANGTHAI = "Y";
                                }
                            }
                        }
                    }
                }
                else //GCN ra và các đối tượng liên quan
                {
                    //Chuyển sang trạng thái đang xử lý
                    if (HoSoLS.DSGiayChungNhan.Contains(it.GIAYCHUNGNHANID))
                    {
                        gcnLS = (GiayChungNhanLS)HoSoLS.DSGiayChungNhan[it.GIAYCHUNGNHANID];
                        gcnLS.TRANGTHAIXULY = "S";
                        if (!gcnIDs.Contains(it.GIAYCHUNGNHANID)) gcnIDs.Add(it.GIAYCHUNGNHANID, it.GIAYCHUNGNHANID);
                        foreach (var id in gcnLS.DSQuyenSuDungDatID)    //đổi trạng thái thửa đất
                        {
                            if (HoSoLS.DSQuyenSuDungDat.Contains(id))
                            {
                                qsddLS = (QuyenSuDungDatLS)HoSoLS.DSQuyenSuDungDat[id];
                                if (!thuaID.Contains(qsddLS.THUADATID))
                                {
                                    thuaID.Add(qsddLS.THUADATID, qsddLS.THUADATID);
                                    if (HoSoLS.DSThua.Contains(qsddLS.THUADATID))
                                    {
                                        tLS = (ThuaDatLS)HoSoLS.DSThua[qsddLS.THUADATID];
                                        tLS.TRANGTHAI = "S";
                                    }
                                }
                            }
                        }
                        foreach (var id in gcnLS.DSQuyenSoHuuTaiSanID)  //Đổi trạng thái tài sản
                        {
                            if (HoSoLS.DSQuyenSoHuuTaiSan.Contains(id))
                            {
                                qshtsLS = (QuyenSoHuuTaiSanLS)HoSoLS.DSQuyenSoHuuTaiSan[id];
                                if (!thuaID.Contains(qshtsLS.TAISANGANLIENVOIDATID))
                                {
                                    taiSanID.Add(qshtsLS.TAISANGANLIENVOIDATID, qshtsLS.TAISANGANLIENVOIDATID);
                                    if (HoSoLS.DSTaiSan.Contains(qshtsLS.TAISANGANLIENVOIDATID))
                                    {
                                        tsLS = (TaiSanLS)HoSoLS.DSTaiSan[qshtsLS.TAISANGANLIENVOIDATID];
                                        tsLS.TRANGTHAI = "S";
                                    }
                                }
                            }
                        }
                    }
                }
            }
            #endregion

            #region "run queries update"
            string ThuaUpdateIDs = "", TaiSanUpdateID = "", gcnUpdateID = "";
            //cập nhật trạng thái giấy chứng nhận
            foreach (DictionaryEntry item in gcnIDs)
            {
                gcnUpdateID += "'" + item.Value.ToString() + "',";
            }
            if (gcnUpdateID.Length > 0)
            {
                gcnUpdateID = gcnUpdateID.Substring(0, gcnUpdateID.Length - 1);
                queries.Add("update DC_GIAYCHUNGNHAN set TRANGTHAIXULY ='S' where GIAYCHUNGNHANID in (" + gcnUpdateID + ");");
            }

            //cập nhật trạng thái thửa đất
            foreach (DictionaryEntry item in thuaID)
            {
                ThuaUpdateIDs += "'" + item.Value.ToString() + "',";
            }
            if (ThuaUpdateIDs.Length > 0)
            {
                ThuaUpdateIDs = ThuaUpdateIDs.Substring(0, ThuaUpdateIDs.Length - 1);
                queries.Add("update DC_THUADAT set TrangThai ='S' where THUADATID in (" + ThuaUpdateIDs + ");");
            }
            //cập nhật trạng thái tài sản
            foreach (DictionaryEntry item in taiSanID)
            {
                TaiSanUpdateID += "'" + item.Value.ToString() + "',";
            }
            if (TaiSanUpdateID.Length > 0)
            {
                TaiSanUpdateID = TaiSanUpdateID.Substring(0, TaiSanUpdateID.Length - 1);
                queries.Add("update DC_TAISANGANLIENVOIDAT set TrangThai ='S' where TAISANGANLIENVOIDATID in (" + TaiSanUpdateID + ");");
            }

            //Chạy lệnh
            string sqlBatch = "";
            for (int i = 0; i < queries.Count; i++)
            {
                sqlBatch += queries[i];
            }

            if (sqlBatch.Length > 0)
                using (MplisEntities db = new MplisEntities())
                {
                    try
                    {
                        if (db.Database.Connection.State == System.Data.ConnectionState.Closed
                            || db.Database.Connection.State == System.Data.ConnectionState.Broken)
                            db.Database.Connection.Open();
                        DbCommand cmd = db.Database.Connection.CreateCommand();
                        sqlBatch = "BEGIN " + sqlBatch + " END; ";
                        cmd.CommandText = sqlBatch;
                        cmd.ExecuteNonQuery();
                        //db.Database.ExecuteSqlCommand(sqlBatch);
                    }
                    catch (Exception ex)
                    {

                    }
                }
            #endregion
        }
        #endregion

        #region "Xóa các dữ liệu cũ - đã được phê duyệt - có thể nên bỏ nhằm tăng tốc độ xử lý và giảm lỗi"
        private static void DeleteCurrentData(HoSoTiepNhanLS HoSoLS)
        {
            List<string> DelQueries = new List<string>();
            string dsGCNID = "", dsThuaID = "", dsTaiSanID = "", dsMDSDDID = "";
            Hashtable delThuaID = new Hashtable(), delTaiSanID = new Hashtable();
            GiayChungNhanLS gcnLS;
            QuyenSuDungDatLS qsddLS;
            QuyenSoHuuTaiSanLS qshtsLS;
            ThuaDatLS tLS;
            TaiSanLS tsLS;

            //Xóa quan hệ
            foreach (var it in HoSoLS.BienDong.DSGcn)
            {
                //chỉ xử lý với dữ liệu ra - là dữ liệu hiện tại còn lưu trong hệ thống
                if (!it.LAGCNVAO.Equals("Y"))
                {
                    dsGCNID = "'" + it.GIAYCHUNGNHANID + "',";
                    if (HoSoLS.DSGiayChungNhan.Contains(it.GIAYCHUNGNHANID))
                    {
                        gcnLS = (GiayChungNhanLS)HoSoLS.DSGiayChungNhan[it.GIAYCHUNGNHANID];
                        foreach (var id in gcnLS.DSQuyenSuDungDatID)
                        {
                            if (HoSoLS.DSQuyenSuDungDat.Contains(id))
                            {
                                qsddLS = (QuyenSuDungDatLS)HoSoLS.DSQuyenSuDungDat[id];
                                dsMDSDDID = "'" + qsddLS.MUCDICHSUDUNGDATID + "',";
                                if (!delThuaID.Contains(qsddLS.THUADATID))
                                {
                                    delThuaID.Add(qsddLS.THUADATID, qsddLS.THUADATID);
                                    dsThuaID = "'" + qsddLS.THUADATID + "',";
                                }
                            }
                        }
                        foreach (var id in gcnLS.DSQuyenSoHuuTaiSanID)
                        {
                            if (HoSoLS.DSQuyenSoHuuTaiSan.Contains(id))
                            {
                                qshtsLS = (QuyenSoHuuTaiSanLS)HoSoLS.DSQuyenSoHuuTaiSan[id];
                                if (!delTaiSanID.Contains(qshtsLS.TAISANGANLIENVOIDATID))
                                {
                                    delTaiSanID.Add(qshtsLS.TAISANGANLIENVOIDATID, qshtsLS.TAISANGANLIENVOIDATID);
                                    dsTaiSanID = "'" + qshtsLS.TAISANGANLIENVOIDATID + "',";
                                    if (HoSoLS.DSTaiSan.Contains(qshtsLS.TAISANGANLIENVOIDATID))
                                    {
                                        tsLS = (TaiSanLS)HoSoLS.DSTaiSan[qshtsLS.TAISANGANLIENVOIDATID];
                                        switch (tsLS.LOAITAISAN)
                                        {
                                            case "1"://DC_NHARIENGLE
                                                DelQueries.Add("delete from DC_NHARIENGLE where NHARIENGLEID = '" + tsLS.TAISANID + "';");
                                                break;
                                            case "2"://DC_NHACHUNGCU
                                            case "3":
                                                DelQueries.Add("delete from DC_NHACHUNGCU where NHACHUNGCUID = '" + tsLS.TAISANID + "';");
                                                break;
                                            case "4"://DC_CANHO
                                                DelQueries.Add("delete from DC_CANHO where CANHOID = '" + tsLS.TAISANID + "';");
                                                break;
                                            case "5"://DC_HANGMUCNGOAICANHO
                                                DelQueries.Add("delete from DC_HANGMUCNGOAICANHO where HANGMUCSOHUUCHUNGID = '" + tsLS.TAISANID + "';");
                                                break;
                                            case "6"://DC_CONGTRINHXAYDUNG
                                                DelQueries.Add("delete from DC_CONGTRINHXAYDUNG where CONGTRINHXAYDUNGID = '" + tsLS.TAISANID + "';");
                                                break;
                                            case "7"://DC_CONGTRINHNGAM
                                                DelQueries.Add("delete from DC_CONGTRINHNGAM where CONGTRINHNGAMID = '" + tsLS.TAISANID + "';");
                                                break;
                                            case "8"://DC_HANGMUCCONGTRINH
                                                DelQueries.Add("delete from DC_HANGMUCCONGTRINH where HANGMUCCONGTRINHID = '" + tsLS.TAISANID + "';");
                                                break;
                                            case "9"://DC_RUNGTRONG
                                                DelQueries.Add("delete from DC_RUNGTRONG where RUNGTRONGID = '" + tsLS.TAISANID + "';");
                                                break;
                                            case "10"://DC_CAYLAUNAM
                                                DelQueries.Add("delete from DC_CAYLAUNAM where CAYLAUNAMID = '" + tsLS.TAISANID + "';");
                                                break;
                                            default:
                                                break;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }

            if (dsGCNID.Length > 0)
            {
                dsGCNID = dsGCNID.Substring(0, dsGCNID.Length - 1);
                if (dsThuaID.Length > 0)
                {
                    dsThuaID = dsThuaID.Substring(0, dsThuaID.Length - 1);
                    if (dsTaiSanID.Length > 0)
                    {
                        dsTaiSanID = dsTaiSanID.Substring(0, dsTaiSanID.Length - 1);
                        DelQueries.Add("delete from DC_THUATAISAN where TAISANGANLIENVOIDATID in (" + dsTaiSanID + ");");
                        DelQueries.Add("delete from DC_TAISANGANLIENVOIDAT where TAISANID in (" + dsTaiSanID + ");");
                    }

                    if (dsMDSDDID.Length > 0)
                    {
                        dsMDSDDID = dsMDSDDID.Substring(0, dsMDSDDID.Length - 1);
                        DelQueries.Add("delete from DC_NGUONGOCSUDUNG where MUCDICHSUDUNGDATID in (" + dsMDSDDID + ");");
                    }

                    DelQueries.Add("delete from DC_QUYENSUDUNGDAT where GIAYCHUNGNHANID in (" + dsGCNID + ");");
                    DelQueries.Add("delete from DC_MUCDICHSUDUNGDAT where MUCDICHSUDUNGDATID in (" + dsMDSDDID + ");");
                    DelQueries.Add("delete from DC_BD_THUA_THUA where THUACHAID in (" + dsThuaID + ");");
                    DelQueries.Add("delete from DC_BD_THUA_THUA where THUADATID in (" + dsThuaID + ");");
                    DelQueries.Add("delete from DC_THUADAT where THUADATID in (" + dsThuaID + ");");
                    DelQueries.Add("delete from DC_QUYENSOHUUTAISAN where GIAYCHUNGNHANID in (" + dsGCNID + ");");
                }
            }

            //Chạy lệnh xóa
            string sqlBatch = "";
            for (int i = 0; i < DelQueries.Count; i++)
            {
                sqlBatch += DelQueries[i];
            }

            if (sqlBatch.Length > 0)
                using (MplisEntities db = new MplisEntities())
                {
                    try
                    {
                        if (db.Database.Connection.State == System.Data.ConnectionState.Closed
                            || db.Database.Connection.State == System.Data.ConnectionState.Broken)
                            db.Database.Connection.Open();
                        DbCommand cmd = db.Database.Connection.CreateCommand();
                        sqlBatch = "BEGIN " + sqlBatch + " END; ";
                        cmd.CommandText = sqlBatch;
                        cmd.ExecuteNonQuery();
                        //db.Database.ExecuteSqlCommand(sqlBatch);
                    }
                    catch (Exception ex)
                    {

                    }
                }
        }
        #endregion

        #region "Lưu các đối tượng chính vào db"
        private static void RestoreObjects(QT_HOSOTIEPNHAN HoSo)
        {
            //Bỏ qua vì dữ liệu hồ sơ và quá trình xử lý chưa đưa vào lịch sử
            //RestoreHoSo(HoSo);

            RestoreBienDong(HoSo);

            RestoreDonDangKy(HoSo.DonDangKy);
        }
        #endregion

        #region "Khôi phục dữ liệu hồ sơ
        private static void RestoreHoSo(QT_HOSOTIEPNHAN HoSo)
        {
            using (MplisEntities db = new MplisEntities())
            {
                db.QT_HOSOTIEPNHAN.Add(HoSo);
                foreach (var it in HoSo.DSFileDinhKem)
                {
                    db.QT_FILEDINHKEMHOSO.Add(it);
                }

                db.SaveChanges();
            }
        }
        #endregion

        #region "Khôi phục dữ liệu biến động"
        private static void RestoreBienDong(QT_HOSOTIEPNHAN HoSo)
        {
            using (MplisEntities db = new MplisEntities())
            {
                //thêm quan hệ chủ - biến động vào db
                foreach (var it in HoSo.BienDong.DSChu)
                {
                    db.DC_BD_CHU.Add(it);
                }
                db.SaveChanges();

                //Thêm thửa vào db
                foreach (var it in HoSo.BienDong.DSThua)
                {
                    if (!it.LOAITHUABD.Equals("R"))
                    {
                        db.DC_THUADAT.Add(it.Thua);
                    }
                    db.DC_BD_THUA.Add(it);
                }
                db.SaveChanges();

                //Thêm quan hệ của thửa vào db
                foreach (var it in HoSo.BienDong.DSThua)
                {
                    //Thêm quan hệ thửa - thửa
                    foreach (var it1 in it.Thua.QHThua)
                    {
                        db.DC_BD_THUA_THUA.Add(it1);
                    }
                    db.SaveChanges();

                    if (!it.LOAITHUABD.Equals("R"))
                    {
                        foreach (var it1 in it.Thua.DSGiaDat)
                        {
                            db.GD_GIATHUADAT.Add(it1);
                        }
                        db.SaveChanges();

                        foreach (var it1 in it.Thua.DSMucDichSuDungDat)
                        {
                            db.DC_MUCDICHSUDUNGDAT.Add(it1);
                            if (it1.NGSDDats != null)
                                foreach (var it2 in it1.NGSDDats)
                                {
                                    db.DC_NGUONGOCSUDUNG.Add(it2);
                                }
                        }
                        db.SaveChanges();
                    }
                }

                //Thêm GCN vào và quan hệ giữa biến động - giấy chứng nhận
                foreach (var it in HoSo.BienDong.DSGcn)
                {
                    if (it.LAGCNVAO.Equals("Y"))
                    {
                        RestoreGCN(it.GiayChungNhan);
                    }
                    db.DC_BD_GCN.Add(it);
                }
                db.SaveChanges();

                //Thêm quan hệ giữa GCN và GCN
                foreach (var it in HoSo.BienDong.DSGcn)
                {
                    if (it.LAGCNVAO.Equals("N"))
                    {
                        foreach (var qh in it.GiayChungNhan.QHGcn_Gcn)
                        {
                            db.DC_BD_GCN_GCN.Add(qh);
                        }
                    }
                }
                db.SaveChanges();
            }
        }

        private static void RestoreGCN(DC_GIAYCHUNGNHAN gcn)
        {
            using (MplisEntities db = new MplisEntities())
            {
                db.DC_GIAYCHUNGNHAN.Add(gcn);
                db.SaveChanges();

                //restore quyền sử dụng đất
                foreach (var it in gcn.DSQuyenSDDat)
                {
                    db.DC_QUYENSUDUNGDAT.Add(it);
                }
                db.SaveChanges();

                //restore quyền sở hữu tài sản
                foreach (var it in gcn.DSQuyenSHTS)
                {
                    RestoreTaiSan(it.TaiSanGanLienVoiDat);
                    db.DC_QUYENSOHUUTAISAN.Add(it);
                }
                db.SaveChanges();
            }
        }

        private static void RestoreTaiSan(DC_TAISANGANLIENVOIDAT ts)
        {
            using (MplisEntities db = new MplisEntities())
            {
                switch (ts.LOAITAISAN)
                {
                    case "1"://DC_NHARIENGLE
                        db.DC_NHARIENGLE.Add(ts.NhaRiengLe);
                        break;
                    case "2"://DC_NHACHUNGCU
                    case "3":
                        db.DC_NHACHUNGCU.Add(ts.NhaChungCu);
                        break;
                    case "4"://DC_CANHO
                        db.DC_CANHO.Add(ts.CanHo);
                        break;
                    case "5"://DC_HANGMUCNGOAICANHO
                        db.DC_HANGMUCNGOAICANHO.Add(ts.HangMucNgoaiCanHo);
                        break;
                    case "6"://DC_CONGTRINHXAYDUNG
                        db.DC_CONGTRINHXAYDUNG.Add(ts.CongTrinhXayDung);
                        break;
                    case "7"://DC_CONGTRINHNGAM
                        db.DC_CONGTRINHNGAM.Add(ts.CongTrinhNgam);
                        break;
                    case "8"://DC_HANGMUCCONGTRINH
                        db.DC_HANGMUCCONGTRINH.Add(ts.HangMucCongTrinh);
                        break;
                    case "9"://DC_RUNGTRONG
                        db.DC_RUNGTRONG.Add(ts.RungTrong);
                        break;
                    case "10"://DC_CAYLAUNAM
                        db.DC_CAYLAUNAM.Add(ts.CayLauNam);
                        break;
                    default:
                        break;
                }
                db.DC_TAISANGANLIENVOIDAT.Add(ts);
                db.SaveChanges();

                //restore thửa tài sản
                foreach (var it in ts.DSThua)
                {
                    db.DC_THUATAISAN.Add(it);
                }
                db.SaveChanges();
            }
        }
        #endregion

        #region "Khôi phục dữ liệu đơn đăng ký"
        private static void RestoreDonDangKy(DC_DONDANGKY DonDangKy)
        {
            using (MplisEntities db = new MplisEntities())
            {
                //restore don dang ky
                db.DC_DONDANGKY.Add(DonDangKy);
                db.SaveChanges();

                //restore quan hệ đăng ký - chủ
                foreach (var it in DonDangKy.DSDangKyChu)
                {
                    db.DC_DANGKY_NGUOI.Add(it);
                }
                db.SaveChanges();

                //restore quan hệ đăng ký - giấy chứng nhận
                foreach (var it in DonDangKy.DSDangKyGCN)
                {
                    db.DC_DANGKY_GCN.Add(it);
                }
                db.SaveChanges();

                //restore quan hệ đăng ký - thửa
                foreach (var it in DonDangKy.DSDangKyThua)
                {
                    db.DC_DANGKY_THUA.Add(it);
                }
                db.SaveChanges();

                //restore quan hệ đăng ký - tài sản
                foreach (var it in DonDangKy.DSDangKyTaiSan)
                {
                    db.DC_DANGKY_TAISAN.Add(it);
                }
                db.SaveChanges();

                //restore Xác nhận đơn đăng ký
                foreach (var it in DonDangKy.DSXacNhan)
                {
                    db.DC_XACNHANDONDANGKY.Add(it);
                }
                db.SaveChanges();

                //restore Ý kiến xác nhận
                foreach (var it in DonDangKy.DSXacNhan)
                {
                    foreach (var it1 in it.DSYKienXacNhan)
                    {
                        db.DC_YKIENXACNHAN.Add(it1);
                    }
                }
                db.SaveChanges();
            }
        }
        #endregion

        #region "Cập nhật dữ liệu liên quan thửa đất nằm ngoài bộ hồ sơ"
        private static void CapNhatDuLieuLienQuanThuaDat_KPDL(HoSoTiepNhanLS HoSoLS)
        {
            Hashtable thuaIDS = new Hashtable();
            List<string> tIDs = new List<string>();

            //lấy danh sách thửa vào
            foreach (var it in HoSoLS.BienDong.DSThua.Where(ir => ir.LOAITHUABD.Equals("R")))
            {
                if (!thuaIDS.Contains(it.THUADATID))
                {
                    thuaIDS.Add(it.THUADATID, it.THUADATID);
                    tIDs.Add(it.THUADATID);
                }
            }

            if (thuaIDS.Count > 0)
            {
                #region "Xử lý với quyền sử dụng đất"
                //lấy danh sách các MDSD liên quan mà không có trong bộ hồ sơ xử lý - Chỉ lấy của thửa vào
                QuyenSuDungDatLS qsdd;
                string qsddIDs = "";
                foreach (DictionaryEntry it in HoSoLS.DSQuyenSuDungDat)
                {
                    qsdd = (QuyenSuDungDatLS)it.Value;
                    if (thuaIDS.Contains(qsdd.THUADATID))
                        qsddIDs += qsdd.QUYENSUDUNGDATID + ",";
                }

                string[] IDs;
                List<DC_QUYENSUDUNGDAT> dsQSDD;
                DC_QUYENSUDUNGDAT data;
                ThuaDatLS thuaRa, thuaGocLS;
                bool daGan, daganMDSDD;

                using (MplisEntities db = new MplisEntities())
                {
                    //Xử lý với MDSD đất
                    dsQSDD = new List<DC_QUYENSUDUNGDAT>();
                    if (qsddIDs.Length > 0)
                    {
                        qsddIDs = qsddIDs.Substring(0, qsddIDs.Length - 1);
                        IDs = qsddIDs.Split(',');
                        var data1 = (from it in db.DC_QUYENSUDUNGDAT.Where(ab => tIDs.Contains(ab.THUADATID))
                                     where !IDs.Contains(it.QUYENSUDUNGDATID)
                                     select new
                                     {
                                         it,
                                         mdsd = db.DC_MUCDICHSUDUNGDAT.Where(i=>i.MUCDICHSUDUNGDATID.Equals(it.MUCDICHSUDUNGDATID)).FirstOrDefault()
                                     }).ToList();
                        foreach (var dt in data1)
                        {
                            data = dt.it;
                            data.MdsdDat = dt.mdsd;
                            dsQSDD.Add(data);
                        }
                    }
                    else
                    {
                        var data2 = (from it in db.DC_QUYENSUDUNGDAT.Where(ab => tIDs.Contains(ab.THUADATID))
                                     select new
                                     {
                                         it,
                                         mdsd = db.DC_MUCDICHSUDUNGDAT.Where(i => i.MUCDICHSUDUNGDATID.Equals(it.MUCDICHSUDUNGDATID)).FirstOrDefault()
                                     }).ToList();
                        foreach (var dt in data2)
                        {
                            data = dt.it;
                            data.MdsdDat = dt.mdsd;
                            dsQSDD.Add(data);
                        }
                    }

                    if (dsQSDD != null && dsQSDD.Count > 0)
                    {
                        foreach (var q in dsQSDD)
                        {
                            daGan = false;
                            thuaGocLS = (ThuaDatLS)HoSoLS.DSThua[q.THUADATID];
                            foreach (var it in HoSoLS.BienDong.DSThua)
                            {
                                thuaRa = (ThuaDatLS)HoSoLS.DSThua[it.THUADATID];
                                if (it.LOAITHUABD.Equals("R"))  //thửa ra
                                {
                                    if (q.THUADATID.Equals(thuaRa.THUADATID) && thuaRa.THUAGOCID != null && !thuaRa.THUAGOCID.Equals(""))
                                    {
                                        q.THUADATID = thuaRa.THUAGOCID;
                                        daganMDSDD = false;
                                        //tìm mdsd đối ứng trong mỗi thửa ra
                                        foreach (var md in thuaRa.DSMucDichSuDungDat)
                                        {
                                            if (md.MDSDGOCID != null && md.MUCDICHSUDUNGDATID.Equals(q.MdsdDat.MUCDICHSUDUNGDATID))
                                            {
                                                q.MUCDICHSUDUNGDATID = md.MDSDGOCID;
                                                daganMDSDD = true;
                                                break;
                                            }
                                        }
                                        if (!daganMDSDD) //nếu không tìm đc MDSD đối ứng trên thửa mới thì chỉ gán lại thửa đất id cho MDSD
                                        {
                                            q.MdsdDat.THUADATID = thuaRa.THUADATID;
                                        }
                                        daGan = true;
                                        break;
                                    }
                                }
                                else if (it.LOAITHUABD.Equals("V"))
                                {
                                    if (thuaRa.XAID.Equals(thuaGocLS.XAID)
                                        && thuaRa.SOHIEUTOBANDO.Equals(thuaGocLS.SOHIEUTOBANDO)
                                        && thuaRa.SOTHUTUTHUA.Equals(thuaGocLS.SOTHUTUTHUA))
                                    {
                                        q.THUADATID = thuaRa.THUADATID;
                                        q.MdsdDat.THUADATID = thuaRa.THUADATID;
                                        daGan = true;
                                        break;
                                    }
                                }
                            }
                            if (!daGan)
                            {
                                //Tìm thửa cha của thửa đầu vào để gán
                                foreach (var it in HoSoLS.BienDong.DSThua)
                                {
                                    if (it.LOAITHUABD.Equals("R"))  //thửa ra
                                    {
                                        thuaRa = (ThuaDatLS)HoSoLS.DSThua[it.THUADATID];
                                        if (q.THUADATID.Equals(thuaRa.THUADATID) && thuaRa.QHThua != null && thuaRa.QHThua.Count > 0)
                                        {
                                            q.THUADATID = thuaRa.QHThua[0].THUACHAID;
                                            q.MdsdDat.THUADATID = thuaRa.QHThua[0].THUACHAID;
                                            daGan = true;
                                            break;
                                        }
                                    }
                                }
                                if (!daGan)
                                {
                                    //Lấy một thửa đầu vào bất kỳ để gán
                                    foreach (var it in HoSoLS.BienDong.DSThua)
                                    {
                                        if (it.LOAITHUABD.Equals("V"))  //thửa vào
                                        {
                                            thuaRa = (ThuaDatLS)HoSoLS.DSThua[it.THUADATID];
                                            q.THUADATID = thuaRa.THUADATID;
                                            q.MdsdDat.THUADATID = thuaRa.THUADATID;
                                            daGan = true;
                                            break;
                                        }
                                    }
                                }
                            }
                        }

                        db.SaveChanges();
                    }
                }
                #endregion

                #region "Cập nhật quan hệ giữa thửa đất đầu ra với tài sản"
                QuyenSoHuuTaiSanLS qshts;
                List<DC_THUATAISAN> dsThuaTS;
                string tsIDs = "";

                foreach (DictionaryEntry it in HoSoLS.DSQuyenSoHuuTaiSan)
                {
                    qshts = (QuyenSoHuuTaiSanLS)it.Value;
                    tsIDs += qshts.TAISANGANLIENVOIDATID + ",";
                }

                using (MplisEntities db = new MplisEntities())
                {
                    if (tsIDs.Length > 0)
                    {
                        tsIDs = tsIDs.Substring(0, tsIDs.Length - 1);
                        IDs = tsIDs.Split(',');
                        dsThuaTS = (from it in db.DC_THUATAISAN.Where(ab => tIDs.Contains(ab.THUADATID))
                                    where !IDs.Contains(it.TAISANGANLIENVOIDATID)
                                    select it).ToList();
                    }
                    else
                    {
                        dsThuaTS = (from it in db.DC_THUATAISAN.Where(ab => tIDs.Contains(ab.THUADATID))
                                    select it).ToList();
                    }

                    foreach (var q in dsThuaTS)
                    {
                        thuaGocLS = (ThuaDatLS)HoSoLS.DSThua[q.THUADATID];
                        foreach (var it in HoSoLS.BienDong.DSThua)
                        {
                            thuaRa = (ThuaDatLS)HoSoLS.DSThua[it.THUADATID];
                            if (it.LOAITHUABD.Equals("R"))  //thửa ra
                            {
                                if (q.THUADATID.Equals(thuaRa.THUADATID) && !thuaRa.THUAGOCID.Equals(""))
                                {
                                    q.THUADATID = thuaRa.THUAGOCID;
                                    break;
                                }
                            }
                            else if (it.LOAITHUABD.Equals("V"))  //thửa vào
                            {
                                if (thuaRa.XAID.Equals(thuaGocLS.XAID)
                                    && thuaRa.SOHIEUTOBANDO.Equals(thuaGocLS.SOHIEUTOBANDO)
                                    && thuaRa.SOTHUTUTHUA.Equals(thuaGocLS.SOTHUTUTHUA))
                                {
                                    q.THUADATID = thuaRa.THUADATID;
                                    break;
                                }
                            }
                        }
                    }

                    db.SaveChanges();
                }
                #endregion
            }
        }
        #endregion

        #region "Khôi phục dữ liệu lịch sử cũ - chưa viết, tạm thời để lại"
        private static void RestoreOldHistoryData(LS_BOHOSO BoHoSo)
        {
            //Xóa dữ liệu phục vụ tra cứu

            //Khôi phục lịch sử GCN

            //Khôi phục lịch sử thửa đất
        }
        #endregion

        #endregion

        #region "Lấy dữ liệu gốc (ban đầu có tính pháp lý) từ dữ liệu lịch sử"
        #region "Lấy dữ liệu thửa đất"
        public static DC_THUADAT getThuaDatTuLSByThuaDatID(string thuadatid)
        {
            DC_THUADAT td = null;
            ThuaDatLS tdLS = null;
            LS_BOHOSO HoSo;

            HoSo = getHoSoLSByThuaDatID(thuadatid);
            if (HoSo != null)
            {
                HoSoTiepNhanLS HoSoLS = JsonConvert.DeserializeObject<HoSoTiepNhanLS>(HoSo.DATA);
                RestoreHashData(HoSoLS);
                if (HoSoLS.DSThua.Contains(thuadatid))
                {
                    tdLS = (ThuaDatLS)HoSoLS.DSThua[thuadatid];
                    td = Mapper.Map<ThuaDatLS, DC_THUADAT>(tdLS);
                }
            }

            return td;
        }

        public static DC_THUADAT getThuaDatTuLSByXaID(string xaid, string SoToBD, string STTThua)
        {
            DC_THUADAT td = null;
            ThuaDatLS tdLS = null;
            LS_BOHOSO HoSo;

            HoSo = getHoSoLSByBaMa(xaid, SoToBD, STTThua);
            if (HoSo != null)
            {
                HoSoTiepNhanLS HoSoLS = JsonConvert.DeserializeObject<HoSoTiepNhanLS>(HoSo.DATA);
                RestoreHashData(HoSoLS);

                foreach (var it in HoSoLS.BienDong.DSThua)
                {
                    if (it.LOAITHUABD.Equals("R"))
                    {
                        tdLS = (ThuaDatLS)HoSoLS.DSThua[it.THUADATID];
                        if (tdLS.XAID.Equals(xaid) && tdLS.SOHIEUTOBANDO.Equals(SoToBD) && tdLS.SOTHUTUTHUA.Equals(STTThua))
                        {
                            td = Mapper.Map<ThuaDatLS, DC_THUADAT>(tdLS);
                            break;
                        }
                    }
                }
            }

            return td;
        }
        #endregion
        #endregion

        #region "Tra cứu dữ liệu - có hỗ trợ tra cứu từ dữ liệu lịch sử"
        public static LS_BOHOSO getHoSoLSByBienDongID(string BienDongID)
        {
            LS_BOHOSO ret = null;

            using (MplisEntities db = new MplisEntities())
            {
                ret = (from bhs in db.LS_BOHOSO
                       where bhs.BIENDONGID == BienDongID
                       select bhs).FirstOrDefault();
            }

            return ret;
        }

        public static LS_BOHOSO getHoSoLSByThuaDatID(string ThuaDatID)
        {
            LS_BOHOSO ret = null;

            using (MplisEntities db = new MplisEntities())
            {
                var qr = (from ttc in db.LS_TC_THUA
                          where ttc.THUAID == ThuaDatID
                          select new
                          {
                              ttc,
                              bhs = db.LS_BOHOSO.Where(i => i.BOHOSOID.Equals(ttc.BOHOSOID)).FirstOrDefault()
                          }).FirstOrDefault();

                if (qr != null) ret = qr.bhs;
            }

            return ret;
        }

        //public static LS_BOHOSO getHoSoLSByMaXa(string maKVHC, string SoToBD, string STTThua)
        //{
        //    LS_BOHOSO ret = null;

        //    using (MplisEntities db = new MplisEntities())
        //    {
        //        ret = (from ttc in db.LS_TC_THUA
        //               where ttc.MAKVHC == maKVHC && ttc.SHTOBD == SoToBD && ttc.STTTHUA == STTThua
        //               join bhs in db.LS_BOHOSO on ttc.BOHOSOID equals bhs.BOHOSOID
        //               select bhs).OrderByDescending(t => t.NGAYPD).FirstOrDefault();
        //    }

        //    return ret;
        //}

        public static LS_BOHOSO getHoSoLSByBaMa(string xaid, string SoToBD, string STTThua)
        {
            LS_BOHOSO ret = null;

            using (MplisEntities db = new MplisEntities())
            {
                var qr = (from ttc in db.LS_TC_THUA
                          where ttc.XAID == xaid && ttc.SHTOBD == SoToBD && ttc.STTTHUA == STTThua
                          select new
                          {
                              ttc,
                              bhs = db.LS_BOHOSO.Where(i => i.BOHOSOID.Equals(ttc.BOHOSOID)).OrderByDescending(t => t.NGAYPD).FirstOrDefault()
                          }).FirstOrDefault();

                if (qr != null) ret = qr.bhs;
            }

            return ret;
        }
        #endregion

        #region "Lịch sử"

        #endregion

    }
}