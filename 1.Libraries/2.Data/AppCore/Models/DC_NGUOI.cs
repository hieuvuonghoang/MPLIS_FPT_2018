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
    
    public partial class DC_NGUOI
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DC_NGUOI()
        {
            this.DC_BD_CHU = new HashSet<DC_BD_CHU>();
            this.DC_DANGKY_NGUOI = new HashSet<DC_DANGKY_NGUOI>();
            this.DC_GCN_TILESH = new HashSet<DC_GCN_TILESH>();
            this.DC_GIAYCHUNGNHAN = new HashSet<DC_GIAYCHUNGNHAN>();
            this.DC_KHOANDUOCTRU = new HashSet<DC_KHOANDUOCTRU>();
            this.DC_MIENGIAMNVTC = new HashSet<DC_MIENGIAMNVTC>();
            this.DC_NGUOI_DIACHI = new HashSet<DC_NGUOI_DIACHI>();
            this.DC_NONVTC = new HashSet<DC_NONVTC>();
            this.DC_QUYENSOHUUTAISAN = new HashSet<DC_QUYENSOHUUTAISAN>();
            this.DC_QUYENSUDUNGDAT = new HashSet<DC_QUYENSUDUNGDAT>();
            this.DC_QUYENQUANLYDAT = new HashSet<DC_QUYENQUANLYDAT>();
        }
    
        public string NGUOIID { get; set; }
        public string CHITIETID { get; set; }
        public string LOAIDOITUONGID { get; set; }
        public string uId { get; set; }
        public Nullable<System.DateTime> THOIDIEMKHOITAO { get; set; }
        public Nullable<System.DateTime> THOIDIEMCAPNHAT { get; set; }
        public string NGUOICAPNHATID { get; set; }
        public string DOITUONGSUDUNGID { get; set; }
        public string MADINHDANH { get; set; }
        public string MASOTHUE { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DC_BD_CHU> DC_BD_CHU { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DC_DANGKY_NGUOI> DC_DANGKY_NGUOI { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DC_GCN_TILESH> DC_GCN_TILESH { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DC_GIAYCHUNGNHAN> DC_GIAYCHUNGNHAN { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DC_KHOANDUOCTRU> DC_KHOANDUOCTRU { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DC_MIENGIAMNVTC> DC_MIENGIAMNVTC { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DC_NGUOI_DIACHI> DC_NGUOI_DIACHI { get; set; }
        public virtual DM_DOITUONGSUDUNG DM_DOITUONGSUDUNG { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DC_NONVTC> DC_NONVTC { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DC_QUYENSOHUUTAISAN> DC_QUYENSOHUUTAISAN { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DC_QUYENSUDUNGDAT> DC_QUYENSUDUNGDAT { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DC_QUYENQUANLYDAT> DC_QUYENQUANLYDAT { get; set; }
    }
}
