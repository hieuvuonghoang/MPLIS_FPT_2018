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
    
    public partial class DC_NGHIAVUTAICHINH
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DC_NGHIAVUTAICHINH()
        {
            this.DC_GTKEMTHEO = new HashSet<DC_GTKEMTHEO>();
            this.DC_KHOANDUOCTRU = new HashSet<DC_KHOANDUOCTRU>();
            this.DC_MIENGIAMNVTC = new HashSet<DC_MIENGIAMNVTC>();
            this.DC_NONVTC = new HashSet<DC_NONVTC>();
        }
    
        public string NGHIAVUTAICHINHID { get; set; }
        public string QUYENSUDUNGDATID { get; set; }
        public string QUYENSOHUUTAISANID { get; set; }
        public string LOAINGHIAVUTAICHINHID { get; set; }
        public Nullable<decimal> TONGSOTIEN { get; set; }
        public Nullable<decimal> TONGSOTIENMIENGIAM { get; set; }
        public Nullable<decimal> TONGSOTIENNO { get; set; }
        public Nullable<System.DateTime> NGAYBATDAU { get; set; }
        public string HOANTHANH { get; set; }
        public string uId { get; set; }
        public Nullable<System.DateTime> THOIDIEMKHOITAO { get; set; }
        public Nullable<System.DateTime> THOIDIEMCAPNHAT { get; set; }
        public string NGUOICAPNHATID { get; set; }
        public string SOPHIEUCHUYEN { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DC_GTKEMTHEO> DC_GTKEMTHEO { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DC_KHOANDUOCTRU> DC_KHOANDUOCTRU { get; set; }
        public virtual DC_LOAINGHIAVUTAICHINH DC_LOAINGHIAVUTAICHINH { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DC_MIENGIAMNVTC> DC_MIENGIAMNVTC { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DC_NONVTC> DC_NONVTC { get; set; }
    }
}
