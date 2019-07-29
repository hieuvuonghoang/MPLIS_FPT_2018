using System;
using System.Collections.Generic;
using System.Linq;
using AppCore.Models;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace MPLIS.Libraries.Data.QTHT.Models
{
   public class HT_TinhThamSoViewModel
    {
        public string BASEMAPSERVICELINK { get; set; }
        public decimal? CAPGCNLAYERINDEX { get; set; }
        public string CAPGCNSERVICELINK { get; set; }
        public string GEOMETRYSERVER { get; set; }
        public string GETDATAEDITDESKTOP { get; set; }
        public decimal? GIADATGRLAYERINDEX { get; set; }
        public string GIADATGRSERVICELINK { get; set; }
        public decimal? GIADATLAYERINDEX { get; set; }
        public string GIADATSERVICELINK { get; set; }
        public decimal? HIENTRANGLAYERINDEX { get; set; }
        public string HIENTRANGSERVICELINK { get; set; }
        public decimal? KHOANHDATLAYERINDEX { get; set; }
        public string KHOANHDATSERVICELINK { get; set; }
        public decimal? KINHTUYENTRUC { get; set; }
        public decimal? KVHCLAYERHUYENINDEX { get; set; }
        public decimal? KVHCLAYERTINHINDEX { get; set; }
        public decimal? KVHCLAYERXAINDEX { get; set; }
        public string KVHCSERVICELINK { get; set; }
        public string LOADEXPORTDGN { get; set; }
        public string LOADEXPORTGML { get; set; }
        public string LOADEXPORTSHAPEFILE { get; set; }
        public decimal? MDSDLAYERINDEX { get; set; }
        public string MDSDSERVICELINK { get; set; }
        public string NGUOICAPNHATID { get; set; }
        public decimal? QUYHOACHCAPTINHLAYERINDEX { get; set; }
        public string QUYHOACHCAPTINHSERVICELINK { get; set; }
        public decimal? QUYHOACHCAPHUYENLAYERINDEX { get; set; }
        public string QUYHOACHCAPHUYENSERVICELINK { get; set; }
        public decimal? THUADATLAYERINDEX { get; set; }
        public decimal? THUADATMAPSERVERINDEX { get; set; }
        public string THUADATMAPSERVERLINK { get; set; }
        public string THUADATSERVICELINK { get; set; }
        public string TINHID { get; set; }
        public string TINHTHAMSOID { get; set; }
        public string VETINHSERVICELINK { get; set; }


        private MplisEntities _dataContext = new MplisEntities();

        public List<HC_TINH> GetListTT()
        {
            using (var context = new MplisEntities())
            {
                var list = context.HC_TINH.OrderByDescending(m => m.TENTINH).ToList();
                return list;
            }
        }
    }
}
