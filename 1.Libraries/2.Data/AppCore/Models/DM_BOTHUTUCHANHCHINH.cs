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
    
    public partial class DM_BOTHUTUCHANHCHINH
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DM_BOTHUTUCHANHCHINH()
        {
            this.QT_THUTUCHANHCHINH = new HashSet<QT_THUTUCHANHCHINH>();
        }
    
        public string BOTHUTUCHANHCHINHID { get; set; }
        public string TENBOTHUTUCHANHCHINH { get; set; }
        public string CANCUPHAPLY { get; set; }
        public string THUTUSAPXEP { get; set; }
        public string uId { get; set; }
        public Nullable<System.DateTime> THOIDIEMKHOITAO { get; set; }
        public string NGUOICAPNHATID { get; set; }
        public Nullable<System.DateTime> THOIDIEMCAPNHAT { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<QT_THUTUCHANHCHINH> QT_THUTUCHANHCHINH { get; set; }
    }
}
