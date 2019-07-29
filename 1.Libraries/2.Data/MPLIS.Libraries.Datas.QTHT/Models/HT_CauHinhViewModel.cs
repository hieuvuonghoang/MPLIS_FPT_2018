using System;
using System.Web;
using AppCore.Models;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;

namespace MPLIS.Libraries.Data.QTHT.Models
{
    public partial class HT_CauHinhViewModel
    {
        private MplisEntities _dataContext = new MplisEntities();
        public HT_CAUHINH aHT_CauHinh { get;  set; }
        public List<SearchCauHinhListModel> ch_listFind { get; set; }
        public List<SearchDVHC> listDVHC { get; set; }
        public string iddvhcCauHinh { get; set; }
        public string TenDVHC { get; set; }
        public List<HC_TINH> GetListTT()
        {
            using (var context = new MplisEntities())
            {
                var list = context.HC_TINH.ToList();
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
        public List<HC_DMKVHC> GetListXP()
        {
            using (var context = new MplisEntities())
            {
                var list = context.HC_DMKVHC.Where(m => m.KVHCID == "").ToList();
                return list;
            }
        }
    }
    public class SearchCauHinhListModel
    {
        public byte? CAP { get; set; }
        public string CAUHINHID { get; set; }
        public string GIATRI { get; set; }
        public string MADONVIHANHCHINHID { get; set; }
        public string NGUOICAPNHATID { get; set; }
        public string TENCAUHINH { get; set; }
        public DateTime? THOIDIEMCAPNHAT { get; set; }
        public DateTime? THOIDIEMKHOITAO { get; set; }
        public string UID { get; set; }
        public string TenDVHC { get; set; }
        public string TENDONVIHANHCHINH { get; set; }
    }
    public class SearchDVHC
    {
        public string IDDVHC { get; set; }
    }
}
