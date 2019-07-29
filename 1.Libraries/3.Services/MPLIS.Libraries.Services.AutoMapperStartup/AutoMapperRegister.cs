using MPLIS.Libraries.Services.AutoMapperStartup.ClassMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPLIS.Libraries.Services.AutoMapperStartup
{
    public static class AutoMapperRegister
    {
        public static void Run()
        {
            XuLyHoSoMapper.Execute();
            QuanTriQuyTrinhMapper.Execute();
            SSOMapper.Execute();
        }
    }
}
