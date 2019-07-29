using AppCore.Models;
using MPLIS.Libraries.Data.XuLyHoSo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPLIS.Libraries.Services.AutoMapperStartup.ClassMapper
{
    public static class XuLyHoSoMapper
    {
        public static void Execute()
        {
            //Mapping thông tin tiếp nhận hồ sơ
            AutoMapper.Mapper.CreateMap<QT_HOSOTIEPNHAN, HoSoTiepNhanLS>();
            AutoMapper.Mapper.CreateMap<QT_FILEDINHKEMHOSO, FileDinhKemHoSoLS>();

            AutoMapper.Mapper.CreateMap<HoSoTiepNhanLS, QT_HOSOTIEPNHAN>();
            AutoMapper.Mapper.CreateMap<FileDinhKemHoSoLS, QT_FILEDINHKEMHOSO>();

            #region Đăng ký
            //Mapping Đăng ký
            AutoMapper.Mapper.CreateMap<DC_DONDANGKY, DonDangKyLS>();
            AutoMapper.Mapper.CreateMap<DC_DANGKY_GCN, DangKy_GCNLS>();
            AutoMapper.Mapper.CreateMap<DC_DANGKY_GCN, GCNDonVM>();
            AutoMapper.Mapper.CreateMap<DC_DANGKY_NGUOI, DangKy_NguoiLS>();
            AutoMapper.Mapper.CreateMap<DC_DANGKY_NGUOI, ChuDonVM>();
            AutoMapper.Mapper.CreateMap<DC_DANGKY_NGUOI, DC_DANGKY_NGUOI>()
                .ForMember(dest => dest.DC_DONDANGKY, opt => opt.Ignore())
                .ForMember(dest => dest.DC_NGUOI, opt => opt.Ignore());
            AutoMapper.Mapper.CreateMap<DC_DANGKY_TAISAN, DangKy_TaiSanLS>();
            AutoMapper.Mapper.CreateMap<DC_DANGKY_THUA, DangKy_ThuaLS>();
            AutoMapper.Mapper.CreateMap<DC_DANGKY_THUA, ThuaDonVM>();
            AutoMapper.Mapper.CreateMap<DC_XACNHANDONDANGKY, XacNhanDonDangKyLS>();
            AutoMapper.Mapper.CreateMap<DC_YKIENXACNHAN, YKienXacNhanLS>();

            AutoMapper.Mapper.CreateMap<DonDangKyLS, DC_DONDANGKY>();
            AutoMapper.Mapper.CreateMap<DangKy_GCNLS, DC_DANGKY_GCN>();
            AutoMapper.Mapper.CreateMap<GCNDonVM, DC_DANGKY_GCN>()
                .ForMember(dest => dest.DC_DONDANGKY, opt => opt.Ignore())
                .ForMember(dest => dest.DC_GIAYCHUNGNHAN, opt => opt.Ignore())
                .ForMember(dest => dest.GiayChungNhan, opt => opt.Ignore());
            AutoMapper.Mapper.CreateMap<DangKy_NguoiLS, DC_DANGKY_NGUOI>();
            AutoMapper.Mapper.CreateMap<ChuDonVM, DC_DANGKY_NGUOI>()
                .ForMember(dest => dest.Chu, opt => opt.Ignore())
                .ForMember(dest => dest.DC_DONDANGKY, opt => opt.Ignore())
                .ForMember(dest => dest.DC_NGUOI, opt => opt.Ignore());
            AutoMapper.Mapper.CreateMap<DangKy_TaiSanLS, DC_DANGKY_TAISAN>();
            AutoMapper.Mapper.CreateMap<DangKy_ThuaLS, DC_DANGKY_THUA>();
            AutoMapper.Mapper.CreateMap<ThuaDonVM, DC_DANGKY_THUA>()
                .ForMember(dest => dest.DC_DONDANGKY, opt => opt.Ignore())
                //.ForMember(dest => dest.DC_MUCDICHSUDUNGDAT, opt => opt.Ignore())
                .ForMember(dest => dest.Thua, opt => opt.Ignore());
            AutoMapper.Mapper.CreateMap<XacNhanDonDangKyLS, DC_XACNHANDONDANGKY>();
            AutoMapper.Mapper.CreateMap<YKienXacNhanLS, DC_YKIENXACNHAN>();
            #endregion

            #region Biến động
            //Mapping Biến động
            AutoMapper.Mapper.CreateMap<DC_BIENDONG, BienDongLS>();
            AutoMapper.Mapper.CreateMap<DC_BD_CHU, BDChuLS>();
            AutoMapper.Mapper.CreateMap<DC_BD_GCN, BDGiayChungNhanLS>();
            AutoMapper.Mapper.CreateMap<DC_BD_GCN, GCNBDVM>();
            AutoMapper.Mapper.CreateMap<DC_BD_GCN, DC_BD_GCN>()
                .ForMember(dest => dest.DC_BIENDONG, opt => opt.Ignore())
                .ForMember(dest => dest.DC_GIAYCHUNGNHAN, opt => opt.Ignore());
            AutoMapper.Mapper.CreateMap<DC_BD_THUA, BDThuaLS>();
            AutoMapper.Mapper.CreateMap<DC_BD_THUA, ThuaBDVM>();
            AutoMapper.Mapper.CreateMap<DC_BD_THECHAP, BDTheChapLS>();
            AutoMapper.Mapper.CreateMap<DC_BD_THECHAP, TheChapVM>();
            AutoMapper.Mapper.CreateMap<DC_QUYETDINH, QuyetDinhLS>();
            AutoMapper.Mapper.CreateMap<DC_BIENDONG, TTChungBienDongVM>()
                .ForMember(dest => dest.SOQUYETDINH, opt => opt.MapFrom(s => s.CurDC_QUYETDINH.SOQUYETDINH));
            AutoMapper.Mapper.CreateMap<DC_BD_CHU, ChuBDVM>();

            AutoMapper.Mapper.CreateMap<BienDongLS, DC_BIENDONG>()
                .ForMember(dest => dest.DC_BD_CHU, opt => opt.Ignore())
                .ForMember(dest => dest.DC_BD_GCN, opt => opt.Ignore())
                .ForMember(dest => dest.DC_BD_THECHAP, opt => opt.Ignore())
                .ForMember(dest => dest.DC_BD_THUA, opt => opt.Ignore())
                .ForMember(dest => dest.DC_LOAIBIENDONG, opt => opt.Ignore())
                .ForMember(dest => dest.DC_NOICONGCHUNG, opt => opt.Ignore());
            AutoMapper.Mapper.CreateMap<BDChuLS, DC_BD_CHU>();
            AutoMapper.Mapper.CreateMap<BDGiayChungNhanLS, DC_BD_GCN>();
            AutoMapper.Mapper.CreateMap<GCNBDVM, DC_BD_GCN>()
                .ForMember(dest => dest.DC_BIENDONG, opt => opt.Ignore())
                .ForMember(dest => dest.DC_GIAYCHUNGNHAN, opt => opt.Ignore())
                .ForMember(dest => dest.GiayChungNhan, opt => opt.Ignore());
            AutoMapper.Mapper.CreateMap<BDThuaLS, DC_BD_THUA>();
            AutoMapper.Mapper.CreateMap<ThuaBDVM, DC_BD_THUA>()
                .ForMember(dest => dest.DC_BIENDONG, opt => opt.Ignore())
                .ForMember(dest => dest.DC_THUADAT, opt => opt.Ignore())
                .ForMember(dest => dest.Thua, opt => opt.Ignore());
            AutoMapper.Mapper.CreateMap<BDTheChapLS, DC_BD_THECHAP>();
            AutoMapper.Mapper.CreateMap<TheChapVM, DC_BD_THECHAP>()
                .ForMember(x => x.DC_BIENDONG, opt => opt.Ignore())
                .ForMember(x => x.DC_QUYENSOHUUTAISAN, opt => opt.Ignore())
                .ForMember(x => x.DC_QUYENSUDUNGDAT, opt => opt.Ignore())
                .ForMember(x => x.DSQuyenSoHuuTaiSan, opt => opt.Ignore())
                .ForMember(x => x.DSQuyenSuDungDat, opt => opt.Ignore());
            AutoMapper.Mapper.CreateMap<QuyetDinhLS, DC_QUYETDINH>();
            AutoMapper.Mapper.CreateMap<TTChungBienDongVM, DC_BIENDONG>()
                .ForMember(x => x.CurDC_QUYETDINH, opt => opt.Ignore())
                .ForMember(x => x.DC_BD_CHU, opt => opt.Ignore())
                .ForMember(x => x.DC_BD_GCN, opt => opt.Ignore())
                .ForMember(x => x.DC_BD_THECHAP, opt => opt.Ignore())
                .ForMember(x => x.DC_BD_THUA, opt => opt.Ignore())
                .ForMember(x => x.DC_LOAIBIENDONG, opt => opt.Ignore())
                .ForMember(x => x.DC_NOICONGCHUNG, opt => opt.Ignore())
                .ForMember(x => x.DSChu, opt => opt.Ignore())
                .ForMember(x => x.DSGcn, opt => opt.Ignore())
                .ForMember(x => x.DSThua, opt => opt.Ignore())
                .ForMember(x => x.LS_BD_GCN, opt => opt.Ignore())
                .ForMember(x => x.LS_BD_THUA, opt => opt.Ignore())
                .ForMember(x => x.LS_BOHOSO, opt => opt.Ignore())
                .ForMember(x => x.TheChapObj, opt => opt.Ignore());
            AutoMapper.Mapper.CreateMap<ChuBDVM, DC_BD_CHU>()
                .ForMember(x => x.Chu, opt => opt.Ignore())
                .ForMember(x => x.DC_BIENDONG, opt => opt.Ignore())
                .ForMember(x => x.DC_NGUOI, opt => opt.Ignore());
            #endregion

            #region Giấy chứng nhận
            //Mapping Giấy chứng nhận
            AutoMapper.Mapper.CreateMap<DC_GIAYCHUNGNHAN, GiayChungNhanLS>();
            AutoMapper.Mapper.CreateMap<DC_BD_GCN_GCN, GCN_GCNLS>();
            AutoMapper.Mapper.CreateMap<DC_QUYENSOHUUTAISAN, QuyenSoHuuTaiSanLS>();
            AutoMapper.Mapper.CreateMap<DC_QUYENSUDUNGDAT, QuyenSuDungDatLS>();
            AutoMapper.Mapper.CreateMap<DC_QUYENQUANLYDAT, QuyenQuanLyDatLS>();
            AutoMapper.Mapper.CreateMap<DC_QUYENSOHUUTAISAN, QuyenSHTSVM>();

            AutoMapper.Mapper.CreateMap<GiayChungNhanLS, DC_GIAYCHUNGNHAN>();
            AutoMapper.Mapper.CreateMap<GCN_GCNLS, DC_BD_GCN_GCN>();
            AutoMapper.Mapper.CreateMap<QuyenSoHuuTaiSanLS, DC_QUYENSOHUUTAISAN>();
            AutoMapper.Mapper.CreateMap<QuyenSuDungDatLS, DC_QUYENSUDUNGDAT>();
            AutoMapper.Mapper.CreateMap<QuyenQuanLyDatLS, DC_QUYENQUANLYDAT>();
            AutoMapper.Mapper.CreateMap<QuyenSHTSVM, DC_QUYENSOHUUTAISAN>()
                .ForMember(x => x.Chu, opt => opt.Ignore())
                .ForMember(x => x.DC_BD_THECHAP, opt => opt.Ignore())
                .ForMember(x => x.DC_GIAYCHUNGNHAN, opt => opt.Ignore())
                .ForMember(x => x.DC_NGUOI, opt => opt.Ignore())
                .ForMember(x => x.DC_TAISANGANLIENVOIDAT, opt => opt.Ignore())
                .ForMember(x => x.TaiSanGanLienVoiDat, opt => opt.Ignore());
           
            AutoMapper.Mapper.CreateMap<DC_GIAYCHUNGNHAN, DC_GIAYCHUNGNHAN>()
                .ForMember(x => x.DC_BD_GCN, opt => opt.Ignore())
                .ForMember(x => x.DC_BD_GCN_GCN, opt => opt.Ignore())
                .ForMember(x => x.DC_BD_GCN_GCN1, opt => opt.Ignore())
                .ForMember(x => x.DC_BD_TREN_GCN, opt => opt.Ignore())
                .ForMember(x => x.DC_DANGKY_GCN, opt => opt.Ignore())
                .ForMember(x => x.DC_GCN_TILESH, opt => opt.Ignore())
                .ForMember(x => x.DC_NGUOI, opt => opt.Ignore())
                .ForMember(x => x.DC_QUYENSOHUUTAISAN, opt => opt.Ignore())
                .ForMember(x => x.DC_QUYENQUANLYDAT, opt => opt.Ignore())
                .ForMember(x => x.HT_TOCHUC, opt => opt.Ignore());

            AutoMapper.Mapper.CreateMap<DC_GCN_TILESH, GCNTiLeSoHuuVM>();
            AutoMapper.Mapper.CreateMap<GCNTiLeSoHuuVM, DC_GCN_TILESH>();
            //Mapping Hạn Chế
            AutoMapper.Mapper.CreateMap<DC_HANCHE, HanCheLS>();
            AutoMapper.Mapper.CreateMap<HanCheLS, DC_HANCHE>();
            AutoMapper.Mapper.CreateMap<DC_LOAIHANCHE, LoaiHanCheLS>();
            AutoMapper.Mapper.CreateMap<LoaiHanCheLS, DC_LOAIHANCHE>();
            AutoMapper.Mapper.CreateMap<DC_HANCHE, DC_HANCHE>()
                .ForMember(x => x.DC_LOAIHANCHE, opt => opt.Ignore());
            //Mapping TLSH
            AutoMapper.Mapper.CreateMap<DC_GCN_TILESH, TyLeSoHuuLS>();
            AutoMapper.Mapper.CreateMap<TyLeSoHuuLS, DC_GCN_TILESH>();
            AutoMapper.Mapper.CreateMap<DC_GCN_TILESH, DC_GCN_TILESH>()
                .ForMember(x => x.DC_GIAYCHUNGNHAN, opt => opt.Ignore())
                .ForMember(x => x.DC_NGUOI, opt => opt.Ignore())
                .ForMember(x => x.DM_LOAIDTMIENGIAM, opt => opt.Ignore());
            #endregion

            #region Chủ
            //Mapping Chủ
            AutoMapper.Mapper.CreateMap<DC_NGUOI, DC_NGUOI>()
                    .ForMember(dest => dest.DC_BD_CHU, opt => opt.Ignore())
                    .ForMember(dest => dest.DC_DANGKY_NGUOI, opt => opt.Ignore())
                    .ForMember(dest => dest.DC_GIAYCHUNGNHAN, opt => opt.Ignore())
                    .ForMember(dest => dest.DC_KHOANDUOCTRU, opt => opt.Ignore())
                    //.ForMember(dest => dest.DC_MIENGIAMNGHIAVUTAICHINH, opt => opt.Ignore())
                    .ForMember(dest => dest.DC_NGUOI_DIACHI, opt => opt.Ignore())
                    .ForMember(dest => dest.DM_DOITUONGSUDUNG, opt => opt.Ignore())
                    .ForMember(dest => dest.DC_NONVTC, opt => opt.Ignore())
                    .ForMember(dest => dest.DC_QUYENSOHUUTAISAN, opt => opt.Ignore())
                    .ForMember(dest => dest.DC_QUYENSUDUNGDAT, opt => opt.Ignore())
                    .ForMember(dest => dest.DC_QUYENQUANLYDAT, opt => opt.Ignore());
            AutoMapper.Mapper.CreateMap<DC_NGUOI, NguoiLS>();
            AutoMapper.Mapper.CreateMap<DC_CANHAN, CaNhanLS>();
            AutoMapper.Mapper.CreateMap<DC_NHOMNGUOI, NhomNguoiLS>();
            AutoMapper.Mapper.CreateMap<DC_NHOMNGUOI_THANHVIEN, NhomNguoiThanhVienLS>();
            AutoMapper.Mapper.CreateMap<DC_HOGIADINH, HoGiaDinhLS>();
            AutoMapper.Mapper.CreateMap<DC_VOCHONG, VoChongLS>();
            AutoMapper.Mapper.CreateMap<DC_HOGIADINH, DC_HOGIADINH>();
            AutoMapper.Mapper.CreateMap<DC_CONGDONG, CongDongLS>();
            AutoMapper.Mapper.CreateMap<DC_CONGDONG, DC_CONGDONG>();
            AutoMapper.Mapper.CreateMap<DC_TOCHUC, ToChucLS>();
            AutoMapper.Mapper.CreateMap<DC_TOCHUC, DC_TOCHUC>();
            AutoMapper.Mapper.CreateMap<DC_HOGIADINH_THANHVIEN, HoGiaDinhThanhVienLS>();
            AutoMapper.Mapper.CreateMap<DC_HOGIADINH_THANHVIEN, DC_HOGIADINH_THANHVIEN>()
                .ForMember(dest => dest.DM_QHVOICHUHO, opt => opt.Ignore());
            AutoMapper.Mapper.CreateMap<DC_HOGIADINH_THANHVIEN, HoGiaDinhThanhVienDataTable>();
            AutoMapper.Mapper.CreateMap<DC_GIAYTOTUYTHAN, GiayToTuyThanLS>();

            AutoMapper.Mapper.CreateMap<NguoiLS, DC_NGUOI>();
            AutoMapper.Mapper.CreateMap<CaNhanLS, DC_CANHAN>();
            AutoMapper.Mapper.CreateMap<NhomNguoiLS, DC_NHOMNGUOI>();
            AutoMapper.Mapper.CreateMap<NhomNguoiThanhVienLS, DC_NHOMNGUOI_THANHVIEN>();
            AutoMapper.Mapper.CreateMap<VoChongLS, DC_VOCHONG>();
            AutoMapper.Mapper.CreateMap<HoGiaDinhLS, DC_HOGIADINH>();
            AutoMapper.Mapper.CreateMap<CongDongLS, DC_CONGDONG>();
            AutoMapper.Mapper.CreateMap<ToChucLS, DC_TOCHUC>();
            AutoMapper.Mapper.CreateMap<HoGiaDinhThanhVienLS, DC_HOGIADINH_THANHVIEN>();
            AutoMapper.Mapper.CreateMap<GiayToTuyThanLS, DC_GIAYTOTUYTHAN>();

            AutoMapper.Mapper.CreateMap<DC_NHOMNGUOI, DC_NHOMNGUOI>()
                .ForMember(dest => dest.DC_NHOMNGUOI_THANHVIEN, opt => opt.Ignore());

            AutoMapper.Mapper.CreateMap<DC_NHOMNGUOI_THANHVIEN, DC_NHOMNGUOI_THANHVIEN>()
                .ForMember(dest => dest.DC_NHOMNGUOI, opt => opt.Ignore());

            AutoMapper.Mapper.CreateMap<DC_NHOMNGUOI_THANHVIEN, NhomNguoiThanhVienDataTable>();

            #endregion

            #region Thửa

            //Mapping thửa
            AutoMapper.Mapper.CreateMap<DC_THUADAT, ThuaDatLS>();
            AutoMapper.Mapper.CreateMap<DC_MUCDICHSUDUNGDAT, MucDichSuDungDatLS>();
            AutoMapper.Mapper.CreateMap<DC_NGUONGOCSUDUNG, NguonGocSuDungDatLS>();
            AutoMapper.Mapper.CreateMap<DC_BD_THUA_THUA, Thua_ThuaLS>();
            AutoMapper.Mapper.CreateMap<GD_GIATHUADAT, GiaThuaDatLS>();
            AutoMapper.Mapper.CreateMap<DC_THUATAISAN, ThuaTaiSanLS>();
            AutoMapper.Mapper.CreateMap<DC_VITRITHUADAT, DC_VITRITHUADAT>();
            AutoMapper.Mapper.CreateMap<DC_TRANHCHAP, DC_TRANHCHAP>()
                .ForMember(dest => dest.DC_THUADAT, opt => opt.Ignore());
            AutoMapper.Mapper.CreateMap<DC_NGUONGOCSUDUNG, DC_NGUONGOCSUDUNG>()
                .ForMember(dest => dest.DC_MUCDICHSUDUNGDAT, opt => opt.Ignore())
                .ForMember(dest => dest.DM_LOAINGUONGOCSUDUNG, opt => opt.Ignore());
            AutoMapper.Mapper.CreateMap<ThuaDatLS, DC_THUADAT>();
            AutoMapper.Mapper.CreateMap<MucDichSuDungDatLS, DC_MUCDICHSUDUNGDAT>();
            AutoMapper.Mapper.CreateMap<NguonGocSuDungDatLS, DC_NGUONGOCSUDUNG>();
            AutoMapper.Mapper.CreateMap<Thua_ThuaLS, DC_BD_THUA_THUA>();
            AutoMapper.Mapper.CreateMap<GiaThuaDatLS, GD_GIATHUADAT>();
            AutoMapper.Mapper.CreateMap<ThuaTaiSanLS, DC_THUATAISAN>();
            #endregion

            #region Tài sản

            //Mapping tài sản
            AutoMapper.Mapper.CreateMap<DC_TAISANGANLIENVOIDAT, TaiSanLS>();
            AutoMapper.Mapper.CreateMap<DC_TAISANGANLIENVOIDAT, DC_TAISANGANLIENVOIDAT>()
                .ForMember(dest => dest.DC_QUYENSOHUUTAISAN, opt => opt.Ignore())
                .ForMember(dest => dest.DC_TAISAN_DIACHI, opt => opt.Ignore())
                .ForMember(dest => dest.DC_THUATAISAN, opt => opt.Ignore());
            AutoMapper.Mapper.CreateMap<DC_NHARIENGLE, NhaRiengLeLS>();
            AutoMapper.Mapper.CreateMap<DC_CANHO, CanHoLS>();
            AutoMapper.Mapper.CreateMap<DC_CONGTRINHXAYDUNG, CongTrinhXayDungLS>();
            AutoMapper.Mapper.CreateMap<DC_RUNGTRONG, RungTrongLS>();
            AutoMapper.Mapper.CreateMap<DC_CAYLAUNAM, CayLauNamLS>();
            AutoMapper.Mapper.CreateMap<DC_CONGTRINHNGAM, CongTrinhNgamLS>();
            AutoMapper.Mapper.CreateMap<DC_NHACHUNGCU, NhaChungCuLS>();
            AutoMapper.Mapper.CreateMap<DC_HANGMUCNGOAICANHO, HangMucNgoaiCanHoLS>();
            AutoMapper.Mapper.CreateMap<DC_HANGMUCCONGTRINH, HangMucCongTrinhLS>();

            AutoMapper.Mapper.CreateMap<TaiSanLS, DC_TAISANGANLIENVOIDAT>();
            AutoMapper.Mapper.CreateMap<NhaRiengLeLS, DC_NHARIENGLE>();
            AutoMapper.Mapper.CreateMap<CanHoLS, DC_CANHO>();
            AutoMapper.Mapper.CreateMap<CongTrinhXayDungLS, DC_CONGTRINHXAYDUNG>();
            AutoMapper.Mapper.CreateMap<RungTrongLS, DC_RUNGTRONG>();
            AutoMapper.Mapper.CreateMap<CayLauNamLS, DC_CAYLAUNAM>();
            AutoMapper.Mapper.CreateMap<CongTrinhNgamLS, DC_CONGTRINHNGAM>();
            AutoMapper.Mapper.CreateMap<NhaChungCuLS, DC_NHACHUNGCU>();
            AutoMapper.Mapper.CreateMap<HangMucNgoaiCanHoLS, DC_HANGMUCNGOAICANHO>();
            AutoMapper.Mapper.CreateMap<HangMucCongTrinhLS, DC_HANGMUCCONGTRINH>();
            #endregion

            //mapping cho lịch sử
            AutoMapper.Mapper.CreateMap<LS_BD_GCN, LS_BD_GCN>();
            AutoMapper.Mapper.CreateMap<LS_BD_THUA, LS_BD_THUA>();

            //khoanb
            AutoMapper.Mapper.CreateMap<DC_THUADAT, DC_THUADAT>()
            .ForMember(dest => dest.DC_BD_THUA, opt => opt.Ignore())
            .ForMember(dest => dest.DC_BD_THUA_THUA, opt => opt.Ignore())
            .ForMember(dest => dest.DC_BD_THUA_THUA1, opt => opt.Ignore())
            .ForMember(dest => dest.DC_THUADAT_TAILIEUDODAC, opt => opt.Ignore())
            .ForMember(dest => dest.DC_THUADAT_TAISAN, opt => opt.Ignore())
            .ForMember(dest => dest.DC_TRANHCHAP, opt => opt.Ignore())
            .ForMember(dest => dest.GD_GIATHUADAT, opt => opt.Ignore())
            .ForMember(dest => dest.HC_DMKVHC, opt => opt.Ignore())
            .ForMember(dest => dest.DC_TAILIEUDODAC, opt => opt.Ignore())
            .ForMember(dest => dest.DC_THUATAISAN, opt => opt.Ignore());

            AutoMapper.Mapper.CreateMap<DC_MUCDICHSUDUNGDAT, DC_MUCDICHSUDUNGDAT>()
                .ForMember(dest => dest.DM_MUCDICHSUDUNGQH, opt => opt.Ignore())
                .ForMember(dest => dest.DC_VITRITHUADAT, opt => opt.Ignore())
                .ForMember(dest => dest.DM_MUCDICHSUDUNG, opt => opt.Ignore())
                .ForMember(dest => dest.DC_NGUONGOCSUDUNG, opt => opt.Ignore())
                .ForMember(dest => dest.DC_QUYENQUANLYDAT, opt => opt.Ignore())
                .ForMember(dest => dest.DC_QUYENSUDUNGDAT, opt => opt.Ignore());
            AutoMapper.Mapper.CreateMap<GD_GIATHUADAT, GD_GIATHUADAT>()
                .ForMember(dest => dest.DC_THUADAT, opt => opt.Ignore())
                .ForMember(dest => dest.GD_DMLOAIGIADAT, opt => opt.Ignore());
            AutoMapper.Mapper.CreateMap<DangKyChuCaNhan, DC_CANHAN>();
            AutoMapper.Mapper.CreateMap<DangKyChuCaNhan, DC_DANGKY_NGUOI>();
            AutoMapper.Mapper.CreateMap<DC_CANHAN, DangKyChuCaNhan>();
            AutoMapper.Mapper.CreateMap<DC_DANGKY_NGUOI, DangKyChuCaNhan>();

            AutoMapper.Mapper.CreateMap<DangKyChuCaNhan, DangKyChuCaNhan>();

            AutoMapper.Mapper.CreateMap<DC_GIAYTOTUYTHAN, DC_GIAYTOTUYTHAN>();
            AutoMapper.Mapper.CreateMap<DC_CANHAN, DC_CANHAN>()
                .ForMember(x => x.DM_DANTOC, opt => opt.Ignore())
                .ForMember(x => x.DM_QUOCTICH, opt => opt.Ignore()); ;


            AutoMapper.Mapper.CreateMap<DC_VOCHONG, DC_VOCHONG>();

            #region Nhà
            // mapper nhà
            AutoMapper.Mapper.CreateMap<DC_NHARIENGLE, DC_NHARIENGLE>();
            AutoMapper.Mapper.CreateMap<DC_CANHO, DC_CANHO>()
                   .ForMember(dest => dest.DC_NHACHUNGCU, opt => opt.Ignore())
                    .ForMember(dest => dest.DC_CANHO_HANGMUCNCH, opt => opt.Ignore());
            AutoMapper.Mapper.CreateMap<DC_RUNGTRONG, DC_RUNGTRONG>();
            AutoMapper.Mapper.CreateMap<DC_CAYLAUNAM, DC_CAYLAUNAM>();
            AutoMapper.Mapper.CreateMap<DC_CONGTRINHXAYDUNG, DC_CONGTRINHXAYDUNG>()
                .ForMember(dest => dest.DC_HANGMUCCONGTRINH, opt => opt.Ignore());
            AutoMapper.Mapper.CreateMap<DC_HANGMUCNGOAICANHO, DC_HANGMUCNGOAICANHO>()
                .ForMember(dest => dest.DC_CANHO_HANGMUCNCH, opt => opt.Ignore())
                .ForMember(dest => dest.DC_NHACHUNGCU, opt => opt.Ignore());
            AutoMapper.Mapper.CreateMap<DC_NHACHUNGCU, DC_NHACHUNGCU>()
                .ForMember(dest => dest.DC_CANHO, opt => opt.Ignore())
                .ForMember(dest => dest.DC_HANGMUCNGOAICANHO, opt => opt.Ignore())
                .ForMember(dest => dest.DC_KHUCHUNGCU, opt => opt.Ignore());
            AutoMapper.Mapper.CreateMap<DC_CONGTRINHNGAM, DC_CONGTRINHNGAM>();
            AutoMapper.Mapper.CreateMap<DC_HANGMUCCONGTRINH, DC_HANGMUCCONGTRINH>()
                .ForMember(dest => dest.DC_CONGTRINHXAYDUNG, opt => opt.Ignore());
            AutoMapper.Mapper.CreateMap<DC_KHUCHUNGCU, DC_KHUCHUNGCU>()
                 .ForMember(dest => dest.DC_NHACHUNGCU, opt => opt.Ignore());
            AutoMapper.Mapper.CreateMap<DC_TAISAN_DIACHI, DC_TAISAN_DIACHI>()
                 .ForMember(dest => dest.DC_DIACHI, opt => opt.Ignore())
                 .ForMember(dest => dest.DC_TAISANGANLIENVOIDAT, opt => opt.Ignore());

            #endregion
            #region Quyền sử dụng đất
            //Mapping quyến sử dụng đất
            AutoMapper.Mapper.CreateMap<DC_QUYENSUDUNGDAT, DC_QUYENSUDUNGDAT>()
                .ForMember(dest => dest.DC_BD_THECHAP, opt => opt.Ignore())
                .ForMember(dest => dest.DC_MUCDICHSUDUNGDAT, opt => opt.Ignore())
                .ForMember(dest => dest.DC_NGUOI, opt => opt.Ignore());
            AutoMapper.Mapper.CreateMap<DC_QUYENSUDUNGDAT, QuyenSDDatVM>()
                .ForMember(dest => dest.MDSD, opt => opt.MapFrom(s => s.Str_MucDichSDDat));
            AutoMapper.Mapper.CreateMap<DC_QUYENQUANLYDAT, QuyenQLDatVM>()
                .ForMember(dest => dest.MDSD, opt => opt.MapFrom(s => s.Str_MucDichSDDat));
            #endregion

            #region Quyền sở hữu tài sản

            //Mapping quyền sở hữu tài sản
            AutoMapper.Mapper.CreateMap<DC_QUYENSOHUUTAISAN, DC_QUYENSOHUUTAISAN>()
                    .ForMember(dest => dest.DC_BD_THECHAP, opt => opt.Ignore())
                    .ForMember(dest => dest.DC_GIAYCHUNGNHAN, opt => opt.Ignore())
                    .ForMember(dest => dest.DC_TAISANGANLIENVOIDAT, opt => opt.Ignore())
                    .ForMember(dest => dest.DC_NGUOI, opt => opt.Ignore());
            #endregion
            #region Quyền quản lý đất
            //Mapping quyền quản lý đất
            AutoMapper.Mapper.CreateMap<DC_QUYENQUANLYDAT, DC_QUYENQUANLYDAT>()
                    .ForMember(dest => dest.DC_BD_THECHAP, opt => opt.Ignore())
                    .ForMember(dest => dest.DC_GIAYCHUNGNHAN, opt => opt.Ignore())
                    .ForMember(dest => dest.DC_MUCDICHSUDUNGDAT, opt => opt.Ignore())
                    .ForMember(dest => dest.DC_NGUOI, opt => opt.Ignore());
            #endregion
            //Mapping DC_QUYETDINH
            AutoMapper.Mapper.CreateMap<DC_QUYETDINH, DC_QUYETDINH>();
            AutoMapper.Mapper.CreateMap<QuyetDinhVM, DC_QUYETDINH>();
            AutoMapper.Mapper.CreateMap<DC_QUYETDINH, QuyetDinhVM>();
            //Mapping DC_TAISANGANLIENVOIDAT
            AutoMapper.Mapper.CreateMap<DC_TAISANGANLIENVOIDAT, TaiSanGanLienVoiDatVM>();
            AutoMapper.Mapper.CreateMap<TaiSanGanLienVoiDatVM, DC_TAISANGANLIENVOIDAT>();
            //Mapping DC_DANGKY_TAISAN
            AutoMapper.Mapper.CreateMap<DC_DANGKY_TAISAN, TaiSanVM>()
                .ForMember(dest => dest.TaiSanGanLienVoiDatID, opt => opt.MapFrom(s => s.TaiSanGanLienVoiDat.TAISANGANLIENVOIDATID))
                .ForMember(dest => dest.LoaiTaiSan, opt => opt.MapFrom(s => s.TaiSanGanLienVoiDat.LoaiTaiSanGanLienVoiDat.TENLOAITAISANGANLIENVOIDAT))
                .ForMember(dest => dest.TenTaiSan, opt => opt.MapFrom(s => s.TaiSanGanLienVoiDat.TENTAISAN));

            #region Cấu hình luân chuyển
            AutoMapper.Mapper.CreateMap<QT_BUOCQUYTRINH, QT_BUOCQUYTRINH>()
                .ForMember(dest => dest.QT_BUOCQT_CAUHINH, opt => opt.Ignore())
                .ForMember(dest => dest.QT_QUYTRINH, opt => opt.Ignore())
                .ForMember(dest => dest.QT_CONGVIECTHEOBUOC, opt => opt.Ignore())
                .ForMember(dest => dest.QT_GHICHUXULY, opt => opt.Ignore())
                .ForMember(dest => dest.QT_LUANCHUYEN_HOSO, opt => opt.Ignore());
            #endregion


            #region DangKyV2
            AutoMapper.Mapper.CreateMap<DC_DANGKY_GCN, DC_DANGKY_GCN>()
                    .ForMember(dest => dest.DC_DONDANGKY, opt => opt.Ignore())
                    .ForMember(dest => dest.DC_GIAYCHUNGNHAN, opt => opt.Ignore());
            AutoMapper.Mapper.CreateMap<DC_DANGKY_GCN, DangKyGiayChungNhanVM>();
            AutoMapper.Mapper.CreateMap<DangKyGiayChungNhanVM, DC_DANGKY_GCN>();

            AutoMapper.Mapper.CreateMap<DC_DANGKY_NGUOI, DangKyNguoiVM>();
            AutoMapper.Mapper.CreateMap<DangKyNguoiVM, DC_DANGKY_NGUOI>();
            #endregion
        }
    }
}
