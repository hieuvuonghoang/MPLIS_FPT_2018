using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppCore.Models;
using MPLIS.Libraries.Data.QuanTriQuyTrinh.Models;

namespace MPLIS.Libraries.Services.AutoMapperStartup.ClassMapper
{
    public static class QuanTriQuyTrinhMapper
    {
        public static void Execute()
        {
            #region Mapping QT_QUYTRINH
            AutoMapper.Mapper.CreateMap<Hashtable, Hashtable>();

            AutoMapper.Mapper.CreateMap<QT_QUYTRINH, QT_QUYTRINH>()
                .ForMember(dest => dest.QT_BUOCQUYTRINH, opt => opt.Ignore())
                .ForMember(dest => dest.QT_GHICHUXULY, opt => opt.Ignore())
                .ForMember(dest => dest.QT_HOSO_LANXULY, opt => opt.Ignore())
                .ForMember(dest => dest.QT_LUANCHUYEN_HOSO, opt => opt.Ignore())
                .ForMember(dest => dest.QT_NHOMQUYTRINH, opt => opt.Ignore())
                .ForMember(dest => dest.QT_TTHC_QUYTRINH, opt => opt.Ignore());

            AutoMapper.Mapper.CreateMap<QT_NHOMQUYTRINH, QT_NHOMQUYTRINH>()
                .ForMember(dest => dest.QT_QUYTRINH, opt => opt.Ignore());

            AutoMapper.Mapper.CreateMap<QT_BUOCQUYTRINH, QT_BUOCQUYTRINH>()
                .ForMember(dest => dest.QT_BUOCQT_CAUHINH, opt => opt.Ignore())
                .ForMember(dest => dest.QT_QUYTRINH, opt => opt.Ignore())
                .ForMember(dest => dest.QT_CONGVIECTHEOBUOC, opt => opt.Ignore())
                .ForMember(dest => dest.QT_GHICHUXULY, opt => opt.Ignore())
                .ForMember(dest => dest.QT_LUANCHUYEN_HOSO, opt => opt.Ignore());

            AutoMapper.Mapper.CreateMap<QT_BUOCQT_CAUHINH, QT_BUOCQT_CAUHINH>()
                .ForMember(dest => dest.HC_DMKVHC, opt => opt.Ignore())
                .ForMember(dest => dest.HT_NGUOIDUNG, opt => opt.Ignore())
                .ForMember(dest => dest.QT_BUOCQUYTRINH, opt => opt.Ignore());

            AutoMapper.Mapper.CreateMap<QT_CONGVIECTHEOBUOC, QT_CONGVIECTHEOBUOC>()
                .ForMember(dest => dest.QT_BUOCQUYTRINH, opt => opt.Ignore())
                .ForMember(dest => dest.QT_CONGVIECTHUCHIEN, opt => opt.Ignore());
            #endregion
            #region Mapping KHVHC
            #endregion
        }
    }
}
