using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AppCore.Models;
namespace MPLIS.Libraries.Data.QTHT.Models
{
    public class QTHT_ChucNangViewModels
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public QTHT_ChucNangViewModels()
        {
            this.HT_CHUCNANG_NHOMCHUCNANG = new HashSet<HT_CHUCNANG_NHOMCHUCNANG>();
            this.HT_CHUCNANG1 = new HashSet<HT_CHUCNANG>();
        }
        public string CHUCNANGID { get; set; }
        public string KHOACHAID { get; set; }
        public string MACHUCNANG { get; set; }
        public string TENCHUCNANG { get; set; }
        public string MOTA { get; set; }
        public string THUTUSAPXEP { get; set; }
        public string CHOPHEPSUDUNG { get; set; }
        public string uId { get; set; }
        public Nullable<System.DateTime> THOIDIEMKHOITAO { get; set; }
        public string NGUOICAPNHATID { get; set; }
        public Nullable<System.DateTime> THOIDIEMCAPNHAT { get; set; }
        public string URL { get; set; }
        public virtual ICollection<HT_CHUCNANG_NHOMCHUCNANG> HT_CHUCNANG_NHOMCHUCNANG { get; set; }
        public virtual ICollection<HT_CHUCNANG> HT_CHUCNANG1 { get; set; }
        public virtual HT_CHUCNANG HT_CHUCNANG2 { get; set; }
        public IList<HT_CHUCNANG> ListCN { get; set; }
        public IList<HT_CHUCNANG_NHOMCHUCNANG> ListCNQuanHe { get; set; }
        public IList<HT_CHUCNANG> ListCNpop { get; set; }
        public string tenCNcha { get; set; }
        public Boolean _CHOPHEPSUDUNG { get; set; }
        public Nullable<bool> THUCHIENTHUCONG { get; set; }
        public Boolean _THUCHIENTHUCONG { get; set; }
        public string CACBIENDAUVAO { get; set; }
        public string CACBIENDAURA { get; set; }
    }
}
