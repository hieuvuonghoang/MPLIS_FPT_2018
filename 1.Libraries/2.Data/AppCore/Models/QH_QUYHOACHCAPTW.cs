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
    
    public partial class QH_QUYHOACHCAPTW
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public QH_QUYHOACHCAPTW()
        {
            this.QH_DINHKEMQUYHOACHCAPTW = new HashSet<QH_DINHKEMQUYHOACHCAPTW>();
        }
    
        public string QUYHOACHCAPTWID { get; set; }
        public decimal NAMTHANHLAP { get; set; }
        public string TYLEBANDO { get; set; }
        public string NGUONTHANHLAP { get; set; }
        public string COQUANDUYET { get; set; }
        public string COQUANTHAMDINH { get; set; }
        public string COQUANLAP { get; set; }
        public string DONVITUVAN { get; set; }
        public Nullable<System.DateTime> NGAYPHEDUYET { get; set; }
        public string TENKYQUYHOACH { get; set; }
        public string FILEBANDO { get; set; }
        public string SOQUYETDINH { get; set; }
        public string FILEHIENTRANG { get; set; }
        public string FILETHUYETMINH { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<QH_DINHKEMQUYHOACHCAPTW> QH_DINHKEMQUYHOACHCAPTW { get; set; }
    }
}
