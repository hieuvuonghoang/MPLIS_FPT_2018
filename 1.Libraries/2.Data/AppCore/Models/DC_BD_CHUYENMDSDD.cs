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
    
    public partial class DC_BD_CHUYENMDSDD
    {
        public string BDCHUYENMDSDID { get; set; }
        public string MUCDICHSUDUNGID { get; set; }
        public string BIENDONGID { get; set; }
        public string LAMDSDTRUOCKHICHUYEN { get; set; }
        public Nullable<decimal> DIENTICHCHUYENMDSDD { get; set; }
    
        public virtual DC_BIENDONG DC_BIENDONG { get; set; }
        public virtual DM_MUCDICHSUDUNG DM_MUCDICHSUDUNG { get; set; }
    }
}
