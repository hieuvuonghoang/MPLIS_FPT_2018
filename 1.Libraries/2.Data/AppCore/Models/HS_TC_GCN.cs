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
    
    public partial class HS_TC_GCN
    {
        public string SOPHATHANH { get; set; }
        public string SOVAOSO { get; set; }
        public string MAVACH { get; set; }
        public string GCNID { get; set; }
        public string MAKVHC { get; set; }
        public string TCGCNID { get; set; }
        public string HOSOID { get; set; }
    
        public virtual HS_HOSO HS_HOSO { get; set; }
    }
}
