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
    
    public partial class QT_GIAYTOTHEOTTHC
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public QT_GIAYTOTHEOTTHC()
        {
            this.QT_FILEDINHKEMHOSO = new HashSet<QT_FILEDINHKEMHOSO>();
        }
    
        public string GIAYTOTHEOTTHCID { get; set; }
        public string THUTUCHANHCHINHID { get; set; }
        public string TENLOAIGIAYTO { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<QT_FILEDINHKEMHOSO> QT_FILEDINHKEMHOSO { get; set; }
        public virtual QT_THUTUCHANHCHINH QT_THUTUCHANHCHINH { get; set; }
    }
}
