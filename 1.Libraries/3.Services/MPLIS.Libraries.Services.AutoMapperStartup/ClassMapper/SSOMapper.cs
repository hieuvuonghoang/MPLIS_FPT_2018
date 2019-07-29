using AppCore.Models;
using AutoMapper;
using MPLIS.Libraries.Data.SSO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPLIS.Libraries.Services.AutoMapperStartup.ClassMapper
{
    public static class SSOMapper
    {
        public static void Execute()
        {
            //Clone object
            Mapper.CreateMap<SSOUserLoginInfors, SSOUserLoginInfors>();

            //Mapping thông tin tỉnh huyện xã
            Mapper.CreateMap<SSOHcTinh, HC_TINH>()
                .ForMember(dest => dest.HC_HUYEN, opt => opt.Ignore())
                .ForMember(dest => dest.HC_TINHTHAMSO, opt => opt.Ignore());
            Mapper.CreateMap<HC_TINH, SSOHcTinh>();
            Mapper.CreateMap<SSOHcHuyen, HC_HUYEN>()
                .ForMember(dest => dest.HC_TINH, opt => opt.Ignore())
                .ForMember(dest => dest.HC_DMKVHC, opt => opt.Ignore());
            Mapper.CreateMap<HC_HUYEN, SSOHcHuyen>();
            Mapper.CreateMap<SSOHcXa, HC_DMKVHC>()
                .ForMember(dest => dest.HC_HUYEN, opt => opt.Ignore())
                .ForMember(dest => dest.HS_HOSO, opt => opt.Ignore())
                .ForMember(dest => dest.HS_LIENKETTHUADAT, opt => opt.Ignore())
                .ForMember(dest => dest.HS_LICHSU, opt => opt.Ignore())
                .ForMember(dest => dest.HT_XA_NGUOIDUNG, opt => opt.Ignore())
                .ForMember(dest => dest.HT_XA_TOCHUC, opt => opt.Ignore());
            Mapper.CreateMap<HC_DMKVHC, SSOHcXa>();

            //mapping các bảng hệ thống
            Mapper.CreateMap<SSOHtCauHinhNguoiDung, HT_CAUHINHNGUOIDUNG>()
                .ForMember(dest => dest.HT_NGUOIDUNG, opt => opt.Ignore());
            Mapper.CreateMap<HT_CAUHINHNGUOIDUNG, SSOHtCauHinhNguoiDung>();
            Mapper.CreateMap<SSOHtMenu, HT_MENU>()
                .ForMember(dest => dest.HT_MENU1, opt => opt.Ignore())
                .ForMember(dest => dest.HT_MENU2, opt => opt.Ignore())
                .ForMember(dest => dest.HT_NHOMCHUCNANG_MENU, opt => opt.Ignore());
            Mapper.CreateMap<HT_MENU, SSOHtMenu>();
            Mapper.CreateMap<SSOHtNguoiDung, HT_NGUOIDUNG>()
                .ForMember(dest => dest.HT_CAUHINHNGUOIDUNG, opt => opt.Ignore())
                .ForMember(dest => dest.HT_LICHSUTRUYCAP, opt => opt.Ignore())
                .ForMember(dest => dest.HT_NGUOIDUNG_QUYEN, opt => opt.Ignore())
                .ForMember(dest => dest.HT_TOCHUC_NGUOIDUNG, opt => opt.Ignore())
                .ForMember(dest => dest.HT_XA_NGUOIDUNG, opt => opt.Ignore());
            Mapper.CreateMap<HT_NGUOIDUNG, SSOHtNguoiDung>();
            Mapper.CreateMap<SSOHtToChuc, HT_TOCHUC>()
                .ForMember(dest => dest.HT_TOCHUC_NHOMCHUCNANG, opt => opt.Ignore())
                .ForMember(dest => dest.HT_TOCHUC_NGUOIDUNG, opt => opt.Ignore())
                .ForMember(dest => dest.HT_TOCHUC1, opt => opt.Ignore())
                .ForMember(dest => dest.HT_TOCHUC2, opt => opt.Ignore())
                .ForMember(dest => dest.HT_XA_TOCHUC, opt => opt.Ignore());
            Mapper.CreateMap<HT_TOCHUC, SSOHtToChuc>();
            Mapper.CreateMap<SSOHtToChucNguoiDung, HT_TOCHUC_NGUOIDUNG>()
                .ForMember(dest => dest.HT_NGUOIDUNG, opt => opt.Ignore())
                .ForMember(dest => dest.HT_TOCHUC, opt => opt.Ignore());
            Mapper.CreateMap<HT_TOCHUC_NGUOIDUNG, SSOHtToChucNguoiDung>();
            Mapper.CreateMap<SSOHtUngDung, HT_UNGDUNG>()
                .ForMember(dest => dest.HT_NHOMCHUCNANG, opt => opt.Ignore());
            Mapper.CreateMap<HT_UNGDUNG, SSOHtUngDung>();
            Mapper.CreateMap<SSOHtQuyen, HT_QUYEN>()
                .ForMember(dest => dest.HT_CHUCNANG, opt => opt.Ignore())
                .ForMember(dest => dest.HT_NGUOIDUNG_QUYEN, opt => opt.Ignore());
            Mapper.CreateMap<HT_QUYEN, SSOHtQuyen>();
            Mapper.CreateMap<SSOHtChucNang, HT_CHUCNANG>()
                .ForMember(dest => dest.HT_CHUCNANG1, opt => opt.Ignore())
                .ForMember(dest => dest.HT_CHUCNANG2, opt => opt.Ignore())
                .ForMember(dest => dest.HT_CHUCNANG_NHOMCHUCNANG, opt => opt.Ignore())
                .ForMember(dest => dest.HT_QUYEN, opt => opt.Ignore());
            Mapper.CreateMap<HT_CHUCNANG, SSOHtChucNang>();
        }
    }
}
