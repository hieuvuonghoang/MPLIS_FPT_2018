//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AppCore.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class HT_QUYEN
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public HT_QUYEN()
        {
            this.HT_NGUOIDUNG_QUYEN = new HashSet<HT_NGUOIDUNG_QUYEN>();
        }
    
        public string QUYENID { get; set; }
        public string CHUCNANGID { get; set; }
        public string THUTUSAPXEP { get; set; }
        public string CONTROLLERNAME { get; set; }
        public string ACTIONNAME { get; set; }
        public string MOTA { get; set; }
        public string UID { get; set; }
        public Nullable<System.DateTime> THOIDIEMKHOITAO { get; set; }
        public string NGUOICAPNHATID { get; set; }
        public Nullable<System.DateTime> THOIDIEMCAPNHAT { get; set; }
    
        public virtual HT_CHUCNANG HT_CHUCNANG { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HT_NGUOIDUNG_QUYEN> HT_NGUOIDUNG_QUYEN { get; set; }
    }
}