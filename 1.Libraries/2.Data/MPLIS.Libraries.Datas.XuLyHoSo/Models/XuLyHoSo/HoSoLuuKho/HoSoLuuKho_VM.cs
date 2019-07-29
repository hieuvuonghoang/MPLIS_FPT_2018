using AppCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using Newtonsoft.Json;
using AutoMapper;
namespace MPLIS.Libraries.Data.XuLyHoSo.Models
{
    public class HoSoLuuKho_VM
    {
        public HS_HOSO hoso = new HS_HOSO();
        public HS_VITRILUUTRU vitriluu = new HS_VITRILUUTRU();
    }
}
