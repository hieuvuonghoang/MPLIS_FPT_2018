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
    
    public partial class DM_HINHTHUCSUDUNGDAT
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DM_HINHTHUCSUDUNGDAT()
        {
            this.DC_BD_CHUYENHTSDD = new HashSet<DC_BD_CHUYENHTSDD>();
            this.DC_MUCDICHSUDUNGDAT = new HashSet<DC_MUCDICHSUDUNGDAT>();
        }
    
        public string HINHTHUCSUDUNGID { get; set; }
        public string TENHINHTHUCSUDUNG { get; set; }
        public string GHICHU { get; set; }
        public Nullable<decimal> STT { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DC_BD_CHUYENHTSDD> DC_BD_CHUYENHTSDD { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DC_MUCDICHSUDUNGDAT> DC_MUCDICHSUDUNGDAT { get; set; }
    }
}